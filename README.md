# **Gestão de Mini Loja Virtual - BOM NEGÓCIO - com Cadastro de Produtos e Categorias **

## **1. Apresentação**

Bem-vindo ao repositório do projeto **Mini Loja Virtual - Bom Negócio**. Este projeto é uma entrega do MBA DevXpert Full Stack .NET e é referente ao módulo 1 ** (C#, 
ASP.NET Core MVC, SQL, EF Core, APIs REST)  **, o sistema tem o objetivo de realizar a gestão simplificada de produtos e categorias em um formato tipo e-commerce marketplace.
A aplicação consistirá em uma plataforma web básica com uma interface 
intuitiva, que possibilite ao usuário realizar registro/login de usuário, cadastrar, 
visualizar, atualizar e remover categorias e produtos, além de consultar esses 
dados através de uma API REST básica. 

### **Autor(es)**
- **Márcio do Rosário Amaral**


## **2. Proposta do Projeto**

O projeto consiste em: 
     Criar uma aplicação simples, utilizando um pouco de cada conceito ensinado nos cursos básicos (C#, ASP.NET Core MVC, SQL, EF Core, APIs REST), e com isso mostrar uma aplicação funcional.

- **Aplicação MVC:** Interface web para interação com o Vendedor.
- **API RESTful:** Exposição dos recursos de Acesso e Produtos para integração com outras aplicações ou desenvolvimento de front-ends alternativos.
- **Autenticação e Autorização:** Implementação de controle de acesso, diferenciando administradores e usuários comuns.
- **Acesso a Dados:** Implementação de acesso ao banco de dados através de ORM.

## **3. Tecnologias Utilizadas**

- **Linguagem de Programação:** C#
- **Frameworks:**
  - ASP.NET Core MVC
  - ASP.NET Core Web API
  - Entity Framework Core
- **Banco de Dados:** SQL Server e SQLITE
- **Autenticação e Autorização:**
  - ASP.NET Core Identity
  - JWT (JSON Web Token) para autenticação na API
- **Front-end:**
  - Razor Pages/Views
  - HTML/CSS para estilização básica
- **Documentação da API:** Swagger

## **4. Estrutura do Projeto**

A estrutura do projeto é organizada da seguinte forma:


- BomNegocio/
  - BomNegocio.Web/ - Projeto MVC
  - BomNegocio.Api/ - API RESTful
  - BomNegocio.Dados/ - Modelos de Dados e Configuração do EF Core
  - BomNegocio.Modelo/ - Aqui fica as entidades utilizadas na aplicação
- README.md   - Arquivo de Documentação do Projeto
- FEEDBACK.md - Arquivo para Consolidação dos Feedbacks
- .gitignore  - Arquivo de Ignoração do Git

## **5. Funcionalidades Implementadas**

- **CRUD para Produtos e Categorias:** Permite criar, editar, visualizar e excluir Produtos e Categorias.
- **Autenticação e Autorização:** Diferenciação entre usuários comuns e Vendedores.
- **API RESTful:** Exposição de endpoints para operações CRUD via API.
- **Documentação da API:** Documentação automática dos endpoints da API utilizando Swagger.

## **6. Como Executar o Projeto**

### **Pré-requisitos**

- .NET SDK 8.0 ou superior
- SQL Server
- Visual Studio 2022 ou superior (ou qualquer IDE de sua preferência)
- Git

### **Passos para Execução**

1. **Clone o Repositório:**
   - `git clone https://github.com/marcioamaral88/MBA.git`
   - `cd nome-do-repositorio`

2. **Configuração do Banco de Dados:**
   - No arquivo `appsettings.json`, já estpa configurado a string de conexão do SQLITE.
   - Rode o projeto para que a configuração do Seed crie o banco e popule com os dados básicos

3. **Executar a Aplicação MVC:**
   - `cd BomNegocio/BomNegocio.Web/`
   - `dotnet run`
   - Acesse a aplicação em: http://localhost:5000

4. **Executar a API:**
   - `cd BomNegocio/BomNegocio.Api/`
   - `dotnet run`
   - Acesse a documentação da API em: http://localhost:5001/swagger

## **7. Instruções de Configuração**

- **JWT para API:** As chaves de configuração do JWT estão no `appsettings.json`.
- **Migrações do Banco de Dados:** As migrações são gerenciadas pelo Entity Framework Core. Não é necessário aplicar devido a configuração do Seed de dados.

## **8. Documentação da API**

A documentação da API está disponível através do Swagger. Após iniciar a API, acesse a documentação em:

http://localhost:5001/swagger

## **9. Avaliação**

- Este projeto é parte de um curso acadêmico e não aceita contribuições externas. 
- Para feedbacks ou dúvidas utilize o recurso de Issues
- O arquivo `FEEDBACK.md` é um resumo das avaliações do instrutor e deverá ser modificado apenas por ele.
