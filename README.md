# Hospital-Management-System

###

## About The Project


- **`Models-Views-Controllers (MVC)`** was used instead of DataLayer-BusinessLayer-PresentationLayer.
- **`Models`** folder contains the corresponding tables in the database.
- **`Controllers`** folder contains the transactions execute in the database.
- **`Views`** folder contains the presentation of the application.
- **`Data Annotation`** was used to validate the data.
- Each doctor can only see certain information about the patiens they have. (Within the branch)
- Appointmenst can't be created for non-existent patients.
- Appointmenst can't be updated for non-existent patients.
- If you don't enter the required fields, it gives a warning.
- The app has **`search`** rows.
- This project includes Secretary, Doctor and Main pages.
- There is a diagnosis field that can be left blank.

###


## Database


- **`MSSQL`** was used as the database.
- The database contains **`Stock Procedure.`**
- You can create the database with script.sql
- If this database doesn't work, configure the Database.cs class in the Models folder.
