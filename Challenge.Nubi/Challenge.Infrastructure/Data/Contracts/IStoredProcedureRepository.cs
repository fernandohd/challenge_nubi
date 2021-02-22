using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Infrastructure.Data.Contracts
{
    public interface IStoredProcedureInvoker { }

    public interface IStoredProcedureRepository<TDbContext> where TDbContext : DbContext
    {
        Task<IList<TDataModel>> GetStoreProcedureAsync<TDataModel>(string name, IList<ParameterModel> nameValueParams) where TDataModel : DataModelBase;
        Task ExecuteStoredNonQueryAsync(string name, IList<ParameterModel> nameValueParams);
    }
}
