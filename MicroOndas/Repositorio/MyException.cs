using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroOndas.Repositorio
{
    class MyException: Exception
    {

       
        private string _MyExceptionMessage;
        

        
        public string ExceptionMessage
        {
            get { return _MyExceptionMessage; }
            set { _MyExceptionMessage = value; }
        }
        
   

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

          
    }
}
