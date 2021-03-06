using EshopDemo.BLL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo.BLL.Repositories
{

    /// <summary>
    /// Fake repository using FakeContext, getting mock objects
    /// </summary>
    internal class FakeProductRepository : IRepository<Product>
    {

        FakeContext _context;

        public FakeProductRepository()
        {
            _context = new FakeContext();
        }

        public Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
            return  Task.FromResult<Product>(entity);
        }

        public async Task<Product> AddAsync(Product entity)
        {
            _context.Products.Add(entity);
            return entity;
        }

        public  bool Delete(Product entity)
        {
            if (_context.Products.Contains(entity))
            {
                _context.Products.Remove(entity);
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            if (_context.Products.Contains(entity))
            {
                _context.Products.Remove(entity);
                return true;
            }

            return false;
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(product => product.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return _context.Products;
        }

        public async Task<Product> GetAsync(int id)
        {
            return _context.Products.FirstOrDefault(product => product.Id == id);
        }

        public bool Update(Product entity)
        {
            // we have existing item, so for fake, just return true.. Maybe we can find by id and replace, because the entity can be another reference
            return true;
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            // we have existing item, so for fake, just return true.. Maybe we can find by id and replace, because the entity can be another reference
            return true;
        }
    }
}