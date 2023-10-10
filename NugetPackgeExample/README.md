# Publish NuGet packages

```bash
mkdir Publish NugetPackageExample
```

```bash
cd Publish NugetPackageExample
```

```bash
$dotnet new classlib
```

Create file static code your library

```csharp
namespace Ducware.Example;

public static class ConvertNumberToText
{
    public static string ConvertPhoneNumber(string phoneNumber) 
    {
        // Mảng chuỗi tương ứng với từng chữ số
        string[] numberText = { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
        
        // Chuỗi kết quả
        string result = "";
        
        // Duyệt qua từng chữ số trong số điện thoại
        foreach (char digit in phoneNumber)
        {
            // Chuyển đổi chữ số thành số nguyên
            int number = int.Parse(digit.ToString());

            // Thêm chuỗi tương ứng vào kết quả
            result += numberText[number] + " ";
        }
        
        // Trả về kết quả, loại bỏ dấu cách ở cuối chuỗi
        return result.TrimEnd();
    }
}
```

✨ Edit file *.csproj

```csharp
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <PackageId>Ducware.Example</PackageId>
    <Version>1.0.0</Version>
    <Author>Dang Minh Duc</Author>
  </PropertyGroup>

</Project>
```

```bash
dotnet build
```

🌐 **Access**: [https://www.nuget.org/account/apikeys](https://www.nuget.org/account/apikeys)

✨ Select **Create** button 

![Untitled](Publish%20NuGet%20packages%201dcb2e9d3fd440d2b4d7c92bf56f8f73/Untitled.png)

✨ Press **Create** button

![Untitled](Publish%20NuGet%20packages%201dcb2e9d3fd440d2b4d7c92bf56f8f73/Untitled%201.png)

✨ Copy API key

```bash
dotnet pack
```

✨ cd to folder */*.nupkg

```bash
cd bin/Release/
```

✨ Run command to publish package

```bash
dotnet nuget push Ducware.Example.1.0.0.nupkg --api-key oy2negp53cygwlo7uehqsaybyldfhhtuhg3mffxd63uke4 --source https://api.nuget.org/v3/index.json
```

✨ Done !

![Untitled](Publish%20NuGet%20packages%201dcb2e9d3fd440d2b4d7c92bf56f8f73/Untitled%202.png)

🧩 **Install**

📦 **CLI:**

```bash
dotnet add package Ducware.Example --version 1.0.0
```

📦 **Package Manager:**

```bash
Install-Package Ducware.Example -Version 1.0.0
```
