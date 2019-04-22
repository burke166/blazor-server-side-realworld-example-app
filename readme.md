# ![RealWorld Example App](logo.png)

> ### DotnetCore Razor Components codebase containing real world examples (CRUD, auth, advanced patterns, etc) that adheres to the [RealWorld](https://github.com/gothinkster/realworld) spec and API.


### [Demo](https://github.com/gothinkster/realworld)&nbsp;&nbsp;&nbsp;&nbsp;[RealWorld](https://github.com/gothinkster/realworld)


This codebase was created to demonstrate a fully fledged fullstack application built with Razor Components including CRUD operations, authentication, routing, pagination, and more.

We've gone to great lengths to adhere to the Razor Components community styleguides & best practices.

For more information on how to this works with other frontends/backends, head over to the [RealWorld](https://github.com/gothinkster/realworld) repo.


# How it works

This app is constructed with a minimal amount of extra Nuget packages. Basic state is managed in the AppState class without resorting to something like a Blazor/Razor Components Redux clone. Use of local storage is through simple JavaScript functions in the interop.js file rather than a .NET wrapper/3rd-party package. ApiClient contains the basic functionality to consume the RealWorld backend API.

# Getting started

* [Download and install .NET Core 3.0 Preview 4](https://dotnet.microsoft.com/download/dotnet-core/3.0)
* dotnet build
* dotnet run

