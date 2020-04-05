
using System;
// Definición clase AulaEN
namespace ReciclaUAGenNHibernate.EN.ReciclaUA
{
public partial class AulaEN
{
/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo edificio
 */
private ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio;



/**
 *	Atributo planta
 */
private ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta;






public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN Edificio {
        get { return edificio; } set { edificio = value;  }
}



public virtual ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum Planta {
        get { return planta; } set { planta = value;  }
}





public AulaEN()
{
}



public AulaEN(int id, ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta
              )
{
        this.init (Id, edificio, planta);
}


public AulaEN(AulaEN aula)
{
        this.init (Id, aula.Edificio, aula.Planta);
}

private void init (int id
                   , ReciclaUAGenNHibernate.EN.ReciclaUA.EdificioEN edificio, ReciclaUAGenNHibernate.Enumerated.ReciclaUA.PlantaEnum planta)
{
        this.Id = id;


        this.Edificio = edificio;

        this.Planta = planta;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AulaEN t = obj as AulaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
