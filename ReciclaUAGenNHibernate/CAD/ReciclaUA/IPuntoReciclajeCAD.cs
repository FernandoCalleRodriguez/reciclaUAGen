
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IPuntoReciclajeCAD
{
PuntoReciclajeEN ReadOIDDefault (int id
                                 );

void ModifyDefault (PuntoReciclajeEN puntoReciclaje);

System.Collections.Generic.IList<PuntoReciclajeEN> ReadAllDefault (int first, int size);



int Crear (PuntoReciclajeEN puntoReciclaje);

void Modificar (PuntoReciclajeEN puntoReciclaje);


void Borrar (int id
             );


PuntoReciclajeEN BuscarPorId (int id
                              );


System.Collections.Generic.IList<PuntoReciclajeEN> BuscarTodos (int first, int size);




System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorValidar ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosValidados ();


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEdificio (int ? id_edificio);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorEstancia (string id_estancia);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorPlanta (int? id_edificio, int ? num_planta);



System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN> BuscarPuntosPorUsuario (int id_usuario);


int BuscarPuntosPorValidarCount ();


int BuscarPuntosCount ();


ReciclaUAGenNHibernate.EN.ReciclaUA.PuntoReciclajeEN BuscarPuntoPorContenedor (int contenedor_id);
}
}
