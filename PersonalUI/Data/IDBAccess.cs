using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public interface IDBAccess {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task<T> LoadOne<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);
    }
}