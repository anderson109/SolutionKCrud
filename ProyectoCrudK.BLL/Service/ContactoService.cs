using ProyectoCrudK.DAL.Repositories;
using ProyectoCrudK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrudK.BLL.Service
{
    public class ContactoService : IContactoService
    {

        private readonly IGenericRepository<PersonaK> _contactRepo;

        public ContactoService(IGenericRepository<PersonaK> contactRepo)
        {
            _contactRepo = contactRepo;
        }
        public async Task<bool> Actualizar(PersonaK modelo)
        {
            return await _contactRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(PersonaK modelo)
        {
            return await _contactRepo.Insertar(modelo);
        }

        public async Task<PersonaK> Obtener(int id)
        {
            return await _contactRepo.Obtener(id);
        }

        public async Task<PersonaK> ObtenerPorNombre(string nombrePersonaK)
        {
            IQueryable<PersonaK> queryPersonaKSQL = await _contactRepo.ObtenerTodos();
            PersonaK personaK = queryPersonaKSQL.Where(k=>k.NombreK == nombrePersonaK).FirstOrDefault();
            return personaK;
        }

        public async Task<IQueryable<PersonaK>> ObtenerTodos()
        {
            return await _contactRepo.ObtenerTodos();
        }
    }
}
