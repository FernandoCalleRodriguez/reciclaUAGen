using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class UsuarioAdministradorAssemblerDTO {
public static IList<UsuarioAdministradorEN> ConvertList (IList<UsuarioAdministradorDTO> lista)
{
        IList<UsuarioAdministradorEN> result = new List<UsuarioAdministradorEN>();
        foreach (UsuarioAdministradorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static UsuarioAdministradorEN Convert (UsuarioAdministradorDTO dto)
{
        UsuarioAdministradorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new UsuarioAdministradorEN ();



                        if (dto.Notas_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.INotaInformativaCAD notaInformativaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.NotaInformativaCAD ();

                                newinstance.Notas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.NotaInformativaEN>();
                                foreach (int entry in dto.Notas_oid) {
                                        newinstance.Notas.Add (notaInformativaCAD.ReadOIDDefault (entry));
                                }
                        }
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
                        if (dto.Juego_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IJuegoCAD juegoCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.JuegoCAD ();

                                newinstance.Juego = juegoCAD.ReadOIDDefault (dto.Juego_oid);
                        }
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
