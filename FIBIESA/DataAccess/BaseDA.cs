using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;

namespace DataAccess
{
    public class BaseDA
    {
        public virtual List<Base> Pesquisar(string descricao, string tipo)
        {
            List<Base> ba = new List<Base>();

            return ba;
        }
    }
}
