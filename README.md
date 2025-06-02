# Tournament Tracker

A desktop application for managing sports tournaments. The system streamlines team registrations, automatic match scheduling, and results tracking — all optimized for usability and performance.

## Project Description

Tournament Tracker is a Windows Forms application developed to manage the operations of sports tournaments efficiently. It supports:
- Team registration
- Automatic scheduling of matches based on team availability
- Real-time results tracking
- Admin and user role functionalities

The system follows a clean three-tier architecture and ensures smooth data operations with asynchronous ADO.NET integration and robust T-SQL queries.

## Technologies Used

- Language: C#
- Framework: .NET Framework
- Database: SQL Server
- Data Access: ADO.NET, T-SQL, LINQ
- UI: Windows Forms

## Architecture

- Presentation Layer: Windows Forms UI  
- Business Logic Layer: Handles application logic and data processing  
- Data Access Layer: Performs CRUD operations with ADO.NET using Async/Await  

## Features

- Team Registration and Management  
- Automatic Match Scheduling Based on Team Availability  
- Results Tracking and Match Updates  
- Admin and User Role Separation  
- Responsive and maintainable architecture  
- SQL Server integration with optimized schemas, indexes, and queries  

## Roles

- **Admin**: Can manage all teams, matches, and results  
- **User**: Limited to viewing schedules and team status  

Note: Sample credentials or seed data are not included in this version. You may add them manually after restoring the database.

## Database Setup

A `.bak` SQL Server database backup is included in the repository under the `/Database/` folder.

### Connection String

To run the application, update the connection string in the `App.config` file:

```xml
<connectionStrings>
  <add name="TournamentDB"
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=TournamentTracker;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>

## Contact  
Amr Saeed  
Email: amrpr6@gmail.com  
Phone: +20 1024378380
WhatsApp: +20 1024378380
