using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataObjects;
using DataAccess;
using System.Data;

namespace BusinessLayer
{
    public class ObrasBL : BaseBL
    {
        private bool IsValid(Obras instancia)
        {
            bool valido;
            valido = instancia.Titulo.Length <= 100;

            return valido;
        }

        public Int32 InserirBL(Obras instancia)
        {
            if (IsValid(instancia))
            {
                ObrasDA varDA = new ObrasDA();

                return varDA.InserirDA(instancia);
            }
            else
                return 0;
        }

        public bool EditarBL(Obras instancia)
        {
            if (instancia.Id > 0 && IsValid(instancia))
            {
                ObrasDA varDA = new ObrasDA();

                return varDA.EditarDA(instancia);
            }
            else
                return false;
        }

        public bool ExcluirBL(Obras instancia)
        {
            if (instancia.Id > 0)
            {
                ObrasDA varDA = new ObrasDA();

                return varDA.ExcluirDA(instancia);
            }
            else
                return false;
        }

        public List<Obras> PesquisarBL()
        {
            /*criar as regras de negocio*/
            ObrasDA obrasDA = new ObrasDA();

            return obrasDA.PesquisarDA();
        }

        public DataSet PesquisarBL(int obra_id)
        {
            ObrasDA ObrasDA = new ObrasDA();

            return ObrasDA.PesquisarDA(obra_id);
        }

        public List<Obras> PesquisarBL(string campo, string valor)
        {
            ObrasDA obrasDA = new ObrasDA();

            return obrasDA.PesquisarDA(campo, valor);
        }

        public List<Obras> PesquisarBuscaBL(string valor)
        {
            /*criar as regras de negocio*/
            ObrasDA obrasDA = new ObrasDA();

            return obrasDA.PesquisarBuscaDA(valor);
        }

        public override List<Base> Pesquisar(string codDes)
        {
            ObrasDA obraDA = new ObrasDA();

            return obraDA.Pesquisar(codDes);
        }

        /// <summary>
        /// pesquisa realizada com mais de um id 
        /// </summary>
        /// <param name="valor">Id das obras separado por virgula</param>
        /// <returns>Retorna um List<Base></returns>
        public List<Base> PesquisarObras(string cods)
        {
            ObrasDA obraDA = new ObrasDA();

            return obraDA.PesquisarObras(cods);
        }
    }
}
