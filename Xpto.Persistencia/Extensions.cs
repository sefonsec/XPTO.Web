using System;

namespace Xpto.Persistencia
{
    public static class Extensions
    {
        public static string Mensagem(this Exception exception, int max = 0)
        {
            var mensagem = exception.Message;

            var ie = exception.InnerException;

            while (ie != null)
            {
                mensagem += Environment.NewLine + ie.Message;

                ie = ie.InnerException;
            }

            if (max > mensagem.Length)
            {
                max = mensagem.Length;
            }

            return max > 0 ? mensagem.Substring(0, max) : mensagem;
        }
    }
}
