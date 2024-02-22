# Event Sourcing with multi-tenancy

Example of a custom implementation of event sourcing infrastructure with multi-tenancy support.

## Setup

1. Start postgres container using command bellow
   ```shell
   docker run -it -p 127.0.0.1:5432:5432 --name postgres -e POSTGRES_PASSWORD=<PASSWORD> postgres
   ```

2. Configure user secrets
   ```
   "Persistence": {
      "ConnectionStringOptions": {
         "Host": "",
         "Port": "",
         "Username": "",
         "Password": ""
      },
      "DatabaseOptions": {
         "MasterDatabaseName": "",
         "TenantDatabasePrefix": ""
      }
   }
   ```

3. Create databases
   ```shell
   TODO
   ```

4. Run the application
   ```shell
   dotnet run
   ```