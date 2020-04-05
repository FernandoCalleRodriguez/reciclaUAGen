using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUARESTAzure.DTO;

namespace reciclaUAGenReciclaUARESTAzure.AssemblersDTO
{
public class MaterialAssemblerDTO {
public static IList<MaterialEN> ConvertList (IList<MaterialDTO> lista)
{
        IList<MaterialEN> result = new List<MaterialEN>();
        foreach (MaterialDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static MaterialEN Convert (MaterialDTO dto)
{
        MaterialEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new MaterialEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Nombre = dto.Nombre;
                        newinstance.Contenedor = dto.Contenedor;
                        if (dto.Items_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IItemCAD itemCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ItemCAD ();

                                newinstance.Items = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                                foreach (int entry in dto.Items_oid) {
                                        newinstance.Items.Add (itemCAD.ReadOIDDefault (entry));
                                }
                        }
                        newinstance.EsValido = dto.EsValido;
                        if (dto.Usuario_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IUsuarioCAD usuarioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.UsuarioCAD ();

                                newinstance.Usuario = usuarioCAD.ReadOIDDefault (dto.Usuario_oid);
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
