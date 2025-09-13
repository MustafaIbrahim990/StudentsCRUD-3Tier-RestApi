Mustafa A. Ibrahim, [9/13/2025 11:51 PM]
# 📝 README – Student Management System

## 📌 Project Overview  
This project is a Student Management System implemented with a 3-Tier Architecture and RESTful APIs.  
The main goal of the project is to design a separated backend that can be reused with different types of user interfaces — such as desktop, mobile, or web applications — through RESTful API endpoints.  

The system demonstrates a complete workflow of CRUD operations (Create, Read, Update, Delete) while applying separation of concerns and layered architecture principles.  

This project was built as a practical training exercise to strengthen knowledge in C#, ADO.NET, SQL Server, Web APIs, and Windows Forms development.  

---

## 🏗️ Project Structure  

The solution is divided into four layers:  

### 🔹 Students.DAL (Data Access Layer)  
- Built with ADO.NET to interact with SQL Server.  
- Executes queries and stored procedures for CRUD operations.  
- Manages database connections and ensures data persistence is separated from business logic.  

### 🔹 Students.BLL (Business Logic Layer)  
- Contains validation and business rules.  
- Acts as the bridge between DAL and API.  
- Ensures clean and safe data flow before exposing it to APIs/UI.  

### 🔹 Students.API (RESTful API Layer)  
- Built with ASP.NET Core Web API.  
- Exposes CRUD endpoints using HTTP methods (GET, POST, PUT, DELETE).  
- Uses DTOs (Data Transfer Objects) for structured data exchange.  
- Designed to be independent of any UI.  

### 🔹 Students.UI.WinForms (Presentation Layer)  
- A Windows Forms desktop application that consumes the API.  
- Integrates with the backend via HttpClient.  
- Displays and manages data through DataGridView and other controls.  
- Provides input forms for CRUD operations.  

---

## ⚙️ Technologies Used  
- C# (.NET Framework / .NET Core)  
- ASP.NET Core Web API (RESTful APIs)  
- Windows Forms (WinForms)  
- ADO.NET (SQL Client)  
- SQL Server (Database)  

---

## 🚀 Skills Gained from this Project  

### 🔹 Software Architecture & Design  
- Implementing 3-Tier Architecture (DAL, BLL, API, UI).  
- Applying Separation of Concerns and clean code practices.  
- Using DTOs to decouple database models from API/UI.  

### 🔹 Backend Development  
- Building RESTful APIs with ASP.NET Core.  
- Implementing CRUD operations with correct HTTP methods.  
- Managing status codes (200 OK, 400 Bad Request, 404 Not Found, 500 Internal Server Error).  
- Applying layered architecture with dependency separation.  

### 🔹 Database & Data Access  
- Designing tables with primary keys / foreign keys.  
- Writing SQL queries and using stored procedures.  
- Managing connections, transactions, and error handling with ADO.NET.  

### 🔹 Desktop Application Development  
- Developing a WinForms UI.  
- Consuming APIs using HttpClient.  
- Binding API results to DataGridView and other UI elements.  
- Implementing form-based validation before sending data.  

### 🔹 General Development Skills  
- Understanding client-server communication.  
- Handling exceptions and error responses gracefully.  
- Combining C#, SQL Server, APIs, and WinForms into one integrated solution.  

---

## 🛠️ Installation & Usage  

### 1. Database Setup  
1. Install SQL Server.  
2. Create a new database (e.g., StudentsDB).  
3. Run the provided SQL scripts (tables + stored procedures) from the project to initialize the schema.  
4. Update the connection string in Students.DAL and Students.API to match your SQL Server settings.  

### 2. Run the API  
1. Open the solution in Visual Studio.  
2. Set Students.API as the startup project.  
3. Run the project — the API will start (by default on https://localhost:<port>).  
4. You can test the API using tools like Postman or a browser.

Mustafa A. Ibrahim, [9/13/2025 11:51 PM]
### 3. Run the WinForms UI  
1. Set Students.UI.WinForms as the startup project.  
2. In the configuration file (App.config or code), update the API base URL to match the running API.  
3. Run the project.  
4. Use the UI to perform CRUD operations — the app communicates with the backend API and displays results in a DataGridView.  

---

## 🎯 What This Project Demonstrates  
This project shows the ability to:  

✔️ Design and structure an application using layered architecture.  
✔️ Build a reusable backend that can work with any type of UI (mobile, web, or desktop).  
✔️ Work with databases and ADO.NET effectively.  
✔️ Integrate a desktop UI with a backend through RESTful APIs.  
✔️ Deliver a small-scale but complete system: Database → API → UI.
