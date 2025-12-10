using BuildingBlocks.Exceptions;

namespace Basket.API.Basket.Exceptions
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string message) : base(message)
        {
        }
    }
}
