# Database Project

## Choices

- `EmployeeId` is nullable in `Orders`, because:
    - Both parents Employee and Reservation have many orders (one-to-many).
    - So, we can cascade deletion only from one of the parents.
    - Meaning we are allowed to restrict deletion, or set `EmployeeId` to null on delete.
    - The second choice seems more flexible.
    - And you don't even have to assign an order to an employee at creation.

- `Table` deletion is restricted by its `Reservation` entities, because:
    - Reservation deletion already cascades from its Customer parent.
    - So, we can either `SetNull` or `Restrict`.
    - The second choice seems more fitting since a reservation shouldn't exist with a table.

- `OpeningHours` in `Restaurant` is a simple string, because:
    - Its not used in any query of the given requirements.