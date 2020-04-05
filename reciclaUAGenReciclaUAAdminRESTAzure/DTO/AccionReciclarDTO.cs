using System;
using System.Runtime.Serialization;
using ReciclaUAGenNHibernate.EN.ReciclaUA;

namespace reciclaUAGenReciclaUAAdminRESTAzure.DTO
{
public partial class AccionReciclarDTO                  :                           AccionDTO


{
private int contenedor_oid;
public int Contenedor_oid {
        get { return contenedor_oid; } set { contenedor_oid = value;  }
}



private int item_oid;
public int Item_oid {
        get { return item_oid; } set { item_oid = value;  }
}

private int cantidad;
public int Cantidad {
        get { return cantidad; } set { cantidad = value;  }
}
}
}
