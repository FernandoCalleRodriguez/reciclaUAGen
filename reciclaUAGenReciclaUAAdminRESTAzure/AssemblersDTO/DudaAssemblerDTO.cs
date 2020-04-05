using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class DudaAssemblerDTO {
public static IList<DudaEN> ConvertList (IList<DudaDTO> lista)
{
        IList<DudaEN> result = new List<DudaEN>();
        foreach (DudaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static DudaEN Convert (DudaDTO dto)
{
        DudaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new DudaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Titulo = dto.Titulo;
                        newinstance.Cuerpo = dto.Cuerpo;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }

                        if (dto.Respuestas != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IRespuestaCAD respuestaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.RespuestaCAD ();

                                newinstance.Respuestas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN>();
                                foreach (RespuestaDTO entry in dto.Respuestas) {
                                        newinstance.Respuestas.Add (RespuestaAssemblerDTO.Convert (entry));
                                }
                        }
                        newinstance.Fecha = dto.Fecha;
                        newinstance.Util = dto.Util;
                        newinstance.Temas = dto.Temas;
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
