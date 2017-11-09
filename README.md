# ConsumindoApiRest
Exemplo de como consumir uma Api Rest com httpClient

Para testar manualmente uma Api Rest

1.	Baixe a extensão do Chrome “Postman”

		https://chrome.google.com/webstore/search/postman

 
 ![baixar postman](https://github.com/lincolnzocateli/ConsumindoApiRest/blob/master/img/Exemplo-Baixar-Postman.jpg)
 
 

2.	Consumindo um endpoint com verbo GET

		Nesse exemplo meu tema do postman está escuro, por escolha minha.

		Preencha dos dados como:
		Verbo: GET
		EndPoint: https://viacep.com.br/ws/sp/piracicaba/armando salles/json/
		Headers: na maioria das vezes nem precisa do cabeçalho


![teste-get](https://github.com/lincolnzocateli/ConsumindoApiRest/blob/master/img/Exemplo-GET-Postman.jpg)
 

3.	Confira a resposta da request
		É importante observar o Status Code
		Formato da resposta, geralmente é JSON
		Cabeçalho da resposta, pode conter alguma informação do provedor do serviço.

![retorno-teste-get](https://github.com/lincolnzocateli/ConsumindoApiRest/blob/master/img/Exemplo-Resposta-GET-Postman.jpg)


No C# pode ser utilizado o NewtonSoft Json para deserializar a resposta em uma classe, automaticamente, que também faz para xml, arquivo etc..
