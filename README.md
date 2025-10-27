# ReportsAPI

A REST API for reports

## Projects in this Solution

This solution is organized into several projects, each with a specific responsibility.

### Reports.API

*   **Description**: This is the main entry point of the application. It exposes the RESTful API endpoints. It handles HTTP requests and routes requests to the appropriate application services.

### Reports.Data
*   **Description**: It handles the database logic.

### Reports.Models
*   **Description**: It handles the models layer.

### Reports.Services
*   **Description**: It handles the data retrieval.

## Getting Started

Follow these instructions to get a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- dotnet core 8.0

```bash
# Example: .NET SDK
dotnet --version
```

### Installation

A step-by-step series of examples that tell you how to get a development environment running.

1.  Clone the repo
    ```bash
    git clone https://github.com/danielportilloh/ReportsAPI.git
    ```
2.  Navigate to the solution directory
    ```bash
    cd ReportsAPI
    ```
3.  Restore dependencies
    ```bash
    dotnet restore
    ```
4.  Build the solution
    ```bash
    dotnet build
    ```
5.  Run the API project
    ```bash
    dotnet run --project src/Reports.API/Reports.API.csproj
    ```
