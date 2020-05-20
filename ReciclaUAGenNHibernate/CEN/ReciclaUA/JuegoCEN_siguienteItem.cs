
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Juego_siguienteItem) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class JuegoCEN
{
public void SiguienteItem (int p_oid, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum p_tipocontenedor)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Juego_siguienteItem) ENABLED START*/


        JuegoCAD Juegocad = new JuegoCAD ();
        JuegoEN juegoen = Juegocad.BuscarPorId (p_oid);

        ItemCAD Itemcad = new ItemCAD ();

        IList<ItemEN> itemsen = Itemcad.BuscarItemsPorNivel (juegoen.NivelActual.Id);

        if (itemsen [juegoen.ItemActual].Material.Contenedor == p_tipocontenedor) {
                //Acierto
                juegoen.Aciertos++;
                double penalizacion = 1 / juegoen.IntentosItemActual;
                /*
                if (juegoen.IntentosItemActual == 1) {
                        penalizacion = 1;
                }
                else if (juegoen.IntentosItemActual == 2) {
                        penalizacion = 0.75;
                }
                else if (juegoen.IntentosItemActual == 3) {
                        penalizacion = 0.5;
                }
                else{
                        penalizacion = 0.25;
                }
                */
                juegoen.Puntuacion += Convert.ToInt32 (juegoen.NivelActual.Puntuacion * penalizacion);

                juegoen.IntentosItemActual = 1;


                if (juegoen.ItemActual < itemsen.Count) {
                        juegoen.ItemActual++;
                }
                else{
                        juegoen.ItemActual = 0;
                }

                //Obtener siguente nivel

                //juegoen.NivelActual++;

                //Si No existe siguiente nivel

                //juegoen.Finalizado = true;
        }
        else{
                //Fallo
                juegoen.Fallos++;
                juegoen.IntentosItemActual++;
        }

        Juegocad.Modificar (juegoen);

        /*PROTECTED REGION END*/
}
}
}
