---
Instruções de Configuração do Projeto

---
PRÉ-REQUISITOS

Antes de iniciar, certifique-se de ter instalado:

Visual Studio (com suporte para .NET Core)
Docker Desktop

---
CLONAGEM DO PROJETO

Para começar, clone o repositório para sua máquina local usando o Visual Studio. Você pode fazer isso diretamente através da interface do Visual Studio ou via linha de comando: "git clone <https://github.com/NataliaNCCS/BackEndCubos.git>"

---
CONFIGURAÇÃO DO PROJETO DO VISUAL STUDIO

Depois de clonar o repositório, siga estes passos para configurar o projeto:
Abra a solução no Visual Studio.
Navegue até a pasta 1-Services.
Clique com o botão direito no projeto BackEndCubos.OPENAPI.
Escolha Set as Startup Project para definir como o projeto de inicialização.
Inicialização do Docker
Inicialize os contêneres necessários usando Docker Compose. Abra um terminal e execute o seguinte comando no diretório raiz do projeto: "docker-compose up"
Isso vai configurar e iniciar todos os serviços necessários definidos no seu docker-compose.yml.

--- 
CONFIGURAÇÃO DO BANCO DE DADOS

Para configurar o banco de dados e aplicar as migrations do Entity Framework, siga estas etapas:

Abra o Console do Gerenciador de Pacotes no Visual Studio.
Navegue para o diretório do projeto de infraestrutura: "cd .\BackEndCubos.Infra"
Execute o seguinte comando para atualizar o banco de dados: "update-database"

Após seguir estas etapas, seu ambiente deve estar configurado e pronto para ser usado. Execute o projeto no Visual Studio para iniciar a aplicação.
