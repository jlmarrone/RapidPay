# RapidPay API

To launch the application, first of all, the connection string might be adjusted. Currently, appsettings.Development.json has the following one:
    
* "DefaultConnection": "Server=localhost;Database=RapidPayDb;Trusted_Connection=True;MultipleActiveResultSets=true;Trust Server Certificate=true;"

The code is configured to automaticly run migrations when launching the app.

### Authentication Credentials:

* Admin -> user: admin - password: admin123
* Guest -> user: guest - passwoerd: guest123
