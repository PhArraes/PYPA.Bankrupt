# PYPA.Bankrupt


## Dependências 
 <a href="https://dotnet.microsoft.com/download">dotnet core 2.2 SDK</a>
 
## Execução Comand Line
 Entrar no diretório: 
 ``` 
 PYPA.Bankrupt\PYPA.Bankrupt 
 ```
 Executar:
 ```
 $ dotnet build
 $ dotnet run
 ```
  
 
## Execução Visual Studio 2019
Abrir Solução:
``` 
PYPA.Bankrupt\PYPA.Bankrupt.sln
```
 Executar projeto console: 
 ``` 
 PYPA.Bankrupt\PYPA.Bankrupt 
 ```


## Formato da Saída
```
Quantas partidas terminam por time out:
         => 0
Quantos turnos em média demora uma partida:
         => 92
Qual a porcentagem de vitórias por comportamento dos jogadores:
         => aleatório = 18,33%
         => cauteloso = 25,00%
         => exigente = 19,00%
         => impulsivo = 35,67%
Qual o comportamento que mais vence:
         => impulsivo
```

## Opcional
  Especificar o número de vezes que as simulações serão executadas
 ```
 $ dotnet run 3
 ```
 Saída:
 ```
Quantas partidas terminam por time out:
         => 0
Quantos turnos em média demora uma partida:
         => 95
Qual a porcentagem de vitórias por comportamento dos jogadores:
         => aleatório = 16,67%
         => cauteloso = 27,00%
         => exigente = 19,33%
         => impulsivo = 35,67%
Qual o comportamento que mais vence:
         => impulsivo
---------------------------------------------------
Quantas partidas terminam por time out:
         => 2
Quantos turnos em média demora uma partida:
         => 100
Qual a porcentagem de vitórias por comportamento dos jogadores:
         => aleatório = 19,00%
         => cauteloso = 24,67%
         => exigente = 21,67%
         => impulsivo = 34,67%
Qual o comportamento que mais vence:
         => impulsivo
---------------------------------------------------
Quantas partidas terminam por time out:
         => 0
Quantos turnos em média demora uma partida:
         => 91
Qual a porcentagem de vitórias por comportamento dos jogadores:
         => aleatório = 17,67%
         => cauteloso = 25,00%
         => exigente = 20,00%
         => impulsivo = 37,33%
Qual o comportamento que mais vence:
         => impulsivo
---------------------------------------------------
 ```
