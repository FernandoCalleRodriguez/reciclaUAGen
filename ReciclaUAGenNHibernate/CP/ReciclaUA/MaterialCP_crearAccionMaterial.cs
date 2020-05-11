
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;
using ReciclaUAGenNHibernate.CEN.ReciclaUA;

/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CP.ReciclaUA_Material_crearAccionMaterial) ENABLED START*/
//  references to other libraries
using System.Linq;
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CP.ReciclaUA
{
    public partial class MaterialCP : BasicCP
    {
        public void CrearAccionMaterial(int p_oid)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CP.ReciclaUA_Material_crearAccionMaterial) ENABLED START*/

            IMaterialCAD materialCAD = null;
            MaterialCEN materialCEN = null;
            AccionWebCEN accionWebCEN = null;
            ITipoAccionCAD tipoAccionCAD = null;
            TipoAccionCEN tipoAccionCEN = null;
            TipoAccionEN tipoAccion = null;
            IUsuarioWebCAD usuarioWebCAD = null;
            UsuarioWebCEN usuarioWebCEN = null;
            MaterialEN material = null;


            try
            {
                SessionInitializeTransaction();
                materialCAD = new MaterialCAD(session);
                materialCEN = new MaterialCEN(materialCAD);
                tipoAccionCAD = new TipoAccionCAD(session);
                tipoAccionCEN = new TipoAccionCEN(tipoAccionCAD);
                usuarioWebCAD = new UsuarioWebCAD(session);
                usuarioWebCEN = new UsuarioWebCEN(usuarioWebCAD);
                accionWebCEN = new AccionWebCEN();

                material = materialCEN.BuscarPorId(p_oid);

                if (usuarioWebCEN.BuscarPorId(material.Usuario.Id) != null)
                {
                    tipoAccion = tipoAccionCEN.BuscarTodos(0, -1).Where(t => t.Nombre.Equals("Material")).FirstOrDefault();

                    if (tipoAccion == null)
                    {
                        var id = tipoAccionCEN.Crear(10, "Material");
                        tipoAccion = tipoAccionCEN.BuscarPorId(id);
                    }
                    accionWebCEN.Crear(material.Usuario.Id, tipoAccion.Id);
                }

                SessionCommit();
            }
            catch (Exception ex)
            {
                SessionRollBack();
                throw ex;
            }
            finally
            {
                SessionClose();
            }


            /*PROTECTED REGION END*/
        }
    }
}
