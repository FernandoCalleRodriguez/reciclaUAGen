
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Item_crearItem) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class ItemCP : BasicCP
{
public int CrearItem ()
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Item_crearItem) ENABLED START*/

        IItemCAD itemCAD = null;
        ItemCEN itemCEN = null;

        int result = -1;


        try
        {
                SessionInitializeTransaction ();
                itemCAD = new ItemCAD (session);
                itemCEN = new  ItemCEN (itemCAD);



                // Write here your custom transaction ...

                throw new NotImplementedException ("Method CrearItem() not yet implemented.");



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
