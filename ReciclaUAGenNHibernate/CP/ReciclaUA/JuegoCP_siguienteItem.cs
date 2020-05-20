
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



/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Juego_siguienteItem) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
public partial class JuegoCP : BasicCP
{
public ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN SiguienteItem (int p_oid, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipocontenedor)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Juego_siguienteItem) ENABLED START*/

        IJuegoCAD juegoCAD = null;
        JuegoCEN juegoCEN = null;
        JuegoEN juegoEN = null;

        INivelCAD nivelCAD = null;
        NivelCEN nivelCEN = null;
        NivelEN nivelEN = null;


        try
        {
                SessionInitializeTransaction ();
                juegoCAD = new JuegoCAD (session);
                juegoCEN = new JuegoCEN (juegoCAD);
                juegoEN = juegoCAD.BuscarPorId (p_oid);

                nivelCAD = new NivelCAD (session);
                nivelCEN = new NivelCEN (nivelCAD);

                ItemCAD Itemcad = new ItemCAD ();

                IList<ItemEN> itemsen = Itemcad.BuscarItemsPorNivel (juegoEN.NivelActual);
                nivelEN = nivelCAD.BuscarPorId (juegoEN.NivelActual);


                if (itemsen [juegoEN.ItemActual].Material.Contenedor == p_tipocontenedor) {
                        //Acierto
                        juegoEN.Aciertos++;
                        double penalizacion = 1 / juegoEN.IntentosItemActual;

                        juegoEN.Puntuacion += nivelEN.Puntuacion * penalizacion;

                        juegoEN.IntentosItemActual = 1;


                        if (juegoEN.ItemActual <= itemsen.Count) {
                                juegoEN.ItemActual++;
                        }
                        else{
                                juegoEN.ItemActual = 0;
                                IList<NivelEN> niveles = nivelCAD.BuscarTodos (0, -1);

                                if (juegoEN.NivelActual <= niveles.Count) {
                                        juegoEN.NivelActual++;
                                }
                                else{
                                        juegoEN.Finalizado = true;
                                }
                        }
                }
                else{
                        //Fallo
                        juegoEN.Fallos++;
                        juegoEN.IntentosItemActual++;
                }

                juegoCAD.Modificar (juegoEN);




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
        return juegoEN;


        /*PROTECTED REGION END*/
}
}
}
