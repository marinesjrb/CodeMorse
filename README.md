# Code Challenge: Codigo Morse
Este programa tem como objetivo traduzir mensagens escritas em código morse a mensagens regulares de texto.

## Índice
- [Instalação](#instalação)
- [Como usar](#como-usar)

## Instalação

Para rodar o projeto, clone este repositório e execute:
dotnet run


## Como usar

Para enviar uma requisição e ter seu código morse traduzido:
curl -k -X POST "{{LOCAL_URL}}/v1/decodifications" -H "Content-Type:application/json" -d '{"request": "YOU_MORSE_CODE_HERE"}'

Caso queira, o projeto também possui uma página Swagger e requisições podem ser utilizadas pela interface. É só rodar o projeto
dotnet run
e acessar a raiz da url onde ele estiver disponível:
ex: https://localhost:7288

Aqui e no swagger estão descritas opções de teste:
request - response
"AA" - ""
"" - ""
" " - ""
".- -... -.-." - "ABC"
".... . -.--   .--- ..- -.. ." - "HEY JUDE"
".-   .-.. ..- .-   -- .   - .-. .- .. ..-" - "A LUA ME TRAIU"
"WW .- -... -.-. !!" - "ABC"

Para demais testes, segue abaixo a tabela de Código Morse:


