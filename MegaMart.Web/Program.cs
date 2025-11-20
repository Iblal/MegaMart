using MegaMart.Application.Behaviors;
using MediatR;
using MegaMart.Persistence;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using MegaMart.Domain.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetValue<string>("ConnectionString");

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(MegaMart.Application.AssemblyReference.Assembly));

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                MegaMart.Infrastructure.AssemblyReference.Assembly,
                MegaMart.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());


builder
    .Services
    .AddControllers()
    .AddApplicationPart(MegaMart.Presentation.AssemblyReference.Assembly);

builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

builder.Services.AddValidatorsFromAssembly(MegaMart.Application.AssemblyReference.Assembly,
    includeInternalTypes: true);

builder.Services.AddIdentity<User, IdentityRole>()
        .AddEntityFrameworkStores<DatabaseContext>()
        .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<User>>();
builder.Services.AddScoped<SignInManager<User>>();
builder.Services.AddScoped<PasswordHasher<User>>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
