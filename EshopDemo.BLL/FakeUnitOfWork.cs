using EshopDemo.BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopDemo.BLL
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        public IRepository<Product> ProductRepository { get; }

        public void Commit()
        {
            
        }

        public FakeUnitOfWork()
        {
            ProductRepository = new FakeProductRepository();
        }
    }
}
