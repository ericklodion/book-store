
# Book Stores

Este projeto implementa de forma basica a relação entre autores, assuntos, tabelas de preço e livros de uma livraria. Tenha em vista que em um projeto real contaríamos com muitos outros dados, ferramentas, funcionalidades e técnicas de desenvolvimento.


## Ferramentas e tecnologias utilizadas

- Angular 6
- Node v14.16.1
- .NET 6
- Postgresql
## Setup backend

- Informe a string de conexão do seu banco Postgresql nos projetos bs-api e bs-data.
- Execute o seguinte comando para instalação do dotnet-ef
```bash
  dotnet tool install --global dotnet-ef
```
- Execute o comando abaixo para criação do seu banco de dados
```bash
  dotnet ef database update --project bs-data
```
- Abra o arquivo Scripts.sql que se encontra dentro do projeto bs-data e execute-o diretamente no banco de dados.


## Setup frontend

- Execute o seguinte comando para instalação dos pacotes necessários
```bash
  npm install
```
- Altere o arquivo envirolment.ts com o endereço da sua API backend
- Execute o projeto com o comando abaixo
```bash
  ng serve
```
## Autores

- [@ericklodion](https://www.github.com/ericklodion)

