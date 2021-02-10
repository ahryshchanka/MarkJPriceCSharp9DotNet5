using MarkJPriceCSharp9DotNet5.Ch18.Entities;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch18
{
    internal interface ICustomerRepository
    {
        Task<Customer?> CreateAsync(Customer c);
        Task<IEnumerable<Customer>> RetrieveAllAsync();
        Task<Customer?> RetrieveAsync(string id);
        Task<Customer?> UpdateAsync(string id, Customer c);
        Task<bool?> DeleteAsync(string id);
    }

    internal class CustomerRepository : ICustomerRepository
    {
        private readonly Northwind _db;
        private static ConcurrentDictionary<string, Customer> _customersCache = new();

        public CustomerRepository(Northwind db)
        {
            _db = db;
            if (_customersCache.IsEmpty)
            {
                var data = db.Customers.ToDictionary(c => c.CustomerId, c => c);
                _customersCache = new ConcurrentDictionary<string, Customer>(data);
            }
        }

        public async Task<Customer?> CreateAsync(Customer c)
        {
            c.CustomerId = c.CustomerId.ToUpperInvariant();
            var added = await _db.Customers.AddAsync(c);
            int affected = await _db.SaveChangesAsync();

            return affected != 0
                ? _customersCache.AddOrUpdate(c.CustomerId, c, UpdateCache)
                : null;
        }

        public async Task<IEnumerable<Customer>> RetrieveAllAsync()
            => await Task.FromResult(_customersCache.Values);

        public async Task<Customer?> RetrieveAsync(string id)
        {
            id = id.ToUpperInvariant();
            _customersCache.TryGetValue(id, out Customer? c);

            return await Task.FromResult(c);
        }

        public async Task<Customer?> UpdateAsync(string id, Customer c)
        {
            id = id.ToUpperInvariant();
            c.CustomerId = c.CustomerId.ToUpperInvariant();
            _db.Customers.Update(c);
            int affected = await _db.SaveChangesAsync();

            return affected == 1
                ? UpdateCache(id, c)
                : null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
            id = id.ToUpper();
            Customer? c = await _db.Customers.FindAsync(id);
            _db.Customers.Remove(c);
            int affected = await _db.SaveChangesAsync();

            return affected == 1
                ? (bool?)_customersCache.TryRemove(id, out c)
                : null;
        }

        private Customer? UpdateCache(string id, Customer c)
        {
            if (!_customersCache.TryGetValue(id, out Customer? old))
            {
                return null;
            }

            if (_customersCache.TryUpdate(id, c, old))
            {
                return c;
            }

            return null;
        }
    }
}