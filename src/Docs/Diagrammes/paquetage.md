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
    interface IScoreManager
}

package "Card Management" {
    class Card
    enum CardType
    enum GridSize
    interface ICardManager
}

package "Persistence" {
    interface ISaveManager
    interface ILoadManager
}

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

@enduml
