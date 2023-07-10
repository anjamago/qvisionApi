
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Inyect;

public class HelperConnection
{
    public static string GetConnectionSQL(IConfiguration configuration)
    {
        var mssql = configuration.GetValue<string>("ServiceDockerDatabase:User");

        var database = "";//mssql.Database;
        var a = configuration["ConnectionStrings"];
        var ab = configuration["ConnectionStrings:User"];
        if (database.Contains("Server="))
        {
            return database;
        }

        var server = "";//$"{mssql.Host}";
        var user = "";// mssql.User;
        var pwd = "";// mssql.Password;

        return string.Format(
            "Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;Encrypt=False;Persist Security Info=True;",
            server,
            database,
            user,
            pwd);
    }
}