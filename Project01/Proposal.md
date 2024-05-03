# THIS IS DEPRECATED AND WILL NOT BE DEVELOPED. 
# Please see cSharpBird for current project.

## Proposal
- The largest camera stores close for holidays and this can cause some inconvenience despite their warnings
- An opportunity exists for a competitor that is open during these times
- To expedite the creation and take advantage of existing closures, we propose the creation of a simple store where customers can:
    - Move through product categories
    - View products and specifications
    - Add items to cart

## Requirements

- The application should be a C# Console Application
- The application should build and run
- The application should interact with users, and provide some console UI
    - Two user types; administrator and customer accounts
- The application should allow for multiple users to log in and persist their data
    - Store "shopping carts" where customer has added products to the cart for checkout
- The application should demonstrate good input validation
    - Validation of customer data provide an example
- The application should persist data to a SQL Server DB
    - Customer or product data, shopping carts are possible stored values
- The application should communicate to DB via ADO.NET or Entity Framework Core
- The application should have unit tests

## Nice to Have

- n-tier architecture
- dependency injection
- The application should log errors and system events to a file or a DB table
- Basic user authentication and authorization (admins vs normal users with passwords)