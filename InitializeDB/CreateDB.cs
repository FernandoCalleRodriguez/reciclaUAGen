
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
using System.Globalization;
using Newtonsoft.Json.Linq;
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
                Random random = new Random ();

                /** TIPOS DE ACCION **/
                Console.WriteLine ("Tipos de acción...");

                TipoAccionCEN tipoAccionCEN = new TipoAccionCEN ();
                var idTipo1 = tipoAccionCEN.Crear (10, "Duda");
                var idTipo2 = tipoAccionCEN.Crear (5, "Respuesta");
                tipoAccionCEN.Crear (10, "Item");
                tipoAccionCEN.Crear (30, "Punto");
                tipoAccionCEN.Crear (10, "Material");

                /** USUARIOS **/
                Console.WriteLine ("Usuarios...");

                IList<int> ids_usuarios = new List<int>();
                UsuarioAdministradorCEN adminCEN = new UsuarioAdministradorCEN ();
                // var idAdminFer = adminCEN.Crear("Fernando", "de la Calle Rodríguez", "fdlc4@alu.ua.es", "fdlc4");
                // var idAdminAddel = adminCEN.Crear ("Addel Arnaldo", "Goya Jorge", "aagj2@alu.ua.es", "aagj2");
                var id_admin = adminCEN.Crear ("admin", "admin", "admin@ua.es", "admin");

                UsuarioWebCEN usuCEN = new UsuarioWebCEN ();
                // ids_usuarios.Add(usuCEN.Crear ("Angela Sofia", "Sbrizzi Quilotte", "assq1@alu.ua.es", "assq1"));
                // ids_usuarios.Add(usuCEN.Crear ("José Antonio", "Agulló García", "jaag14@alu.ua.es", "jaag14"));
                // ids_usuarios.Add(usuCEN.Crear ("mohamed", "walid Nebili", "mwn1@alu.ua.es", "mwn1"));
                // ids_usuarios.Add(usuCEN.Crear("Fernando", "de la Calle Rodríguez", "fdelacallerodriguez@gmail.com", "fdlc4"));
                ids_usuarios.Add (usuCEN.Crear ("usu1", "usu1", "usu1@ua.es", "usu1"));
                ids_usuarios.Add (usuCEN.Crear ("usu2", "usu2", "usu2@ua.es", "usu2"));

                /** NOTAS INFORMATIVAS **/
                Console.WriteLine ("Notas informativas...");

                var lorem = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque dui diam, tempus ac velit placerat, venenatis volutpat velit. Nam eget turpis nisi. Curabitur lectus arcu, vestibulum vitae interdum a, feugiat non neque. Sed velit ligula, tincidunt nec fringilla at, interdum eu nunc. Proin quis viverra nibh. Ut nec risus sem. Aenean enim libero, varius sit amet sem at, luctus semper dui. Donec feugiat ultricies quam, nec consequat dolor rutrum non. Ut sed massa nec nisi tincidunt dapibus id nec justo. Nunc vel enim id felis lacinia faucibus. Praesent molestie, nulla eleifend accumsan rhoncus, orci sem posuere mauris, id sollicitudin arcu eros eu leo. In quis lorem nec erat ornare suscipit in a felis. Cras porttitor lacus pretium, varius arcu at, sollicitudin erat. Nam aliquet accumsan metus et tincidunt. Nam et laoreet lectus, ut scelerisque elit. Phasellus vel enim ut dolor iaculis suscipit.";
                NotaInformativaCEN notaCEN = new NotaInformativaCEN ();

                for (int i = 0; i < 10; i++) {
                        var id_nota = notaCEN.Crear (id_admin, "Nota informativa " + (i + 1), lorem);
                }

                /* DUDA */
                Console.WriteLine ("Duda...");

                DudaCEN duda = new DudaCEN ();
                Tuple<TemaEnum, string>[] temas = new Tuple<TemaEnum, string> [3];
                temas [0] = new Tuple<TemaEnum, string>(TemaEnum.anecdota, "Anécdota");
                temas [1] = new Tuple<TemaEnum, string>(TemaEnum.cuestion, "Cuestión");
                temas [2] = new Tuple<TemaEnum, string>(TemaEnum.consejo, "Consejo");

                RespuestaCEN respuesta = new RespuestaCEN ();

                foreach (var tema in temas) {
                        Console.WriteLine ("  " + tema.Item2 + "...");
                        for (int i = 0; i < 5; i++) {
                                var id_duda = duda.Crear (tema.Item2 + " " + (i + 1), lorem, ids_usuarios [random.Next (0, ids_usuarios.Count)], tema.Item1);
                                for (int j = 0; j < 5; j++) {
                                        respuesta.Crear (lorem.Substring (random.Next (0, lorem.Length / 2)), id_duda, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                                }
                        }
                }

                /* MATERIAL */
                Console.WriteLine ("Materiales...");

                MaterialCEN materialCEN = new MaterialCEN ();

                int id_vidrio = materialCEN.Crear ("Vidrio", TipoContenedorEnum.cristal, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                int id_alimento = materialCEN.Crear ("Alimento", TipoContenedorEnum.organico, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                int id_carton = materialCEN.Crear ("Cartón", TipoContenedorEnum.papel, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                int id_plastico = materialCEN.Crear ("Plástico", TipoContenedorEnum.plastico, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                int id_papel = materialCEN.Crear ("Papel", TipoContenedorEnum.papel, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                int id_cristal = materialCEN.Crear ("Cristal", TipoContenedorEnum.cristal, ids_usuarios [random.Next (0, ids_usuarios.Count)]);

                IList<int> ids_materiales = new List<int> {
                        id_vidrio,
                        id_alimento,
                        id_carton,
                        id_plastico,
                        id_papel,
                        id_cristal
                };

                foreach (int id in ids_materiales) {
                        materialCEN.ValidarMaterial (id);
                }

                materialCEN.Crear ("Espejo", TipoContenedorEnum.cristal, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                materialCEN.Crear ("Papel aluminio", TipoContenedorEnum.plastico, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                materialCEN.Crear ("Excremento", TipoContenedorEnum.organico, ids_usuarios [random.Next (0, ids_usuarios.Count)]);
                materialCEN.Crear ("Cartulina", TipoContenedorEnum.papel, ids_usuarios [random.Next (0, ids_usuarios.Count)]);

                /* ITEMS */
                Console.WriteLine ("Ítems...");

                ItemCEN itemCEN = new ItemCEN ();
                int id_item_1 = itemCEN.Crear ("Botella", "Botella de agua de plastico", "https://folder.es/41611-large_default/caja-de-35-botellas-de-agua-nestle-aquarel-033l.jpg", ids_usuarios [random.Next (0, ids_usuarios.Count)], id_plastico);
                int id_item_2 = itemCEN.Crear ("Macarrones", "Restos de macarrones", "https://www.rebanando.com/uploads/media/maxresdefault-jpg-19.jpeg?1449350333", ids_usuarios [random.Next (0, ids_usuarios.Count)], id_alimento);
                int id_item_3 = itemCEN.Crear ("Caja", "Caja de cartón de televisión", "https://www.farodeoriente.com/wp-content/uploads/2020/04/TV-samsung-caja-740x416.jpg", ids_usuarios [random.Next (0, ids_usuarios.Count)], id_carton);
                int id_item_4 = itemCEN.Crear ("Botellín", "Botellín de cristal de cerveza", "https://cervezafresca.com/wp-content/uploads/2011/04/cruzcampo.jpg", ids_usuarios [random.Next (0, ids_usuarios.Count)], id_vidrio);
                // Console.WriteLine("Creados los items: " + id_item_1 + ", " + id_item_2 + ", " + id_item_3 + ", " + id_item_4 + ", ");

                IList<int> ids_items = new List<int> { id_item_1, id_item_2, id_item_3, id_item_4 };

                foreach (int id in ids_items) {
                        itemCEN.ValidarItem (id, random.Next (5, 20));
                }

                /* NIVELES */
                Console.WriteLine ("Niveles...");

                NivelCEN nivelCEN = new NivelCEN ();

                int id_nivel_1 = nivelCEN.Crear (1, 5);
                int id_nivel_2 = nivelCEN.Crear (2, 10);
                // Console.WriteLine("Creados los niveles: " + id_nivel_1 + ", " + id_nivel_2);

                IList<int> ItemsNivel1 = new List<int>();
                ItemsNivel1.Add (id_item_1);
                ItemsNivel1.Add (id_item_2);
                nivelCEN.AsignarItems (id_nivel_1, ItemsNivel1);

                IList<int> ItemsNivel2 = new List<int>();
                ItemsNivel2.Add (id_item_3);
                ItemsNivel2.Add (id_item_4);
                nivelCEN.AsignarItems (id_nivel_2, ItemsNivel2);

                /* ZONAS Y PUNTOS */
                Console.WriteLine ("Zonas y puntos...");

                ContenedorCEN contenedorCEN = new ContenedorCEN ();
                TipoContenedorEnum[] contenedores = new TipoContenedorEnum [4];
                contenedores [0] = TipoContenedorEnum.cristal;
                contenedores [1] = TipoContenedorEnum.organico;
                contenedores [2] = TipoContenedorEnum.papel;
                contenedores [3] = TipoContenedorEnum.plastico;

                EdificioCEN edificioCEN = new EdificioCEN ();
                PlantaCEN plantaCEN = new PlantaCEN ();
                EstanciaCEN estanciaCEN = new EstanciaCEN ();
                PuntoReciclajeCEN puntoCEN = new PuntoReciclajeCEN ();

                /* SIGUA */
                string path = @"..\..\resources\sigua_eps.json";
                StreamReader sr = File.OpenText (path);
                //Console.WriteLine(sr.ReadToEnd().Trim());
                JArray aEdificios = JArray.Parse (sr.ReadToEnd ().Trim ());

                foreach (var itemEdificio in aEdificios.Children ()) {
                        var edificioProperties = itemEdificio.Children<JProperty>();

                        var id = edificioProperties.FirstOrDefault (x => x.Name == "id");
                        var nombre = edificioProperties.FirstOrDefault (x => x.Name == "nombre");
                        var plantas = edificioProperties.FirstOrDefault (x => x.Name == "plantas");

                        Console.WriteLine ("Edificio: " + nombre + "...");

                        var id_edificio = Int32.Parse (id.Value.ToString ());
                        id_edificio = edificioCEN.Crear (nombre.Value.ToString (), id_edificio);

                        foreach (var planta in plantas.Children ().Children ()) {
                                PlantaEnum plantaE;
                                JProperty plantaProperties = (JProperty)planta;

                                if (plantaProperties.Name == "P1") {
                                        plantaE = PlantaEnum.P1;
                                }
                                else if (plantaProperties.Name == "P2") {
                                        plantaE = PlantaEnum.P2;
                                }
                                else if (plantaProperties.Name == "P3") {
                                        plantaE = PlantaEnum.P3;
                                }
                                else if (plantaProperties.Name == "P4") {
                                        plantaE = PlantaEnum.P4;
                                }
                                else if (plantaProperties.Name == "PS") {
                                        plantaE = PlantaEnum.PS;
                                }
                                else{
                                        plantaE = PlantaEnum.PB;
                                }

                                var id_planta = plantaCEN.Crear (plantaE, id_edificio);

                                foreach (var itemEstancia in planta.Children ().Children ()) {
                                        var estanciaProperties = itemEstancia.Children<JProperty>();

                                        var estancia_codigo = estanciaProperties.FirstOrDefault (x => x.Name == "codigo");
                                        var estancia_lon = estanciaProperties.FirstOrDefault (x => x.Name == "longitud");
                                        var estancia_lat = estanciaProperties.FirstOrDefault (x => x.Name == "latitud");
                                        var estancia_nom = estanciaProperties.FirstOrDefault (x => x.Name == "nombre");
                                        var estancia_act = estanciaProperties.FirstOrDefault (x => x.Name == "actividad");

                                        if (estancia_act.Value.ToString () == "Aseos" || estancia_act.Value.ToString () == "Vestuarios" || estancia_act.Value.ToString () == "Pasillos" || estancia_act.Value.ToString () == "Aseo femenino" || estancia_act.Value.ToString () == "Aseo masculino" || estancia_act.Value.ToString () == "Jardines")

                                                if (estanciaCEN.BuscarPorId (estancia_codigo.Value.ToString ()) == null) {
                                                        double latitud, longitud;
                                                        latitud = double.Parse (estancia_lat.Value.ToString ().Replace (',', '.'), CultureInfo.InvariantCulture);
                                                        longitud = double.Parse (estancia_lon.Value.ToString ().Replace (',', '.'), CultureInfo.InvariantCulture);

                                                        var id_estancia = estanciaCEN.Crear (estancia_codigo.Value.ToString (), estancia_act.Value.ToString (), latitud, longitud, estancia_nom.Value.ToString (), id_edificio, id_planta);
                                                        var id_punto = puntoCEN.Crear (latitud, longitud, ids_usuarios [random.Next (0, ids_usuarios.Count)], id_estancia);
                                                        puntoCEN.ValidarPunto (id_punto);

                                                        foreach (TipoContenedorEnum c in contenedores) {
                                                                if (random.Next (0, 100) > 50) {
                                                                        contenedorCEN.Crear (c, id_punto);
                                                                }
                                                        }
                                                }
                                }
                        }
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
