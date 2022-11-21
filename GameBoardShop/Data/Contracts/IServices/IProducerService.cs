using GameBoardShop.Models;
using GameBoardShop.ViewModels;

namespace GameBoardShop.Data.Contracts.IServices
{
    public interface IProducerService
    {
        public Producer MapToModel(NewProducerVM newProducerVM);
    }
}
