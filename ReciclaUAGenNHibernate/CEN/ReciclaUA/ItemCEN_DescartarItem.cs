
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Item_descartarItem) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class ItemCEN
{
public void DescartarItem (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Item_descartarItem) ENABLED START*/

        // Write here your custom code...

        ItemCAD cad = new ItemCAD ();
        ItemEN item = cad.BuscarPorId (p_oid);


        if (item.EsValido != Enumerated.ReciclaUA.EstadoEnum.enProceso) {
                throw new ModelException ("No se puede descartar un item que no esta en proceso de validacion");
        }

        item.EsValido = Enumerated.ReciclaUA.EstadoEnum.descartado;

        cad.Modificar (item);

        //throw new NotImplementedException ("Method DescartarItem() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
