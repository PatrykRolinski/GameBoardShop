namespace GameBoardShop.Models
{
    public class Price
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Guid ItemId { get; set; }
        public virtual required Item Item { get; set; }
    }
}
