using System.ComponentModel.DataAnnotations;

namespace GameBoardShop.ViewModels.ProducerModels
{
    public class ProducerVM
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageURL { get; set; }
        public required DateTime CreatedAt { get; set; }
    }
}
