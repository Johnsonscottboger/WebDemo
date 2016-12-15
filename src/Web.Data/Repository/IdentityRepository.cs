using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Data.IRepository;
using System.Collections.Generic;
using Web.Data.Context;

namespace Web.Data.Repository
{
    public class IdentityRepository<T> : IIdentityRepository<T> where T:class
    {
        private readonly MyContext context;
        private readonly DbSet<T> dbSet;
        public IdentityRepository(MyContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        public bool AddUser(T user, bool IsCommit = true)
        {
            dbSet.Add(user);
            if (IsCommit)
                return context.SaveChanges() > 0;
            else
                return false;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        public async Task<bool> AddUserAsync(T user, bool IsCommit = true)
        {
            await dbSet.AddAsync(user);
            if (IsCommit)
                return await context.SaveChangesAsync() > 0;
            else
                return false;
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public bool CheckEamil(Expression<Func<T,bool>> predicate)
        {
            return dbSet.Any(predicate);
        }

        /// <summary>
        /// 检查邮箱是否存在
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public async Task<bool> CheckEmailAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.AnyAsync(predicate);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public T GetUser(Expression<Func<T, bool>> predicate)
        {
            return dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        public async Task<T> GetUserAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// 根据用户名获取角色
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public Task<IEnumerable<Object>> GetUserRolesAsync(String username) 
        {
            return null; 
        }
    }
}
