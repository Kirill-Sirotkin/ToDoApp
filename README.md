# ToDoApp
Small app to keep track of ToDos

Hello! In this README I will give a description of the project and explain how to run this ToDoApp.

## **Section 1. Description**

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

*Section 3. Using the app*

Now you can run the app. To do it in VSCode, press f5 or navigate to the debug tab and press "run and debug".
![7](https://user-images.githubusercontent.com/92231063/211399691-ca4ba6f1-7641-44e3-a07d-07df94a38d78.png)

This process will take a few seconds, after which a browser window will open.

To make REST API calls, you can use the SwaggerUI or Postman.
To use Swagger, navigate to http://localhost:5019/swagger. This will open the following page:
![8](https://user-images.githubusercontent.com/92231063/211400853-20918bd3-d8d6-4055-843c-0735e6cec6b7.png)

Then, you can use the UI to make API calls. Click the API you need -> click "Try it out" button -> fill the parameter/body of the call (if needed) -> click "Execute" button. Here is an example of "Signup" API:
![9](https://user-images.githubusercontent.com/92231063/211401990-de4efbeb-3d32-40f7-8336-00e578316cb1.png)
![10](https://user-images.githubusercontent.com/92231063/211402016-1002609e-80e2-4fa2-8995-e1c16443bcdc.png)
![11](https://user-images.githubusercontent.com/92231063/211402033-c7de18c4-9785-44e8-94e8-855afd216fca.png)

If signup is successful, you will be automatically signed in and given a JWToken in the response body of the request (JWT also given on successful standalone signin API call). This token is needed to authorize yourself and use all other REST APIs.
![17](https://user-images.githubusercontent.com/92231063/211406133-1469d55b-e7e9-4d1d-bb35-b56260ee3421.png)

To authorize using the JWT, user the "Authorize" button in SwaggerUI:
![12](https://user-images.githubusercontent.com/92231063/211403303-3481eefe-1a2e-40a0-9241-d71cfb47b0f5.png)

This will open a small context window where you can enter the token. Don't forget to add "Bearer ", *then* paste the token!
![13](https://user-images.githubusercontent.com/92231063/211403524-4996c359-7b8d-438a-ada6-d9272dde01ac.png)

After that, other APIs should become available. Without authorization, they will give error 401.

Alternatively, it is possible to make calls using Postman.
For example, here is GET a list of all ToDos API call:

(without specifying status)
![14](https://user-images.githubusercontent.com/92231063/211404467-0902ca93-c0b9-4fca-9fcb-9c0dc8d208d9.png)

(with a specific status)
![15](https://user-images.githubusercontent.com/92231063/211404635-de88dd13-6220-46f8-a22d-3c9d7b2de8d1.png)

Notice the Authorization tab between the call and the response. The JWT can be entered there. Alternatively, it can be added in the Headers tab, using Key=Authorization and Value=Bearer <token value>:
![16](https://user-images.githubusercontent.com/92231063/211405244-aa3aea2c-6acc-4477-b5b7-ca9c6908f7d1.png)

With that, the instructions for the app are complete! I hope you enjoy using it.
  
*Section 4. Additional information*

In this section I will write some more about the project.

The API endpoints are the following:
  1. http://localhost:5019/api/v1/signup 
    POST that allows the user to create their "account" in the system.
    Does not require authorization.
    Accepts email and password (although it does not check if the "email" parameter is and actual email. Therefore you can just enter a nickname)
  2. http://localhost:5019/api/v1/signin 
    POST that allows the user to sign in and receive a JWToken.
    Does not require authorization.
    Accepts email and password, returns JWT.
  3. http://localhost:5019/api/v1/changePassword 
    PUT that allows and existing user to change their password.
    Requires authorization.
    Accepts old password (to validate the user) and new password, which replaces the old one.
  4. http://localhost:5019/api/v1/todos?status=[status] 
    GET that allows the user to see the list of their ToDos.
    Requires authorization.
    Accepts an optional parameter for the status of ToDo. Without the parameter, retuns all ToDos of that user. With parameter, returns only ToDos with that status.
  5. http://localhost:5019/api/v1/todos 
    POST that allows the user to create a new ToDo.
    Requires authorization.
    Accepts name, description (optional, can be null), and status.
  6. http://localhost:5019/api/v1/todos/id 
    PUT that allows the user to update/edit one of their ToDos.
    Requires authorization.
    Accepts ToDoId, name, description (optional, can be null), and status. Replaces old properties of a ToDo with the new ones.
  7. http://localhost:5019/api/v1/todos/id 
    DELETE that allows the user to delete one of their ToDos.
    Requires authorization.
    Accepts ToDoId. Removes the ToDo from the database.

The project structure is the following:
  1. Controllers: responsible for exposing REST APIs, using routes. They depend on services.
    Main version of the app uses 2 controllers: Authorization (responsible for APIs related to user handling) and ToDo (responsible for APIs related to ToDo handling). 
  2. DTOs: Data Transfer Objects, used to expose only needed field to the user of API.
    There are 2 DTOs: for User and ToDo.
  3. Entities: various classes that are used to execute the functionality of the app. Defines the User and their methods, ToDo and their methods, Settings for JWT and other.
  4. Migrations: migrations of data models into the database.
  5. Repositories: contains the database context to use for migrations and dependency injection.
  6. Services: contains scripts that handle interactions with the database. They take information from the controllers and perform the API functionality.
  
Notice that there are some unused scripts, such as UserController, TemporaryToDoRepository, etc. They were needed during initial stages of development and testing, but they do not fulfill the core requirements of the project. I decided to keep them in the project, just in case.
