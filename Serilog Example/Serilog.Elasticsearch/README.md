# Stream log real-time with Serilog Elasticsearch, Kibana

## 1. Install Serilog package

---

```csharp
<PackageReference Include="Serilog" Version="3.1.1" />
<PackageReference Include="Serilog.AspNetCore" Version="8.0.0" />
<PackageReference Include="Serilog.Enrichers.Environment" Version="2.3.0" />
<PackageReference Include="Serilog.Exceptions" Version="8.4.0" />
<PackageReference Include="Serilog.Sinks.Console" Version="5.0.0" />
<PackageReference Include="Serilog.Sinks.Debug" Version="2.0.0" />
<PackageReference Include="Serilog.Sinks.Elasticsearch" Version="9.0.3" />

```

## 2. Install Elasticsearch, Kibana (local)

**⚙️ Install Elasticsearch and Kibana using Docker**

---

```yaml
version: '3.4'

services:
  elasticsearch:
    container_name: elasticsearch
    image: docker.elastic.co/elasticsearch/elasticsearch:7.9.1
    ports:
      - 9200:9200
    volumes:
      - elasticsearch-data:/usr/share/elasticsearch/data
    environment:
      - xpack.monitoring.enabled=true
      - xpack.watcher.enabled=false
      - "ES_JAVA_OPTS=-Xms512m -Xmx512m"
      - discovery.type=single-node
    networks:
      - elastic

  kibana:
    container_name: kibana
    image: docker.elastic.co/kibana/kibana:7.9.1
    ports:
      - 5601:5601
    depends_on:
      - elasticsearch
    environment:
      - ELASTICSEARCH_URL=http://elasticsearch:9200
    networks:
      - elastic

networks:
  elastic:
    driver: bridge

volumes:
  elasticsearch-data:

```

## 3. Configure Serilog with Elasticsearch

✨ **Step 1:** Add Elasticsearch configuration to **appsettings.json**

---

```json
"ElasticsearchConfiguration": {
  "Uri": "<http://localhost:9200>"
}

```

✨ **Step 2:** Create the **ElasticsearchConfiguration** class to bind values from **appsettings.json** to the class

---

```csharp
public class ElasticsearchConfiguration
{
    public const string Section = "ElasticsearchConfiguration";
    public string Uri { get; init; }
}

```

✨ **Step 3:** Create the **IInstaller** interface

---

```csharp
public interface IInstaller
{
    void InstallServices(IServiceCollection services, IConfiguration configuration);
}

```

✨ **Step 4:** Create the **InstallerExtensions** class to register services that implement the **IInstaller** interface

---

```csharp
public static class InstallerExtensions
{
    public static void InstallerServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
    {
        var installer = typeof(Program).Assembly
                                       .ExportedTypes
                                       .Where(x => typeof(IInstaller)
                                       .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                                       .Select(Activator.CreateInstance)
                                       .Cast<IInstaller>().ToList();

        installer.ForEach(installer => installer.InstallServices(services, configuration));
    }
}

```

✨ **Step 5:** Configure Serilog → local Elasticsearch

---

```csharp
public class SerilogInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services, IConfiguration configuration)
    {
        var elasticsearchConfiguration = new ElasticsearchConfiguration();
        configuration.GetSection(ElasticsearchConfiguration.Section).Bind(elasticsearchConfiguration);

        services.AddSingleton(elasticsearchConfiguration);

        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        var indexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{environment.ToLower().Replace(".", "_")}-{DateTime.UtcNow:yyyy-MM-dd}";

        // Serilog
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .WriteTo.Debug()
            .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(
                new Uri(elasticsearchConfiguration.Uri))
            {
                AutoRegisterTemplate = true,
                IndexFormat = indexFormat
            })
            .CreateLogger();
    }
}

```

✨ **Step 6:** Register services and configure Serilog as the logger

---

```csharp
// Register all services
builder.Services.InstallerServicesInAssembly(builder.Configuration);

// Configure the application to use Serilog as its logger
builder.Host.UseSerilog();

```

## 4. Logging

✏️ **LogInformation** in the GetWeatherForecast API will log the message **"Start WeatherForecast Controller ", DateTime.Now** when calling the API.

---

```csharp
[HttpGet(Name = "GetWeatherForecast")]
public IEnumerable<WeatherForecast> Get()
{
    _logger.LogInformation("Start WeatherForecast Controller ", DateTime.Now);

    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = Random.Shared.Next(-20, 55),
        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    })
    .ToArray();
}

```

🪜 **Step 1:** Run the application and go to Kibana (localhost:9200)

---

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled.png)

⇒ If the configuration is correct, the **Indices** section will appear under **Data** in **Index Management**, with the specified name in the configuration.

🪜 **Step 2:** In the **Kibana** section, select **Discover**

---

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%201.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%201.png)

---

🪜 **Step 3:** Customize the view by date and time

---

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%202.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%202.png)

🪜 **Step 4:** Filter the logs by level

---

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%203.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%203.png)

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%204.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%204.png)

✨ You can also view the logs in the form of a chart (x: time, y: count)

---

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%205.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%205.png)

### 5. Read logs in real-time

⇒ Elasticsearch listens to Log events from Serilog and displays them in real-time in Kibana.

![Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%206.png](Stream%20log%20real-time%20with%20Serilog%20Elasticsearch,%20K%20a1a4640aa6244597859a600d9085f5c3/Untitled%206.png)