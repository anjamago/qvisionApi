
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Inyect;

public class HelperConnection
{
    public static string GetConnectionSQL(IConfiguration configuration)
    {

        var database = configuration.GetValue<string>("ServiceDockerDatabase:Database");

        if (database.Contains("Server="))
        {
            return database;
        }

        var server = configuration.GetValue<string>("ServiceDockerDatabase:Server");
        var user = configuration.GetValue<string>("ServiceDockerDatabase:User");
        var pwd =configuration.GetValue<string>("ServiceDockerDatabase:Passwor");

        return string.Format(
            "Server={0};Database={1};User ID={2};Password={3};Trusted_Connection=False;Encrypt=False;Persist Security Info=True;",
            server,
            database,
            user,
            pwd);
    }
}