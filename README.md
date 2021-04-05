_Repositório apenas para estudo_

# Cruso: Modelagem de Domínios Ricos

O curso Modelagem de Domínios Ricos foi criado para atender uma grande necessidade de todos os programadores:

Escrever aplicações corporativas complexas e com foco no negócio. E para isso é necessário mais do que tecnologia, é preciso conhecer muitos conceitos e padrões como DDD, CQRS, Event Sourcing e etc. São esses os pilares necessários para projetar arquiteturas modernas e distribuídas.

Neste curso você aprenderá todo conceito de forma prática e teórica e irá aprender a desenvolver uma aplicação separada em contextos independentes que se comunicam por eventos.

Apesar da complexidade de regras e de conceitos você será capaz de desenvolver aplicações fáceis de manter e estender, pois utilizaremos as práticas recomendadas que tornam o código desacoplado, simples de entender e fácil de testar.

Todos os códigos deste curso foram escritos com .NET Core (última versão)

Instrutor:

- [Eduardo Pires](https://www.eduardopires.net.br/)

Referências:

- https://desenvolvedor.io/curso-online-modelagem-de-dominios-ricos/

<br>
<br>

## Índice

1. Introdução
   1. Apresentação
   2. Objetivos do Curso
2. Visão Geral do DDD
   1. DDD não é arquitetura de camadas
   2. Quanto devo implementar o DDD?
   3. Visão global do DDD
3. Linguagem Ubíqua
   1. Apresentação
   2. Papeis dentro de um projeto
   3. Dicas essenciais
4. Modelagem Estratégica
   1. Context Map
   2. Bounded Context
   3. Definindo contextos delimitados
   4. Modelo de Negócio vs Modelo de Domínio
   5. Integridade do Modelo
   6. Tipos de relacionamento entre contextos
5. Estilo e Padrões Arquiteturais
   1. A evolução dos estilos arquiteturais
   2. Definindo um estilo arquitetural
   3. Transaction Script Pattern
   4. Table Module Pattern
   5. Domain Model Pattern
   6. Arquitetura Hexagonal
   7. Camadas sugeridas para atender o Domain Model
   8. Camada de apresentação (Presentation Layer)
   9. Camada de aplicação
   10. Camada de Domínio
   11. Camada de Infraestrutura
6. Modelagem Tática
   1. Domain Module
   2. Objetos de Valor (Value Objetcs)
   3. Entidades (Entities)
   4. Agregações (Aggregate)
   5. Serviços de Domínio
   6. Repositórios
   7. Eventos de Domínio
7. Mão na Massa - Modelagem Tática
   1. Iniciando o projeto
   2. Escrevendo a primeira entidade
   3. Validações de entidades
   4. Agregando com objetos de valor
   5. Testando comportamentos
   6. Persistindo com repositórios
   7. Utilizando serviços de domínio
   8. Lançando eventos de domínio
   9. Opções de camada de application
   10. Implementando a camada de application
   11. Conectando a camada de apresentação
   12. Desenvolvendo a apresentação - Validando o funcionamento
8. CQRS
   1. Apresentação
   2. Teorema CAP
   3. Como sincronizar as bases
   4. Command Stack - Query Stack
   5. Utilização de Sagas
9. Mão na Massa – CQRS
   1. Setup do BC de Vendas
   2. Objetos de Domínio
   3. Command e Command Handler
   4. Manipulando comandos na prática
   5. Tratamento de notificações
   6. Event e Event Handler
   7. Implementando Queries (Query Stack)
   8. Adicionando novas funcionalidades com comandos
   9. Integração de BC's - Processamento do pedido
   10. Integração de BC's – Pagamento
   11. Integração de BC's. Finalização do pedido
   12. Visão geral da implementação
   13. Trabalhando com Sagas, Service Bus e Filas MSMQ
10. Event Sourcing
    1. Sobre o que é
    2. Fatores essenciais
    3. [Mão na massa] - Setup do ES no projeto
    4. [Mão na massa] - Persistindo eventos
    5. [Mão na massa] - Finalizando a implementação do ES
11. Encerramento
    1. Palavras finais
    2. Zerei a vida ou só comecei
