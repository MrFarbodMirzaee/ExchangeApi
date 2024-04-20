# ExchangeApi
It's an api with .net 8 about Exchange

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
    "YourDatabaseConnection": "Server=your-server-address;Database=your-database-name;User Id=your-username;Password=your-password;"
  }
}
