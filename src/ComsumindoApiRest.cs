using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ExemploConsumindoApiRest
{
    /// <summary>
    /// Toda request é composta por:
    /// 
    /// 1. Cabeçalho (pode ser n parametros)
    /// 2. Um Endpoint
    /// 3. Um Verbo Http (GET, POST, PUT, DELETE)
    /// 4. Parametros Url (pode ser n parametros)
    /// 
    /// - Se for (POST ou PUT), pode conter um corpo, que pode ser um JSON ou um XML
    /// 
    /// </summary>
    public class ComsumindoApiRest
    {
        
        public IList<MinhaClasse> ConsumindoUmaApiRestParaRetornarCep(string uf, string cidade, string logradouro)
        {

            var handler = new HttpClientHandler();
            var client = new HttpClient(handler);


            ////// Aqui inclui os parametros do cabeçalho da request (Isso é um exemplo)
            ////// cada endpoint determina quais parametros de cabeçalho são necessarios
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "application/json");
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "pt-BR");

            ///// url base do serviço a ser consumido ///////////
            var baseUrl = $"https://viacep.com.br/ws/";

            ///// parametros solicitados pelo serviço ///////////
            var parametrosUrl = $"{uf}/{cidade}/{logradouro}/json/";

            /////////////////////////////////////////////////////////////////////////////////
            /// IMPORTANTE:
            /// Dependendo de como o desenvolvedor construiu a Api
            /// os parametros da url pode ser passadas da seguinte forma:
            /// 
            ///var parametrosUrl = $"?uf={uf}&cidade={cidade}&logradouro={logradouro}";
            ///
            /// ou seja, utilize ? para iniciar os parametros e
            ///          utilize & para separar um parametro de outro.
            ///          utilize = para separar o nome do parametro da variavel contendo 
            ///          o valor
            ///////////////////////////////////////////////////////////////////////////////


            ///// a concatenação da url e parametros formam o endpoint do serviço ///////////
            var endPoint = $"{baseUrl}{parametrosUrl}";


            ///// Cria uma instancia para o retorno da request ///////////
            var retornoTask = new HttpResponseMessage();


            //// Consome o serviço, nesse exemplo o verbo é um GET /////////////
            retornoTask = client.GetAsync(endPoint).Result;

            //// Verifica se houve erro no processo
            if (!retornoTask.IsSuccessStatusCode)
            {
                //// Os codigos de retorno de uma api rest seguem um padrão HttpStatusCode
                Console.WriteLine($"Retornou erro: {retornoTask.StatusCode}");
                Console.ReadKey();
                return new List<MinhaClasse>();
            }


            //// caso não houve erro, obtem o objeto de retorno enviado pelo serviço
            var conteudoRetornado = retornoTask.Content.ReadAsStringAsync();


            //// Automagicamente o conteudo é deserializado para nossa classe C#, basta o nome dos campos
            //// serem iguais, não importa maiuslo/minusculo ou os tipos do campo.
            var minhaClasse = JsonConvert.DeserializeObject<IList<MinhaClasse>>(conteudoRetornado.Result);


            return minhaClasse;
        }



    }





    public class MinhaClasse
    {

            public string Logradouro { get; set; }
            public string Complemento { get; set; }
            public string Numero { get; set; }
            public string Bairro { get; set; }
            public string Localidade { get; set; }
            public string Unidade { get; set; }
            public string UF { get; set; }
            public string Cep { get; set; }
            public string Ibge { get; set; }
            public string Gia { get; set; }
    }
}
