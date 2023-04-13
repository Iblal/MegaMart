using MediatR;
using MegaMart.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace MegaMart.Domain.Errors;

public static class DomainErrors
{
    public static class ProductErrors
    {
        public static readonly Error NameExists = new(
            "MegaMart.ProductNameExists",
            "Can't add product as product with same name already exists.");

        public static readonly Error DoesNotExist = new(
        "MegaMart.ProductDoesNotExist",
        "One or more order products do not exist");

        public static readonly Error InsufficientStock = new (
        "MegaMart.ProductDoesNotExist",
        "Insufficient stock");
    }

    public static class UserErrors
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

        public static readonly Error UserNotFound = new(
            "MegaMart.UserNotFound",
            "UserNotFound.");
    }

}