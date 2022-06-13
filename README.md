**CRUD Metas**

O projeto está utilizando as seguintes tecnologias  e respectivas versões:

* Angular CLI: 13.3.6
* .NETCore 6
* Banco de dados MYSql/MariaDB: 10.4.24
* 

 A aplicação consiste em um crud básico de metas de vendedores, 


Para rodar a aplicação:


Primeiro ir em CRUDMetasAPI, abrir a solution e no arquivo appsettings.json alterar a string de comexão para as informações do banco de dados, com isso: 

* abrir uma janela do Console do Gerenciador de Pacotes e excecutar o comando: Update-Database para que o EF core gere a estrutura das tabelas
* No arquivo QueryDados.sql que fica na pasta raiz da api, estão os dados para serem importados, incluindo um usuario e dados para as tabelas de vendedores, empresas, setores e vendas. Obs: a senha do usuario admin é admin123

Com a base online e o arquivo importado para testar a API:

Fazer um POST no controller de login usando o objeto:

{ 

 "userName": "admin",

    "senha": "admin123"

}


então será retornado um bearer token para acesso aos demais endpoints
