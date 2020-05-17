# DesafioNinja-NET

## Tecnologias utilizadas:
```
.NET Core 3.1
EntityFramework
Microsoft SQLServer
NUnit
```
## IDEs
```
VSCode
VSCommunity
```
## Sistemas Operacionais
```
Windows
Pop!_OS - Ubuntu
```
# Instalação:
## Configurando projeto no SQLServer
Primeiro é necessário configurar o BD
* Abra o arquivo UniversidadeContext.cs na pasta raiz do diretório
* Edite a linha 14 com a seguinte configuração
```
@"Server={Nome do Servidor};Database={Nome do Banco};Trusted_Connection=true;MultipleActiveResultSets=true;User Id={Nome do usuário};Password={Senha};"
```


EXEMPLO 1:
```
@"Server=localhost;Database=UniversidadeDB;Trusted_Connection=true;MultipleActiveResultSets=true;User Id=SA;Password=123;"
```
EXEMPLO 2 (SQLEXPRESS):
```
@"Server=DESKTOP\SQLEXPRESS;Database=UniversidadeDB;Trusted_Connection=True;MultipleActiveResultSets=true;User Id=SA;Password=123;"
```

* Em seguida abra um prompt de comando na pasta raiz da aplicação
* Execute o seguinte comando para instalar o ef-tool caso não possua
```
dotnet tool install --global dotnet-ef --version 3.0.0
```
* Então execute o seguinte comando para criar o banco de dados no SQLServer
```
dotnet ef database update
```
Agora o aplicativo está pronto para uso.

# Executando o aplicativo

Execute pelo Visual Studio Community pressionando F10, ou pelo CMD/Shell pasta raiz da aplicação com o segunite comando:
```
dotnet run
```

# Testes unitários
![tests](https://user-images.githubusercontent.com/50475812/82154676-d1e78d80-9845-11ea-9fdb-db5b3a14ef1c.PNG)

## https://github.com/wdragow/DesafioNinja-NET-Tests
