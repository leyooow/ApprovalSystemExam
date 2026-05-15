# API Contract

## Create Request
POST /api/requests

Request:
{
  "title": "Leave Request",
  "description": "Vacation leave"
}

Response:
{
  "id": "guid",
  "status": "Pending"
}

---

## Get All Requests
GET /api/requests

---

## Get by ID
GET /api/requests/{id}

---

## Approve
POST /api/requests/{id}/approve

---

## Reject
POST /api/requests/{id}/reject

---

## Error Response
{
  "success": false,
  "statusCode" "500",
  "message": "Error Message",
}