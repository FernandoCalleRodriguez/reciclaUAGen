using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using reciclaUAGenReciclaUARESTAzure.DTO;
using reciclaUAGenReciclaUARESTAzure.DTOA;
using reciclaUAGenReciclaUARESTAzure.CAD;
using reciclaUAGenReciclaUARESTAzure.Assemblers;
using reciclaUAGenReciclaUARESTAzure.AssemblersDTO;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;
using ReciclaUAGenNHibernate.CP.ReciclaUA;


/*PROTECTED REGION ID(usingreciclaUAGenReciclaUARESTAzure_ItemControllerAzure) ENABLED START*/
// Meter las referencias para las operaciones que invoquen a las CPs
using System.Threading.Tasks;
using System.Web;
using System.IO;
/*PROTECTED REGION END*/



namespace reciclaUAGenReciclaUARESTAzure.Controllers
{
    [RoutePrefix("~/api/Item")]
    public class ItemController : BasicController
    {
        // Voy a generar el readAll



        // ReadAll Generado a partir del NavigationalOperation
        [HttpGet]

        [Route("~/api/Item/BuscarTodos")]
        public HttpResponseMessage BuscarTodos()
        {
            // CAD, CEN, EN, returnValue
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;

            List<ItemEN> itemEN = null;
            List<ItemDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // Data
                // TODO: paginación

                itemEN = itemCEN.BuscarTodos(0, -1).ToList();

                // Convert return
                if (itemEN != null)
                {
                    returnValue = new List<ItemDTOA>();
                    foreach (ItemEN entry in itemEN)
                        returnValue.Add(ItemAssembler.Convert(entry, session));
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - Empty
            if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }










        [HttpGet]
        // [Route("{idItem}", Name="GetOIDItem")]

        [Route("~/api/Item/{idItem}")]

        public HttpResponseMessage BuscarPorId(int idItem)
        {
            // CAD, CEN, EN, returnValue
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;
            ItemEN itemEN = null;
            ItemDTOA returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // Data
                itemEN = itemCEN.BuscarPorId(idItem);

                // Convert return
                if (itemEN != null)
                {
                    returnValue = ItemAssembler.Convert(itemEN, session);
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 404 - Not found
            if (returnValue == null)
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }



        // No pasa el slEnables: buscarItemsPorUsuario

        [HttpGet]

        [Route("~/api/Item/BuscarItemsPorUsuario")]

        public HttpResponseMessage BuscarItemsPorUsuario(int id_usuario)
        {
            // CAD, CEN, EN, returnValue

            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;


            System.Collections.Generic.List<ItemEN> en;

            System.Collections.Generic.List<ItemDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();



                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // CEN return



                en = itemCEN.BuscarItemsPorUsuario(id_usuario).ToList();




                // Convert return
                if (en != null)
                {
                    returnValue = new System.Collections.Generic.List<ItemDTOA>();
                    foreach (ItemEN entry in en)
                        returnValue.Add(ItemAssembler.Convert(entry, session));
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - Empty
            if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }


        // No pasa el slEnables: buscarItemsPorNivel

        [HttpGet]

        [Route("~/api/Item/BuscarItemsPorNivel")]

        public HttpResponseMessage BuscarItemsPorNivel(int id_nivel)
        {
            // CAD, CEN, EN, returnValue

            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;


            System.Collections.Generic.List<ItemEN> en;

            System.Collections.Generic.List<ItemDTOA> returnValue = null;

            try
            {
                SessionInitializeWithoutTransaction();



                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // CEN return



                en = itemCEN.BuscarItemsPorNivel(id_nivel).ToList();




                // Convert return
                if (en != null)
                {
                    returnValue = new System.Collections.Generic.List<ItemDTOA>();
                    foreach (ItemEN entry in en)
                        returnValue.Add(ItemAssembler.Convert(entry, session));
                }
            }

            catch (Exception e)
            {
                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - Empty
            if (returnValue == null || returnValue.Count == 0)
                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            // Return 200 - OK
            else return this.Request.CreateResponse(HttpStatusCode.OK, returnValue);
        }





        [HttpPost]


        [Route("~/api/Item/Crear")]




        public HttpResponseMessage Crear([FromBody] ItemDTO dto)
        {
            // CAD, CEN, returnValue, returnOID
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;
            ItemDTOA returnValue = null;
            int returnOID = -1;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // Create
                returnOID = itemCEN.Crear(
                        //Atributo Primitivo: p_nombre
                        dto.Nombre,                                                                                                                                         //Atributo Primitivo: p_descripcion
                        dto.Descripcion,                                                                                                                                    //Atributo Primitivo: p_imagen
                        dto.Imagen,                                                                                                                                       //Atributo OID: p_usuario
                                                                                                                                                                          // attr.estaRelacionado: true
                        dto.Usuario_oid                 // association role

                        ,                                         //Atributo OID: p_material
                                                                  // attr.estaRelacionado: true
                        dto.Material_oid                 // association role

                        );
                SessionCommit();

                // Convert return
                returnValue = ItemAssembler.Convert(itemRESTCAD.ReadOIDDefault(returnOID), session);
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 201 - Created
            response = this.Request.CreateResponse(HttpStatusCode.Created, returnValue);

            // Location Header
            /*
             * Dictionary<string, object> routeValues = new Dictionary<string, object>();
             *
             * // TODO: y rolPaths
             * routeValues.Add("id", returnOID);
             *
             * uri = Url.Link("GetOIDItem", routeValues);
             * response.Headers.Location = new Uri(uri);
             */

            return response;
        }




        [HttpPut]



        [Route("~/api/Item/Modificar")]

        public HttpResponseMessage Modificar(int idItem, [FromBody] ItemDTO dto)
        {
            // CAD, CEN, returnValue
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;
            ItemDTOA returnValue = null;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                // Modify
                itemCEN.Modificar(idItem,
                        dto.Nombre
                        ,
                        dto.Descripcion
                        ,
                        dto.Imagen
                        ,
                        dto.EsValido
                        ,
                        dto.Puntuacion
                        );

                // Return modified object
                returnValue = ItemAssembler.Convert(itemRESTCAD.ReadOIDDefault(idItem), session);

                SessionCommit();
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 404 - Not found
            if (returnValue == null)
                return this.Request.CreateResponse(HttpStatusCode.NotFound);
            // Return 200 - OK
            else
            {
                response = this.Request.CreateResponse(HttpStatusCode.OK, returnValue);

                return response;
            }
        }





        [HttpDelete]


        [Route("~/api/Item/Borrar")]

        public HttpResponseMessage Borrar(int p_item_oid)
        {
            // CAD, CEN
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;

            try
            {
                SessionInitializeTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);

                itemCEN.Borrar(p_item_oid);
                SessionCommit();
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 204 - No Content
            return this.Request.CreateResponse(HttpStatusCode.NoContent);
        }









        /*PROTECTED REGION ID(reciclaUAGenReciclaUARESTAzure_ItemControllerAzure) ENABLED START*/
        // Meter las operaciones que invoquen a las CPs
        [HttpPost]
        [Route("~/api/Item/CrearCP")]
        public HttpResponseMessage CrearCP([FromBody] ItemDTO dto)
        {
            // CAD, CEN, returnValue, returnOID
            ItemRESTCAD itemRESTCAD = null;
            ItemCEN itemCEN = null;
            ItemDTOA returnValue = null;
            ItemCP itemCP = null;
            int returnOID = -1;

            // HTTP response
            HttpResponseMessage response = null;
            string uri = null;

            try
            {
                SessionInitializeTransaction();


                itemRESTCAD = new ItemRESTCAD(session);
                itemCEN = new ItemCEN(itemRESTCAD);
                itemCP = new ItemCP(session);

                // Create
                returnOID = itemCEN.Crear(dto.Nombre, dto.Descripcion, dto.Imagen, dto.Usuario_oid, dto.Material_oid);
                itemCP.CrearAccionItem(returnOID);

                SessionCommit();

                // Convert return
                returnValue = ItemAssembler.Convert(itemRESTCAD.ReadOIDDefault(returnOID), session);
            }

            catch (Exception e)
            {
                SessionRollBack();

                if (e.GetType() == typeof(HttpResponseException)) throw e;
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) && e.Message.Equals("El token es incorrecto")) throw new HttpResponseException(HttpStatusCode.Forbidden);
                else if (e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.ModelException) || e.GetType() == typeof(ReciclaUAGenNHibernate.Exceptions.DataLayerException)) throw new HttpResponseException(HttpStatusCode.BadRequest);
                else throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
            finally
            {
                SessionClose();
            }

            // Return 201 - Created
            response = this.Request.CreateResponse(HttpStatusCode.Created, returnValue);

            return response;
        }


        [HttpPost]
        [Route("~/api/Item/UploadImage")]
        public async Task<HttpResponseMessage> UploadImage(int p_oid)
        {
            ItemCEN itemCEN = new ItemCEN();
            ItemEN item = null;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            try
            {
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 5; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".jpeg", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {
                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {
                            string imageName = p_oid + Path.GetExtension(postedFile.FileName);

                            var filePath = HttpContext.Current.Server.MapPath("~/ItemsImages");
                            bool exists = System.IO.Directory.Exists(filePath);
                            if (!exists)
                                System.IO.Directory.CreateDirectory(filePath);

                            var final_path = filePath + "/" + imageName;
                            postedFile.SaveAs(final_path);
                            item = itemCEN.BuscarPorId(p_oid);
                            itemCEN.Modificar(p_oid, item.Nombre, item.Descripcion, final_path, item.EsValido, item.Puntuacion);
                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, message1); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }



        [HttpGet]
        [Route("~/api/Item/GetImage")]
        public Byte[] GetImage(int id, string imageName)
        {
            ItemCEN itemCEN = new ItemCEN();
            ItemEN item = itemCEN.BuscarPorId(id);
            // string tempName = id + imageName;

            if (!item.Imagen.StartsWith("http"))
            {
                var filePath = HttpContext.Current.Server.MapPath("~/ItemsImages");
                bool exists = System.IO.Directory.Exists(filePath);
                if (!exists) return null;
                exists = System.IO.File.Exists(item.Imagen);
                if (!exists) return null;
                Byte[] image = File.ReadAllBytes(item.Imagen);
                return image;
            }
            else
            {
                using (var webClient = new WebClient())
                {
                    try
                    {
                        Byte[] image = webClient.DownloadData(item.Imagen);
                        return image;
                    }
                    catch(Exception e)
                    {
                        return null;
                    }
                }
            }
        }

        [HttpPost]
        [Route("~/api/Item/RemoveImage")]
        public bool RemoveImage(int id, string imageName)
        {
            ItemCEN itemCEN = new ItemCEN();
            ItemEN item = itemCEN.BuscarPorId(id);
            var filePath = HttpContext.Current.Server.MapPath("~/ItemsImages");
            bool exists = System.IO.Directory.Exists(filePath);
            if (!exists) return false;

            if (!item.Imagen.StartsWith("http"))
            {
                exists = System.IO.File.Exists(item.Imagen);
                if (!exists) return false;
                File.Delete(item.Imagen);
                return true;
            }
            return false;
        }

        [HttpGet]
        [Route("~/api/Item/ItemCount")]
        public int NivelCount()
        {
            return new ItemCEN().BuscarTodos(0, -1).Count();
        }

        /*PROTECTED REGION END*/
    }
}
