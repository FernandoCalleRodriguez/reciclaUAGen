
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_confirmacionRespuestaCorrecta) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
public partial class RespuestaCEN
{
public void ConfirmacionRespuestaCorrecta (int p_oid)
{
        /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Respuesta_confirmacionRespuestaCorrecta) ENABLED START*/

        RespuestaEN resp = _IRespuestaCAD.BuscarPorId (p_oid);

        if (resp.EsCorrecta)
                throw new ModelException ("El estado de la respuesta ya es correcta");

        resp.EsCorrecta = true;

        _IRespuestaCAD.Modificar (resp);

        /*PROTECTED REGION END*/
}
}
}
