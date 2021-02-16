using EntityFrameworkCore;
using NUnit.Framework;
using Domain.Domain;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Data.Entity;

namespace GatewayTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            var a = new  GatewayContextFactory();
            //var context = new GatewayContextFactory().Create();
            //context.Gateways.Add(new Gateway() { ipv4 = "10.10.10.10", serial = "123456", Peripheral = new List<Peripheral>() { 
            //    new Peripheral(){ 
            //        status = true,
            //        creatioDate = DateTime.Now,
            //        vendor = "test",
            //        UID = 12121
            //    }
            //} });
            //await context.SaveChangesAsync();
        }

        [Test]
        public async Task Test2()
        {
            //var context = new GatewayContextFactory().Create();
            //var r = await context.Gateways.Include(a => a.Peripheral).ToListAsync();
            //Assert.IsNotNull(r[0].Peripheral);
        }
    }
}