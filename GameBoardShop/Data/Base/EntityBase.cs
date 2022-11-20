namespace GameBoardShop.Data.Base
{
    public class EntityBase : IEntityBase
    {
        public Guid Id { get; init; }
        public required DateTime CreatedAt { get; init; }
        public DateTime? UpdatedAt { get; set; }
    }
}
