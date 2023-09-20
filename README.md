# BackEndCubos

Aqui estão as instruções para configurar e executar o projeto em um ambiente de desenvolvimento local.

---------- Pré-requisitos ----------
PostgreSQL: 
  É necessário ter o PostgreSQL instalado. O projeto foi desenvolvido utilizando a versão 15.4, portanto, é recomendado utilizar esta versão. 
  Faça o download aqui: https://www.postgresql.org/download/.

Visual Studio: 
  O Visual Studio é necessário para a execução e desenvolvimento deste projeto. 
  Caso não o tenha instalado, você pode obter uma cópia aqui: https://visualstudio.microsoft.com/pt-br/.

Configuração
  Conexão com o Banco de Dados: 
  No arquivo appsettings.json, ajuste o valor da chave PostgreSQLConnection com a string de conexão apontando para o seu banco de dados PostgreSQL local.

Migrations: 
  No Package Manager Console do Visual Studio, execute o comando update-database para aplicar as migrations e configurar o banco de dados.


---------- Validações ----------
CPF e CNPJ: 
  Ao adicionar uma pessoa no sistema, o número de CPF e CNPJ é validado. 
  Garanta que esteja inserindo um número válido.

Inserção de Cartão: 
  Na hora de adicionar um cartão:
    Os tipos podem ser definidos através de números:
      0: Físico (Physical)
      1: Virtual
    Ou diretamente pelas strings:
      "physical": Para cartões físicos
      "virtual": Para cartões virtuais

      
---------- Executando o Projeto ----------
Abra o projeto utilizando o Visual Studio.

Faça o "build" do projeto para restaurar todos os pacotes e dependências necessários.

Com o banco de dados rodando e a conexão configurada, inicie a aplicação pressionando F5 ou usando o botão "Run".
