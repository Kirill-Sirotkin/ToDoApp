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

With that, the instruction for the app are complete! I hope you enjoy using it.
  
*Section 4. Additional information*
