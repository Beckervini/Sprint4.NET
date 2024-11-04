using Sprint1_2semestre.Models;
using Sprint1_2semestre.Data;
using Sprint1_2semestre.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sprint1_2semestre.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly ApplicationDbContext _context;

        public EmpresaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> SaveEmpresaAsync(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task<IEnumerable<Empresa>> GetEmpresasAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa?> GetEmpresaByIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id) ?? null;
        }

        public async Task<bool> UpdateEmpresaAsync(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await EmpresaExists(empresa.Id))
                {
                    return false;
                }

                throw;
            }
        }

        public async Task<bool> DeleteEmpresaAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return false;
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> EmpresaExists(int id)
        {
            return await _context.Empresas.AnyAsync(e => e.Id == id);
        }
    }
}
