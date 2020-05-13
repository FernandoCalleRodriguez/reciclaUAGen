
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
using ReciclaUAGenNHibernate.CP.ReciclaUA;
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
                TipoAccionCEN tipoAccionCEN = new TipoAccionCEN ();
                var idTipo1 = tipoAccionCEN.Crear (10, "Duda");
                var idTipo2 = tipoAccionCEN.Crear (5, "Respuesta");
                tipoAccionCEN.Crear (10, "Item");
                tipoAccionCEN.Crear (30, "Punto");
                tipoAccionCEN.Crear (10, "Material");

                // Insert the initilizations of entities using the CEN classes

                UsuarioAdministradorCEN admin = new UsuarioAdministradorCEN ();
                var id_admin = admin.Crear ("admin", "admin", "admin@ua.es", "admin");


                NotaInformativaCEN nota = new NotaInformativaCEN ();
                var id_nota = nota.Crear (id_admin, "Esto es una nota", "Esto es el cuerpo del titulo");

                UsuarioWebCEN usu1 = new UsuarioWebCEN ();
                var id_usu1 = usu1.Crear ("usu1", "usu1", "usu1@ua.es", "usu1");
                Console.WriteLine ("ID Usuario 1: " + id_usu1);

                var id_admin2 = admin.Crear ("admin", "2", "admin2@ua.es", "admin2");
                Console.WriteLine ("ID Usuario Admin 2: " + id_admin2);

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
                materialCEN.ValidarMaterial (id1);
                int itemId1 = itemCEN.Crear (item.Nombre, item.Descripcion, item.Imagen, id_usu1, id1);
                int itemId2 = itemCEN.Crear (item2.Nombre, item2.Descripcion, item2.Imagen, id_usu1, id1);

                nivelCEN.Crear (nivel.Numero, nivel.Puntuacion);


                var meterialDeTipo = materialCEN.BuscarPorTipoContenedor (TipoContenedorEnum.cristal);
                Console.WriteLine ("materiales de tipo " + TipoContenedorEnum.cristal + " :" + meterialDeTipo.Count);
                ItemEN tempItem = itemCEN.BuscarPorId (itemId1);
                Console.WriteLine ("item1 antes: " + tempItem.EsValido);
                itemCEN.ValidarItem (tempItem.Id, 10);
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

                AccionWebCEN accionWebCEN = new AccionWebCEN ();
                // AccionWebCP accionWebCP = new AccionWebCP ();
                // accionWebCEN.Crear (id_usu1, idTipo1);
                // accionWebCEN.Crear (id_usu1, idTipo2);

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
                puntoCEN.Crear (41.042171, -4.996339, id_usu1, id_estancia);
                puntoCEN.Crear (38.351020, -0.498823, id_usu1, id_estancia);
                puntoCEN.Crear (41.972265, -6.451450, id_usu1, id_estancia);
                puntoCEN.Crear (39.203261, -1.716253, id_usu1, id_estancia);
                puntoCEN.Crear (38.386952, -0.555871, id_usu1, id_estancia);

                puntoCEN.BuscarPuntosCercanos (38.340515, -0.515409, 1000);

                /*
                 * int id_punto1 = puntoCEN.Crear (123, 123, id_usu1, id_estancia);
                 * int id_punto2 = puntoCEN.Crear (444, 444, id_usu1, id_estancia);
                 *
                 * Console.WriteLine ("Puntos de reciclaje por validar");
                 * foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorValidar ()) {
                 *      Console.WriteLine ("[" + pEN.Id + "] Punto por validar (" + pEN.EsValido + ")");
                 * }
                 *
                 * PuntoReciclajeEN puntoEN = puntoCEN.BuscarPorId (id_punto1);
                 * Console.WriteLine ("Estado del punto " + puntoEN.Id + " al crear: " + puntoEN.EsValido);
                 * puntoCEN.ValidarPunto (id_punto1);
                 * puntoEN = puntoCEN.BuscarPorId (id_punto1);
                 * Console.WriteLine ("Estado del punto " + puntoEN.Id + " tras validar: " + puntoEN.EsValido);
                 *
                 * Console.WriteLine ("Puntos de reciclaje validados");
                 * foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosValidados ()) {
                 *      Console.WriteLine ("[" + pEN.Id + "] Punto validado (" + pEN.EsValido + ")");
                 * }
                 *
                 * Console.WriteLine ("Puntos de reciclaje segun edificio: " + id_edificio);
                 * foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorEdificio (id_edificio)) {
                 *      Console.WriteLine ("[" + pEN.Id + "]");
                 * }
                 *
                 * Console.WriteLine ("Puntos de reciclaje segun estancia: " + id_estancia);
                 * foreach (PuntoReciclajeEN pEN in puntoCEN.BuscarPuntosPorEstancia (id_estancia)) {
                 *      Console.WriteLine ("[" + pEN.Id + "]");
                 * }
                 *
                 */

                /*
                 * Console.WriteLine ("Puntuacion antes de la accion: " + usu1.BuscarPorId (id_usu1).Puntuacion);
                 * ContenedorCEN contenedorCEN = new ContenedorCEN ();
                 * var id_contenedor = contenedorCEN.Crear (TipoContenedorEnum.cristal, id_punto1);
                 * var item_validado = itemCEN.Crear ("Botella", "Plástico", "", id_usu1, id1);
                 * itemCEN.ValidarItem (item_validado, 20);
                 *
                 * AccionReciclarCEN reciclarCEN = new AccionReciclarCEN ();
                 * reciclarCEN.Crear (id_usu1, id_contenedor, item_validado, 2);
                 * Console.WriteLine ("Puntuacion despues de la accion: " + usu1.BuscarPorId (id_usu1).Puntuacion);
                 *
                 *
                 *
                 * /*
                 * ACESSO SIGUA
                 */
                /*
                 * string path = @"..\..\resources\sigua_backup.json";
                 * StreamReader sr = File.OpenText(path);
                 * //Console.WriteLine(sr.ReadToEnd().Trim());
                 * JArray aEdificios = JArray.Parse(sr.ReadToEnd().Trim());
                 *
                 * foreach (var itemEdificio in aEdificios.Children())
                 * {
                 *     var edificioProperties = itemEdificio.Children<JProperty>();
                 *
                 *     var id = edificioProperties.FirstOrDefault(x => x.Name == "id");
                 *     var nombre = edificioProperties.FirstOrDefault(x => x.Name == "nombre");
                 *     var plantas = edificioProperties.FirstOrDefault(x => x.Name == "plantas");
                 *
                 *     id_edificio = Int32.Parse(id.Value.ToString());
                 *     EdificioCEN e = new EdificioCEN();
                 *     id_edificio = e.Crear(nombre.Value.ToString(), id_edificio);
                 *
                 *
                 *     foreach (var planta in plantas.Children().Children())
                 *     {
                 *         PlantaEnum plantaE;
                 *         JProperty plantaProperties = (JProperty)planta;
                 *
                 *         if (plantaProperties.Name == "P1")
                 *         {
                 *             plantaE = PlantaEnum.P1;
                 *         }
                 *         else if (plantaProperties.Name == "P2")
                 *         {
                 *             plantaE = PlantaEnum.P2;
                 *         }
                 *         else if (plantaProperties.Name == "P3")
                 *         {
                 *             plantaE = PlantaEnum.P3;
                 *         }
                 *         else if (plantaProperties.Name == "P4")
                 *         {
                 *             plantaE = PlantaEnum.P4;
                 *         }
                 *         else if (plantaProperties.Name == "PS")
                 *         {
                 *             plantaE = PlantaEnum.PS;
                 *         }
                 *         else
                 *         {
                 *             plantaE = PlantaEnum.PB;
                 *         }
                 *
                 *         plantaCEN = new PlantaCEN();
                 *         id_planta = plantaCEN.Crear(plantaE, id_edificio);
                 *
                 *         foreach (var itemEstancia in planta.Children().Children())
                 *         {
                 *             var estanciaProperties = itemEstancia.Children<JProperty>();
                 *
                 *             var estancia_codigo = estanciaProperties.FirstOrDefault(x => x.Name == "codigo");
                 *             var estancia_lon = estanciaProperties.FirstOrDefault(x => x.Name == "longitud");
                 *             var estancia_lat = estanciaProperties.FirstOrDefault(x => x.Name == "latitud");
                 *             var estancia_nom = estanciaProperties.FirstOrDefault(x => x.Name == "nombre");
                 *             var estancia_act = estanciaProperties.FirstOrDefault(x => x.Name == "actividad");
                 *
                 *             //if(estancia_act.Value.ToString() == "Aseos" || estancia_act.Value.ToString() == "Vestuarios" || estancia_act.Value.ToString() == "Pasillos" || estancia_act.Value.ToString() == "Aseo femenino" || estancia_act.Value.ToString() == "Aseo masculino"|| estancia_act.Value.ToString() == "Jardines")
                 *
                 *             if (estanciaCEN.BuscarPorId(estancia_codigo.Value.ToString()) == null)
                 *             {
                 *                 estanciaCEN = new EstanciaCEN();
                 *                 estanciaCEN.Crear(estancia_codigo.Value.ToString(), estancia_act.Value.ToString(), double.Parse(estancia_lat.Value.ToString(), CultureInfo.InvariantCulture), double.Parse(estancia_lon.Value.ToString(), CultureInfo.InvariantCulture), estancia_nom.Value.ToString(), id_edificio, id_planta);
                 *
                 *             }
                 *
                 *
                 *         }
                 *     }
                 * }
                 */

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
