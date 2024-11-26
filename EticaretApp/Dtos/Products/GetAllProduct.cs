namespace EticaretApp.Dtos.Products
{
    public class GetAllProduct
    {
            public int TotalProductCount { get; set; }
            public List<GetProduct> Products { get; set; }   
    }
}
