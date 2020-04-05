using System;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using reciclaUAGenReciclaUAAdminRESTAzure.DTO;

namespace reciclaUAGenReciclaUAAdminRESTAzure.AssemblersDTO
{
public class ContenedorAssemblerDTO {
public static IList<ContenedorEN> ConvertList (IList<ContenedorDTO> lista)
{
        IList<ContenedorEN> result = new List<ContenedorEN>();
        foreach (ContenedorDTO dto in lista) {
                result.Add (Convert (dto));
        }
        return result;
}


public static ContenedorEN Convert (ContenedorDTO dto)
{
        ContenedorEN newinstance = null;

        try
        {
                if (dto != null) {
                        newinstance = new ContenedorEN ();



                        newinstance.Id = dto.Id;
                        newinstance.Tipo = dto.Tipo;
                        if (dto.Punto_oid != -1) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IPuntoReciclajeCAD puntoReciclajeCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.PuntoReciclajeCAD ();

                                newinstance.Punto = puntoReciclajeCAD.ReadOIDDefault (dto.Punto_oid);
                        }
                        if (dto.Acciones_oid != null) {
                                ReciclaUAGenNHibernate.CAD.ReciclaUA.IAccionReciclarCAD accionReciclarCAD = new ReciclaUAGenNHibernate.CAD.ReciclaUA.AccionReciclarCAD ();

                                newinstance.Acciones = new System.Collections.Generic.List<ReciclaUAGenNHibernate.EN.ReciclaUA.AccionReciclarEN>();
                                foreach (int entry in dto.Acciones_oid) {
                                        newinstance.Acciones.Add (accionReciclarCAD.ReadOIDDefault (entry));
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
