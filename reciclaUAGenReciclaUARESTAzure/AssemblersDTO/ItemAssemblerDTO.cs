using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class ItemAssemblerDTO {
public static IList<ItemEN> ConvertList (IList<ItemDTO> lista)
{
        IList<ItemEN> result = new List<ItemEN>();
        foreach (ItemDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ItemEN Convert (ItemDTO dto)
{
        ItemEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ItemEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Descripcion = dto.Descripcion;
                        newinstance.Imagen = dto.Imagen;
                        newinstance.EsValido = dto.EsValido;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
                        }
                        if (dto.Nivel_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.INivelCAD nivelCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.NivelCAD ();

                                newinstance.Nivel = nivelCAD.ReadOIDDefault (dto.Nivel_oid);
                        }
                        if (dto.Material_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IMaterialCAD materialCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.MaterialCAD ();

                                newinstance.Material = materialCAD.ReadOIDDefault (dto.Material_oid);
                        }
                        if (dto.AccionReciclar_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IAccionReciclarCAD accionReciclarCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.AccionReciclarCAD ();

                                newinstance.AccionReciclar = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                                foreach (int entry in dto.AccionReciclar_oid) {
                                        newinstance.AccionReciclar.Add (accionReciclarCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.Puntuacion = dto.Puntuacion;
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
