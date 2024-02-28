# AngularApplicaiton
The purpose of this project was to gain a better understanding of how .Net Core, Angular and Repositories work together to create a full stack web application. 
As well as best ways to unit test repositories, controllers and any other methods used throughout the project. This projects main purpose is to create a reading
log to keep track of books read by who at what time.

# Project Breakdown
Tech Used: Asp .Net Core, Entity Framework, Angular, C#, HTML, TypeScript

*AngularAspCore.Client*
This is the front end. The code was initially a free dashboard template found on the internet (makes it easier when you have a starting point as my main focus was not developing from the ground up).
The front end includes components for Adding a Book, Adding a Reader, Adding a Reading Log as well as corresponding components for view the data. The components that display the data also have the 
functionality of deleting data. Each item (book, reader, reading log) has a service used by the components to communicate with the backend to create, read, update and delete. There is functionality
that should be pulled out, especially in the reading log component, into an additional services such as converting the model to a dto. 

*AngularAspCore.Database*
This is the database layer. It uses the Repository Design Pattern. The project is a Class Library that works with Entity Framework Core and MySql Server.
Microsoft.EntityFrameworkCore.Design, Microsoft.EntityFrameworkCore.Tools and Pomelo.EntityFrameworkCore.MySql are the required NuGet packages (It took me
a few to figure out I had to add the Pomelo package). I read that one of the disadvantages of Entity Framework Core is that the project is connected to the Server project therefore
it is not a completely abstracted layer. For the database to work correctly, a connection string needs to be added to the appsettings.json file in the AngularAspCore.Server project as 
well as setting up the builder service in the Program.cs file. (This should be moved into a startup file but again not the purpose of this project for me.) The database project also 
utilizes Generics that each repository inherits so the common methods such as add, update, delete are not repeated and every repository. Each repository contains an interface used for dependency injection
makes for better unit testing as well. 

*AngularAspCore.Server*
This is the API layer of the project. It consist of Controllers that represent the repositories and actions performed via the API. The actions as well as any data models or dtos used here must match the 
services in the front end. I would like to add an extra validation layer here that is used between the api and database layer. Many articles suggest using a Data Transfer Object to go between the database
and api. It allows for encapsulation of properties the front end does not need to know about. I did this for the Reading Log Data Model/ Reading Log Dto as well as set up converters in the database layer 
to convert from one to the other. I might do this for the rest of the models but for right now, I have other goals in mind. 

*AngularAspCore.UnitTest*
This is a nUnit test project that uses Moq. Currently there are unit test for the controllers, repositories and data converters used to convert from model to dto. For some reason, researching generic 
repository unit test kept providing unit test that were done via the controllers. Maybe someone will find my unit test helpful. 

To use this project (I should have taken better notes), 
Install dotnet skd 8
Might need the MySql connector for NET 8.3.0 (I cannot remember.)
you will need to download and install MySql Community Server and MySQL Workbench. Add a new connection for localhost to MySql Workbench. Delete files from Migration folder of Database project. 
From the package manager console in Visual Studio, Change the default project to AngularAspCore.Database. Type "add-migration initial(or whatever you want to call it)." Then type "update-database".
This should create the database in MySql Workbench database you just created. Set AngularAspCore.Server as the start up project and run. 
I like to use VS Code for the front end. You will need to download node.js to use npm. Open a new terminal in Vs Code. Run "npm run start". This should start the project. 
I might be missing some installs... Maybe not. To be determined at a later date. 

Next Steps:
I want to add an Apex graph showing the number of books read in each year. Again trying to make sure I understand concepts. I hope set up my database on AWS after I have wrapped up any analysis or front end items I want to work on. 

Lessons Learned:
Always take notes!! I learned a lot during this project. I had no idea how to set my project up to use the repository pattern. But I did it! At one point I read about using a Generic Repository but thought it was to complicated.
As I was working on setting up the database layer, it occurred to me why using Generics would be useful. A lightbulb flipped and how to set up the repositories using Generics finally made sense. Considering this is a project I just 
threw together to help solidify certain concepts related to my last work project, I do not know of many things I would do differently. Add something here or there yes. I am able to take on a project, take into consideration design patterns, Object Oriented Principles and SOLID principles and excel. 


