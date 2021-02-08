using PersonalUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalUI.Data {
    public interface IPagesData {
        Task<List<PageSectionModel>> GetSections();
    }
}