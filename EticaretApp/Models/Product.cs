namespace EticaretApp.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public List<Images> Images { get; set; }
    }
}
