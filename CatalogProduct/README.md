# CatalogProduct

Este é um projeto ASP.NET 7 para gerenciar um catálogo de produtos.

## Requisitos

- .NET 7 SDK: Download
- Visual Studio 2022 ou superior: Download
- SQL Server ou outro banco de dados compatível

---

## Configuração do Ambiente

1. Clone o Repositório

```bash
git clone https://github.com/joaocarlossm/CatalogProduct.git
cd CatalogProduct
```

2. Configurar o Banco de Dados
Crie um banco de dados no SQL Server.
Atualize a string de conexão no arquivo appsettings.json com as informações do seu banco de dados:

```bash
"ConnectionStrings": {
  "DefaultConnection": "Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
}
```

3. Aplicar Migrações

```bash
dotnet ef database update
```
---

## Executando o Projeto
1. Via Visual Studio
- Abra o projeto no Visual Studio.
- Selecione a configuração de build desejada (Debug ou Release).
- Pressione F5 para iniciar o projeto.
2. Via CLI
  
```bash
dotnet build
dotnet run
```
---

## Estrutura do Projeto
- Controllers: Contém os controladores da API.
- Models: Contém as classes de modelo de dados.
- Data: Contém o contexto do banco de dados e as migrações.
- Services: Contém a lógica de negócios e serviços.

## Contribuição
1. Faça um fork do projeto.
2. Crie uma branch para sua feature

```bash
git checkout -b feature/nova-feature
```

3. Commit suas mudanças
```bash
git commit -m 'Adiciona nova feature'
```

4. Faça o push para a branch (git push origin feature/nova-feature).
5. Abra um Pull Request.

Contato
João Carlos - joaocarlossouzamagalhaes@gmail.com
