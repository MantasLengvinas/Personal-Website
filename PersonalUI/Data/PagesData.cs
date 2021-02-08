using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalUI.Models;

namespace PersonalUI.Data {
    public class PagesData : IPagesData {

        private readonly ISQLDataAccess _db;

        public PagesData(ISQLDataAccess db) {
            _db = db;
        }

        public Task<List<PageSectionModel>> GetSections() {
            string sql = "select * from dbo.Pages";

            return _db.LoadData<PageSectionModel, dynamic>(sql, new { });
        }
    }
}
