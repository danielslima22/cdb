# cdb
Simulador simples do cálculo do CDB - Ele permite calcular e exibir os resultados de um investimento em CDB.

## - FrontEnd - Angular. 

## Pré-requisitos

- Node.js (versão 12 ou superior)
- Angular CLI (versão 10 ou superior)

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/danielslima22/cdb.git
   cd cdb

2. Instale as dependências:

bash
npm install

## Executando o Projeto
Para iniciar o servidor de desenvolvimento, execute:

bash
ng serve
O projeto estará disponível em http://localhost:4200/.

## Executando os Testes

Para executar os testes unitários, use o comando:

bash
ng test

Para executar os testes de ponta a ponta (e2e), use o comando:

bash
ng e2e

## Estrutura do Projeto

src/app: Contém os componentes e serviços do projeto.

components: Contém os componentes do projeto.
investment-form: Componente do formulário de simulação de CDB.
investment-result: Componente para exibir o resultado da simulação de CDB.
services: Contém os serviços do projeto.
cdb.service.ts: Serviço responsável por calcular os valores de CDB.

Tecnologias Utilizadas
Angular
Angular Material
RxJS

## - BackEnd - .Net. 

# CDB.API

## Descrição

CDB.API é uma API desenvolvida em **ASP.NET Core .NET 8** para calcular o rendimento de um Certificado de Depósito Bancário (**CDB**). O projeto segue os princípios **CQRS, SOLID e Clean Code**, garantindo **alta manutenibilidade e separação de responsabilidades**. Além disso, a API conta com **Swagger**, **ILogger** para logging e **testes automatizados** para garantir a qualidade do código.

---

## Tecnologias Utilizadas

- **.NET 8** (ASP.NET Core)
- **CQRS** (usando MediatR)
- **Princípios SOLID e Clean Code**
- **MediatR** para manipulação de comandos e queries
- **ILogger** para logging estruturado
- **Swagger** para documentação interativa da API
- **Testes automatizados** com xUnit e Moq

---

## Como Rodar o Projeto

### Requisitos

- **.NET 8 SDK** instalado
- Visual Studio 2022 (opcional)

### Executando no Terminal

1. Clone o repositório:
   ```sh
   git clone https://github.com/danielslima22/cdb.git
   ```
2. Acesse a pasta do projeto:
   ```sh
   cd cdb/CDB.API
   ```
3. Execute a API:
   ```sh
   dotnet run
   ```

### Executando no Visual Studio

1. Abra o **Visual Studio 2022**.
2. Carregue a solução **CDB.API.sln**.
3. Defina **CDB.API** como projeto de inicialização.
4. Pressione `F5` para rodar a API.

---

## Como Testar a API

### Acessando o Swagger

Após iniciar a API, acesse a documentação interativa via Swagger:

- **URL:** [https://localhost:7101/swagger/index.html](https://localhost:7101/swagger/index.html)

### Executando Testes Automatizados

Para rodar os testes unitários, use:

```sh
dotnet test
```

---

## Estrutura do Projeto

```
/CDB.API
├── Controllers/       # Controllers da API
├── Application/       # Lógica de aplicação (CQRS)
│   ├── Handlers/      # Handlers do CQRS
│   ├── Queries/       # Queries do CQRS
├── Services/          # Serviços de negócio
├── Models/            # Modelos de dados
├── Program.cs         # Arquivo principal do projeto
├── README.md          # Documentação do projeto
```

---

## Autor

- **Daniel Lima**
- **GitHub:** [danielslima22/cdb](https://github.com/danielslima22/cdb)
- **LinkedIn:** [linkedin.com/in/daniellima22](https://linkedin.com/in/daniellima22)

Se tiver dúvidas ou sugestões, fique à vontade para contribuir! 🚀
