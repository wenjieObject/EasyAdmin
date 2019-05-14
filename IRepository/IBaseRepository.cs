using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository
{
    public interface IBaseRepository<T,TKey> : IDisposable where T : class
    {
        #region 同步方法

        /// <summary>
        /// 通过主键获取实体对象
        /// </summary>
        /// <param name="id">主键ID</param>
        /// <returns></returns>
        T Get(TKey id);

        /// <summary>
        /// 插入一条记录并返回主键值(自增类型返回主键值，否则返回null)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int? Insert(T entity);

        #endregion
    }
}
