using ExemploConsumindoApiRest;
using System;

namespace ConsumindoApiRest.Start
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var exemplo = new ComsumindoApiRest();
            var endereco = exemplo.ConsumindoUmaApiRestParaRetornarCep("sp", "piracicaba", "armando salles");


            ///// Aqui é um exemplo para leitura de uma classe C# em forma de Lista
            foreach (var item in endereco)
            {
                Console.WriteLine(
                                  $"{item.Logradouro}" + Environment.NewLine +
                                  $"{item.Numero}" + Environment.NewLine +
                                  $"{item.Bairro}" + Environment.NewLine +
                                  $"{item.Cep}" + Environment.NewLine +
                                  $"{item.Complemento}" + Environment.NewLine +
                                  $"{item.Localidade}" + Environment.NewLine +
                                  $"{item.Unidade}" + Environment.NewLine +
                                  $"{item.UF}" + Environment.NewLine +
                                  $"{item.Gia}" + Environment.NewLine +
                                  $"{item.Ibge}" + Environment.NewLine +
                                  "==========================================================" + Environment.NewLine
                                  );
            }

            Console.ReadKey();

        }


    }

}
