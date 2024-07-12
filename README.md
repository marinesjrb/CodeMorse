# Code Challenge: Codigo Morse
Este programa tem como objetivo traduzir mensagens escritas em código morse para mensagens regulares de texto.

Foi escrito em .Net 6.0 e organizado como um MVC simples para uma solução escalável e simples, com entrada da requisição via HTTPS método POST 
a uma Controller pela rota "/v1/decodes/morsecodes", seguinte os padrões de boas práticas de nomenclatura e responsabilidade de REST APIs,
possibilitando versionamento e crescimento da aplicação para demais futuras possíveis traduções e operações.
Possui também um Handler que contém de fato o código que realiza a tradução e lança uma exceção caso algo no fluxo não saia como planejado.
Na pasta Utils, temos a criação de um dicionário de tradução dos símbolos para caracteres de texto regular.

Em uma pasta à parte, na CodeMorseTests, temos os testes unitários da função Handle implementada.

Testes de integração podem ser feitos via CLI ou interface swagger, configurada no Program.cs deste repositório.

## Índice
- [Instalação](#instalação)
- [Como usar](#como-usar)

## Instalação

Para rodar o projeto, clone este repositório e, dentro da pasta CodeMorse do projeto, execute:

`dotnet run`


## Como usar

### 1. CLI
  
- Para enviar uma requisição via CLI e ter seu código morse traduzido, dado que o programa já está rodando, execute:

`curl -k -X POST "{{LOCAL_URL}}/v1/decodes/morsecode" -H "Content-Type:application/json" -d '"YOUR_MORSE_CODE_HERE"'`

e o retorno será uma string com o texto traduzido.

exemplo:

- Para enviar uma única requisição via CLI com múltiplos códigos morse a traduzir, pode executar:

`curl -k -X POST "{{LOCAL_URL}}/v1/decodes/morsecodes" -H "Content-Type:application/json" -d '{ "codes": [ YOUR_LIST_OF_CODES_HERE ]}'`

e o restorno será uma lista `texts` de strings traduzidas.

exemplo:

`curl -k -X POST "{{LOCAL_URL}}/v1/decodes/morsecodes" -H "Content-Type:application/json" -d '{ "codes": [ ".-", ".-", " .- ", ".... . -.--   .--- ..- -.. ." ]}'`

onde a url padrão setada neste projeto é `https://localhost:7288`

### 2. SWAGGER
  
Caso queira, o projeto também possui uma página Swagger e requisições podem ser utilizadas pela interface. É só rodar o projeto

`dotnet run`

e acessar a raiz da url onde ele estiver disponível:

url padrão configurada neste projeto: `https://localhost:7288`

pela interface do swagger, pode clicar em "Try it out" na rota desejada e inserir sua entrada.


## Testes

Aqui estão descritas algumas opções de teste (os símbolos '/'representam um terceiro espaço separados entre palavras):

| request | response |
| -------- | -------- |
| "AA" | "" |
| "" | "" |
| " " | "" |
| ".- -... -.-." | "ABC" |
| ".... . -.-- / .--- ..- -.. ." | "HEY JUDE" |
| ".- / .-.. ..- .-   -- . / - .-. .- .. ..-" | "A LUA ME TRAIU" |
| ".- ...- .. .- --- / ... . -- / .- ... .-" | "AVIAO SEM ASA" |
| "..-. --- ..- --. . .. .-. .- / ... . -- / -... .-. .- ... .-" | "FOGUEIRA SEM BRASA" |
| "WW .- -... -.-. !!" | "ABC" |

O projeto ainda possui testes unitários, que [podem ser rodados via terminal](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test#examples:~:text=command%20line.-,Examples,-Run%20the%20tests) desta forma:

`dotnet test ../CodeMorseTests/CodeMorseTests.csproj`


Para demais testes, segue abaixo a tabela de Código Morse:

![image](https://super.abril.com.br/wp-content/uploads/2022/10/SI_codigomorse_site2.jpg?quality=90&strip=info&w=1024)

