using Sprint1_2semestre.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprint1_2semestre.Interfaces
{
    public interface IEmpresaService
    {
        Task<Empresa> SaveEmpresaAsync(Empresa empresa);
        Task<IEnumerable<Empresa>> GetEmpresasAsync();
        Task<Empresa?> GetEmpresaByIdAsync(int id); 
        Task<bool> DeleteEmpresaAsync(int id);
        Task<bool> UpdateEmpresaAsync(Empresa empresa);
    }
}
