using GameBoardShop.Models;
using GameBoardShop.ViewModels.ProducerModels;

namespace GameBoardShop.Data.Contracts.IServices
{
    public interface IProducerService
    {
        public Producer MapToModel(NewProducerVM newProducerVM);
        public void UpdateModel(ProducerVM producerVM, Producer producer);
        public ProducerVM MapToProducerVM(Producer producer);
        public List<ProducerVM> MapToProducerVM(IEnumerable<Producer> producers);
    }
}
