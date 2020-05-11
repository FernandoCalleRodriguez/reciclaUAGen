
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Item_validarItem) ENABLED START*/
//  references to other libraries
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
    public partial class ItemCEN
    {
        public void ValidarItem(int p_oid, int p_puntuacion)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Item_validarItem) ENABLED START*/
            ItemCAD cad = new ItemCAD();
            ItemEN item = cad.BuscarPorId(p_oid);



            if (item.EsValido != Enumerated.ReciclaUA.EstadoEnum.enProceso)
            {
                throw new ModelException("No se puede validar un item que no est? en proceso de validaci?n");
            }

            item.EsValido = Enumerated.ReciclaUA.EstadoEnum.verificado;
            item.Puntuacion = p_puntuacion;

            cad.Modificar(item);

            ItemCP cp = new ItemCP();
            cp.CrearAccionItem(p_oid);

            //throw new NotImplementedException ("Method ValidarItem() not yet implemented.");

            /*PROTECTED REGION END*/
        }
    }
}
