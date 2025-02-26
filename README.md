# Stocks App using .NET

This is a .NET-based Stock Market Application that fetches real-time stock data from the **Finnhub API** and implements core .NET features.

## Features
- **Entity Framework Core** for database management
- **Dependency Injection** for service management
- **Authentication & Authorization** using ASP.NET Identity
- **Logging** with Serilog
- **MVC Views** for the frontend

## Setup Instructions
1. **Clone the repository**
   ```sh
   git clone https://github.com/your-username/stocks-app-dotnet.git
   cd stocks-app-dotnet
   ```
2. **Set up the database**
   - Update `appsettings.json` with your database connection string.
   - Run migrations:
     ```sh
     dotnet ef database update
     ```
3. **Set up API key**
   - Register at [Finnhub.io](https://finnhub.io/) to get an API key.
   - Add it to `appsettings.json`:
     ```json
     "FinnhubSettings": {
       "ApiKey": "your_api_key_here"
     }
     ```
4. **Run the application**
   ```sh
   dotnet run
   ```

## Tech Stack
- **Backend:** ASP.NET Core
- **Frontend:** Razor Views
- **Database:** SQL Server
- **Authentication:** Identity
- **Logging:** Serilog
