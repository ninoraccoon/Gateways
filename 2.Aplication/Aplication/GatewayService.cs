using Aplication.Contracts;
using Aplication.Dto;
using Repositories.Contracts;
using Repositories.EFRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplication
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository _repo;

        public GatewayService(IGatewayRepository repo) {
            _repo = repo;
        }

        public async Task<int> AddPeripheral(int id, Peripheral ph)
        {
            var gw = await _repo.Get(id);
            if (gw.Peripheral.Count == 10) {
                throw new Exception("Gateway is on full capacity(10)");
            }
            gw.Peripheral.Add(this.ConvetToDomain(ph));
            return await _repo.Update(gw);             
        }

        public async Task<int> Create(Gateway gateway)
        {
            return await _repo.Create(this.ConvertToDomain(gateway));
        }

        public async Task<Gateway> Get(int id)
        {
            return ConvertoModel(await _repo.Get(id));
        }

        public async Task<ICollection<Gateway>> GetAll()
        {
            return (await _repo.GetAll()).Select(i => ConvertoModel(i)).ToList();
        }

        public async Task<int> Remove(int id)
        {
            return await _repo.Remove(id);
        }

        public Task<int> RemovePeripheral(int id, int idPeripheral)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(int id, Gateway gateway){

            gateway.id = id;
            if (gateway.Peripheral != null)
                gateway.Peripheral.ForEach(i => {
                    i.GatewayId = id;
                });
            return await _repo.Update(ConvertToDomain(gateway));
        }

        private Domain.Domain.Peripheral ConvetToDomain(Peripheral ph) {
            return new Domain.Domain.Peripheral() { 
                creatioDate = ph.creatioDate,
                status = ph.status,
                UID = ph.UID,
                vendor = ph.vendor,
                id = ph.id, 
                GatewayId = ph.GatewayId
            };
        }

        private Domain.Domain.Gateway ConvertToDomain(Gateway gateway) {
            var r = new Domain.Domain.Gateway()
            {
                ipv4 = gateway.ipv4,
                serial = gateway.serial,
                id = gateway.id
            };
            if (gateway.Peripheral != null)
                r.Peripheral = gateway.Peripheral.Select(i => ConvetToDomain(i)).ToList();
            return r;
        }

        private Gateway ConvertoModel(Domain.Domain.Gateway gw) {
            return new Gateway()
            {
                id = gw.id,
                ipv4 = gw.ipv4,
                serial = gw.serial,
                Peripheral = gw.Peripheral!=null?gw.Peripheral.Select(i=> ConvertoModel(i)).ToList():null
            };
        }

        private Peripheral ConvertoModel(Domain.Domain.Peripheral ph)
        {
            return new Peripheral()
            {
                creatioDate = ph.creatioDate,
                GatewayId = ph.GatewayId,
                status = ph.status,
                UID = ph.UID,
                vendor = ph.vendor,
                id = ph.id
            };
        }
    }
}
