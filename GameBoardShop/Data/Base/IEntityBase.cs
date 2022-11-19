namespace GameBoardShop.Data.Base
{
    public interface IEntityBase
    {
        public Guid GuidId { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; set;} 
    }
}
