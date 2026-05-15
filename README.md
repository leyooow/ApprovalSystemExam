# Request Approval Feature

## Overview
This project implements a Request Approval feature using:
- .NET 8 Web API
- React (Vite)
- SQL Server (chosen for relational consistency and transaction reliability)
- Azure deployment

## Architecture
- Frontend: React app for request creation and approval
- Backend: .NET API handling business logic
- Database: SQL Server storing requests and approval state
- Deployment: Azure (App Service / VM)

## Key Features
- Create Request
- View Requests
- Get Request by ID
- Approve / Reject Request

## Tech Decisions
- SQL Server: Strong ACID compliance, relational integrity
- .NET API: Handles all business logic (clean separation)
- React: Lightweight and fast UI

## How to Run
### API 
dotnet run --project ApprovalRequest
### UI
npm install
npm run dev


## Deployment Approach
- API → Azure App Service / VM
- UI → Azure App Service or Static hosting
- DB → Azure SQL


## Author Approach
Designed as a Technical Lead exercise focusing on:
- Clear architecture
- Proper separation of concerns
- Maintainable and testable code
