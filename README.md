# MS Service App

## How to Run Project

There are multiple ways to run this project using two pre-configured environments `local` and `docker`.  The `appsettings.json` files are configured to run the projects in different ways and connect different application logging mechanisms.  When running locally the application logs to the console window

### DOTNET CLI

The CLI makes everything easier in .NET engineering.  Running this application is no different.  This task is aided by the launchsettings.json file that sets all the parameters required to run the API on your local machine.  Ports, environments and logging are all configured in the settings, so the only command required is the following single line statement.  

``` bash
dotnet run --project ./src/Presentation
```

### DOCKER COMPOSE

Docker compose makes it easier to start multiple containers at one time and manage their configuration from one file (`docker-compose.yml`).  This project will run the application 

- App - http://localhost:8080/swagger
- Rotate Matrix - https://localhost:8080/api/Matrix

### Example
curl -X 'POST' \
  'https://localhost:8080/api/Matrix' \
  -H 'accept: */*' \
  -H 'Content-Type: application/json' \
  -d '{
    "body": [
        [
            1,
            2
        ],
        [
            3,
            4
        ]
    ]
}'


To start the Containers

``` bash
docker-compose up --build -d
```

To shut down the containers

``` bash
docker-compose down
```


## Features

There are plenty of handy implementations of features throughout this solution, in no particular order here are some that might interest you.

- Logging using [Serilog](https://github.com/serilog/serilog)
- Mediator Pattern using [Mediatr](https://github.com/jbogard/MediatR)
- Validation using [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- Testing using [Shouldly](https://github.com/shouldly/shouldly) and [NSubstitute](https://github.com/nsubstitute/NSubstitute)
- OpenApi using [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
- Object Mapping using [AutoMapper](https://github.com/AutoMapper/AutoMapper)