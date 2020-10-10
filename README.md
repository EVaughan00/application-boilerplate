## Dotnet application boilerplate

Install the dotnet template using:

dotnet new -i ./

Create a new application using:

dotnet new boilerplate -n Application

# Structure
The basic structure looks like this:

![application structure](https://i.ibb.co/Dwfky4g/New-Project.png)

Pretty frequent architecture; client sends a request to the API Gateway, it decides where the request will proceed. Assuming all of our microservices are secured with at least JWT Authorization, Auth Resource provides a new JWT.

## API Gateway
API Gateway is implemented using [Ocelot](https://github.com/ThreeMammals/Ocelot).  **Ocelot** makes it very simple to map microservices to specific routes using only *json configuration file* (in this case called `ocelot.json`.

> This application runs on `http://localhost:5000`

## Auth Resource (TODO)
Auth Resource is a simple REST Service that provides us with **JWT** (JSON Web Token) which we must propagate through ours microservices in order to pass the security gates. 

In this case, there is a *util class* called `JwtGenerator` with method called `Generate` which takes two arguments; username (for JWT sub Claim) and role name. Role name is essential since we want to guard our endpoints in microservices with `[Authorize(Roles = "ROLE_NAME")]`.

JWT is set to expire in 24 hours.

You can change all JWT Claims and properties in `Generate` method, mentioned above.

## Microservices

The dotnet microservice template is best used with the application boilerplate structure. The boilerplate contains
all dependency paths as well as an API Gateway for microservices placed in the 'Services' directory. 
Docker-compose is used to spin up, microservices, databases, and the API Gateway.

## Microservices Communication (TODO)

Communication between microservices can be both async and sync. Synchronous (*REST*) communication is yet to be implemented in near future, though asynchronous (*RabbitMQ*) will be when it becomes necessary.
