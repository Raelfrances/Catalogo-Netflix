# Gerenciador de Catálogos da Netflix com Azure Functions e CosmosDB

Este projeto implementa um gerenciador de catálogos da Netflix utilizando Azure Functions e CosmosDB.

## Infraestrutura em Cloud

1. Crie uma **Resource Group** no Azure.
2. Crie uma **Storage Account**.
3. Crie uma **Azure Cosmos DB** com a API de sua escolha (SQL API será usada neste exemplo).
4. Configure a **Azure Functions App**.

## 1. Arquitetura
A arquitetura do sistema é composta pelos seguintes componentes:

- Storage Account: Armazena os arquivos do catálogo (imagens, vídeos, etc.).
- Cosmos DB: Armazena os metadados do catálogo (título, descrição, gênero, etc.).
-  Azure Functions: Funções serverless que implementam a lógica de negócios do sistema:
- Salvar Arquivos: Recebe arquivos e os armazena no Storage Account.
- Salvar Metadados: Recebe metadados e os armazena no Cosmos DB.
- Filtrar Catálogo: Permite filtrar os registros do catálogo por critérios específicos.
- Listar Catálogo: Lista os registros do catálogo, com suporte a paginação.

## 2. Tecnologias Utilizadas
- Azure Functions: Plataforma de computação serverless para executar o código do sistema.
- Azure Cosmos DB: Banco de dados NoSQL para armazenar os metadados do catálogo.
- Azure Storage: Serviço de armazenamento de objetos para guardar os arquivos do catálogo.
- Linguagem de Programação: Escolha uma linguagem suportada pelo Azure Functions (ex: C#, JavaScript, Python).
- SDKs do Azure: Bibliotecas para interagir com os serviços do Azure (Storage Account, Cosmos DB).

## 3. Implantação
-Criar Recursos no Azure:

- Crie um grupo de recursos para organizar seus serviços.
- Provisione uma conta do Storage Account.
- Crie uma conta do Cosmos DB com um banco de dados e um contêiner.
- Crie as funções do Azure (Salvar Arquivos, Salvar Metadados, Filtrar Catálogo, Listar Catálogo).
- Desenvolver Funções do Azure:

- Implemente a lógica de negócios de cada função utilizando a linguagem de programação escolhida e os SDKs do Azure.
- Utilize o SDK do Azure Storage para interagir com o Storage Account.
- Utilize o SDK do Azure Cosmos DB para interagir com o Cosmos DB.
- Configurar Funções do Azure:

- Configure as funções para serem acionadas por HTTP.
- Defina as rotas e os parâmetros de entrada para cada função.
- Configure as credenciais de acesso aos serviços do Azure (Storage Account, Cosmos DB).
- Implantar Funções do Azure:
-  Implante as funções para o Azure utilizando o Azure CLI, Visual Studio ou outras ferramentas de implantação.
## 4. Como Usar
- Salvar Arquivos:

- Envie os arquivos para a função "Salvar Arquivos".
- A função retornará a URL dos arquivos armazenados no Storage Account.
Salvar Metadados:

- Envie os metadados para a função "Salvar Metadados", incluindo as URLs dos arquivos.
- A função armazenará os metadados no Cosmos DB.

#- Filtrar Catálogo:

- Envie os critérios de filtro para a função "Filtrar Catálogo".
- A função retornará os registros do catálogo que correspondem aos critérios.

# -Listar Catálogo:

- Acesse a função "Listar Catálogo" para obter a lista de registros do catálogo.
- Utilize os parâmetros de paginação para navegar pelos resultados.

5. Próximos Passos
-  Implementar Interface de Usuário: Crie uma interface web ou mobile para facilitar o uso do sistema.
- Adicionar Autenticação e Autorização: Proteja o acesso às funções e aos dados do catálogo.
- Otimizar Desempenho: Utilize os recursos avançados do Cosmos DB para otimizar as consultas e o desempenho do sistema.
- Monitorar e Diagnosticar: Utilize as ferramentas do Azure para monitorar o desempenho das funções e diagnosticar erros.

