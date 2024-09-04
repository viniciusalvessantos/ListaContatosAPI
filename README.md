# Lista de Contatos - Arquitetura Modular com DDD e CQRS

Este repositório contém o código de uma aplicação de gerenciamento de contatos, desenvolvida como parte de um teste técnico para uma vaga de desenvolvedor. A aplicação utiliza **Arquitetura Modular**, **Domain-Driven Design (DDD)** e **CQRS (Command Query Responsibility Segregation)**, com foco em boas práticas de design e escalabilidade.

## Tecnologias Utilizadas

- **C# e .NET Core**: Linguagem e framework principais.
- **Entity Framework Core**: Para mapeamento objeto-relacional (ORM).
- **MediatR**: Implementação do padrão CQRS.
- **SQL Server**: Banco de dados relacional.
- **Arquitetura Modular**: Estrutura do projeto dividida em módulos independentes.
- **DDD (Domain-Driven Design)**: Aplicação dos conceitos de design orientado ao domínio.
- **CQRS**: Separação clara entre comandos (escrita) e consultas (leitura).

## Funcionalidades

- **CRUD de Contatos**: Operações de criar, ler, atualizar e deletar contatos.
- **Validações de Domínio**: Implementadas no nível de regras de negócio para garantir a integridade dos dados.
- **Camadas de Arquitetura**: O projeto segue o padrão de **Arquitetura Limpa (Clean Architecture)**, separando as responsabilidades em camadas de domínio, aplicação e infraestrutura.

## Estrutura do Projeto

O projeto foi organizado em módulos com o objetivo de facilitar a manutenção e escalabilidade:

- **Domínio**: Define as regras de negócio e as entidades.
- **Aplicação**: Contém os serviços de aplicação, comandos, e consultas.
- **Infraestrutura**: Implementa o repositório de dados e integrações externas.

## Objetivos

O objetivo deste projeto é demonstrar a capacidade de trabalhar com:

- **Arquitetura Modular**: Facilitando a escalabilidade e manutenção.
- **DDD**: Aplicando regras de negócio no coração da aplicação.
- **CQRS**: Segregando as operações de leitura e escrita para otimizar a performance.
- **Boas Práticas de Código**: Mantendo o projeto limpo, organizado e preparado para ambientes de produção.

## Como Executar o Projeto

1. Clone este repositório:
   ```bash
   git clone https://github.com/usuario/lista_de_contatos.git
   ```
## Como Executar o Projeto

1. **Configure o banco de dados (SQL Server)**:
   - Certifique-se de que as conexões de banco de dados estão corretas no arquivo de configuração.

2. **Restaure as dependências do projeto**:
   ```bash
   dotnet restore
   ```
