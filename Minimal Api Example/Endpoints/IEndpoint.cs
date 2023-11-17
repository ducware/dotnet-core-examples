namespace MinimalAPI.CouponApi.Endpoints
{
    public interface IEndpoint
    {
        static abstract void Map(IEndpointRouteBuilder endpoints);
    }
}
