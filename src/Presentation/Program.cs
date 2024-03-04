using MsServiceApp;

var builder = WebApplication
                .CreateBuilder(args)
                .ConfigureBuilder();

var app = builder
            .Build()
            .ConfigureApplication();


await app.RunAsync();