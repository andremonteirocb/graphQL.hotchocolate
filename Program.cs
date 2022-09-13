using Microsoft.EntityFrameworkCore;

const string AllowedOrigin = "allowedOrigin";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GraphQLDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("GraphQLDbContext")));

builder.Services.AddInMemorySubscriptions();

builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>();

builder.Services.AddScoped<EmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<DepartmentRepository, DepartmentRepository>();

builder.Services.AddCors(option =>
{
    option.AddPolicy(AllowedOrigin,
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(AllowedOrigin);
app.UseWebSockets();
app.UseRouting()
   .UseEndpoints(endpoints =>
   {
       endpoints.MapGraphQL();
   });

app.Run();
