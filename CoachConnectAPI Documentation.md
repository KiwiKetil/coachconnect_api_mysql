# CoachConnectAPI Documentation

How to run CoachConnectAPI with MySQL:
1.      Run the database script called Coach_Connect_DB.sql
2.      Create two environment variables: COACH_CONNECT_USERNAME:coach-app, COACH_CONNECT_PASSWORD:coach123
3.   	Open command line in visual studio
4.   	Navigate to the CoachConnect.API project 
5.   	Run this command: dotnet ef migrations add initialMigration --project ../CoachConnect.DataAccess -o Data/Migrations
6.   	Run this command: dotnet ef database update
7.      Execute SQL Script: CoachConnect_TestData.sql (use passwords.txt for valid usernames/passwords)
8.   	All done with creating the database.
#### Login

Login as user, coach or admin with a valid username and password.
Valid Usernames and passwords for the  database are attached in Passwords.txt. 
Make sure the script CoachConnect_TestData.sql is executed first.

POST https://localhost:7036/api/v1/login
____
``` json
{
  "username": "string",
  "password": "string"
}
```


## User (Player parent or responsible for player):

#### Get all users:
____
``` txt
Queries can be used for filtering. Leaving all queries empty returns all users by default pagesize 10. Queries available: FirstName, LastName, PhoneNumber, Email and sortby options.
```
``` txt
Authorized for: 
Admin
```
GET: https://localhost:7036/api/v1/users


#### Get user by UserId:
___
``` txt
Authorized for: Admin
```
GET: https://localhost:7036/api/v1/users/8f2466af-57c3-458c-82d8-676d80573c6c

#### Update user by Userid:
___
``` txt
Authorized for: Admin, User
Extra authorization:
 - Users can only update their own profile.
 ```
PUT: https://localhost:7036/api/v1/users/8f2466af-57c3-458c-82d8-676d80573c6c

``` json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "email": "string"
}
```
#### Delete user by UserId:
____
``` txt
Authorized for: Admin, User
Extra authorization:
 - Users can only update their own profile.
```
DELETE: https://localhost:7036/api/v1/users/8f2466af-57c3-458c-82d8-676d80573c6c

#### Register a new user:
____
``` txt
Authorized for: No Authorization
```
POST: https://localhost:7036/api/v1/users/register
``` json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "password": "string",
  "email": "string"
}
```
## Coach:
___

#### Get all coaches:
___
``` txt
Queries can be used for filtering. Leaving all queries empty returns all coaches by default pagesize 10. Queries available: FirstName, LastName, PhoneNumber, Email and sortby options.
```
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/coaches

#### Get coach by CoachId:
____
``` txt
Authorized for: Admin
```
GET: https://localhost:7036/api/v1/coaches/2b1e02fc-4b92-4b0d-84a7-2418ff07ac13

#### Update coach by CoachId:
____ 
``` txt
Authorized for: Admin, Coach
Extra authorization: 
 - Coach can only update own profile.
```
PUT: https://localhost:7036/api/v1/coaches/92a93093-c123-4748-a8d9-558d61690d76
``` json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "email": "string"
}
```

#### Delete coach by CoachId:
___
``` txt
Authorized for: Admin, Coach
Extra authorization: 
 - Coach can only delete own profile.
```
DELETE: https://localhost:7036/api/v1/coaches/2b1e02fc-4b92-4b0d-84a7-2418ff07ac13

#### Register new coach:
___
``` txt
Authorized for: No Authorization
```
POST: https://localhost:7036/api/v1/coaches/register
``` json
{
  "firstName": "string",
  "lastName": "string",
  "phoneNumber": "string",
  "password": "string",
  "email": "string"
}
```
## Game:
___
#### Get all games:
____
``` txt
Queries can be used for filtering. Leaving all queries empty returns all games by default pagesize 10. 
Queries available: TeamId, Location, GameTime and sortby options.
```
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/games

#### Get game by GameId:
____
``` txt
Authorized for: Admin, Coach, User
```
Get: https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca808725555

#### Update Game by GameId:
___
``` txt
Authorized for: Admin, Coach
Extra authorization: 
 - Coaches can only update games for their own team.. 
A game can not be updated to a date where the team already has a game registered.
```
PUT: https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca80812cde3
``` json
{
  "location": "string",
  "homeTeam": {
    "teamId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "awayTeam": {
    "teamId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "gameTime": "2024-05-07T07:31:07.536Z"
}
```

#### Delete game by GameId :
____
``` txt
Authorized for: Admin, Coach
Extra authorization: 
 - Coaches can only delete games for their own team. 
```
DELETE: https://localhost:7036/api/v1/games/2f042e86-d75e-4591-a810-aca80812cde3


