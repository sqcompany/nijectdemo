using System;
using System.Linq;
using System.Linq.Expressions;

namespace Entities.Abstract
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 获取所有的实体对象
        /// </summary>
        /// <returns></returns>
        IQueryable<T> All();

        /// <summary>
        /// 通过Lamda表达式过滤符合条件的实体对象
        /// </summary>
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 根据条件验证对象是否存在.
        /// </summary>
        bool Contains(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 获取实体总数
        /// </summary>
        int Count();

        /// <summary>
        /// 通过Lamda表达式查询符合条件的实体对象数量
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 通过键值查找并返回单个实体
        /// </summary>
        T Find(params object[] keys);

        /// <summary>
        /// 通过表达式查找复合条件的单个实体
        /// </summary>
        /// <param name="predicate"></param>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 创建实体对象
        /// </summary>
        T Create(T t);

        /// <summary>
        /// 删除实体对象
        /// </summary>
        void Delete(T t);

        /// <summary>
        /// 删除符合条件的多个实体对象
        /// </summary>
        int Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 更新实体并保存到数据库中.
        /// </summary>
        /// <param name="t">Specified the object to save.</param>
        T Update(T t);

        /// <summary>
        /// 清除所有的数据
        /// </summary>
        /// <returns>Total clear item count</returns>
        void Clear();

        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int Submit();
    }
}
