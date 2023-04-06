using MediatR;
using MegaMart.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace MegaMart.Domain.Errors;

public static class DomainErrors
{
    public static class Product
    {
        public static readonly Error ProductNameExists = new(
            "MegaMart.ProductNameExists",
            "Can't add product as product with same name already exists.");
    }

    public static class User
    {
        public static IdentityError EmailAlreadyRegistered =>
            new IdentityError
            {
                Code = "MegaMart.EmailAlreadyRegistered",
                Description = "Registration failed. Email is already registered."
            };


        public static readonly Error InvalidCredentials = new(
            "MegaMart.InvalidCredentials",
            "Incorrect username or password.");
    }

}