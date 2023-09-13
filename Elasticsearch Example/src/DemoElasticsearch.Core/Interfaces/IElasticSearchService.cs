namespace DemoElasticsearch.Core.Interfaces
{
    public interface IElasticSearchService
    {
        void CreateElasticSearchIndex(string index);
        void DeleteElasticSearchIndex(string index);
        void SendDocumentToIndex<T>(string index, T document) where T : class;
        bool IsExist(string index);
        void DeleteDocumentById<T>(string index, int id) where T : class;
        Task<bool> IsExistDocument(string index, int id);
        Task<List<T>> GetDocumentFromIndex<T>(string index, string keyword, int size) where T : class;
        Task<List<string>> GetIndexList();
    }
}
