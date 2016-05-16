# Tavis.Http

This library provides some core interfaces, classes and extentions that are used by other Tavis HTTP related projects.

## ClientBuilder

ClientBuilder is provided to give a `Katana` style way of building a message handler pipeline for `HttpClient`

    var builder = new ClientBuilder();

    builder.Use(new SomeMiddleware1());
    builder.Use(new SomeMiddleware2());

    var client = builder.Build();
    

A `IClientBuilder` interface is declared so that middleware creators can create extension methods to simplifiy the creation of middleware components.

## IRequestFactory
This interface is design to allow a client library to abstract away the application semantics of creating an HTTP request.  This allows reusable HTTP handling code to create and re-create the request if necessary.  The LinkRelation string is a type identifier and allows dispatching of a response based on the identifier

## IResponseHandler
This interface enables centralized response handling.