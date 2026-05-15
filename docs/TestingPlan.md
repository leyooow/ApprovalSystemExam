# Testing Plan

## Overview
This project implements both **unit testing** and **integration testing** to ensure:
- Business logic correctness
- API reliability
- Prevention of regressions

Testing is implemented using **xUnit**, following best practices for isolation and maintainability.

---

## Testing Strategy

### 1. Unit Tests (Service Layer)

Scope:
- Business logic inside `RequestService`
- Validation of status transitions (Approve/Reject)
- Handling of missing data

Approach:
- Use **xUnit** as test framework
- Use **Moq** to mock repository and dependencies
- Use **FluentAssertions** for readable assertions

Key Scenarios:
- Create request successfully
- Get request by ID (found / not found)
- Approve request
- Reject request
- Handle invalid or missing request


### 2. Integration Tests (API Layer)

Scope:
- Full HTTP request/response cycle
- Controller + Service interaction

Approach:
- Use WebApplicationFactory
- Run API in-memory
- Use real HTTP client

Key Scenarios:
- Create request → returns 201 Created
- Get request by ID → returns 404 Not Found
- Full flow: Create → Approve → Validate response

---

### 3. Manual Testing

- Validate UI forms
- Verify API endpoints via Swagger or Postman
- End-to-end flow:
  - Create → Approve → Verify state reflects correctly

---

## Test Data Strategy

- Unit tests use mocked data
- Integration tests use generated test data
- No dependency on real production database

---

## Error & Edge Case Testing

- Null or invalid inputs
- Request not found
- Approval of already processed request (future enhancement)
- Exception handling scenarios

---

## Tools Used

- xUnit
- Moq
- FluentAssertions
- WebApplicationFactory

---

## Test Execution

Run all tests using:

    dotnet test

---

## CI/CD Integration

- Tests run automatically in pipeline
- Build fails if any test fails
- Ensures only stable code is deployed

Example pipeline step:

    - name: Run Tests
      run: dotnet test

---

## Success Criteria

- All critical scenarios are covered
- No failing tests
- No regression in approval workflow

---

## Technical Lead Notes

As a Technical Lead, I ensured:
- Clear separation between unit and integration testing
- Tests reflect real system behavior
- Required properties are handled explicitly to avoid runtime issues
- Testing is integrated into CI/CD for consistent quality
- Developers follow a standardized testing approach 