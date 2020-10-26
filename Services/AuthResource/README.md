# Dotnet microservice authresource

## Structure 

![microservice structure](https://hackernoon.com/hn-images/1*YVxaXqiIYskqPauNKZ2OSA.png)

The structure features a bare bones clean architecture with CQRS, MediatR, custom database contexts, and a RabbitMQ event bus. 

## Usage

Install the microservice as a dotnet authresource using:

dotnet new -i ./

Create a new microservice using:

dotnet new microservice -n Identity

This will change all "AuthResource" tags in the microservice to "Identity".

## Application boilerplate

This authresource is best used with the application-boilerplate structure. The boilerplate contains
all dependency paths as well as an API Gateway for microservices placed in the 'Services' directory.
Docker-compose is used to spin up, microservices, databases, and the API Gateway.
