
namespace Catalog.API.Exceptions
{   
    public class productNotFoundException: Exception
    {
        public productNotFoundException() : base("product not found!")
        {
        }
    }
}