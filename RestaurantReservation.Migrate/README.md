# Migrate

- Use this console app to run migrations.
- Simply run `docker-compose.migrate.yml` to persist migrations to the database.
- Or run commands using this project `RestaurantReservation.Migrate` as startup project,
  and `RestauratReservation.Db` as migrations project.
- But be sure to add `DatabaseSettings__ConnectionString` environmental variable to the command.