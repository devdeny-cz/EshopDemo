using EshopDemo.BLL.Repositories;

namespace EshopDemo.BLL
{
    public interface IUnitOfWork
    {
        IRepository<Product> ProductRepository { get; }

        void Commit();
    }
}