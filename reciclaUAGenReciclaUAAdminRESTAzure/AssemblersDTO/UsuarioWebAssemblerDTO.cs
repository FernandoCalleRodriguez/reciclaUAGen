using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class UsuarioWebAssemblerDTO {
public static IList<UsuarioWebEN> ConvertList (IList<UsuarioWebDTO> lista)
{
        IList<UsuarioWebEN> result = new List<UsuarioWebEN>();
        foreach (UsuarioWebDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static UsuarioWebEN Convert (UsuarioWebDTO dto)
{
        UsuarioWebEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new UsuarioWebEN ();




                        if (dto.Acciones != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IAccionCAD accionCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.AccionCAD ();

                                newinstance.Acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionEN>();
                                foreach (AccionDTO entry in dto.Acciones) {
                                        newinstance.Acciones.Add (AccionAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Puntuacion = dto.Puntuacion;
                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Apellidos = dto.Apellidos;
                        newinstance.Email = dto.Email;
                        newinstance.Pass = dto.Pass;
                        newinstance.Fecha = dto.Fecha;
                        if (dto.Items_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IItemCAD itemCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ItemCAD ();

                                newinstance.Items = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                                foreach (int entry in dto.Items_oid) {
                                        newinstance.Items.Add (itemCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Dudas_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IDudaCAD dudaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.DudaCAD ();

                                newinstance.Dudas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.DudaEN>();
                                foreach (int entry in dto.Dudas_oid) {
                                        newinstance.Dudas.Add (dudaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Respuestas_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IRespuestaCAD respuestaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.RespuestaCAD ();

                                newinstance.Respuestas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
                                foreach (int entry in dto.Respuestas_oid) {
                                        newinstance.Respuestas.Add (respuestaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Puntos_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IPuntoReciclajeCAD puntoReciclajeCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.PuntoReciclajeCAD ();

                                newinstance.Puntos = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN>();
                                foreach (int entry in dto.Puntos_oid) {
                                        newinstance.Puntos.Add (puntoReciclajeCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.EmailVerificado = dto.EmailVerificado;
                        if (dto.Materiales_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IMaterialCAD materialCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.MaterialCAD ();

                                newinstance.Materiales = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN>();
                                foreach (int entry in dto.Materiales_oid) {
                                        newinstance.Materiales.Add (materialCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Borrado = dto.Borrado;
                }
        }
        catch (Exception ex)
        {
                throw ex;
        }
        return newinstance;
}
}
}
