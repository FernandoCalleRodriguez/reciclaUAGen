using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class UsuarioWebDTO              :                           UsuarioDTO


{
private System.Collections.Generic.IList<AccionDTO> acciones;
public System.Collections.Generic.IList<AccionDTO> Acciones {
        get { return acciones; } set { acciones = value;  }
}
private int puntuacion;
public int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}
}
}
