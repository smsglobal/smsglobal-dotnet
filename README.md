# SMSGlobal Dotnet

![.NET Core](https://github.com/smsglobal/smsglobal-dotnet/workflows/.NET%20Core/badge.svg)

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
 

More info can be found here. [SMSGlobal Rest API](https://www.smsglobal.com/rest-api/#api-endpoints)
 
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

More info for this end point can be found here. [POST /v2/sms](http://api.smsglobal.com/v2/doc#post--v2-sms)

### Receive all Messages

This can be used to view list of all outgoing messages. The messages returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string filter = "limit=1";
var response = await client.SMS.SMSGetAll(filter);
```
The response object will contain all the sms sent messages objects.

More info for this end point can be found here. [GET /v2/sms](http://api.smsglobal.com/v2/doc#get--v2-sms)

### Get Message By Id

This can be used to view details of an outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSGetId(id);
```
The response object will contain details of the message.

More info for this end point can be found here. [GET /v2/sms/{id}](http://api.smsglobal.com/v2/doc#get--v2-sms-{id})

### Delete Message

This can be used to delete outgoing message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSDeleteId(id);
```
The reponse of this request will return status code where 204 means message deleted successfully.

More info for this end point can be found here. [DELETE /v2/sms/{id}](http://api.smsglobal.com/v2/doc#delete--v2-sms-{id})

### Get All Incoming Messages

This can be used to get all incoming messages. The messages returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

 string filter = "limit=1";
 var response = await client.SMS.SMSGetIncoming(filter);
```
The response object will contain all the incoming messages objects.

More info for this end point can be found here. [GET /v2/sms-incoming](http://api.smsglobal.com/v2/doc#get--v2-sms-incoming)

### Get Incoming Message By Id

This can be used to view details of an incoming message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "INCOMING-NUMBER";
var response = await client.SMS.SMSDeleteIncoming(id);
```
The response object will contain details of the incoming message.

More info for this end point can be found here. [GET /v2/sms-incoming/{id}](http://api.smsglobal.com/v2/doc#get--v2-sms-incoming-{id})

### Delete Incoming Message

This can be used to delete an incoming message.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string id = "SMSGLOBAL-OUTGOING-ID";
var response = await client.SMS.SMSGetIncomingById(id);
```
The reponse of this request will return status code where 204 means message deleted successfully.

More info for this end point can be found here. [DELETE /v2/sms-incoming/{id}](http://api.smsglobal.com/v2/doc#delete--v2-sms-incoming-{id})

### Get All Opted Out Numbers

This can be used to get all opted out numbers. The numbers returned can be filtered based on different condition.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string filter = "";
var response = await client.SMS.SMSGetOptOuts(filter);
```
The response object will contain all the opted number objects.

More info for this end point can be found here. [GET /v2/opt-outs](http://api.smsglobal.com/v2/doc#get--v2-opt-outs)

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

More info for this end point can be found here. [POST /v2/opt-outs](http://api.smsglobal.com/v2/doc#post--v2-opt-outs)

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

More info for this end point can be found here. [POST /v2/opt-outs/validate](http://api.smsglobal.com/v2/doc#post--v2-opt-outs-validate)

### Opt In Number

This can be used to opt in a number.

```csharp
var client = new Client(new Credentials("SMSGLOBAL-API-KEY", "SMSGLOBAL-SECRET-KEY"));

string number = "MOBILE-NUMBER";
var response = await client.SMS.SMSDeleteOptOut(number);
```
The reponse of this request will return status code where 204 means opted-in successfully.

More info for this end point can be found here. [DELETE /v2/opt-outs/{number}](http://api.smsglobal.com/v2/doc#delete--v2-opt-outs-{number})


## Getting help

View the [REST API](https://www.smsglobal.com/rest-api/) documentation for a list of available resources.

For more queries contact [smsglobal.com](https://www.smsglobal.com/contact/)
