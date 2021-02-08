using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalUI.Models;

namespace PersonalUI.Data {
    public class ProjectsData : IProjectsData {

        private readonly ISQLDataAccess _db;

        public ProjectsData(ISQLDataAccess db) {
            _db = db;
        }

        public Task<List<ProjectModel>> GetProjects() {
            string sql = "select Title, Description, Stack from dbo.Projects";

            return _db.LoadData<ProjectModel, dynamic>(sql, new { });
        }
    }
}
