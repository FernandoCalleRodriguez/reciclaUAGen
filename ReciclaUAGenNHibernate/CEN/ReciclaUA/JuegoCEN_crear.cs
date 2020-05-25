
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Juego_crear) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class JuegoCEN
{
public int Crear (int p_usuarios)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Juego_crear_customized) ENABLED START*/

        JuegoEN juegoEN = null;

        int oid;

        //Initialized JuegoEN
        juegoEN = new JuegoEN ();

        juegoEN.ItemActual = 0
        ;
        juegoEN.Aciertos = 0;
        juegoEN.Fallos = 0;
        juegoEN.Puntuacion = 0;
        juegoEN.IntentosItemActual = 1;
        juegoEN.Finalizado = false;
        juegoEN.NivelActual = 1;

        if (p_usuarios != -1) {
                juegoEN.Usuarios = new ReciclaUAGenNHibernate.EN.ReciclaUA.UsuarioEN ();
                juegoEN.Usuarios.Id = p_usuarios;
        }

        //Call to JuegoCAD

        oid = _IJuegoCAD.Crear (juegoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
