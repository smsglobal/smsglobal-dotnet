# SMSGlobal Dotnet

## SMSGlobal REST API and Libraries for .NET

This is a SDK for the SMSGlobal REST API. Get an API key from SMSGlobal by signing up and viewing the API key page in the MXT platform. Learn more on [smsglobal.com](https://www.smsglobal.com/)

## Supported .NET versions

This library supports .NET applications written in C#, VB.Net, and F# that utilize .NET Framework 3.5 or above or any [supported version](https://dotnet.microsoft.com/platform/support/policy/dotnet-core#lifecycle) of .NET Core (.NET Standard v1.4).

## Installation

The best and easiest way to add the SMSGlobal libraries to your .NET project is to use the NuGet package manager.

## Configuration

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

### Configuration Reference

Key | Description
----|------------
SMSGLOBAL-API-KEY | Your API key from the [MXT Dashboard](https://mxt.smsglobal.com/integrations)
SMSGLOBAL-SECRET-KEY | Your API secret from the [MXT Dashboard](https://mxt.smsglobal.com/integrations)

## Examples

The following examples show how to:

 * [Sending a message](#sending-a-message)
 * [Receive all messages](#receive-all-messages)
 * [Get message by Id](#get-message-by-id)
 * [Delete message](#delete-message)
 
More info can be found here. [SMSGlobal Rest API](https://www.smsglobal.com/rest-api/)
 
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

### Receive all Messages

This can be used to view list of all outgoing messages. The messages returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string filter = "limit=1";
var response = await client.SMS.SMSGetAll(filter);
```

### Get Message By Id

This can be used to view details of an outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSGetId(id);
```

### Delete Message

This can be used to delete outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSDeleteId(id);
```

## Getting help

View the [REST API](https://www.smsglobal.com/rest-api/) documentation for a list of available resources.

For more queries contact [smsglobal.com](https://www.smsglobal.com/contact/)
