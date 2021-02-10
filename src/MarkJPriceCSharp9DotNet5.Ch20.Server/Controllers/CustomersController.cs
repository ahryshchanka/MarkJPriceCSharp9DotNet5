using MarkJPriceCSharp9DotNet5.Ch20.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch20.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly Northwind _db;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(Northwind db, ILogger<CustomersController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> Get(CancellationToken cancellationToken)
            => await _db.Customers.ToListAsync(cancellationToken);

        [HttpGet("{id}")]
        public async Task<Customer> Get(string id, CancellationToken cancellationToken)
            => await _db.Customers.FirstOrDefaultAsync(x => x.CustomerId == id, cancellationToken);

        [HttpPost]
        public async Task<Customer> Post(Customer customer, CancellationToken cancellationToken)
        {
            await _db.Customers.AddAsync(customer, cancellationToken);
            return customer;
        }

        [HttpDelete("{id}")]
        public async Task<Customer> Put(Customer customer, CancellationToken cancellationToken)
        {
            _db.Entry(customer).State = EntityState.Modified;
            await _db.SaveChangesAsync(cancellationToken);
            return customer;
        }

        [HttpDelete("{id}")]
        public async Task Delete(string id, CancellationToken cancellationToken)
        {
            Console.WriteLine($"id == {id}");
            Customer customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
        }
    }
}