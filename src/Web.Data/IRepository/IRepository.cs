using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Data.Paging;

namespace RedMan.Data.IRepository
{
    public interface IRepository<T>
    {
        #region 单模型操作
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool Add(T entity, bool IsCommit = true);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddAsync(T entity, bool IsCommit = true);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool Update(T entity, bool IsCommit = true);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> UpdateAsync(T entity, bool IsCommit = true);

        /// <summary>
        /// 添加或更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool AddOrUpdate(T entity, bool IsCommit = true);

        /// <summary>
        /// 添加或更新
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddOrUpdateAsync(T entity, bool IsCommit = true);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool Delete(T entity, bool IsCommit = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(T entity, bool IsCommit = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predicate, bool IsCommit = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(Expression<Func<T, bool>> predicate, bool IsCommit = true);
        #endregion

        #region 集合模型操作
        /// <summary>
        /// 添加列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool AddRange(IEnumerable<T> entities, bool IsCommit = true);

        /// <summary>
        /// 添加列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> AddRangeAsync(IEnumerable<T> entities, bool IsCommit = true);

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool UpdateRange(IEnumerable<T> entities, bool IsCommit = true);

        /// <summary>
        /// 更新列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities, bool IsCommit = true);

        /// <summary>
        /// 删除列表
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        bool DeleteRange(IEnumerable<T> entities, bool IsCommit = true);

        /// <summary>
        /// 删除列表
        /// </summary>
        /// <param name="entities">实体列表</param>
        /// <param name="IsCommit">是否提交</param>
        /// <returns></returns>
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities, bool IsCommit = true);
        #endregion

        #region 查找所有
        /// <summary>
        /// 延时查找所有
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        IQueryable<T> FindAllDelay(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 延时查找所有
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        Task<IQueryable<T>> FindAllDelayAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查找所有
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 查找所有
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 延时查找前N条的数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="amount">数量</param>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="order">排序键</param>
        /// <returns></returns>
        IQueryable<T> FindTopDelay<TOrderKey>(Int32 amount, Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey);

        /// <summary>
        /// 延时查找前N条数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="amount">数量</param>
        /// <param name="predicate">Labmda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <returns></returns>
        Task<IQueryable<T>> FindTopDelayAsync<TOrderKey>(Int32 amount, Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey);

        /// <summary>
        /// 查找前N条数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="amount">数量</param>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <returns></returns>
        IEnumerable<T> FindTop<TOrderKey>(Int32 amount, Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey);

        /// <summary>
        /// 查找前N条数据
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="amount">数量</param>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <returns></returns>
        Task<IEnumerable<T>> FindTopAsync<TOrderKey>(Int32 amount, Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey);
        #endregion

        #region 分页查找

        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        PagingModel<T> FindPaging(Expression<Func<T, bool>> predicate, PagingModel<T> pagingModel);

        /// <summary>
        /// 分页查找
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        Task<PagingModel<T>> FindPagingAsync(Expression<Func<T, bool>> predicate, PagingModel<T> pagingModel);

        /// <summary>
        /// 分页查找并排序
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        PagingModel<T> FindPagingOrderBy<TOrderKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey, PagingModel<T> pagingModel);

        /// <summary>
        /// 分页查找并排序
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        Task<PagingModel<T>> FindPagingOrderByAsync<TOrderKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey, PagingModel<T> pagingModel);

        /// <summary>
        /// 分页查找并排序
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        PagingModel<T> FindPagingOrderByDescending<TOrderKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey, PagingModel<T> pagingModel);

        /// <summary>
        /// 分页查找并排序
        /// </summary>
        /// <typeparam name="TOrderKey">排序键类型</typeparam>
        /// <param name="predicate">Lambda表达式</param>
        /// <param name="orderKey">排序键</param>
        /// <param name="pagingModel">分页模型</param>
        /// <returns></returns>
        Task<PagingModel<T>> FindPagingOrderByDescendingAsync<TOrderKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TOrderKey>> orderKey, PagingModel<T> pagingModel);

        #endregion

        #region 连接查询
        /// <summary>
        /// 内连接查询
        /// </summary>
        /// <typeparam name="TInner">要联接的序列类型</typeparam>
        /// <typeparam name="TKey">联接键的类型</typeparam>
        /// <typeparam name="TResult">返回值类型</typeparam>
        /// <param name="inner">要联接的序列</param>
        /// <param name="outerKeySelector">用于从第一个序列的每个元素提取联接键的函数</param>
        /// <param name="innerKeySelector">用于从第二个序列的每个元素提取联接键的函数</param>
        /// <param name="resultSelector">用于从两个匹配元素创建结果元素的函数</param>
        /// <returns></returns>
        IEnumerable<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner,Func<T,TKey> outerKeySelector,Func<TInner,TKey> innerKeySelector,Func<T,TInner,TResult> resultSelector);

        /// <summary>
        /// 内连接查询
        /// </summary>
        /// <typeparam name="TInner">要联接的序列类型</typeparam>
        /// <typeparam name="TKey">联接键的类型</typeparam>
        /// <typeparam name="TResult">返回值类型</typeparam>
        /// <param name="inner">要联接的序列</param>
        /// <param name="outerKeySelector">用于从第一个序列的每个元素提取联接键的函数</param>
        /// <param name="innerKeySelector">用于从第二个序列的每个元素提取联接键的函数</param>
        /// <param name="resultSelector">用于从两个匹配元素创建结果元素的函数</param>
        /// <returns></returns>
        Task<IEnumerable<TResult>> JoinAsync<TInner, TKey, TResult>(IEnumerable<TInner> inner,Func<T,TKey> outerkeySelector,Func<TInner,TKey> innerkeySelector,Func<T,TInner,TResult> resultSelector);
        #endregion

        #region SQL命令
        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="parameters">可选参数</param>
        /// <returns>受影响的行数</returns>
        int ExecuteSqlCommand(string commandText, params object[] parameters);

        /// <summary>
        /// 执行SQL命令
        /// </summary>
        /// <param name="commandText">SQL命令</param>
        /// <param name="parameters">可选参数</param>
        /// <returns>受影响的行数</returns>
        Task<int> ExecuteSqlCommandAsync(string commandText, params object[] parameters);

        #endregion

        #region 验证是否存在
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="predicate">Lambda表达式</param>
        /// <returns></returns>
        Task<bool> IsExistAsync(Expression<Func<T, bool>> predicate);
        #endregion

        #region 计数
        Int32 Count(Expression<Func<T, bool>> predicate);

        Task<Int32> CountAsync(Expression<Func<T, bool>> predicate);
        #endregion
    }
}
