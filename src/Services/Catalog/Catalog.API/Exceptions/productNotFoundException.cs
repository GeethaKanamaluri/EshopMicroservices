
using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions
{   
    public class productNotFoundException: NotFoundException
    {
        public productNotFoundException(Guid id) : base("product", id)
        {
        }
    }
}