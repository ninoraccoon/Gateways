using Domain.Domain;
using EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFRepositories
{
    public class GatewayRepository : IGatewayRepository
    {
        private readonly IDbContextFactory<GatewayContext> _factory;
        public GatewayRepository(IDbContextFactory<GatewayContext> context) {
            _factory = context;
        }

        public async Task<int> Create(Gateway gateway)
        {
            using (var _context = _factory.Create()) {
                var r1 = _context.Gateways.Add(gateway);
                var result = await _context.SaveChangesAsync();
                return r1.id;
            }
           
        }

        public async Task<Gateway> Get(int id)
        {
            using (var _context = _factory.Create())
            {
                return await _context.Gateways.Include(a=>a.Peripheral).SingleOrDefaultAsync(m => m.id == id);
            }
        }

        public async Task<ICollection<Gateway>> GetAll()
        {
            using (var _context = _factory.Create())
            {
                var r = await _context.Gateways.Include(a => a.Peripheral).ToListAsync();
                return r;
            }
        }

        public async Task<int> Remove(int id)
        {
            
            using (var _context = _factory.Create())
            {
                var entity = await _context.Gateways.Include(a => a.Peripheral).SingleOrDefaultAsync(m => m.id == id);
                _context.Gateways.Remove(entity);
                return await _context.SaveChangesAsync();
            }
                
        }

        public async Task<int> Update(Gateway gateway)
        {
            var trueChilds = new List<Peripheral>();
            gateway.Peripheral.ToList().ForEach(j => { trueChilds.Add(j); });
            using (var _context = _factory.Create())
            {
                var r1 = _context.Gateways.Attach(gateway);
                _context.Entry(gateway).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var existingParent = _context.Gateways
                    .Where(p => p.id == gateway.id)
                    .Include(p => p.Peripheral)
                    .SingleOrDefault();

                foreach (var existingChild in existingParent.Peripheral.ToList())
                {
                    if (!trueChilds.Any(c => c.id == existingChild.id))
                        _context.Peripherals.Remove(existingChild);
                }

                foreach (var childModel in gateway.Peripheral)
                {
                    var existingChild = existingParent.Peripheral
                        .Where(c => c.id == childModel.id && c.id != default(int))
                        .SingleOrDefault();

                    if (existingChild != null) { 
                        // Update child
                            _context.Peripherals.Attach(existingChild);
                            _context.Entry(existingChild).State = EntityState.Modified;
                    }                        
                    else
                    {
                        childModel.id = default(int);
                        childModel.GatewayId = gateway.id;
                        _context.Peripherals.Add(childModel);
                    }
                }
                await _context.SaveChangesAsync();

                return r1.id;
            }
        }
        
    }
}
