using EshopDemo.BLL.Repositories;

namespace EshopDemo.BLL
{

    /// <summary>
    /// Unit of work
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Product repository - Crud funcions
        /// </summary>
        IRepository<Product> ProductRepository { get; }

        /// <summary>
        /// Save all changes to database
        /// </summary>
        void Commit();
    }
}