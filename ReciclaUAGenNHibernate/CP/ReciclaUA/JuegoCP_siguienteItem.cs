
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

        ReciclaUAGenNHibernate.EN.ReciclaUA.JuegoEN result = null;


        try
        {
                SessionInitializeTransaction ();
                juegoCAD = new JuegoCAD (session);
                juegoCEN = new  JuegoCEN (juegoCAD);


                /*
                JuegoCAD Juegocad = new JuegoCAD();
                JuegoEN juegoen = Juegocad.BuscarPorId(p_oid);

                ItemCAD Itemcad = new ItemCAD();

                IList<ItemEN> itemsen = Itemcad.BuscarItemsPorNivel(juegoen.NivelActual.Id);

                if (itemsen[juegoen.ItemActual].Material.Contenedor == p_tipocontenedor)
                {
                    //Acierto
                    juegoen.Aciertos++;
                    double penalizacion = 1 / juegoen.IntentosItemActual;

                    juegoen.Puntuacion += Convert.ToInt32(juegoen.NivelActual.Puntuacion * penalizacion);

                    juegoen.IntentosItemActual = 1;


                    if (juegoen.ItemActual < itemsen.Count)
                    {
                        juegoen.ItemActual++;
                    }
                    else
                    {
                        juegoen.ItemActual = 0;
                    }

                    //Obtener siguente nivel

                    //juegoen.NivelActual++;

                    //Si No existe siguiente nivel

                    //juegoen.Finalizado = true;
                }
                else
                {
                    //Fallo
                    juegoen.Fallos++;
                    juegoen.IntentosItemActual++;
                }

                Juegocad.Modificar(juegoen);
                */



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
