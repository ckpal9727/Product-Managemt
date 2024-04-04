The Product Management System is an ASP.NET Core MVC application designed to manage product details. It allows users to input product details such as Product No, Product Name, Cost Price, and Quantity. The Sales Price is automatically calculated based on the Cost Price with added VAT. The application utilizes Entity Framework for database operations.

Key Components:

IAccountRepository Interface: Defines the contract for data access of user operations.
IProductRepository Interface: Defines the contract for data access of product operations.


DB Context for Entity Framework: Handles communication with the database and provides CRUD operations.
Models: Represent the structure of the data entities, including SingUpModel,Login Model,ProductAddModel.
      SingUp Model :For Register a new user to system.
      Login Model: For Login structure of User.
      ProductAddModel : Defines the strucure to add product;
Security:For security used seesion to manage the state of user.
Validation: Form validation is implemented to ensure the correctness of user input.
Controllers: Handle user requests, interact with repository for access the resource as per user request.
Views: Render the user interface for inputting product details and displaying product information.

Features:

Input Product Details: Users can input product details including Product No, Product Name, Cost Price, and Quantity.
Automated Sales Price Calculation: The Sales Price is automatically calculated based on the Cost Price with added VAT (122.50% + 10%) and rounded to two decimal values.
User Authentication: Users need to be logged in to perform add/update operations on products.
View Product List: Users can view the list of products even without logging in.
Encapsulation: Product details are encapsulated within the Product class, ensuring data integrity and security.
