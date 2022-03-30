using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servico;
using App1_ConsultarCEP.Servico.Modelo;

namespace App1_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            
			InitializeComponent();

            BotaoId.Clicked += BuscarCEP;
           
            
		}
        private void BuscarCEP(object sender, EventArgs args) {

            //pegar o texto digitado na caixa 
            //o trim para retirar todos os espacos em branco
            string cep = CepId.Text.Trim();

            //TODO - Lógica do programa quando é clicado no botao
            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

           RESULTADO.Text = string.Format("Endereço: {2} de {3} {0}, {1}", end.localidade , end.uf, end.logradouro, end.bairro);    


        }
	}
}
