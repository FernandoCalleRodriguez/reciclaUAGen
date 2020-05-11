
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Material_crearAccionMaterial) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class MaterialCP : BasicCP
{
public void CrearAccionMaterial (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Material_crearAccionMaterial) ENABLED START*/

        IMaterialCAD materialCAD = null;
        MaterialCEN materialCEN = null;



        try
        {
                SessionInitializeTransaction ();
                materialCAD = new MaterialCAD (session);
                materialCEN = new  MaterialCEN (materialCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CrearAccionMaterial() not yet implemented.");



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
