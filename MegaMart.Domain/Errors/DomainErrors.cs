using MediatR;
using MegaMart.Domain.Shared;

namespace MegaMart.Domain.Errors;

public static class DomainErrors
{
    public static class Product
    {
        public static readonly Error ProductNameExists = new(
            "MegaMart.ProductNameExists",
            "Can't add product as product with same name already exists.");
    }

}