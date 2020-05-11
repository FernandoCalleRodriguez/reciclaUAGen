
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Duda_crearDuda) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class DudaCP : BasicCP
{
public void CrearDuda (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Duda_crearDuda) ENABLED START*/

        IDudaCAD dudaCAD = null;
        DudaCEN dudaCEN = null;



        try
        {
                SessionInitializeTransaction ();
                dudaCAD = new DudaCAD (session);
                dudaCEN = new  DudaCEN (dudaCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CrearDuda() not yet implemented.");



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
