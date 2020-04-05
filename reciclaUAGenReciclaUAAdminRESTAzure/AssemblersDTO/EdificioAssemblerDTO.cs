using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class EdificioAssemblerDTO {
public static IList<EdificioEN> ConvertList (IList<EdificioDTO> lista)
{
        IList<EdificioEN> result = new List<EdificioEN>();
        foreach (EdificioDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static EdificioEN Convert (EdificioDTO dto)
{
        EdificioEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new EdificioEN ();



                        newinstance.Nombre = dto.Nombre;
                        newinstance.Id = dto.Id;
                        if (dto.Estancias_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IEstanciaCAD estanciaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.EstanciaCAD ();

                                newinstance.Estancias = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.EstanciaEN>();
                                foreach (string entry in dto.Estancias_oid) {
                                        newinstance.Estancias.Add (estanciaCAD.ReadOIDDefault (entry));
                                }
                        }
                        if (dto.Plantas_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IPlantaCAD plantaCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.PlantaCAD ();

                                newinstance.Plantas = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.PlantaEN>();
                                foreach (int entry in dto.Plantas_oid) {
                                        newinstance.Plantas.Add (plantaCAD.ReadOIDDefault (entry));
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
