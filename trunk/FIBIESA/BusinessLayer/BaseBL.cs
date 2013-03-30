using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;

namespace BusinessLayer
{
    public class BaseBL
    {
        public virtual List<Base> Pesquisar(string descricao)
        {
            BaseDA baDA = new BaseDA();

            return baDA.Pesquisar(descricao);
        }
    }
}
