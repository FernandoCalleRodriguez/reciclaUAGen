
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


/*PROTECTED REGION ID(usingReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_login) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace ReciclaUAGenNHibernate.CEN.ReciclaUA
{
    public partial class UsuarioCEN
    {
        public string Login(string p_pass, string p_email)
        {
            /*PROTECTED REGION ID(ReciclaUAGenNHibernate.CEN.ReciclaUA_Usuario_login) ENABLED START*/
            string result = null;
            UsuarioEN en = _IUsuarioCAD.BuscarPorCorreo(p_email);
            if(en != null) {

                if (en.Pass.Equals(Utils.Util.GetEncondeMD5(p_pass)))
                    result = this.GetToken(en.Id);
            }



            return result;
            /*PROTECTED REGION END*/
        }
    }
}
