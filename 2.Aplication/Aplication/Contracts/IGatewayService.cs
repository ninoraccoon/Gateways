using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Contracts
{
    public interface IGatewayService
    {
        public Task<int> Create(Gateway gateway);
        public Task<int> Update(int id, Gateway gateway);
        public Task<int> Remove(int id);
        public Task<ICollection<Gateway>> GetAll();
        public Task<Gateway> Get(int id);
        public Task<int> AddPeripheral(int id, Peripheral gateway);
        public Task<int> RemovePeripheral(int id, int idPeripheral);
    }
}
