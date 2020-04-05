
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Duda_obtenerNumeroDeRespuestas) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class DudaCP : BasicCP
{
public int ObtenerNumeroDeRespuestas (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Duda_obtenerNumeroDeRespuestas) ENABLED START*/

        IDudaCAD dudaCAD = null;
        DudaCEN dudaCEN = null;

        int result = 0;


        try
        {
                SessionInitializeTransaction ();
                dudaCAD = new DudaCAD (session);
                dudaCEN = new  DudaCEN (dudaCAD);



                // Write here your custom transaction ...

                DudaEN duda = dudaCAD.ReadOIDDefault (p_oid);
                result = duda.Respuestas.Count;

                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }
        return result;


        /*PROTECTED REGION END*/
}
}
}
