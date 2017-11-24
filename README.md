Evolution Simulator
==========
 
This is desktop application intended to simulate the plant evolution.

The plants in the map carry out different activities : water absortion, grow up, reproduction, dead.

Every plant is defined by a specific DNA and the activities above have in acount the DNA values to be completed.

During the reproduction activity 2 plants exchange the DNA creating new seeds with a new DNA.

There is a 10% of posibilities that a gen(value) mutates during the reproduction.

Each plant receive a certain damage depending the kind of field where is growing. Also a plant is able to absorb a certain porcentage
of water also depending on the kind of fiel where is located.

Development Status
--------------------

Currently fixing bugs with Saving a map (It fails if the map has been already saved)
Refactoring application to make it more readible and maintenable
Future features
- Map designer 
- Map selector

Have a look in https://github.com/jose-sanchez/EvolutionSimulator/projects/1 to see the current open tasks
 
Technology
--------------------
 
+ .Net with c#
+ Entity Framework 
+ SQL Express

Installation
--------------------
1) Clone the repository in your local machine

2) Open Sql Server Manager Studio an Attach to SQL server the DB contained into data.mdf, add read and write permission to your user. Or Run the scritps in folder DataBase starting by DataBaseCreation.sql(amend the db creation path) and then add the user permissions

3) Open Visual Studio and Update the app.config with the connection string from your computer:  provider connection string=&quot;Data Source=DESKTOP-26M7VNU\SQLEXPRESS;Initial Catalog=DATA.MDF;integrated security=True;connect timeout=30;multipleactiveresultsets=True;App=EntityFramework&quot;"

4) Compile  and execute the application







