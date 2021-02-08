using PersonalUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public class UserData : IUserData {
        private readonly ISQLDataAccess _db;

        public UserData(ISQLDataAccess db) {
            _db = db;
        }

        public Task<UserModel> GetUser(UserModel user) {
            string sql = "select * from dbo.Users where Username='" + user.Username + "'";

            return _db.LoadOne<UserModel, dynamic>(sql, new { });
        }

    }
}
