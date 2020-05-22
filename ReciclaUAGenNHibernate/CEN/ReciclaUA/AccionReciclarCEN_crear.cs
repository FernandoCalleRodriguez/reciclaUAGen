
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_AccionReciclar_crear) ENABLED START*/
using ReciclaUAGenNHibernate.CP.ReciclaUA;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class AccionReciclarCEN
{
public int Crear (int p_usuario, int p_contenedor, int p_item, int p_cantidad)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_AccionReciclar_crear_customized) ENABLED START*/

        AccionReciclarEN accionReciclarEN = null;

        int oid;

        //Initialized AccionReciclarEN
        accionReciclarEN = new AccionReciclarEN ();

        if (p_usuario != -1) {
                accionReciclarEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioWebEN ();
                accionReciclarEN.Usuario.Id = p_usuario;
        }


        if (p_contenedor != -1) {
                accionReciclarEN.Contenedor = new ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN ();
                accionReciclarEN.Contenedor.Id = p_contenedor;
        }


        if (p_item != -1) {
                accionReciclarEN.Item = new ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN ();
                accionReciclarEN.Item.Id = p_item;
        }

        accionReciclarEN.Cantidad = p_cantidad;
        accionReciclarEN.Fecha = DateTime.Now;

        //Call to AccionReciclarCAD

        oid = _IAccionReciclarCAD.Crear (accionReciclarEN);

        return oid;
        /*PROTECTED REGION END*/
}
}
}
