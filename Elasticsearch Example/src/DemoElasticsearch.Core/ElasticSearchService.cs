using DemoElasticsearch.Core.Interfaces;
using DemoElasticsearch.Core.Models;
using Nest;

namespace DemoElasticsearch.Core
{
    public class ElasticSearchService : IElasticSearchService
    {
        private readonly IElasticClient _client;

        public ElasticSearchService(IElasticClient client)
        {
            _client = client;
        }

        public async void CreateElasticSearchIndex(string index)
        {
           await _client.Indices.CreateAsync(index);
        }

        public async void DeleteDocumentById<T>(string index, int id) where T : class
        {
            await _client.DeleteAsync(new DocumentPath<T>(id), idx => idx.Index(index));
        }

        public async void DeleteElasticSearchIndex(string index)
        {
            await _client.Indices.DeleteAsync(index);
        }

        public async Task<List<T>> GetDocumentFromIndex<T>(string index, string keyword, int size) where T : class
        {
            var result = await _client.SearchAsync<T>(
                         s => s.Query(
                             q => q.QueryString(
                                 d => d.Query('*' + keyword + '*')
                             )).Size(size).Index(index));
            return result.Documents.ToList();
        }

        public async Task<List<string>> GetIndexList()
        {
            var indices = await _client.Indices.GetAliasAsync();
            var res = indices.Indices.Keys.Select(indexName => indexName.Name).ToList();
            return res;
        }

        public bool IsExist(string index)
        {
            var res = _client.Indices.Exists(index);
            if (res.IsValid)
            {
                return true;
            }
            return false; 
        }

        public async Task<bool> IsExistDocument(string index, int id)
        {
            var existsResponse = await _client.DocumentExistsAsync<Product>(new DocumentPath<Product>(id), idx => idx.Index(index));
            return existsResponse.Exists;
        }

        public async void SendDocumentToIndex<T>(string index, T document) where T : class
        {
            await _client.IndexAsync(document, idx => idx.Index(index));
        }
    }
}
