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

## Individual Requirements
- User Object
    - User object should possess:
        - Unique identifier (GUID; assigned at creation)
        - Unique email (string; checked against database)
        - Name (string; can be added or changed after account creation, nullable)
    - Will be related to other objects by:
        - Checklist:
            - "Owner" of checklist, able to edit and print
- Checklist Object
    - Checklist object should possess:
        - Unique identifier (GUID; assigned at creation)
        - Birder (object; assigned at creation)
        - Location (string/object; assigned at creation by user)
        - Date (DateTime; assigned at creation by user OR system)
        - List<Bird> (list of objects; assigned AFTER creation by Birder) || List<List <string>>> (list of banding codes, number as string)
    - Will be related to other objects by:
        - Birder/Owner able to edit and print after log in
        - Location, containing details of given hotspot (optional)
        - Birds, by containing list of birds seen
- Bird Object (Nice to have; otherwise, pull from CSV/SQL)
    - Bird Object should possess:
        - Unique identifier (GUID; assigned at creation)
        - Species name (string; assigned at creation)
        - Rarity (string; assigned at creation by user OR system default)
    - Will be related to other objects by:
        - Contained within a List in checklist
- Location Object (Nice to have; otherwise, just userdata)
    - Location Object should possess:
        - Unique identifier (GUID; assigned at creation)
        - Location name (string; assigned at creation)
        - County (string; assigned at creation by user OR system default)
        - State (string; assigned at creation by user OR system default)