#### Register Game:
_____
``` json
Authorized for: Admin, Coach
Extra authorization: 
 - Coaches can only register games for their own team. 
A game can not be registered on a date where the team already has a game registered.
```
POST: https://localhost:7036/api/v1/games/register
``` json
{
  "location": "string",
  "homeTeam": {
    "teamId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "awayTeam": {
    "teamId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "gameTime": "2024-05-07T07:31:56.706Z"
}
```

## GameAttendances:
#### Get all game attendances:
____
``` txt
Queries can be used for filtering. Leaving all queries empty returns all gameattendances by default pagesize 10. Queries available: PlayerLastName, TeamId, GameId and sortby options.
```
``` txt
Authorized for: Admin, Coach'
```
GET: https://localhost:7036/api/v1/gameattendances

#### Get game attendances by GameAttendanceId:
____
``` txt
Authorized for: Admin
```
GET: https://localhost:7036/api/v1/gameattendances/8215514a-c2f8-46fd-a547-ab5c1fc76004

#### Delete gameattendance by GameAttendanceId:
____
``` txt
Authorized for: Admin, Coach
Extra authorization: 
 - Coaches can only delete a game attendance when the attendance is related to their own team.
```
DELETE: https://localhost:7036/api/v1/gameattendances/aa15514a-c2f8-46fd-a547-ab5c1fc76e14

#### Register gameattendance:
___
``` txt
Authorized for: Admin, Coach
 - Registering a game attendance will add +1 to the players game attendance statistics.
Extra authorization: 
 - Coaches can only register a game attendance on their own team.
 - Coaches can only register a game attendance if the player they are registering is playing on their team.
 - Registration will only work If the game attendance does not already exists for the specified game and player
```
POST: https://localhost:7036/api/v1/gameattendances/register
``` json
{
  "gameId": {
    "gameId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  },
  "playerId": {
    "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
  }
}
```

## Player

#### Get all players:
____
``` txt
Queries can be used for filtering. Leaving all queries empty returns all players by default pagesize 10. Queries available: PlayerFirstName, PlayerLastName, TeamId, UserId and sortby options.
```
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/players


#### Get Player by PlayerId:
____
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/players/87654321-2345-2345-2345-123456789144

#### Get Players by UserId:
____
``` txt 
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/players/player/UserId/12345678-90ab-cdef-1234-567890abcdef 

#### Get Players by TeamId:
___
``` txt 
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/players/player/TeamId/d3b5a3d1-e0f2-4bf6-a5c3-7e8d9f1a2013 

#### Register Player:
___
``` txt
Authorized for: Admin, Coach, User
```
POST: https://localhost:7036/api/v1/players/register 
``` json
{
  "firstName": "Fredrik",
  "lastName": "Walin",
  "userId": "12345678-90ab-cdef-1234-567890abcdef",
  "teamId": "0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4020"
}
```

#### Update Player by PlayerId:
___
``` txt
Authorized for: Admin, Coach, User
```
PUT: https://localhost:7036/api/v1/players/87654321-2345-2345-2345-123456789144 
``` json
{
  "firstName": "Fredrik",
  "lastName": "Walin"
}
```

## Team

#### Get all teams:
``` txt
Queries can be used for filtering. Leaving all queries empty returns all players by default pagesize 10. Queries available: TeamCity, TeamName, CoachId and sortby options.
```
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/teams


#### Get Team by TeamId:
____
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/teams/0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4020 

