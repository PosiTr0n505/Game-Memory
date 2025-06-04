``` plantuml
@startuml
hide circle
allowmixing
skinparam classAttributeIconSize 0
skinparam classBackgroundColor #ffffb9
skinparam classBorderColor #800000
skinparam classArrowColor #800000
skinparam classFontColor black
skinparam classFontName Tahoma

' Déclaration des paquets
package "Game Management" {
    class GameManager
    class Game
    interface IGameManager
}

package "Player Management" {
    class Player
    class Score
    class Leaderboard
    class ScoreManager
    interface IScoreManager
}

package "Card Management" {
    class Card
    class CardManager
    enum CardType
    enum GridSize
    interface ICardManager
}

package "Persistence" {
    interface ISaveManager
    interface ILoadManager

    package "JSONPersistence" {
        class JsonSaveManager
        class JsonLoadManager
    }

    package "XMLPersistence" {
        class XmlSaveManager
        class XmlLoadManager
    }

    package "STUBPersistence" {
        class StubSaveManager
        class StubLoadManager
    }
}

JsonSaveManager ..|> ISaveManager
JsonLoadManager ..|> ILoadManager

XmlSaveManager ..|> ISaveManager
XmlLoadManager ..|> ILoadManager

StubSaveManager ..|> ISaveManager
StubLoadManager ..|> ILoadManager


' Dépendances internes aux classes
GameManager --> Game
GameManager ..> IGameManager
GameManager --> CardManager
GameManager --> ScoreManager
GameManager ..> ISaveManager
GameManager ..> ILoadManager

Game --> Player
Game --> IScoreManager

ScoreManager --> Leaderboard
Leaderboard --> Score
Score --> Player

CardManager ..> ICardManager
Card --> GridSize
Card --> CardType

' Dépendances entre paquetages
"Game Management" ..> "Player Management" : <<use>>
"Game Management" ..> "Card Management" : <<use>>
"Game Management" ..> "Persistence" : <<use>>
"Player Management" ..> "Card Management" : <<use>>
"Persistence" ..> "JSONPersistence" : <<include>>
"Persistence" ..> "XMLPersistence" : <<include>>
"Persistence" ..> "STUBPersistence" : <<include>>

```

Ce diagramme est divisé en 4 paquets : <br>
- **Game Management** <br>
- **Player Management**  <br>
- **Card Management**  <br>
- **Persistence**  <br> <br>

Chacun des paquets contient des classes (Models et Managers ainsi que des interfaces).  <br>

Le Game Management permet de gérer le déroulement d'une partie. <br>
Il contient  :  <br>
- **GameManager** qui est le contrôleur central d'une partie et qui gère la logique globale du jeu.  <br>
- **Game** qui représente l'état d'une partie ainsi que ses joueurs, ses tours, son nombre de cartes restantes etc..  <br>
- **IGameManager** qui est une interface permettant de gérer le démarrage d'une partie, la gestion des tours, la mise à jour du score..  <br> <br>

Le Player Management permet de gérer les joueurs ainsi que leurs scores.  <br>
Il contient :   <br>
- **ScoreManager** qui gère les calculs et la persistance des scores. <br>
- **IScoreManager** est une interface pour la gestion des scores. <br>
- **Leaderboard** : représente un classement, stocke plusieurs objets Score. <br>
- **Score**: encapsule un score individuel avec valeur et nombre de parties jouées. <br>
- **Player** : représente un joueur avec son nom, score courant et nombre de mouvements. <br>  <br>

Le Card Management permet de gérer les cartes et leurs propriétés.  <br>
Il contient : <br>
- **CardManager** qui contrôle les opérations sur les cartes (retournement, comparaison, appariement).<br>
- **ICardManager** est une interface agissant sur les opérations sur les cartes.<br>
- **Card** : classe représentant une carte, avec un identifiant(id) et un état visible(isFaceUp).<br>
- **CardType** et **GridSize** : enums définissant respectivement le type de carte et la taille de la grille<br><br>

La persistence permet de gérer la sauvegarde et le chargement des données. <br>
Elle contient les interfaces `ISaveManager` et `ILoadManager` qui définissent les contrats pour ces opérations.  

Le paquet **Persistence** est subdivisé en trois sous-paquets :  
- **JSONPersistence**: contenant `JsonSaveManager` et `JsonLoadManager`, qui assurent la persistance au format JSON.  
- **XMLPersistence**: contenant `XmlSaveManager` et `XmlLoadManager`, qui assurent la persistance au format XML.  
- **STUBPersistence**: contenant `StubSaveManager` et `StubLoadManager`, qui fournissent des implémentations factices utilisées pour le développement et les tests.

Ces implémentations concrètes respectent les interfaces de sauvegarde et de chargement, permettant ainsi à `GameManager` de rester découplé des détails spécifiques de persistance.
