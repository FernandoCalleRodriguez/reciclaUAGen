
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class PuntoReciclajeCEN
{
public int Crear (double p_latitud, double p_longitud, int p_usuario, string p_estancia)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_PuntoReciclaje_crear_customized) ENABLED START*/

        PuntoReciclajeEN puntoReciclajeEN = null;

        int oid;

        //Initialized PuntoReciclajeEN
        puntoReciclajeEN = new PuntoReciclajeEN ();
        puntoReciclajeEN.Latitud = p_latitud;

        puntoReciclajeEN.Longitud = p_longitud;

        puntoReciclajeEN.EsValido = Enumerated.ReciclaUA.EstadoEnum.enProceso;

        if (p_usuario != -1) {
                puntoReciclajeEN.Usuario = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                puntoReciclajeEN.Usuario.Id = p_usuario;
        }


        if (p_estancia != null) {
                puntoReciclajeEN.Estancia = new ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN ();
                puntoReciclajeEN.Estancia.Id = p_estancia;
        }

        //Call to PuntoReciclajeCAD

        oid = _IPuntoReciclajeCAD.Crear (puntoReciclajeEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
