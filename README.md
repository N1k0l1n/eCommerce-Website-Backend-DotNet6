# eCommerce-backend
eCommerce-backend is a backend web application built with C# that provides API endpoints for an eCommerce website. The application allows users to browse products, add products to their cart, and place orders.

## Getting Started
Prerequisites
.NET SDK (version 5.0 or higher)
A database management system (SQL Server, MySQL, PostgreSQL, etc.)

## Installing
Clone the repository:

bash
Copy code
git clone https://github.com/username/ecommerce-backend.git
Navigate to the eCommerce-backend directory:

bash
Copy code
cd ecommerce-backend/eCommerce-backend
Open the appsettings.json file and update the database connection string with your database credentials.

Run the following commands to create and migrate the database:

sql
Copy code
dotnet ef database update
Run the application:

Copy code
dotnet run
The application should now be running on http://localhost:5000.

## Usage
Endpoints
The following endpoints are available:

GET /api/products - get a list of all products
GET /api/products/{id} - get a specific product by ID
POST /api/cart/items - add an item to the user's cart
GET /api/cart/items - get a list of items in the user's cart
DELETE /api/cart/items/{id} - remove an item from the user's cart
POST /api/orders - place an order
Authorization
To access protected endpoints, you must include a JWT token in the Authorization header of your requests. You can obtain a JWT token by sending a POST request to the /api/auth/login endpoint with a valid username and password.

bash
Copy code
POST /api/auth/login HTTP/1.1
Content-Type: application/json

{
  "username": "user",
  "password": "password"
}
The /api/auth/login endpoint returns a JWT token that you can include in the Authorization header of your requests to access protected endpoints.

sql
Copy code
GET /api/products HTTP/1.1
Authorization: Bearer <jwt_token>
Replace <jwt_token> with the token returned by the /api/auth/login endpoint.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
This project is licensed under the MIT License - see the LICENSE file for details.
