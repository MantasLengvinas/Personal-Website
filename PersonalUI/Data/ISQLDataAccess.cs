using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public interface ISQLDataAccess {
        string ConnectionString { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadOne<T, U>(string sql, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}