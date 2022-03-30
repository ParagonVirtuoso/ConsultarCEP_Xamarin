using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCEP.Servico.Modelo; //para poder usar a classe anterior e definir cada item como objeto
using Newtonsoft.Json; //necessita intalar pelo nuget para usar essa biblio

namespace App1_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        //o {0} é para posteriormente ser substituido pelo cep
        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";
           //usando como Endereco para que possa retornar
        public static Endereco BuscarEnderecoViaCEP(String cep) {
            //primeiro parametro que é a url e o segundo é o cep que o usuario digitou
            string NovoEnderecoURL = string.Format(EnderecoUrl, cep);

            //cliente web necessario usar a biblioteca System.Net
            WebClient wc = new WebClient();
            //fazer com que o webclientfaca o download dependendo dos metodos
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //metodo para descerializar a informacao
                            //ele vai quebrar o objeto Endereco e vai armazenar em Conteudo
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);
            if (end.cep == null) return null;
            //retorno da variavel endereco que tem o conteudo e tenha o objeto com as informacoes
            return end;
        }

    }
}
