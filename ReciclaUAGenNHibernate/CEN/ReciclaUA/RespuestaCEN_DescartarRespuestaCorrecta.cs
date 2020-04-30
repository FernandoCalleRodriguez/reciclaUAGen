
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ReciclaUAGenNHibernate.Exceptions;
using ReciclaUAGenNHibernate.EN.ReciclaUA;
using ReciclaUAGenNHibernate.CAD.ReciclaUA;


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_descartarRespuestaCorrecta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class RespuestaCEN
{
public bool DescartarRespuestaCorrecta (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_descartarRespuestaCorrecta) ENABLED START*/

        RespuestaEN resp = _IRespuestaCAD.BuscarPorId (p_oid);

        if (!resp.EsCorrecta)
                throw new ModelException ("El estado de la respuesta no es correcta");

        resp.EsCorrecta = false;

        _IRespuestaCAD.Modificar (resp);

        return true;
        /*PROTECTED REGION END*/
}
}
}
