# Add documentation for the daysbetweendates
## daysbetweendates

This endpoint calculates the number of days between two given dates.

### Request

- Method: GET
- Path: `/daysbetweendates`
- Parameters:
    - `startDate` (required): The start date in the format `YYYY-MM-DD`.
    - `endDate` (required): The end date in the format `YYYY-MM-DD`.

### Response

- Status: 200 OK
- Body: The number of days between the start and end dates.

### Example

Request:
