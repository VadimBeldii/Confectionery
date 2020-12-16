namespace Confectionery.DAL.EF.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }
    }
}
