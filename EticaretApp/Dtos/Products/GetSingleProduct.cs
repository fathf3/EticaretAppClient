using EticaretApp.Models;

namespace EticaretApp.Dtos.Products
{
    public class GetProduct
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public List<Images> Image { get; set; }
    }
  
    public class GetSingleProduct
    {
        public GetProduct Product { get; set; }
    }
}
