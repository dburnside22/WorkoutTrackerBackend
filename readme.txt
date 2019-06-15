VS 2019 Community Edition installer: https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019

MySQL 8.0 installer: https://dev.mysql.com/downloads/installer/

Example appsettings.Development.json file:
{
    "Logging": {
        "LogLevel": {
            "Default": "Debug",
            "System": "Information",
            "Microsoft": "Information"
        }
    },
    "ConnectionStrings": {
        "DefaultConnection": "server=localhost;port=3306;database=[your database name];uid=root;password=[your database server password]"
    },
    "Jwt": {
        "Issuer": "https://localhost:[Your project's port number]"
    }
}