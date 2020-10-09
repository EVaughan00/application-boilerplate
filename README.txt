## Dotnet application boilerplate

Install the dotnet template using:

dotnet new -i ./

Create a new application using:

dotnet new boilerplate -n Application

The dotnet microservice template is best used with the application boilerplate structure. The boilerplate contains
all dependency paths as well as an API Gateway for microservices placed in the 'Services' directory. 
Docker-compose is used to spin up, microservices, databases, and the API Gateway.
