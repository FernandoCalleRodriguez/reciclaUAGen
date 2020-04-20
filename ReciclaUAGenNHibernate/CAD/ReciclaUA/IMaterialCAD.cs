
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IMaterialCAD
{
MaterialEN ReadOIDDefault (int id
                           );

void ModifyDefault (MaterialEN material);

System.Collections.Generic.IList<MaterialEN> ReadAllDefault (int first, int size);



System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarPorTipoContenedor (ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TipoContenedorEnum ? tipo_contenedor);


int Crear (MaterialEN material);

void Modificar (MaterialEN material);


void Borrar (int id
             );


MaterialEN BuscarPorId (int id
                        );


System.Collections.Generic.IList<MaterialEN> BuscarTodos (int first, int size);




System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorValidar ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesValidados ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.MaterialEN> BuscarMaterialesPorUsuario (int id_usuario);


int BuscarMaterialesPorValidarCount ();
}
}
