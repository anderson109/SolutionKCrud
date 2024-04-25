using ProyectoCrudK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrudK.BLL.Service
{
    public interface IContactoService
    {
        Task<bool> Insertar(PersonaK modelo);
        Task<bool> Actualizar(PersonaK modelo);
        Task<bool> Eliminar(int id);
        Task<PersonaK> Obtener(int id);
        Task<IQueryable<PersonaK>> ObtenerTodos();
        Task<PersonaK> ObtenerPorNombre(string nombrePersonaK);

    }
}
