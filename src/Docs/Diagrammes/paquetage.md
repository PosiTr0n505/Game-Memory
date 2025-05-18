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

package "GameCore" {
    class GameManager
    class Game
    interface IGameManager
}

package "PlayerSystem" {
    class Player
    class Score
    class Leaderboard
    interface IScoreManager
}

package "CardSystem" {
    class Card
    enum CardType
    enum GridSize
    interface ICardManager
}

package "Persistence" {
    interface ISaveManager
    interface ILoadManager
}

' Dépendances (exactes selon le diagramme de classes fourni)
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

@enduml
```