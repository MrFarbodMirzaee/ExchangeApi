# ExchangeApi
It's an api with .net 8 about Exchange

## REST Swagger Image
Here's an example of the REST Swagger image for the API:
This image provides a visual representation of the API's endpoints, request/response models, and other relevant information. 
![Swagger UI_Page_1](https://github.com/user-attachments/assets/99d56d4e-c97b-4df4-8b54-ae6ca46699e0)
![Swagger UI_Page_2](https://github.com/user-attachments/assets/61a55892-69a3-48a6-84d3-780aac66424a)
![Swagger UI_Page_3](https://github.com/user-attachments/assets/9e7a56ef-5e8c-4373-9ec7-4559da496ca0)
![Swagger UI_Page_4](https://github.com/user-attachments/assets/c5230aa3-72df-45f6-aa62-c8a62b4d2c18)


## gRPC client Image
Here's an example of the gRPC client image on Console app :
![Screenshot 2024-07-09 214203](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/33dffafb-07c9-41f9-80b8-6350f6b9d1b9)
## GraphQl Image:
Here's an example of the GraphQl:
![347079224-2716057b-fb00-4688-b614-87ca3263d5ea](https://github.com/MrFarbodMirzaee/ExchangeApi/assets/134764233/db67e4f6-d519-4d3c-b196-5db04cfff689)

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
