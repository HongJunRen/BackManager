using BackManager.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BackManager.Infrastructure
{
    public abstract class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>, IAggregateRoot<TPrimaryKey>
    {
        public abstract IQueryable<TEntity> GetAll();
        public abstract IQueryable<TEntity> GetAll(string sql, params object[] parameters);
        public abstract IList<Dto> GetAlls<Dto>(string sql, params object[] parameters);
        public abstract IList<Dto> GetAlls<Dto>(string sql, CommandType commandType, params object[] parameters);
        public abstract int ExecuteScalar(string sql);
        public virtual List<TEntity> GetAllList()
        {
            return GetAll().ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync()
        {
            return Task.FromResult(GetAllList());
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).ToList();
        }

        public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(GetAllList(predicate));
        }

        public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
        {
            return queryMethod(GetAll());
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            var entity = FirstOrDefault(id);

            return entity;
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            var entity = await FirstOrDefaultAsync(id);

            return entity;
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return Task.FromResult(FirstOrDefault(id));
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(FirstOrDefault(predicate));
        }

        public abstract TEntity Insert(TEntity entity);

        public virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            return Task.FromResult(Insert(entity));
        }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
        {
            return Insert(entity).Id;
        }

        public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            return Task.FromResult(InsertAndGetId(entity));
        }

        public abstract TEntity Update(TEntity entity);

        public virtual Task<TEntity> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Update(entity));
        }

        public abstract void Delete(TEntity entity);

        public virtual Task DeleteAsync(TEntity entity)
        {
            Delete(entity);
            return Task.FromResult(0);
        }

        public abstract void Delete(TPrimaryKey id);

        public virtual Task DeleteAsync(TPrimaryKey id)
        {
            Delete(id);
            return Task.FromResult(0);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
        {
            foreach (var entity in GetAll().Where(predicate).ToList())
            {
                Delete(entity);
            }
        }

        public virtual Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
        {
            Delete(predicate);
            return Task.FromResult(0);
        }

        public virtual int Count()
        {
            return GetAll().Count();
        }

        public virtual Task<int> CountAsync()
        {
            return Task.FromResult(Count());
        }

        public virtual int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).Count();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(Count(predicate));
        }

        public virtual long LongCount()
        {
            return GetAll().LongCount();
        }

        public virtual Task<long> LongCountAsync()
        {
            return Task.FromResult(LongCount());
        }

        public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().Where(predicate).LongCount();
        }

        public virtual Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Task.FromResult(LongCount(predicate));
        }

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
            );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }

        public PageResult<TEntity> QueryPage<S>(Expression<Func<TEntity, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<TEntity, S>> funcOrderby, bool IsDesc = true)
        {
            var list = this.GetAll();
            if (funcWhere != null)
            {
                list = list.Where(funcWhere);
            }
            if (IsDesc)
            {
                list = list.OrderByDescending(funcOrderby);
              
            }
            else
            {
                 list = list.OrderBy(funcOrderby);
            }
            int Total = list.Count();
            int PageTotal = (Total % pageSize == 0) ? Total / pageSize : (Total / pageSize) + 1;

            PageResult<TEntity> result = new PageResult<TEntity>()
            {
                Rows = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageTotal = PageTotal,
                Total = list.Count()
            };
            return result;
        }

        public PageResult<Parg> QueryPage<Parg>(string sql, int pageSize, int pageIndex, string Orderby, bool IsDesc = true)
        {
            //一般情况下，客户端通过传递 pageNo（页码）、pageSize（每页条数）两个参数去分页查询数据库中的数据，在数据量较小（元组百 / 千级）时使用 MySQL自带的 limit 来解
            //select * from table limit (pageNo-1)*pageSize,pageSize;
            //在数据量较小的时候简单的使用 limit 进行数据分页在性能上面不会有明显的缓慢，但是数据量达到了 万级到百万级 sql语句的性能将会影响数据的返回。这时需要利用主键或者唯一索引进行数据分页；
            //select * from table where good_id > (pageNo-1)*pageSize order by good_id limit pageSize; 
            string getOrderBy()
            {
              
                if (IsDesc)
                {
                    return $"order by {Orderby} DESC";
                }
                else
                {
                    return $"order by {Orderby} ";
                }
            }
            string pageSql = $@"select * from 
                              (
                               {sql}
                              )t
                               {
                                 getOrderBy()
                                }
                               offset   {(pageIndex - 1) * pageSize}   rows fetch next  {pageSize} rows only ";
            IEnumerable<Parg> Rows = this.GetAlls<Parg>(pageSql, null);
            int Total = this.ExecuteScalar(sql);
            int PageTotal = (Total % pageSize == 0) ? Total / pageSize : (Total / pageSize) + 1;

            return new PageResult<Parg>()
            {
                Rows = Rows,
                Total = Total,
                PageTotal = PageTotal
            };


        }
    }
}