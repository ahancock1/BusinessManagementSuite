# RestaurantFramework
Framework for the restaurant application and server using .NET 4.5 C# and Entity Framework 6+

Restaurant Management Application Framework

# Notes
Remove DataAccess library and replace it with the Restaurant.Service library. 
This library will be used by the server and as a web service. The generic library is used by the listeners which send and receive data. Anything other than the generic service wil be used as a web service. The restaurantDbContext will be renamed to RestarurantContext and put in the data library. DataModels library to be renamed to Data.

Data - contains the data models and is used by every application

Service - provides access to the data used by the web site and server

Network - provides applications with access to the framework through serialiazable packets

Web - Website

Android - Android application

iOS - Apple application

Windows - 

Common - A library of helpers classes and extensions
