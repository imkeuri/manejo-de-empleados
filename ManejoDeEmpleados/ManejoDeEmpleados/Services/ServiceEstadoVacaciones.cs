using ManejoDeEmpleados.Models;

namespace ManejoDeEmpleados.Services
{
    public class ServiceEstadoVacaciones
    {
        manejoempleadosContext db = new();

        public void AddVacacionesEstados(Vacacione empleadoSolicitud)
        {
            Vacacionesestado vacaciones = new Vacacionesestado();

            vacaciones.Estado = false;

            vacaciones.VacacionesId = empleadoSolicitud.Id;

            db.Vacacionesestados.Add(vacaciones);
            db.SaveChangesAsync();
        }
    }
}
