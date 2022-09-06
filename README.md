# BioTranan

Hyggligt nöjd med denna backend. Uppgift Systemutvecklare YH 2021.

Har anpassat (och slimmat) repository mot kravställare från kund, och jag injecerar repository i controller.

Nästa projekt funderar jag på om en bättre lösning är att göra generic repository, som injectas i services som matchar entiteter 1:1 och ligger i Domain. Där services sedan injectas i controllers.


Fördelar är att man följer REST bättre, samt att man inte riskerar att få bloatade/spretiga repository interfaces.

Nackdelar är att det blir många endpoints och/eller services som inte kommer användas, samt att dependency injection container blir bloatad vid många entiteter.


Tror sista alternativet är att föredra och kommer välja denna lösning på nästa projekt. Ser mycket fram emot att bolla detta med framtida kollega över en kaffe :)

Projektet är förberett för att hänga på en UI-Head i React när den kursen börjar. Nuvarande UI-head är ett enklare C#/MVC.


![Screenshot](01_Arkitektur.png)
![Screenshot](02_db.png)
![Screenshot](04_API.png)
![Screenshot](05_UI.png)
![Screenshot](06_UI.png)




