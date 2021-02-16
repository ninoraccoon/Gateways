using Aplication.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Contracts
{
    interface IPeripheralService
    {
        public int Create(Peripheral gateway);
        public int Update(int id, Peripheral gateway);
        public int Remove(int id);
        public ICollection<Peripheral> GetAll();
        public Peripheral Get(int id);
        public Peripheral GetAllByGateway(int id);
    }
}
