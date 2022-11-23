# Guia de MVC

## Carlos Rocha

### 2017-0931U

5T1-S

### Notes:

- Añadir: builder.Services.AddDbContext<NotasContext>(options => {
  options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStrings:LocalDB")); });
- Se uso SQL server localDB
