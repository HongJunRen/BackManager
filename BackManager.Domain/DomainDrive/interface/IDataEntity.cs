using BackManager.Domain.DomainDrive;
using System.Threading.Tasks;

namespace BackManager.Domain
{
    /// <summary>
    /// 表单基本操作接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataEntity<T> where T : class
    {
        ApiResult<long?> Insert(T model);

        ApiResult<long> Delete(long id);

        ApiResult<long> Update(T model);

        ApiResult<T> GetModel(long id);


        ApiResult<PageResult<T>> GridInfo<Par>(QueryParameter<Par> parameter)
            where Par : class;

    }

    /// <summary>
    /// 表单基本操作接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataEntityAsync<T> where T : class
    {
        
        Task<ApiResult<long>> InsertAsync(T model);

        Task<ApiResult<long>> DeleteAsync(long[] ids);

        Task<ApiResult<long>> UpdateAsync(T model);

        Task<ApiResult<T>> GetModelAsync(long id);

        Task<ApiResult<PageResult<T>>> GridInfoAsync<Par>(QueryParameter<Par> parameter)
            where Par : class;

    }
}
