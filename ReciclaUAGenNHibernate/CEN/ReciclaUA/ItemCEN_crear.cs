
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Item_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class ItemCEN
{
public int Crear (string p_nombre, string p_descripcion, string p_imagen, int p_usuario, int p_material)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Item_crear_customized) ENABLED START*/

        ItemEN itemEN = null;

        int oid;

        //Initialized ItemEN
        itemEN = new ItemEN ();
        itemEN.Nombre = p_nombre;
        itemEN.EsValido = Enumerated.ReciclaUA.EstadoEnum.enProceso;
        itemEN.Descripcion = p_descripcion;

        itemEN.Imagen = p_imagen;


        if (p_usuario != -1) {
                itemEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                itemEN.Usuario.Id = p_usuario;
        }


        if (p_material != -1) {
                itemEN.Material = new ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN ();
                itemEN.Material.Id = p_material;
        }

        //Call to ItemCAD

        oid = _IItemCAD.Crear (itemEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
