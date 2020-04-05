
using System;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace ReciclaUAGenNHibernate.CAD.ReciclaUA
{
public partial interface IRespuestaCAD
{
RespuestaEN ReadOIDDefault (int id
                            );

void ModifyDefault (RespuestaEN respuesta);

System.Collections.Generic.IList<RespuestaEN> ReadAllDefault (int first, int size);



int Crear (RespuestaEN respuesta);

void Modificar (RespuestaEN respuesta);


void Borrar (int id
             );


RespuestaEN BuscarPorId (int id
                         );


System.Collections.Generic.IList<RespuestaEN> BuscarTodos (int first, int size);


System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorDuda (int ? id_duda);






System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestaPorEsCorrecta ();



System.Collections.Generic.IList<ReciclaUAGenNHibernate.EN.ReciclaUA.RespuestaEN> BuscarRespuestasPorUsuario (int id_usuario);
}
}
