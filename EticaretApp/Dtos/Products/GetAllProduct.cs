using EticaretApp.Models;

namespace EticaretApp.Dtos.Products
{
    public class GetAllProduct
    {
            public int TotalProductCount { get; set; }
            public List<Product> Products { get; set; }   
    }
}
