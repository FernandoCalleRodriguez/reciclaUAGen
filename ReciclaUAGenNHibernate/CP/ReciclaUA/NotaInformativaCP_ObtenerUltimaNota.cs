
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_NotaInformativa_obtenerUltimaNota) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class NotaInformativaCP : BasicCP
{
public ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN ObtenerUltimaNota ()
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_NotaInformativa_obtenerUltimaNota) ENABLED START*/

        INotaInformativaCAD notaInformativaCAD = null;
        NotaInformativaCEN notaInformativaCEN = null;

        IList<NotaInformativaEN> notas = notaInformativaCAD.BuscarTodos (0, -1);
        NotaInformativaEN resultNota = notas [1];

        for (int i = 1; i < notas.Count; i++) {
                if (resultNota.Fecha <= notas [i].Fecha) {
                        resultNota = notas [i];
                }
        }


        try
        {
                SessionInitializeTransaction ();
                notaInformativaCAD = new NotaInformativaCAD (session);
                notaInformativaCEN = new NotaInformativaCEN (notaInformativaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method ObtenerUltimaNota() not yet implemented.");



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
        return resultNota;


        /*PROTECTED REGION END*/
}
}
}
