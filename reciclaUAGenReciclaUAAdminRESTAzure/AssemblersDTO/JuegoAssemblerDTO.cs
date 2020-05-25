using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class JuegoAssemblerDTO {
public static IList<JuegoEN> ConvertList (IList<JuegoDTO> lista)
{
        IList<JuegoEN> result = new List<JuegoEN>();
        foreach (JuegoDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static JuegoEN Convert (JuegoDTO dto)
{
        JuegoEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new JuegoEN ();



                        newinstance.Id = dto.Id;
                        newinstance.ItemActual = dto.ItemActual;
                        newinstance.Aciertos = dto.Aciertos;
                        newinstance.Fallos = dto.Fallos;
                        newinstance.Puntuacion = dto.Puntuacion;
                        if (dto.Usuarios_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuarios = usuarioCAD.ReadOIDDefault (dto.Usuarios_oid);
                        }
                        newinstance.IntentosItemActual = dto.IntentosItemActual;
                        newinstance.Finalizado = dto.Finalizado;
                        newinstance.NivelActual = dto.NivelActual;
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
