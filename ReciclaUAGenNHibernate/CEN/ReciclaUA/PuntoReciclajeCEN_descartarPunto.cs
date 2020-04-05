
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_descartarPunto) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class PuntoReciclajeCEN
{
public void DescartarPunto (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_descartarPunto) ENABLED START*/

        // Write here your custom code...

        PuntoReciclajeCAD cad = new PuntoReciclajeCAD ();
        PuntoReciclajeEN en = cad.BuscarPorId (p_oid);

        if (en.EsValido != Enumerated.ReciclaUA.EstadoEnum.enProceso) {
                throw new ModelException ("No se puede descartar un punto de reciclaje que no est� en proceso de validaci�n");
        }

        en.EsValido = Enumerated.ReciclaUA.EstadoEnum.descartado;

        cad.Modificar (en);

        /*PROTECTED REGION END*/
}
}
}
