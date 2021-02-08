using PersonalUI.Models;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public interface IUserData {
        Task<UserModel> GetUser(UserModel user);
    }
}