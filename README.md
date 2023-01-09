# ToDoApp
Small app to keep track of ToDos

Hello! In this README I will give a description of the project and explain how to run this ToDoApp.

*Section 1. Description*

This app has been done using the C# language, ASP.NET Core with Entity Framework and uses PostgreSQL as a database.
To create the project, debug and edit files VSCode application was used.
It exposes a set of REST APIs that allow the user to:
1. Sign up
2. Sign in
3. Change password
4. Get a list of user's ToDos (optionally filtered by status of ToDo)
5. Create new ToDos
6. Update (edit) ToDos
7. Delete ToDos

The user must be logged in to use APIs №№3-7.

The database consists of 2 tables:
1. Users
2. ToDos

The tables are arranged in a one-to-many relationship, meaning that one user can have multiple ToDos, but every ToDo belongs only to a single unique user.

*Section 2. Setup*

Before using the APIs, the app needs to be set up.
As mentioned above, the project was done in VSCode. For better results I recommend using it too. However, any code editor should work.

Step 1.
Download all project files archive from github.
![1](https://user-images.githubusercontent.com/92231063/211395423-3fa2f63e-588d-4c31-874f-9e036f3b3e25.png)

Step 2. 
Extract the ToDoApp-main folder and open it using VSCode.
![2](https://user-images.githubusercontent.com/92231063/211395775-07b3bb48-3c8d-462d-87a6-6cdef96b9d1c.png)

Step 3.
Make sure that the required packages (names listed in ToDoApp.csproj file) are installed and up-to-date.
![6](https://user-images.githubusercontent.com/92231063/211398237-b976c50b-6a0d-47f4-9c70-04891dd408fb.png)

Step 4.
Create a new database using PostgresSQL. For conveniently checking if it works properly, I recommend using a database manager (I'm using DBeaver).
![3](https://user-images.githubusercontent.com/92231063/211396426-5f77e674-e17f-4a7a-bbf5-0385e6f6827d.png)

Step 5. 
Navigate to appsettings.Development.json file in project root folder. There, change the "Db" variable in "ConnectionStrings" to match your PostgreSQL settings.
![4](https://user-images.githubusercontent.com/92231063/211396831-e80c36af-c266-4d4e-bf8c-23753335ddf6.png)

Step 6.
The relevant database migrations should be present in the Migrations folder. Therefore, it should be enough to open the terminal (in VSCode or Windows Powershell), navigate to project root folder and enter "dotnet ef database update" - without quotation marks. This will create the Users and ToDos tables in your PostgreSQL database.
![5](https://user-images.githubusercontent.com/92231063/211397686-2f9c5be0-2cdc-41e0-a874-d399f22f01e4.png)

With that, the setup should be done.
