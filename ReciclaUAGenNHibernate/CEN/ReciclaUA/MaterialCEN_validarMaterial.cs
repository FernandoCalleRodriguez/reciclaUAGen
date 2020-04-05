
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Material_validarMaterial) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class MaterialCEN
{
public void ValidarMaterial (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Material_validarMaterial) ENABLED START*/

        // Write here your custom code...

        MaterialCAD cad = new MaterialCAD ();
        MaterialEN en = cad.BuscarPorId (p_oid);

        if (en.EsValido != Enumerated.ReciclaUA.EstadoEnum.enProceso) {
                throw new ModelException ("No se puede validar un material que no esta en proceso de validacion");
        }

        en.EsValido = Enumerated.ReciclaUA.EstadoEnum.verificado;

        cad.Modificar (en);
        /*PROTECTED REGION END*/
}
}
}
