📚 Sistema de Gerenciamento de Biblioteca
Este projeto é um Sistema de Gerenciamento de Biblioteca, no qual implementei funcionalidades completas para o controle de livros, usuários e empréstimos, garantindo um fluxo organizado e eficaz para o funcionamento de uma biblioteca.

✅ Principais Funcionalidades
Cadastro de Livros
Permite adicionar novos livros com todas as informações necessárias.

Validações dos Dados
Todas as entradas de dados são validadas com regras bem definidas.

Consulta de Livros

Listagem de todos os livros cadastrados

Consulta de um livro específico

Remoção de Livros
Exclusão segura de livros do sistema.

Cadastro de Usuários
Gerenciamento de usuários que podem realizar empréstimos.

Cadastro de Empréstimos
Registro de empréstimos com associação entre usuários e livros.

Definição de Data de Devolução
Estabelecimento da data prevista para devolução no momento do empréstimo.

Devolução de Livros
Registro e controle da devolução dos livros.

Mensagens Automáticas de Status
Geração automática de mensagens informando se:

O empréstimo está em dia ✅

Ou está em atraso ⚠️

Notificações por E-mail
Implementação de um serviço SMTP para envio de e-mails notificando os usuários sobre o status de seus empréstimos (em dia ou em atraso). 📩

🛠 Tecnologias e Boas Práticas Aplicadas
ASP.NET Core API – Backend robusto e escalável

Entity Framework Core – Acesso a dados com banco em memória para testes e SQL Server em produção

Arquitetura Limpa – Separação clara de responsabilidades entre as camadas da aplicação

CQRS com MediatR – Organização dos fluxos de comandos e consultas

Padrão Repository – Abstração do acesso a dados

FluentValidation – Validações robustas para entradas de dados

Serviço SMTP – Envio automatizado de e-mails de notificação
