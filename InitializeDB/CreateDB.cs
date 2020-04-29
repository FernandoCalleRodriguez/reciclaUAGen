
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using System.Net;
using System.IO;
using System.Linq;
using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;
//using ReciclaUAGenNHibernate.Enumerated.ReciclaUA;


/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local); database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

        try
        {
                // Insert the initilizations of entities using the CEN classes

                UsuarioAdministradorCEN admin = new UsuarioAdministradorCEN ();
                var id_admin = admin.Crear ("admin", "admin", "admin@ua.es", "admin");


                NotaInformativaCEN nota = new NotaInformativaCEN ();
                var id_nota = nota.Crear (id_admin, "Esto es una nota", "Esto es el cuerpo del titulo");

                UsuarioWebCEN usu1 = new UsuarioWebCEN ();
                var id_usu1 = usu1.Crear ("usu1", "usu1", "usu1@ua.es", "usu1");
                Console.WriteLine ("ID Usuario 1: " + id_usu1);

                var id_admin2 = admin.Crear("admin", "2", "admin2@ua.es", "admin2");
                Console.WriteLine("ID Usuario Admin 2: " + id_admin2);

                /*usu1.Borrar(id_usu1);
                 * Console.WriteLine( usu1.BuscarPorId(id_usu1).Borrado);*/

                /*
                 *  DUDA
                 */
                string[] temas = new string [2];
                temas [0] = "reciclaje";
                temas [1] = "vidrio";

                DudaCEN duda = new DudaCEN ();
                int id_duda = duda.Crear ("Duda1", "Esto es una duda", id_usu1, TemaEnum.anecdota);
                id_duda = duda.Crear ("Duda2", "Esto es una duda 2", id_usu1, TemaEnum.anecdota);
                id_duda = duda.Crear ("Duda3", "Esto es una duda 3", id_usu1, TemaEnum.consejo);

                duda.IndicarDudaUtil (id_duda);
                DudaEN dudaResultado = duda.BuscarPorId (id_duda);
                Console.WriteLine ("Utilidad de la duda:" + dudaResultado.Util);

                duda.IndicarDudaNoUtil (id_duda);
                dudaResultado = duda.BuscarPorId (id_duda);
                Console.WriteLine ("Utilidad de la duda:" + dudaResultado.Util);

                RespuestaCEN respuesta = new RespuestaCEN ();
                respuesta.Crear ("Esto es una respuesta", id_duda, id_usu1);
                respuesta.Crear ("Esto es una respuesta 2", id_duda, id_usu1);
                respuesta.Crear ("Esto es una respuesta 3", id_duda, id_usu1);
                int idr = respuesta.Crear ("Esto es una respuesta 4", id_duda, id_usu1);

                IList<RespuestaEN> respuestaResultados = respuesta.BuscarRespuestaPorDuda (id_duda);
                int id_respuesta = respuestaResultados.First<RespuestaEN>().Id;
                respuesta.ConfirmacionRespuestaCorrecta (id_respuesta);
                RespuestaEN respuestaResultado = new RespuestaEN ();
                respuestaResultado = respuesta.BuscarPorId (id_respuesta);
                Console.WriteLine ("�Es respuesta correcta?:" + respuestaResultado.EsCorrecta);


                //material,nivel,item

                MaterialCEN materialCEN = new MaterialCEN ();
                NivelCEN nivelCEN = new NivelCEN ();
                ItemCEN itemCEN = new ItemCEN ();

                MaterialEN material = new MaterialEN (){
                        Contenedor = TipoContenedorEnum.cristal,
                        Nombre = "Contenedor 1"
                };
                MaterialEN material2 = new MaterialEN (){
                        Contenedor = TipoContenedorEnum.cristal,
                        Nombre = "Contenedor 2"
                };
                ItemEN item = new ItemEN (){
                        Nombre = "item",
                        Descripcion = "description",
                        Imagen = "image file path",
                        EsValido = EstadoEnum.enProceso
                };
                ItemEN item2 = new ItemEN (){
                        Nombre = "item2",
                        Descripcion = "description2",
                        Imagen = "image file path2",
                        EsValido = EstadoEnum.enProceso
                };
                List<ItemEN> items = new List<ItemEN>();
                items.Add (item);
                material.Items = items;
                NivelEN nivel = new NivelEN (){
                        Item = items,
                        Numero = 1,
                        Puntuacion = 1
                };

                int id1 = materialCEN.Crear (material.Nombre, material.Contenedor, id_usu1);
                int id2 = materialCEN.Crear (material2.Nombre, material2.Contenedor, id_usu1);

                int itemId1 = itemCEN.Crear (item.Nombre, item.Descripcion, item.Imagen, id_usu1, id1);
                int itemId2 = itemCEN.Crear (item2.Nombre, item2.Descripcion, item2.Imagen, id_usu1, id1);

                nivelCEN.Crear (nivel.Numero, nivel.Puntuacion);


                var meterialDeTipo = materialCEN.BuscarPorTipoContenedor (TipoContenedorEnum.cristal);
                Console.WriteLine ("materiales de tipo " + TipoContenedorEnum.cristal + " :" + meterialDeTipo.Count);
                ItemEN tempItem = itemCEN.BuscarPorId (itemId1);
                Console.WriteLine ("item1 antes: " + tempItem.EsValido);
                itemCEN.ValidarItem (tempItem.Id);
                tempItem = itemCEN.BuscarPorId (itemId1);
                Console.WriteLine ("item1 despues de validar: " + tempItem.EsValido);

                itemCEN.DescartarItem (itemId2);
                tempItem = itemCEN.BuscarPorId (itemId2);
                Console.WriteLine ("item2 despues de descartar: " + tempItem.EsValido);

                var itemsPorValidar = itemCEN.BuscarItemsPorValidar ();
                Console.WriteLine ("el total de items por validar es :" + itemsPorValidar.Count);

                var itemsValidados = itemCEN.BuscarItemsValidados ();
                Console.WriteLine ("el total de items validados es :" + itemsValidados.Count);

                ///ADDEL
                TipoAccionCEN tipoAccionCEN = new TipoAccionCEN ();
                var idTipo = tipoAccionCEN.Crear (1, "tipo accion 1");
                AccionWebCEN accionWebCEN = new AccionWebCEN ();
                accionWebCEN.Crear (id_usu1, DateTime.Now, idTipo);
                var result = accionWebCEN.BuscarPorAutor (id_usu1);
                Console.WriteLine ("total de acciones del autor con id " + id_usu1 + " es :" + result.Count);

                result = accionWebCEN.BuscarPorAutor (55);
                Console.WriteLine ("total de acciones del autor con id 55" + result.Count);




                // PUNTOS RECICLAJE

                EdificioCEN edificioCEN = new EdificioCEN ();
                int id_edificio = edificioCEN.Crear ("Edificio 1", 500);

                PlantaCEN plantaCEN = new PlantaCEN ();
                int id_planta = plantaCEN.Crear (PlantaEnum.PB, id_edificio);

                EstanciaCEN estanciaCEN = new EstanciaCEN ();
                string id_estancia = estanciaCEN.Crear ("0500PB001", "Aula", 123.09999d, 2.3123313d, "Aula PB 001", id_edificio, id_planta);

                PuntoReciclajeCEN puntoCEN = new PuntoReciclajeCEN ();
                int id_punto1 = puntoCEN.Crear (123, 123, id_usu1, id_estancia);
                int id_punto2 = puntoCEN.Crear (444, 444, id_usu1, id_estancia);

                Console.WriteLine ("Puntos de reciclaje por validar");
                foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorValidar ()) {
                        Console.WriteLine ("[" + pEN.Id + "] Punto por validar (" + pEN.EsValido + ")");
                }

                PuntoReciclajeEN puntoEN = puntoCEN.BuscarPorId (id_punto1);
                Console.WriteLine ("Estado del punto " + puntoEN.Id + " al crear: " + puntoEN.EsValido);
                puntoCEN.ValidarPunto (id_punto1);
                puntoEN = puntoCEN.BuscarPorId (id_punto1);
                Console.WriteLine ("Estado del punto " + puntoEN.Id + " tras validar: " + puntoEN.EsValido);

                Console.WriteLine ("Puntos de reciclaje validados");
                foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosValidados ()) {
                        Console.WriteLine ("[" + pEN.Id + "] Punto validado (" + pEN.EsValido + ")");
                }

                Console.WriteLine ("Puntos de reciclaje segun edificio: " + id_edificio);
                foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorEdificio (id_edificio)) {
                        Console.WriteLine ("[" + pEN.Id + "]");
                }

                Console.WriteLine ("Puntos de reciclaje segun estancia: " + id_estancia);
                foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorEstancia (id_estancia)) {
                        Console.WriteLine ("[" + pEN.Id + "]");
                }

                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
