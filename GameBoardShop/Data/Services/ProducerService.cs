using GameBoardShop.Data.Contracts.IServices;
using GameBoardShop.Models;
using GameBoardShop.ViewModels;

namespace GameBoardShop.Data.Services
{
    public class ProducerService : IProducerService
    {
        public Producer MapToModel(NewProducerVM newProducerVM)
        {
            var producer = new Producer() 
            { 
                Name = newProducerVM.Name!,
                CreatedAt = DateTime.UtcNow, 
                Description=newProducerVM.Description,
                ImageURL=newProducerVM.Description
            };
            return producer;
        }
    }
}
