using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class DudaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private string titulo;
public string Titulo
{
        get { return titulo; }
        set { titulo = value; }
}

private string cuerpo;
public string Cuerpo
{
        get { return cuerpo; }
        set { cuerpo = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private int util;
public int Util
{
        get { return util; }
        set { util = value; }
}

private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum tema;
public ReciclaUAGenNHibernate.Enumerated.ReciclaUA.TemaEnum Tema
{
        get { return tema; }
        set { tema = value; }
}


/* Rol: Duda o--> UsuarioAdminAutenticado */
private UsuarioAdminAutenticadoDTOA usuarioDuda;
public UsuarioAdminAutenticadoDTOA UsuarioDuda
{
        get { return usuarioDuda; }
        set { usuarioDuda = value; }
}


/* ServiceLink: obtenerNumeroDeRespuestas */
private int obtenerNumeroDeRespuestas;
public int ObtenerNumeroDeRespuestas
{
        get { return obtenerNumeroDeRespuestas; }
        set { obtenerNumeroDeRespuestas = value; }
}

/* ServiceLink: obtenerSiRespuestaValida */
private bool obtenerSiRespuestaValida;
public bool ObtenerSiRespuestaValida
{
        get { return obtenerSiRespuestaValida; }
        set { obtenerSiRespuestaValida = value; }
}
}
}