#### Get Teams by CoachId:
____
``` txt 
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/teams/0a1b2c3d-4e5f-6a7b-8c9d-0e1f2a3b4020 

#### Register Team:
___
``` txt
Authorized for: Admin, Coach, User
```
POST: https://localhost:7036/api/v1/teams/register 
``` json
{
  "teamCity": "Frankfurt",
  "teamName": "TeamNumber1",
  "coachId": "0a95b9b1-6fb7-42a7-8333-56e649a48fe7"
}
```

#### Update Team by TeamId:
___
``` txt
Authorized for: Admin, Coach, User
```
PUT: https://localhost:7036/api/v1/teams/028070a6-602c-4162-9a34-6a6fcd3ca4bd 
``` json
{
  "teamCity": "Frankfurt",
  "teamName": "TeamNumber1"
}
```
#### Delete Team by TeamId
___
``` txt
Authorized for: Admin, Coach
```
DEL: https://localhost:7036/api/v1/teams/028070a6-602c-4162-9a34-6a6fcd3ca4bd 

## Practices: 

#### Get all practices:
____
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/practices?page=1&size10

#### Get practice by PracticeId:
____
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/practices/2f042e86-d75e-4591-a810-aca808726604

#### Register Practice:
___
``` txt
Authorized for: Admin, Coach
```
POST: https://localhost:7036/api/v1/practices
``` json
{
  "location": "Barcelona",
  "practiceDate": "2024-06-06T19:30:00.000Z"
}
```

#### Update Practice by PracticeId:
___
``` txt
Authorized for: Admin, Coach
```
PUT: https://localhost:7036/api/v1/practices/2f042e86-d75e-4591-a810-aca808726405
``` json
{
  "location": "Barcelona",
  "practiceDate": "2024-06-06T19:30:00.000Z"
}
```

#### Delete practice by PracticeId :
____
``` txt
Authorized for: Admin, Coach 
```
DELETE: https://localhost:7036/api/v1/practices/2f042e86-d75e-4591-a810-aca808726604

## PracticeAttendances

#### Get all practice attendances:
____
``` txt
Authorized for: Admin, Coach, User
```
GET: https://localhost:7036/api/v1/practice/attendances?PageNumber=1&PageSize=20

#### Get practice attendance by PracticeAttendanceId:
____
``` txt
Authorized for: Admin, Coach
```
GET: https://localhost:7036/api/v1/practice/attendances/9415514a-c2f8-46fd-a547-ab5c1fc76012

#### Get practice attendances by practiceId
``` txt
Authorized for: Admin, Coach
```
GET: https://localhost:7036/api/v1/practice/attendances/2f042e86-d75e-4591-a810-aca808726604 

#### Register practiceattendance:
___
``` txt
Authorized for: Admin, Coach
 - Registering a practice attendance will add +1 to the players practice attendance statistics.
```
POST: https://localhost:7036/api/v1/practices/attendances/register
``` json
{
  "practiceId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "playerId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```
#### Delete practiceattendance by PracticeAttendanceId:
____
``` txt
Authorized for: Admin, Coach
```

DELETE: https://localhost:7036/api/v1/practice/attendances/9415514a-c2f8-46fd-a547-ab5c1fc76012

### JWT:
___
JWT is used for Authentication and Authorization.

Successful login will give a token containing the roles associated with the user, coach or Admin. Roles are set when a user or coach registers for the first time.
There is one Admin already registered in the db.

### Strongly typed IDs:
___
Each entity type has its own strongly typed id (of GUID):

Examples:

UserId
CoachId
TeamId
PracticeId
GameAttendanceId
Etc

### Docker:
___
A dockerfile is included for Mysql. The dockerfile for Mysql is located in the Mysql folder in the parent Docker folder. 
All Integration Tests are done using a docker container containing the database to test against.

### Serilog:
___
Serilog is active and will log important events. Logger will also log to MySql. Logs will create a new log file every day.

### Validations:
___
Fluent Validation is active to make sure no faulty data is inserted in the database.

MySQL Script with testdata for testing endpoints:

A script is included with some basic data, used for testing the APIs endpoints. 

User, Coach and Admin usernames and passwords are attached in file Passwords.txt to use for retrieving a JWT token for using the API endpoints.

### TestData script 
___
CoachConnect_TestData.sql
Passwords.txt

### Integrationtests
___
Integration tests have been done to make sure the API Endpoints work as expected. Initialize tests and a docker container containing a test database with complete data will automatically start. The container will also dispose automatically after tests are done. Make sure Docker Desktop is running.

### GlobalExceptionMiddleware: 
___
The GlobalExceptionMiddleware is a middleware component making sure if any exceptions happen in the api they are caught in the middleware and handled here to return a 500 error..

### N-Tier Architecture
___
We chose to implement N-tier architecture right from the start to structure and organize the code in a way that makes it more modular, scalable, and easier to maintain. By dividing the application into separate layers, such as API, BusinessLayer, and DataAccess, we achieve better separation of concerns and reduce the complexity of the code. This makes it easier to handle changes and add new features while providing a more organized and structured codebase. N-tier architecture also facilitates better testability and simplifies isolating and troubleshooting issues in different parts of the application. Therefore, we have chosen to include this architecture as an integral part of our development process.


### Environment Variables
___
We implemented environment variables to enhance the security of database credentials by hiding these sensitive details from the code. By using environment variables, sensitive data like usernames and passwords can be kept out of the source code and managed externally by system administrators. This reduces the risk of accidental exposure of sensitive information and strengthens the security of the application. Additionally, using environment variables allows for seamless configuration changes without the need to modify the code itself, providing flexibility and easy administration of the application's configuration.


### Rate Limiter
___
Rate Limiter was implemented to safeguard the application against excessive usage or abuse of services. This ensures that the system doesn't get overwhelmed or exploited, maintaining a stable and reliable experience for users. By limiting the number of requests or actions that can be performed within a given time interval, Rate Limiter helps to maintain the performance and security of the application. This is particularly important in cases where the application faces high loads or potential security threats.