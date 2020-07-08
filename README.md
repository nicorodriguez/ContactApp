# ContactApp

ContactApp is a .Net App to manage, save, edit, retrieve, search and delete Contacts.

## Installation

Use NuGet Packages and install the following libraries.

```bash
  Microsoft.AspNetCore
  Microsoft.EntityFrameworkCore.Tools
  Microsoft.EntityFrameworkCore.SqlServer
  Microsoft.Extensions.Configuration.Json
  Microsoft.AspNetCore.Mvc.NewtonsoftJson
  FluentValidation
  Newtonsoft.Json
  Swashbuckle.AspNetCore
```

Use a SQL Server Database installed in the following location.

```bash
  Data Source=localhost\\SQLEXPRESS
```

Create Database using ApplicationContext definitions.

```bash
  Go to Tools > NuGet Package Manager > Package Manager Console
  Type => Update-Database 20200708050746_second-migration
```

## Usage

```bash
  Select "ContactApp" instead of "ISS".
  After you run you application, you are able to use SWAGGER to test all endpoints.
```
