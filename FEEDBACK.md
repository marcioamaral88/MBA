# Feedback - Avaliação Geral

## Front End

### Navegação
  * Pontos positivos:
    - Projeto MVC com navegação funcional, CRUD de entidades operacionais na interface.
    - Controllers e views bem estruturadas.

  * Pontos negativos:
    - AuthController customizado no MVC, sendo desnecessário dado que o Identity já provê os fluxos via Razor.

### Design
  - Interface básica, com foco em funcionalidades administrativas. Cumpre o papel esperado.

### Funcionalidade
  * Pontos positivos:
    - CRUD funcional implementado nas camadas MVC e parcialmente na API.
    - Identity funcional nas duas camadas.
    - Seed de dados, migrations automáticas e SQLite corretamente aplicados.
    - No MVC, o vendedor é criado com ID compartilhado no momento da criação do usuário do Identity.
    - Modelagem de entidades simples, mas adequada ao domínio.

  * Pontos negativos:
    - CRUD na API está incompleto.
    - A criação do vendedor com o usuário do Identity não foi implementada na API.
    - Não há controle de domínio: qualquer vendedor pode alterar produtos de outros.
    - Duplicação do seed entre MVC e API.
    - Utilização de várias camadas sem necessidade (Model e Data poderiam ser uma camada `Core` única).
    - Muitos arquivos desnecessários versionados, como artefatos do Visual Studio (`.vs`, `.user`, `.suo`, `.v2`, `.bin`, etc.).

## Back End

### Arquitetura
  * Pontos positivos:
    - Separação modular em MVC, API, Dados e Modelo.

  * Pontos negativos:
    - Estrutura desnecessariamente segmentada para o nível do desafio.
    - Regras de negócio implementadas diretamente em controllers, sem serviços ou repositórios.
    - Múltiplos pontos de seed e configuração redundante.

### Funcionalidade
  * Pontos positivos:
    - Funcionalidade principal disponível nas telas principais.

  * Pontos negativos:
    - Ausência de validação de propriedade de produto.
    - API incompleta.
    - Lógica duplicada e descentralizada.

### Modelagem
  * Pontos positivos:
    - Modelos com estrutura clara e bem definida.
    - Simples e compatível com o escopo do projeto.

## Projeto

### Organização
  * Pontos positivos:
    - Estrutura modular com múltiplos projetos.
    - Uso de solution `.sln`, arquivos de configuração e documentação.

  * Pontos negativos:
    - Muitos arquivos desnecessários versionados.
    - Separação exagerada para a proposta do desafio.

### Documentação
  * Pontos positivos:
    - `README.md` e `FEEDBACK.md` presentes.

### Instalação
  * Pontos positivos:
    - Projeto executa localmente com SQLite e migrations.

  * Pontos negativos:
    - Duplicação de lógica de seed.

---

# 📊 Matriz de Avaliação de Projetos

| **Critério**                   | **Peso** | **Nota** | **Resultado Ponderado**                  |
|-------------------------------|----------|----------|------------------------------------------|
| **Funcionalidade**            | 30%      | 8        | 2,4                                      |
| **Qualidade do Código**       | 20%      | 7        | 1,4                                      |
| **Eficiência e Desempenho**   | 20%      | 7        | 1,4                                      |
| **Inovação e Diferenciais**   | 10%      | 8        | 0,8                                      |
| **Documentação e Organização**| 10%      | 7        | 0,7                                      |
| **Resolução de Feedbacks**    | 10%      | 8        | 0,8                                      |
| **Total**                     | 100%     | -        | **7,5**                                  |

## 🎯 **Nota Final: 7,5 / 10**
