# AssesmentApp
Assesment Todo App For Uplers interview

This code is devide mainly in 6 parts
1. Core > Domain
2. Core > Application
3. Infrastructure > Identity
4. Infrastructure > Persistence
5. Web > Api
6. Frontend(Frontend project in angular)

Go to TodoApp Folder And

**Run Command**
"ng serve" to run the frontend app

Get Todo.Sln in visual studio To run backend

Then you can see all the features

# Projects Explantion

Todo.Domain
-------------
This project contains all the base entity other then Authentication related like ApplicationUser or ApplicationRole

This contains BaseEntity which has Id field for primary key so you don't need to repeat the same code it follows DRY principle.

This contains BaseAuditableEntity which has all audit fields.

Todo.Application
-----------------
This is the application layor for the project which contains all commands and query

We use mediator for behavior pattern
and other than that you can find repository pattern and unitofwork pattern to keep code simple and easily maintainable.

It also use fluent validation to validate commands and has dependency injection to make all the process service oriented. And maintains all the behaviors so you don't need to invoke validation or exception behavior manually

Todo.Identity
-------------
This one has all the user identity related model and database configuration although it targets same database as persistence.

And you can find all IAuthenticationRepository implementation here also Token Service and User Service implementations.

Todo.Persistence
-------------------
This one has all the database configuration related todo master and contains all repositories and unit of work regarding that.

Todo.Shared
------------
This one has ApplicationUser and ApplicationRole models defined it is here so we can use it anywhere. We can't put it in domain as domain shouldn't have any dependancies other than base.

Todo.API
------------
This contains all the apis.<br/>
This also maintain all middleware and filters by default all apis will be authorized but only those who has [allowanonymous] on top of them can be accessed by anyone.


Frontend
-------------
This is out angular application which has all frontend implementations.
You can register your self and use app for your tasks.
After registering you don't need to login it will automatically log you in.<br>
And you will be redirected to todo page. Where you can have all your todo you can add new. mark exisiting as done and also delete any one you want.<br>
I have used Angular Material for better ui ux.