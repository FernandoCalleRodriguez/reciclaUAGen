using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class NotaInformativaAssemblerDTO {
public static IList<NotaInformativaEN> ConvertList (IList<NotaInformativaDTO> lista)
{
        IList<NotaInformativaEN> result = new List<NotaInformativaEN>();
        foreach (NotaInformativaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static NotaInformativaEN Convert (NotaInformativaDTO dto)
{
        NotaInformativaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new NotaInformativaEN ();



                        newinstance.Id = dto.Id;
                        if (dto.UsuarioAdministrador_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioAdministradorCAD usuarioAdministradorCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioAdministradorCAD ();

                                newinstance.UsuarioAdministrador = usuarioAdministradorCAD.ReadOIDDefault (dto.UsuarioAdministrador_oid);
                        }
                        newinstance.Titulo = dto.Titulo;
                        newinstance.Cuerpo = dto.Cuerpo;
                        newinstance.Fecha = dto.Fecha;
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
