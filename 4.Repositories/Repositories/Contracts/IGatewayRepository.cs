using Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IGatewayRepository
    {
        public Task<int> Create(Gateway gateway);
        public Task<int> Update(Gateway gateway);
        public Task<int> Remove(int id);
        public Task<ICollection<Gateway>> GetAll();
        public Task<Gateway> Get(int id);

    }
}
