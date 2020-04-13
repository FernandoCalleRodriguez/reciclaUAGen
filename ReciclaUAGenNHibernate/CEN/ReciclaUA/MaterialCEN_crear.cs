
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Material_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class MaterialCEN
{
public int Crear (string p_nombre, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_contenedor, int p_usuario)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Material_crear_customized) ENABLED START*/

        MaterialEN materialEN = null;

        int oid;

        //Initialized MaterialEN
        materialEN = new MaterialEN ();
        materialEN.Nombre = p_nombre;
        materialEN.EsValido = Enumerated.ReciclaUA.EstadoEnum.enProceso;
        materialEN.Contenedor = p_contenedor;


        if (p_usuario != -1) {
                materialEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                materialEN.Usuario.Id = p_usuario;
        }

        //Call to MaterialCAD

        oid = _IMaterialCAD.Crear (materialEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
