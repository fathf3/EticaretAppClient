namespace EticaretApp.Models
{
    public class Order
    {
        public string id { get; set; }
        public DateTime createdDate { get; set; }
        public string orderCode { get; set; }
        public int totalPrice { get; set; }
        public string userName { get; set; }
        public bool completed { get; set; }
    }

    public class OrderRoot
    {
        public int totalOrderCount { get; set; }
        public List<Order> orders { get; set; }
    }
}
