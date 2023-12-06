using MiniExcelLibs.Attributes;

namespace ExportExcel.Application.WeatherForecasts.Queries.GetWeatherForecasts;
public class WeatherForecast
{
    [ExcelColumn(Name = "Ngày", Index=0, Width = 100)]
    public DateTime Date { get; init; }
    [ExcelColumn(Name = "Độ C", Index = 1, Width = 45)]
    public int TemperatureC { get; init; }
    [ExcelColumn(Name = "Độ F", Index = 2, Width = 45)]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    [ExcelColumn(Name = "Tóm tắt", Index = 3, Width = 45)]
    public string? Summary { get; init; }
}
