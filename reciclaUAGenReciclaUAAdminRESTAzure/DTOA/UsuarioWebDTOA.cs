using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTOA
{
public class UsuarioWebDTOA
{
private string nombre;
public string Nombre
{
        get { return nombre; }
        set { nombre = value; }
}

private string apellidos;
public string Apellidos
{
        get { return apellidos; }
        set { apellidos = value; }
}

private string email;
public string Email
{
        get { return email; }
        set { email = value; }
}

private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}

private Nullable<DateTime> fecha;
public Nullable<DateTime> Fecha
{
        get { return fecha; }
        set { fecha = value; }
}

private int puntuacion;
public int Puntuacion
{
        get { return puntuacion; }
        set { puntuacion = value; }
}

private bool emailVerificado;
public bool EmailVerificado
{
        get { return emailVerificado; }
        set { emailVerificado = value; }
}

private bool borrado;
public bool Borrado
{
        get { return borrado; }
        set { borrado = value; }
}
}
}
