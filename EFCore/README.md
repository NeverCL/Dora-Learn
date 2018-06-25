# 说明

`dotnet add package Microsoft.EntityFrameworkCore`

`dotnet add package Pomelo.EntityFrameworkCore.MySql`

MySQL Version：2.0.1 与 EntityFrameworkCore Version：2.1.1 不兼容

`protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)`

```shell
dotnet ef migrations add Init
dotnet ef database update
```