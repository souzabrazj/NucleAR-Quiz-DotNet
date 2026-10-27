# NucleAR Quiz - Módulo .NET (PoC Administrativa)

## Grupo e Integrantes
João Victor de Souza Braz - RM566862
Felipe Cuesta Puerta de Oliveira - RM567703
Vitor Costa de Godoi - RM568448
Vitor Santos Domingues - RM568375
Lucas Pompeu - RM567010
Turma: 2TDSPR

## Descrição Resumida da Solução
O **NucleAR Quiz** é uma plataforma digital interativa e gamificada desenvolvida em parceria com a Amazul/CTMSP para aproximar a sociedade da tecnologia nuclear, desmistificando estigmas e evidenciando as suas aplicações pacíficas, seguras e indispensáveis (como na medicina, agricultura e geração de energia).

## O que foi desenvolvido nesta Sprint
Nesta Sprint Flash de ideação, desenvolvemos uma aplicação console em .NET 8.0 focada na **Gestão de Competições (Torneios)** do painel administrativo da solução[cite: 1, 2]. A aplicação conta com:
* **Entidade de Domínio:** Gestão da entidade `Competicao` com atributos coerentes com o tema.
* **Validações e Regras de Negócio:** Validação de campos obrigatórios e regra restritiva garantindo entre 4 e 10 questões por torneio para a calibragem do temporizador proporcional[cite: 2].
* **Operações completas:** Cadastro de novos registos, listagem geral e busca flexível por critérios (nome ou categoria temática)[cite: 1].
* **Persistência Local:** Salvamento e recuperação automática dos dados em ficheiro JSON, garantindo a permanência entre execuções[cite: 1].
* **Tratamento de Erros:** Estruturas robustas de `try/catch` assegurando que a aplicação não quebre inesperadamente[cite: 1].
  
## Instruções de Execução
1. Certifica-te de ter o [.NET 8.0 SDK](https://dotnet.microsoft.com/) instalado na tua máquina.
2. Clona este repositório e acede à pasta do projeto via terminal.
3. Executa o comando abaixo para iniciar a aplicação:
   ```bash
   dotnet run

## Como o .NET se aplica à solução do grupo
O ecossistema .NET complementa perfeitamente a arquitetura do projeto ao fornecer alta performance, tipagem estática robusta e facilidade na construção de microsserviços de apoio e ferramentas utilitárias administrativas. Enquanto o core da aplicação e as APIs principais são estruturados em Java[cite: 1], a introdução do .NET nesta Prova de Conceito demonstra versatilidade tecnológica na gestão de dados e validações de domínio, garantindo agilidade no desenvolvimento de backends complementares para o ecossistema educacional da Amazul/CTMSP[cite: 1, 2].
