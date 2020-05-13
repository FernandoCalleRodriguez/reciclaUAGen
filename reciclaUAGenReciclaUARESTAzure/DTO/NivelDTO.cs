using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUARESTAzure.DTO
{
public partial class NivelDTO
{
private int id;
public int Id {
        get { return id; } set { id = value;  }
}
private int numero;
public int Numero {
        get { return numero; } set { numero = value;  }
}
private int puntuacion;
public int Puntuacion {
        get { return puntuacion; } set { puntuacion = value;  }
}


private System.Collections.Generic.IList<int> item_oid;
public System.Collections.Generic.IList<int> Item_oid {
        get { return item_oid; } set { item_oid = value;  }
}



private System.Collections.Generic.IList<int> juego_oid;
public System.Collections.Generic.IList<int> Juego_oid {
        get { return juego_oid; } set { juego_oid = value;  }
}
}
}
