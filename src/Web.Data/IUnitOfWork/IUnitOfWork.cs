using RedMan.Data.IRepository;
using System;
using System.Threading.Tasks;

namespace RedMan.Data.IUnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        /// <summary>
        /// 提交
        /// </summary>
        bool SaveChanges();

        /// <summary>
        /// 提交
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// 获取仓储实例
        /// </summary>
        /// <typeparam name="TRepo">泛型参数</typeparam>
        /// <returns>IRepository</returns>
        IRepository<TRepo> Repository<TRepo>() where TRepo : class;
    }
}
