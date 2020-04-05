using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class PlantaAssemblerDTO {
public static IList<PlantaEN> ConvertList (IList<PlantaDTO> lista)
{
        IList<PlantaEN> result = new List<PlantaEN>();
        foreach (PlantaDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static PlantaEN Convert (PlantaDTO dto)
{
        PlantaEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new PlantaEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Planta = dto.Planta;
                        if (dto.Estancias_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IEstanciaCAD estanciaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.EstanciaCAD ();

                                newinstance.Estancias = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN>();
                                foreach (string entry in dto.Estancias_oid) {
                                        newinstance.Estancias.Add (estanciaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Edificio_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IEdificioCAD edificioCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.EdificioCAD ();

                                newinstance.Edificio = edificioCAD.ReadOIDDefault (dto.Edificio_oid);
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
