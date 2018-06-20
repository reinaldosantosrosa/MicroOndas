using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    class MyException: Exception
    {

        #region Fields
        private string _exceptionmessage;
        #endregion

        #region Properties
        public string ExceptionMessage
        {
            get { return _exceptionmessage; }
            set { _exceptionmessage = value; }
        }
        #endregion
               

        #region Constructor


        /// Construtor da classe, este popula a field _exceptionmessage, usado para armazenar a mensagem original da exception.


        public MyException(Exception excep)
        {
            ExceptionMessage = excep.Message;
        }


        /// Construtor da classe, este popula a field _exceptionmessage, usado para armazenar a mensagem da exception.
        /// Use msgDefinida(int) para melhor manutenção desta classe.

        public MyException(string excepmsg)
        {
            ExceptionMessage = excepmsg;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna mensagens de procedimentos inválidos (cath)

        public static string MsgDefinida(int tipomsg)
        {
            string msg = "Operacao invalida. Tente novamente!";

            switch (tipomsg)
            {
                case 1:
                    msg = "Campo tempo nao contem valor valido";
                    break;
                case 2:
                    msg = "Potencia deve estar entre 1 e 10";
                    break;
               
                default:
                    break;
            }

            return msg;
        }


        #endregion
    }
}
