namespace EticaretApp.Dtos.Orders
{
    public class GetOrder
    {
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string OrderCode { get; set; }
        public int TotalPrice { get; set; }
        public string UserName { get; set; }
        public bool Completed { get; set; }
    }

    public class OrderRoot
    {
        public int TotalOrderCount { get; set; }
        public List<GetOrder> Orders { get; set; }
    }
}
