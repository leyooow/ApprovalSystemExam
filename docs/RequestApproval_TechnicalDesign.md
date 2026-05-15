# Technical Design

## Architecture Overview
React UI → .NET API → SQL Server

## API Layer
- Controllers: Handle HTTP
- Services: Business logic
- Repository: DB access

## Business Logic Placement
- API Service Layer handles:
  - Approval rules
  - Status validation
  - Prevent duplicate approvals

## Database Design
Table: Requests

Fields:
- Id (GUID)
- Title
- Description
- Status (Pending/Approved/Rejected)
- CreatedDate
- UpdatedDate

## Frontend Design
- Pages:
  - Create Request
  - Request List
  - Request Details
- State handled via hooks

## Validation
- Backend is source of truth
- Frontend does basic UX validation

## Error Handling
- Standard API response: 
{ success: false, message: "", errors: [] }


## Security
- Input validation
- API authorization (planned extension)