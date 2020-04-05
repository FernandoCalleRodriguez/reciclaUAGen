using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class RespuestaDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
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

private bool esCorrecta;
public bool EsCorrecta
{
        get { return esCorrecta; }
        set { esCorrecta = value; }
}

private int util;
public int Util
{
        get { return util; }
        set { util = value; }
}


/* Rol: Respuesta o--> UsuarioWebAutenticado */
private UsuarioWebAutenticadoDTOA usuarioRespuesta;
public UsuarioWebAutenticadoDTOA UsuarioRespuesta
{
        get { return usuarioRespuesta; }
        set { usuarioRespuesta = value; }
}
}
}
