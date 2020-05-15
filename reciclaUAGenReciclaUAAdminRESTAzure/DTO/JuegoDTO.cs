using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class JuegoDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private int itemActual;
public int ItemActual {
        get { return itemActual; } set { itemActual = value;  }
}
private int aciertos;
public int Aciertos {
        get { return aciertos; } set { aciertos = value;  }
}
private int fallos;
public int Fallos {
        get { return fallos; } set { fallos = value;  }
}
private int puntuacion;
public int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}


private System.Collections.Generic.IList<int> usuarios_oid;
public System.Collections.Generic.IList<int> Usuarios_oid {
        get { return usuarios_oid; } set { usuarios_oid = value;  }
}



private int nivelActual_oid;
public int NivelActual_oid {
        get { return nivelActual_oid; } set { nivelActual_oid = value;  }
}

private int intentosItemActual;
public int IntentosItemActual {
        get { return intentosItemActual; } set { intentosItemActual = value;  }
}
private bool finalizado;
public bool Finalizado {
        get { return finalizado; } set { finalizado = value;  }
}
}
}
