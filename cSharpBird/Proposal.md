## Proposal
- There must be a way to store checklists while eBird is down for maintenance or issues

## Requirements

- The application should be a C# Console Application
- The application should build and run
- The application should interact with users, and provide some console UI
    - Single user type that has objects associated with it (checklists)
    - Superuser that controls additional classes of objects (locations, species)
- The application should allow for multiple users to log in and persist their data
    - Checklists will be saved in SQL/JSON; option to print as text file for user to refer to later
- The application should demonstrate good input validation
    - Validation of locations and species
- The application should persist data to a SQL Server DB
    - Checlists, locations, and species will be stored here
- The application should communicate to DB via ADO.NET or Entity Framework Core
- The application should have unit tests

## Nice to Have

- n-tier architecture
- dependency injection
- The application should log errors and system events to a file or a DB table
- Basic user authentication and authorization (admins vs normal users with passwords)