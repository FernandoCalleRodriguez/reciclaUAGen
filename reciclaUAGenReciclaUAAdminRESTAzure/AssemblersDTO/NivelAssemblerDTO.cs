using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class NivelAssemblerDTO {
public static IList<NivelEN> ConvertList (IList<NivelDTO> lista)
{
        IList<NivelEN> result = new List<NivelEN>();
        foreach (NivelDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static NivelEN Convert (NivelDTO dto)
{
        NivelEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new NivelEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Numero = dto.Numero;
                        newinstance.Puntuacion = dto.Puntuacion;
                        if (dto.Item_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IItemCAD itemCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.ItemCAD ();

                                newinstance.Item = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.ItemEN>();
                                foreach (int entry in dto.Item_oid) {
                                        newinstance.Item.Add (itemCAD.ReadOIDDefault (entry));
                                }
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
