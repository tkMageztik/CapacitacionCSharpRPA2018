using ASPNETCoreWebApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCoreWebApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Alumno.Any())
            {
                return;
            }

            var alumnos = new Alumno[]
            {
                new Alumno{ Nombre = "Juan", Apellido="Ruiz de Castilla"}
            };

            foreach (Alumno a in alumnos)
            {
                context.Alumno.Add(a);
            }

            //var tipDocs = new TipoDocumentoViewModel[]
            //{
            //    new TipoDocumentoViewModel{ TipDoc = "DNI", DesDoc="DNI"},
            //    new TipoDocumentoViewModel{ TipDoc = "Pasaporte", DesDoc="Pasaporte"},
            //    new TipoDocumentoViewModel{ TipDoc="CE", DesDoc="Carné de extranjería"}
            //};
            //foreach (TipoDocumentoViewModel s in tipDocs)
            //{
            //    context.TipoDocumentoViewModel.Add(s);
            //}


            context.SaveChanges();
        }

    }

}
