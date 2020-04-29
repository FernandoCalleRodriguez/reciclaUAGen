using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsGherkin
{
    public class Inicializar
    {


        public void InitializeData()
        {
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

            try
            {

                UsuarioWebCEN usu1 = new UsuarioWebCEN();
                var id_usu1 = usu1.Crear("usu1", "usu1", "usu1@ua.es", "usu1");
                Console.WriteLine("ID Usuario 1: " + id_usu1);


                /*PROTECTED REGION END*/
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.InnerException);
                throw ex;
            }
        }
    }
}
