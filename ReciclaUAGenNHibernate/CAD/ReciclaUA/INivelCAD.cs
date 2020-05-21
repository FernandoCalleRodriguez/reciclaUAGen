
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface INivelCAD
{
NivelEN ReadOIDDefault (int id
                        );

void ModifyDefault (NivelEN nivel);

System.Collections.Generic.IList<NivelEN> ReadAllDefault (int first, int size);



int Crear (NivelEN nivel);

void Modificar (NivelEN nivel);


void Borrar (int id
             );


NivelEN BuscarPorId (int id
                     );


System.Collections.Generic.IList<NivelEN> BuscarTodos (int first, int size);


void AsignarItems (int p_Nivel_OID, System.Collections.Generic.IList<int> p_item_OIDs);

void DesasignarItems (int p_Nivel_OID, System.Collections.Generic.IList<int> p_item_OIDs);

int BuscarNivelCount ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.NivelEN> BuscarNivelPorNumero (int ? p_numero);
}
}
