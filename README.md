Aqui estão as instruções para configurar e executar o projeto em um ambiente de desenvolvimento local.

Pré-requisitos
PostgreSQL: É necessário ter o PostgreSQL instalado. O projeto foi desenvolvido utilizando a versão 15.4. Recomenda-se utilizar esta versão. Faça o download aqui.

Visual Studio: O Visual Studio é essencial para a execução e desenvolvimento deste projeto. Caso não o tenha instalado, obtenha-o aqui.

Configuração
Conexão com o Banco de Dados: No arquivo appsettings.json, ajuste o valor da chave PostgreSQLConnection com a string de conexão que aponte para o seu banco de dados PostgreSQL local.

Migrations: No Package Manager Console do Visual Studio, execute o comando update-database para aplicar as migrations e preparar o banco de dados.

Validações
CPF e CNPJ: Ao adicionar uma pessoa no sistema, o número de CPF e CNPJ é validado. Certifique-se de inserir um número válido.

Inserção de Cartão: Ao adicionar um cartão:

Tipos definidos através de números:
0: Físico (Physical)
1: Virtual
Ou através das strings:
"physical": Cartões Físicos
"virtual": Cartões Virtuais
Executando o Projeto
Abra o projeto utilizando o Visual Studio.
Execute o "build" do projeto para restaurar todos os pacotes e dependências.
Com o banco de dados ativo e a conexão configurada, inicie a aplicação pressionando F5 ou usando o botão "Run".
