using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class PuntoReciclajeAssemblerDTO {
public static IList<PuntoReciclajeEN> ConvertList (IList<PuntoReciclajeDTO> lista)
{
        IList<PuntoReciclajeEN> result = new List<PuntoReciclajeEN>();
        foreach (PuntoReciclajeDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PuntoReciclajeEN Convert (PuntoReciclajeDTO dto)
{
        PuntoReciclajeEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PuntoReciclajeEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Latitud = dto.Latitud;
                        newinstance.Longitud = dto.Longitud;
                        newinstance.EsValido = dto.EsValido;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }

                        if (dto.Contenedores != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IContenedorCAD contenedorCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ContenedorCAD ();

                                newinstance.Contenedores = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ContenedorEN>();
                                foreach (ContenedorDTO entry in dto.Contenedores) {
                                        newinstance.Contenedores.Add (ContenedorAssemblerDTO.Convert (entry));
                                }
                        }
                        if (dto.Estancia_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IEstanciaCAD estanciaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.EstanciaCAD ();

                                newinstance.Estancia = estanciaCAD.ReadOIDDefault (dto.Estancia_oid);
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
