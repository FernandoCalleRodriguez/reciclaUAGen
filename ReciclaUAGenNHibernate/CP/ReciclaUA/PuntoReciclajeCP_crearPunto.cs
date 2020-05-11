
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_crearPunto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class PuntoReciclajeCP : BasicCP
{
public void CrearPunto (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_PuntoReciclaje_crearPunto) ENABLED START*/

        IPuntoReciclajeCAD puntoReciclajeCAD = null;
        PuntoReciclajeCEN puntoReciclajeCEN = null;



        try
        {
                SessionInitializeTransaction ();
                puntoReciclajeCAD = new PuntoReciclajeCAD (session);
                puntoReciclajeCEN = new  PuntoReciclajeCEN (puntoReciclajeCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CrearPunto() not yet implemented.");



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


        /*PROTECTED REGION END*/
}
}
}
