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

## Database Noted

Mirroring a database for rolling updates 

https://msdn.microsoft.com/en-us/library/ms189852.aspx

## References

returning a list from a wcf service  http://www.topwcftutorials.net/2013/05/collections-from-wcf-service.html

pushing notifications to a website http://stackoverflow.com/questions/17986907/push-notification-mechanism-between-a-server-and-a-client-app

Generic WCF Service

http://weblogs.asp.net/zareian/how-to-write-a-generic-service-in-wcf

http://it.toolbox.com/blogs/paytonbyrd/wcf-design-pattern-generic-service-19027

use this for accessing the number of bytes sent in each wcf message call

http://www.codeproject.com/Articles/24349/Generic-WCF-Host


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

//http://www.codeproject.com/Articles/650869/Creating-a-Self-Hosted-WCF-Service
// Create the ServiceHost.
using (ServiceHost host = new ServiceHost(typeof(HelloWorldService), baseAddress))
{
    // Enable metadata publishing.
    ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
    smb.HttpGetEnabled = true;
    smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
    host.Description.Behaviors.Add(smb);

    // Open the ServiceHost to start listening for messages. Since
    // no endpoints are explicitly configured, the runtime will create
    // one endpoint per base address for each service contract implemented
    // by the service.
    host.Open();

    Console.WriteLine("The service is ready at {0}", baseAddress);
    Console.WriteLine("Press <Enter> to stop the service.");
    Console.ReadLine();

    // Close the ServiceHost.
    host.Close();
}

```

Fix this error: The communication object, System.ServiceModel.ServiceHost, cannot be used for communication because it is in the Faulted state. Run as a fucking admin... update the manifest

~~The server can be hosted as an .exe or a windows service which will start and stop when the computer is shutdown and restarted.~~

~~Butcher this in the App.Config to set up the service correctly~~ All the hosting is done neatly in code not through a config file. todo: maybe add own simpler config file once serialisation class has been fixed

``` XML
<system.serviceModel>
  <services>
    <service behaviorConfiguration="DefaultBehavior" name="Namespace.Service1">
      <endpoint address="" binding="netTcpBinding" bindingConfiguration="TCPBindingConfig" name="TCPEndpoint" contract="Namespace.IService1" />
      <endpoint address="mex" binding="mexTcpBinding" bindingConfiguration="" name="TcpMetaData" contract="IMetadataExchange" />
      <host>
        <baseAddresses>
          <add baseAddress="net.tcp://localhost:8001/Namespace/Service1" />
        </baseAddresses>
      </host>
    </service>
    <service behaviorConfiguration="DefaultBehavior" name="Namespace.Service2">
      <endpoint address="" binding="netTcpBinding" bindingConfiguration="TCPBindingConfig" name="TCPEndpoint" contract="Namespace.IService2" />
      <endpoint address="mex" binding="mexTcpBinding" bindingConfiguration="" name="TcpMetaData" contract="IMetadataExchange" />
      <host>
        <baseAddresses>
          <add baseAddress="net.tcp://localhost:8002/Namespace/Service2" />
        </baseAddresses>
      </host>
    </service>
    ...
  </services>
  <bindings>
    <netTcpBinding>
      <binding name="TCPBindingConfig" maxBufferSize="5242880" maxReceivedMessageSize="5242880">
        <readerQuotas maxStringContentLength="5242880" />
        <security mode="None" />
      </binding>
    </netTcpBinding>
  </bindings>
  <behaviors>
    <serviceBehaviors>
      <behavior name="DefaultBehavior">
        <serviceMetadata httpGetEnabled="false" />
        <serviceDebug includeExceptionDetailInFaults="true" />
        <serviceThrottling maxConcurrentCalls="21" maxConcurrentSessions="50" />
      </behavior>
    </serviceBehaviors>
  </behaviors>
</system.serviceModel>
```


Program: http://stackoverflow.com/questions/334472/run-wcf-servicehost-with-multiple-contracts

~~Servcice: http://www.codeproject.com/Articles/653493/WCF-Hosting-with-Windows-Service~~

File Service: http://www.codeproject.com/Articles/33825/WCF-TCP-based-File-Server

Licence generation: http://www.codeproject.com/Articles/11012/License-Key-Generation

~~Ensure only one version of the server is running (Program)~~

IIS Hosting: http://www.codeproject.com/Articles/550796/A-Beginners-Tutorial-on-How-to-Host-a-WCF-Service

## EF Notes
```
[MaxLength(100, "{0} can have a max of {1} characters")]
public string Address { get; set; }
```
Will output the following if it is over the character limit: "Address can have a max of 100 characters"

The placeholders I am aware of are:
```
{0} = Property Name
{1} = Max Length
{2} = Min Length
```

Database schema notes
http://www.entityframeworktutorial.net/code-first/table-dataannotations-attribute-in-code-first.aspx
