using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            // *IMPLEMENTE AQUI*
            Console.WriteLine("Digite a placa do veículo para estacionar: Ex abc-1234 ou abc-1a23");
            string placa = Console.ReadLine();

            if(VerificarPlaca(placa)) 
            {
                if(ConsultarPlacas(placa))
                {
                    veiculos.Add(placa);
                }
                else
                {
                    Console.WriteLine("Veículo já cadastrado!");
                }
            } 
            else
            {
                Console.WriteLine("Digite uma placa válida!");
            }
        }

        private bool VerificarPlaca(string placa)
        {
            string pattern = @"[A-Za-z]{3}[-]{1}\d{4}";
            string patternMercosul = @"[A-Za-z]{3}[-]{1}\d{1}[A-Za-z]{1}\d{2}";
            Match m = Regex.Match(placa, pattern);
            Match mMercosul = Regex.Match(placa, patternMercosul);
            return m.Success || mMercosul.Success;
        }

        private bool ConsultarPlacas(string placa) 
        {
            foreach (string v in veiculos)
            {
                if(placa == v)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = "";
            placa = Console.ReadLine();

            if(!VerificarPlaca(placa)){
                Console.WriteLine("Digite uma placa válida!");
            }
            else
            {
                // Verifica se o veículo existe
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    int horas = 0;
                    decimal valorTotal = 0; 

                    horas = Convert.ToInt32(Console.ReadLine());

                    valorTotal = precoInicial + precoPorHora * horas;


                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*

                    veiculos.Remove(placa);

                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                foreach (string v in veiculos)
                {
                    Console.WriteLine(v);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
