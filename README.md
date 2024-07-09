# ExchangeApi
It's an api with .net 8 about Exchange

## REST Swagger Image
Here's an example of the REST Swagger image for the API:
This image provides a visual representation of the API's endpoints, request/response models, and other relevant information. You can include this image in your README to give users a quick overview of the API's functionality.
![Swagger UI_Page_1](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/3f4417e4-0aba-4797-8904-b342e24e25eb)
![Swagger UI_Page_2](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/e0e9a262-cfaf-4643-bc1d-6ab0b3d1db8d)
![Swagger UI_Page_3](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/cd000655-341b-4879-aea4-23a4baef6867)
## gRPC client Image
Here's an example of the gRPC client image on Console app :
![Screenshot 2024-07-09 214203](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/33dffafb-07c9-41f9-80b8-6350f6b9d1b9)
## GraphQl Image:
Here's an example of the GraphQl:
![Screenshot 2024-07-09 180656](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/2716057b-fb00-4688-b614-87ca3263d5ea)

## Table of Contents
- [Installation](#installation)
- [Usage](#usage)
- [Database Connection](#database-connection)

## Installation
To install and run the API locally, follow these steps:

1. **Clone the Repository:**
2. **Install Dependencies:**
3. **Set Up Environment Variables:**
5. **Start the API:**
6. **Verify the Installation:**
Open a web browser or use an API testing tool like Postman to send requests to the API endpoints and verify that it's running correctly.

## Usage
1. **Authentication:**
   If the API requires authentication, provide details on how users can authenticate themselves, such as using API keys, tokens, or other authentication methods.

2. **Endpoints and Requests:**
   Provide a list of available endpoints and the corresponding HTTP methods (e.g., GET, POST, PUT, DELETE). Include examples of request payloads and parameters if applicable.

   Example:
   - `GET /api/users`: Retrieve a list of users.
   - `POST /api/users`: Create a new user. Request payload example:
     ```json
     {
       "username": "example",
       "email": "example@example.com"
     }
     ```

3. **Responses:**
   Describe the format of the responses returned by the API, including status codes, response bodies, and any relevant error messages.

   Example:
   - Successful response (200 OK):
     ```json
     {
       "id": 1,
       "username": "example",
       "email": "example@example.com"
     }
     ```
   - Error response (4xx or 5xx):
     ```json
     {
       "error": "Invalid input data"
     }
     ```

## Database Connection
If you want to connect to the database, you can use the following connection string as an example:

```json
{
  "ConnectionStrings": {
    "ExchangeApi": "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```
```json
{
  "ConnectionStrings": {
    "ExchangeApiIdentity": "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```
```json
{
  "ConnectionStrings": {
    "ExchangeApiGrpc": "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```
```json
{
  "ConnectionStrings": {
    "ExchangeApiGraphQl": "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
```
