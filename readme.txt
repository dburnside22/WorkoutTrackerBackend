Step 1: 
Install Visual Studio with ASP NET CORE v2.1
VS 2019 Community Edition installer: https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2019
Run everything with default options, but when it asks which "Workloads" you would like, make sure "ASP.NET and web development" is selected

Step 2: 
Install and turn on MySQL server v8.0
MySQL 8.0 installer: https://dev.mysql.com/downloads/installer/
Run everything with default options

Step 3:
Create an empty database in your MySQL server instance

Step 4:
Add an appsettings.Development.json file
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

Step 5:
In Visual Studio, execute the command "Update-Database" in the "Package Manager Console" window

Step 6:
Hit the endpoint "/api/token/login" with a POST request containing the following JSON content:
{
	"username":"un",
	"password":"pw"
}
The endpoint will return 200 with JSON content on success:
{
	"token":"a very, very, very long string of random characters"
}
The endpoint will return 401 with no content if the login fails
The endpoint will return 400 if the username or password are missing, with JSON content:
{
	"Name of Property that is missing/invalid":
	[
		"An error message regarding the given property"
	]
}