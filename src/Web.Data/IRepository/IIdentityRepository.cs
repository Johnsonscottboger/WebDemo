using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Web.Data.IRepository
{
    public interface IIdentityRepository<T>
    {
        bool AddUser(T user, bool IsCommit = true);

        Task<bool> AddUserAsync(T user, bool IsCommit = true);

        T GetUser(Expression<Func<T, bool>> predicate);

        Task<T> GetUserAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<Object>> GetUserRolesAsync(string username);

        bool CheckEamil(Expression<Func<T, bool>> predicate);

        Task<bool> CheckEmailAsync(Expression<Func<T, bool>> predicate);
    }
}
