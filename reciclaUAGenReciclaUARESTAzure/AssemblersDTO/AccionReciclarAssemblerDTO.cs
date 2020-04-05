using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class AccionReciclarAssemblerDTO {
public static IList<AccionReciclarEN> ConvertList (IList<AccionReciclarDTO> lista)
{
        IList<AccionReciclarEN> result = new List<AccionReciclarEN>();
        foreach (AccionReciclarDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static AccionReciclarEN Convert (AccionReciclarDTO dto)
{
        AccionReciclarEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new AccionReciclarEN ();



                        if (dto.Contenedor_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IContenedorCAD contenedorCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ContenedorCAD ();

                                newinstance.Contenedor = contenedorCAD.ReadOIDDefault (dto.Contenedor_oid);
                        }
                        if (dto.Item_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IItemCAD itemCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ItemCAD ();

                                newinstance.Item = itemCAD.ReadOIDDefault (dto.Item_oid);
                        }
                        newinstance.Cantidad = dto.Cantidad;
                        newinstance.Id = dto.Id;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioWebCAD usuarioWebCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioWebCAD ();

                                newinstance.Usuario = usuarioWebCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
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
