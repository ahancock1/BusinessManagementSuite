# RestaurantFramework
Framework for the restaurant application and server using .NET 4.5 C# and Entity Framework 6+

Restaurant Management Application Framework

# Notes
Remove DataAccess library and replace it with the Restaurant.Service library. 
This library will be used by the server and as a web service. The generic library is used by the listeners which send and receive data. Anything other than the generic service wil be used as a web service. The restaurantDbContext will be renamed to RestarurantContext and put in the data library. DataModels library to be renamed to Data.


## Libraries

Data - contains the data models and is used by every application

Service - provides access to the data used by the web site and server

Network - provides applications with access to the framework through serialiazable packets

Web - Website

Android - Android application

iOS - Apple application

Windows - 

Common - A library of helpers classes and extensions

## References

Use ServiceHost to host the web services in the server, example:

```
// Host the service within this EXE console application. 
public static void Main()
{
  using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
  {
    try
    {
      // Open the ServiceHost to start listening for messages.
      serviceHost.Open();

        // The service can now be accessed.
      Console.WriteLine("The service is ready.");
      Console.WriteLine("Press <ENTER> to terminate service.");
      Console.ReadLine();

      // Close the ServiceHost.
      serviceHost.Close();
    }
    catch (TimeoutException timeProblem)
    {
      Console.WriteLine(timeProblem.Message);
      Console.ReadLine();
    }
    catch (CommunicationException commProblem)
    {
      Console.WriteLine(commProblem.Message);
      Console.ReadLine();
    }
  }
}
```
The server can be hosted as an .exe or a windows service which will start and stop when the computer is shutdown and restarted.

File Service http://www.codeproject.com/Articles/33825/WCF-TCP-based-File-Server
