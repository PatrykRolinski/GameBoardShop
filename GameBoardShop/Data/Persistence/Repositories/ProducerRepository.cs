using GameBoardShop.Data.Contracts.Persistence;
using GameBoardShop.Models;
using Persistence;
using Persistence.Repositories;

namespace GameBoardShop.Data.Persistence.Repositories
{
    public class ProducerRepository : BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(GameBoardShopContext context) : base(context)
        {

        }
    }
}
