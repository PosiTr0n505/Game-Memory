``` plantuml
@startuml
hide circle
allowmixing
skinparam classAttributeIconSize 0
skinparam classBackgroundColor #ffffb9
skinparam classBorderColor #800000
skinparam classArrowColor #800000
skinparam classFontColor #black
skinparam classFontName Tahoma

' ---------------- CLASSES PRINCIPALES ----------------

class Player {
    - nameTag: string
    - currentScore: int
    - movesCount: int
}

class Score {
	-/ player: Player
    -/ scoreValue: int
    - gridSize: int
    - gamesPlayed: int
}


Score o--> Player

class Leaderboard {
    + addScore(Score: score): void
    + getTopScores(gridSize: int): List<Score>
}

Leaderboard o--> "0..*" Score : scores

class Game {
    - player1: Player
    - player2: Player
	- grid: Grid
    +/ currentPlayer: Player
    - rounds: int
    - remainingCardsCount: int
    + switchPlayer(): void
    + startGame(): void
    + isGameFinished(): bool
}

Game o--> Player : 2
Game *--> Grid

class Grid {
    + showGrid(): void
}

Grid o--> "0..*" Card : contient

class Card {
    - id: int
    -/ isFaceUp: bool
}

' ---------------- INTERFACES ----------------

interface IGameManager {
    + incrementMoves(): void
    + flipCard(x: int, y: int): void
    + startGame(): void
    + isGameFinished(): bool
	+ updateScore(score: int): void
    + switchPlayer(): void
}

interface IScoreManager {
    + getScore(): int
    + saveScore(): void 
    + incrementGamesPlayed(score: Score): void
    + changeBestScore(score: Score, int): void
}

interface IGridManager {
    + initializeGrid(): void
    + clearGrid(): void
}

interface ICardManager {
    + flipCard(card: Card): void
	+ unflipCard(card: Card): void
    + compareCards(card1: Card, card2: Card): bool
    + matchCard(card: Card): void
}

class ISaveManager {
    + saveGame(game: Game): void
}

class ILoadManager {
    + loadGame(): Game
}

' ---------------- IMPLEMENTATIONS DES MANAGERS ----------------

class GameManager
GameManager ..|> IGameManager
GameManager --> ISaveManager
GameManager --> ILoadManager
GameManager o--> '-/Game' Game

class ScoreManager
ScoreManager ..|> IScoreManager
ScoreManager --> Score
ScoreManager --> Leaderboard

class GridManager
GridManager ..|> IGridManager
GridManager --> Grid

class CardManager
CardManager ..|> ICardManager
CardManager --> Card
@enduml
```
