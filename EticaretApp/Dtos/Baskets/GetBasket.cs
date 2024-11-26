namespace EticaretApp.Dtos.Baskets
{
    public class GetBasket
    {
        public string BasketItemId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string ImagePath { get; set; }
    }
    
}
