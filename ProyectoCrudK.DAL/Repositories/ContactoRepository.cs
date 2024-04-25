
using ProyectoCrudK.DAL.DataContext;
using ProyectoCrudK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoCrudK.DAL.Repositories
{
    public class ContactoRepository : IGenericRepository<PersonaK>
    {
        private readonly ADBContext _dbcontext;

        public ContactoRepository(ADBContext context)
        {
            _dbcontext = context;
        }
        public async Task<bool> Actualizar(PersonaK modelo)
        {
            _dbcontext.PersonaKs.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            PersonaK modelo = _dbcontext.PersonaKs.First(k => k.Id == id);
            _dbcontext.PersonaKs.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(PersonaK modelo)
        {
           _dbcontext.PersonaKs.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<PersonaK> Obtener(int id)
        {
            return await _dbcontext.PersonaKs.FindAsync(id);

        }

        public async Task<IQueryable<PersonaK>> ObtenerTodos()
        {
            IQueryable<PersonaK> queryPersonaKSQL = _dbcontext.PersonaKs;
            return queryPersonaKSQL;
        }
    }
}
