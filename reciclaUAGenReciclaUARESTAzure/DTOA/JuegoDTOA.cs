using System;
using System.Linq;
using System.Web;

using System.Collections.Generic;

namespace reciclaUAGenReciclaUARESTAzure.DTOA
{
public class JuegoDTOA
{
private int id;
public int Id
{
        get { return id; }
        set { id = value; }
}


private int itemActual;
public int ItemActual
{
        get { return itemActual; }
        set { itemActual = value; }
}

private int aciertos;
public int Aciertos
{
        get { return aciertos; }
        set { aciertos = value; }
}

private int fallos;
public int Fallos
{
        get { return fallos; }
        set { fallos = value; }
}

private double puntuacion;
public double Puntuacion
{
        get { return puntuacion; }
        set { puntuacion = value; }
}

private int intentosItemActual;
public int IntentosItemActual
{
        get { return intentosItemActual; }
        set { intentosItemActual = value; }
}

private bool finalizado;
public bool Finalizado
{
        get { return finalizado; }
        set { finalizado = value; }
}

private int nivelActual;
public int NivelActual
{
        get { return nivelActual; }
        set { nivelActual = value; }
}
}
}
