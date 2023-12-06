using MiniExcelLibs.Attributes;

namespace ExportExcel.Application.WeatherForecasts.Queries.GetWeatherForecasts;
public class WeatherForecast
{
    [ExcelColumnIndex(0)]
    [ExcelColumnName("Ngày")]
    [ExcelColumnWidth(100)]
    public DateTime Date { get; init; }
    [ExcelColumnIndex(1)]
    [ExcelColumnName("Độ C")]
    [ExcelColumnWidth(45)]
    public int TemperatureC { get; init; }
    [ExcelColumnIndex(2)]
    [ExcelColumnName("Độ F")]
    [ExcelColumnWidth(45)]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    [ExcelColumnIndex(3)]
    [ExcelColumnName("Tóm tắt")]
    [ExcelColumnWidth(45)]
    public string? Summary { get; init; }
}
