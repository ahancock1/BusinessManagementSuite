# Restaurant Framework
Framework for the restaurant application and server using .NET 4.5 C# and Entity Framework 6+

Restaurant Management Application Framework

## Notes

Look into using iPod touch as a touch screen device

## Libraries

Data - Contains the data models and is used by every application

DataAccess - Contains mapping for Entity Framework and Data context

Listeners - Packet listeners for the TCP side of the server

Service - provides access to the data used by the web site and server

Network - provides applications with access to the framework through serialiazable packets

Server - Main application for hosting, can be installed as a console application or a web service

ServiceHost - Used for hosting web services with IIS (Doesn't allow TCP)

Web - ASP.NET Web site

Android - Android application

iOS - iPhone/iPad application

Windows - Windows phone/tablet application

Common - A library of helpers classes and extensions

## References

Use `ServiceHost` to host the web services in the server, example:

``` C#
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
~~The server can be hosted as an .exe or a windows service which will start and stop when the computer is shutdown and restarted.~~

Program: http://stackoverflow.com/questions/334472/run-wcf-servicehost-with-multiple-contracts

~~Servcice: http://www.codeproject.com/Articles/653493/WCF-Hosting-with-Windows-Service~~

File Service: http://www.codeproject.com/Articles/33825/WCF-TCP-based-File-Server

Licence generation: http://www.codeproject.com/Articles/11012/License-Key-Generation

~~Ensure only one version of the server is running (Program)~~

IIS Hosting: http://www.codeproject.com/Articles/550796/A-Beginners-Tutorial-on-How-to-Host-a-WCF-Service
