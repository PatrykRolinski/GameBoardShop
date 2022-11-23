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
                ImageURL=newProducerVM.ImageURL
            };
            return producer;
        }

        public ProducerVM MapToProducerVM(Producer producer)
        {
            var vmProducer = new ProducerVM()
            {
                CreatedAt = producer.CreatedAt,
                Description = producer.Description,
                Id = producer.Id,
                ImageURL = producer.ImageURL,
                Name = producer.Name
            };
            return vmProducer;
        }

        public List<ProducerVM> MapToProducerVM(IEnumerable<Producer> producers)
        {
            var producersVMList =new List<ProducerVM>();

            foreach (var producer in producers)
            {
                var vmProducer = new ProducerVM()
                {
                    CreatedAt = producer.CreatedAt,
                    Description = producer.Description,
                    Id = producer.Id,
                    ImageURL = producer.ImageURL,
                    Name = producer.Name
                };
                producersVMList.Add(vmProducer);
            }
            return producersVMList;
        }

    }
}
