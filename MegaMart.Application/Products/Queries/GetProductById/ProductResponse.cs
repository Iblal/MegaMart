using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaMart.Application.Products.Queries.GetProductById
{
    public sealed record ProductResponse(Guid Id, string Name, string Description, double Price);
}
