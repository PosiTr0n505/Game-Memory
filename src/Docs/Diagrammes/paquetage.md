@startuml
hide circle
allowmixing
skinparam classAttributeIconSize 0
skinparam classBackgroundColor #ffffb9
skinparam classBorderColor #800000
skinparam classArrowColor #800000
skinparam classFontColor #black
skinparam classFontName Tahoma

package "Game Management" {
    interface IGameManager {
        +incrementMoves(): void
        +flipCard(x: int, y: int): void
        +startGame(): void
        +isGameOver(): bool
        +updateScore(score: int): void
        +switchPlayer(): void
    }

    class GameManager {
        +flipCard(): void
        +startGame(): void
        +isGameFinished(): bool
        +playRound(): void
    }

    class Game {
        +currentPlayer: Player
        +rounds: int
        +remainingCardsCount: int
        +switchPlayer(): void
    }

    class TwoPlayersGame {
        +nextTurn(): void
    }

    class SinglePlayerGame {
        +nextTurn(): void
    }
}

package "Player Management" {
    interface IScoreManager {
        +getScore(): int
        +saveScore(): void
        +incrementGamesPlayed(score: Score): void
        +changeBestScore(score: Score, best: int): void
    }

    class Player {
        -nameTag: string
        -currentScore: int
        -gamesPlayed: int
        -bestScore: int
        -movesCount: int
        +updateScore(score: int): void
        +incrementGamesPlayed(): void
        +incrementMoves(): void
    }

    class Score {
        +ScoreValue: int
        +gamesPlayed: int
    }

    class ScoreManager {
        +getScore(): int
        +addScore(score: Score): void
        +saveScore(): void
    }

    class Leaderboard {
        +addScore(player: Player, score: Score): void
        +getTopScores(gridSize: int): List<Score>
    }
}

package "Card and Grid Management" {
    interface ICardManager {
        +flipCard(card: Card): void
        +unflipCard(card: Card): void
        +compareCards(card1: Card, card2: Card): bool
        +matchCard(card: Card): void
    }

    class CardManager {
    }

    class Card {
        -id: int
        -isFaceUp: bool
        +flipCard(): void
        +compareCard(card: Card): bool
        +matchCard(): void
        +unflipCard(): void
    }

    enum GridSize
    enum CardType

    class Grid {
        +initializeGrid(): void
        +showGrid(): void
    }

    class Deck {
        +initializeDeck(): void
        +shuffleDeck(): void
        +drawCard(): Card
    }
}

package "Persistence" {
    interface ISaveManager {
        +saveGame(game: Game): void
    }

    interface ILoadManager {
        +loadGame(): Game
    }
}

' Dépendances entre paquets (conformes au diagramme de classes d'origine)
"Game Management" ..> "Player Management" : utilise
"Game Management" ..> "Card and Grid Management" : utilise
"Game Management" ..> "Persistence" : sauvegarde/charge
"Player Management" ..> "Card and Grid Management" : utilise GridSize
"Card and Grid Management" ..> "Player Management" : Score vers Player
"Player Management" ..> "Leaderboard Management" : Leaderboard

@enduml
