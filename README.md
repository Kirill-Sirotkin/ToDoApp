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
