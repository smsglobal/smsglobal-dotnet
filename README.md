# SMSGlobal Dotnet

![.NET Core](https://github.com/smsglobal/smsglobal-dotnet/workflows/.NET%20Core/badge.svg)
[![Nuget](https://img.shields.io/nuget/v/SMSGlobal)](https://www.nuget.org/packages/SMSGlobal)

## SMSGlobal REST API and Libraries for .NET

This is an SDK for SMSGlobal’s REST API that supports .NET applications written in C#, VB.Net, and F# to enable SMS and opt out functionality.

Sign up for a [free SMSGlobal account](https://www.smsglobal.com/mxt-sign-up/?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk) today and get your API Key from our advanced SMS platform, MXT. Plus, enjoy unlimited free developer sandbox testing to try out your API in full!

## Supported .NET versions

This library supports .NET applications written in C#, VB.Net, and F# that utilize .NET Standard 2.1 which supports .NET Core 3.0 and unavailable for .NET Framework. [supported version](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Installation

The best and easiest way to add the SMSGlobal libraries to your .NET project is to use the NuGet package manager.

### With Visual Studio IDE

From within Visual Studio, you can use the NuGet GUI to search for and install the SMSGlobal NuGet package. Or, as a shortcut, simply type the following command into the Package Manager Console:

    Install-Package SMSGlobal

### With .NET Core Command Line Tools

If you are building with the .NET Core command line tools, then you can run the following command from within your project directory:

    dotnet add package SMSGlobal
    
### Azure functions

From within Visual Studio while creating azure function app, you can use the NuGet GUI to search for and install the SMSGlobal NuGet package. Or, as a shortcut, simply type the following command into the Package Manager Console:

    Install-Package SMSGlobal
    
More information can be found here. [Nuget Client Tools](https://docs.microsoft.com/en-us/nuget/install-nuget-client-tools)

## Configuration

First import the package by using SMSGlobal api:

```csharp
using SMSGlobal.api;
```
To setup the configuration of the SMSGlobal client you have to create following object with Rest and Secret API keys.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));
```
And then consume the function like this:

```csharp
var response = await client.SMS.SMSSend(new
{
    origin = "Test",
    destination = "DESTINATION-NUMBER",
    message = "This is a test message"
});
```
The response object will contain the result object and also two keys fields:

1. statuscode: This code can be used to determine the outcome of the call. Based on data passed you can get different status codes such as 400, 404, 200 etc.

2. statusmessages: This message can be used to determine the outcome of the call. Each status code has a status message linked. 

Each api call have different status codes and messages, more info about status codes can be found here. [Rest API](https://www.smsglobal.com/rest-api/?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk)

### Configuration Reference

Key | Description
----|------------
SMSGLOBAL-API-KEY | Your REST API key from the [MXT](https://mxt.smsglobal.com/integrations?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk)
SMSGLOBAL-SECRET-KEY | Your REST API secret from the [MXT](https://mxt.smsglobal.com/integrations?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk)

## Examples

The following examples show how to: 

### SMS

 * [Sending a message](#sending-a-message)
 * [Receive all messages](#receive-all-messages)
 * [Get message by Id](#get-message-by-id)
 * [Delete message](#delete-message)

### SMS-Incoming

 * [Get all incoming messages](#get-all-incoming-messages)
 * [Get incoming message by Id](#get-incoming-message-by-id)
 * [Delete incoming message](#delete-incoming-message)

### Opt-Outs

 * [Get all opted out numbers](#get-all-opted-out-numbers)
 * [Opt out number](#opt-out-number)
 * [Validate for opt out](#validate-opt-out)
 * [Opt in number](#opt-in-number)
 

More info can be found here. [SMSGlobal Rest API](https://www.smsglobal.com/rest-api/?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk#api-endpoints)
 
### Sending a Message

This can be used to send a single message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

var response = await client.SMS.SMSSend(new
{
    origin = "Test",
    destination = "DESTINATION-NUMBER",
    message = "This is a test message"
});
```

This can be used to send a multiple messages.

```csharp

Object[] messages = new Object[2];

messages[0] = new {
origin = "Test",
destination = "DESTINATION-NUMBER-1",
message = "This is a test message"
};

messages[1] = new {
origin = "Test",
destination = "DESTINATION-NUMBER-2",
message = "This is a test message"
};

var response = await client.SMS.SMSSend(new { messages = messages });
			
```
The response object will contain collection of outgoing message objects.

This can be used to send to multiple destinations.

```csharp
string[] destinations = new string[2];

destinations[0] = "DESTINATION-NUMBER-1";
destinations[1] = "DESTINATION-NUMBER-2";

var response = await client.SMS.SMSSend(new
{
   origin = "Test",
   destinations = destinations,
   message = "This is a test message"
});
```
The response object will contain collection of outgoing message objects.

Same way we can send mutiple messages of array having multiple destinations array in it.

```csharp

Object[] messages = new Object[2];

string[] destinations1 = new string[2];

destinations[0] = "DESTINATION-NUMBER-1";
destinations[1] = "DESTINATION-NUMBER-2";

string[] destinations2 = new string[2];

destinations[0] = "DESTINATION-NUMBER-3";
destinations[1] = "DESTINATION-NUMBER-4";

messages[0] = new {
origin = "Test",
destinations = destinations1,
message = "This is a test message"
};

messages[1] = new {
origin = "Test",
destinations = destinations2,
message = "This is a test message"
};

var response = await client.SMS.SMSSend(new { messages = messages });

```
The response object will contain collection of outgoing message objects.

### Receive all Messages

This can be used to view list of all outgoing messages. The messages returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string filter = "limit=1";
var response = await client.SMS.SMSGetAll(filter);
```
The response object will contain all the sms sent messages objects.

### Get Message By Id

This can be used to view details of an outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSGetId(id);
```
The response object will contain details of the message.

### Delete Message

This can be used to delete outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSDeleteId(id);
```
The reponse of this request will return status code where 204 means message deleted successfully.

### Get All Incoming Messages

This can be used to get all incoming messages. The messages returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

 string filter = "limit=1";
 var response = await client.SMS.SMSGetIncoming(filter);
```
The response object will contain all the incoming messages objects.

### Get Incoming Message By Id

This can be used to view details of an incoming message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "INCOMING-NUMBER";
var response = await client.SMS.SMSDeleteIncoming(id);
```
The response object will contain details of the incoming message.

### Delete Incoming Message

This can be used to delete an incoming message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSGetIncomingById(id);
```
The reponse of this request will return status code where 204 means message deleted successfully.

### Get All Opted Out Numbers

This can be used to get all opted out numbers. The numbers returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string filter = "";
var response = await client.SMS.SMSGetOptOuts(filter);
```
The response object will contain all the opted number objects.

### Opt Out Number

This can be used to opt out numbers.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

Object[] payload = new Object[2];
payload[0] = new
{
    number = "MOBILE-NUMBER"
};
payload[1] = new
{
    number = "MOBILE-NUMBER"
};

var response = await client.SMS.SMSPostOptOut(new { optouts = payload });
```
The response object will contain collection of Opt out number object. Optout object consist of number and status(exist, valid, and invalid) properties.

### Validate Opt Out

This can be used to validate mobile numbers for opt-out.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

Object[] payload = new Object[2];
payload[0] = new
{
    number = "MOBILE-NUMBER"
};
payload[1] = new
{
    number = "MOBILE-NUMBER"
};

var response = await client.SMS.SMSPostOptOutValidate(new { optouts = payload });
```
The response object will contain collection of Opt out number object. Optout object consist of number and status(exist, valid, and invalid) properties.

### Opt In Number

This can be used to opt in a number.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string number = "MOBILE-NUMBER";
var response = await client.SMS.SMSDeleteOptOut(number);
```
The reponse of this request will return status code where 204 means opted-in successfully.

## Getting help

View the [REST API](https://www.smsglobal.com/rest-api/?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk) documentation for a list of available resources.

For any query [contact us](https://www.smsglobal.com/contact/?utm_source=dev&utm_medium=github&utm_campaign=dotnet_sdk) 
