using ExportExcel.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Http.HttpResults;
using MiniExcelLibs;

namespace ExportExcel.Web.Endpoints;
public class WeatherForecasts : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .RequireAuthorization()
            .MapGet(GetWeatherForecasts)
            .MapGet(ExportExcelWeatherForecasts, "export");
    }

    public async Task<Results<FileStreamHttpResult, NotFound>> ExportExcelWeatherForecasts(CancellationToken cancellationToken)
    {
        var memoryStream = new MemoryStream();
        await memoryStream.SaveAsAsync(Weathers, cancellationToken: cancellationToken);
        memoryStream.Seek(0, SeekOrigin.Begin);
        return TypedResults.File(memoryStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "weathers.xlsx");
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(ISender sender)
    {
        return await sender.Send(new GetWeatherForecastsQuery());
    }

    private readonly static List<WeatherForecast> Weathers = new()
    {
        new() { Date = DateTime.Now, TemperatureC = 37, Summary = "Cloudy" },
        new() { Date = DateTime.Now.AddDays(1), TemperatureC = 38, Summary = "Rainy" },
        new() { Date = DateTime.Now.AddDays(2), TemperatureC = 39, Summary = "Snowly" },
    };
}
