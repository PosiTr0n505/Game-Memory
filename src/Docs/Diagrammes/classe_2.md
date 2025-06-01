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
    +/ ScoreValue: int
    - gamesPlayed: int
}

Score o--> "1" Player : "-/ player: Player"
Score o--> GridSize : "+/ GridSize: GridSize"

class Leaderboard {
    + addScore(Score: score)
    + getTopScores(gridSize: int): List<Score>
}

Leaderboard o--> "0..*" Score : "+/ Scores"

class Game {
    +/ currentPlayer: Player
    - rounds: int
    - remainingCardsCount: int
    + switchPlayer()
    + startGame()
    + isGameFinished(): bool
}

Game  o--> "1..2" Player : "+/Player1\n+/Player2"

class Card {
    - id: int
    -/ isFaceUp: bool
}

class ObservableObject {
    + event PropertyChangedEventHandler PropertyChanged
    + void OnPropertyChanged(string propertyName = null)
}

Player --|> ObservableObject
Game --|> ObservableObject
Card --|> ObservableObject


Card *--> CardType : "+/CardType"

class CardType <<enum>>

' ---------------- INTERFACES ----------------

interface IGameManager  <<interface>> {
    + incrementMoves()
    + flipCard(x: int, y: int)
    + startGame()
    + isGameOver(): bool
	+ updateScore(score: int)
    + switchPlayer()
}

interface IScoreManager  <<interface>> {
    + getScore(): int
    + saveScore()
    + incrementGamesPlayed(score: Score)
    + changeBestScore(score: Score, int)
}


interface ICardManager  <<interface>> {
    + flipCard(card: Card)
	+ unflipCard(card: Card)
    + compareCards(card1: Card, card2: Card): bool
    + matchCard(card: Card)
}

interface ISaveManager  <<interface>> {
    + saveGame(game: Game)
}

interface ILoadManager <<interface>> {
    + loadGame(): Game
}

' ---------------- IMPLEMENTATIONS DES MANAGERS ----------------

class GameManager
GameManager ..|> IGameManager
GameManager ..|> ISaveManager
GameManager ..|> ILoadManager
GameManager o--> "1" Game : "-/game"
GameManager *--> "1" CardManager
GameManager *--> "1" ScoreManager

GameManager ..> Player
GameManager ..> Score
GameManager ..> Card

class ScoreManager
ScoreManager ..|> IScoreManager
ScoreManager *--> "1" Leaderboard : +/Leaderboard

ScoreManager ..> Player
ScoreManager ..> Score

class CardManager
CardManager ..|> ICardManager
CardManager *--> "0..*" Card : "+/Cards"
CardManager *--> GridSize : "+/GridSize"

' DEPENDANCE
CardManager ..> GridSize

enum GridSize <<enum>>

Game ..> Score
Leaderboard ..> Player
IGameManager ..> Player
IGameManager ..> Score
IGameManager ..> Card

@enduml
```

Le point central de notre diagramme de classe est le GameManager, qui permet de coordonner les données via les managers, notre diagramme est composé de plusieurs classes : Card, Score, Player etcc.. qui sont controlées par des interfaces. <br><br>

- Game Manager : <br><br>

Nous avons utilisé un manager pour séparer notre jeu en plusieurs entités (Card, Game...) pour éviter que Game ait trop de responsabilités dans le jeu. <br>
( ---> ) Il est lié à Game, CardManager, ScoreManager pour accéder aux différents états et comportements. <br>
( ...> ) Il est en dépendance avec ISaveManager, ILoadManager et IGameManager car il permet d'injecter la persistance... <br>
GameManager utilise Player donc est également en dépendance avec. <br><br>


- Game : <br><br>

Composé de deux joueurs (player1 et player2), des attributs rounds (nombre de tours du jeu), remainingCardsCount (nombre de cartes restantes), currentPlayer(joueur actif). <br>
Son rôle est de représenter une partie en cours. <br>
Liens : <br>
Cardinalités 1...2 avec Player, car nous voulons exactement 1 ou 2 joueurs dans une partie.<br>
Lien avec IScoreManager pour se déléguer de la gestion du score.<br>
Game dépénd de Score pour gérer le score dans la partie.<br><br>

- CardManager :<br><br>

Son rôle est d'encapsuler toute la logique des cartes : les retourner, les associer, les comparer.<br>
Elle implémente l'interface ICardManager.<br>
Nous avons utilisé un Manager, car manipuler différentes cartes ne doit pas être de la responsabilité du GameManager mais d'un CardManager.<br>
CardManager dépend de GridSize pour pouvoir gérer la taille de la grille <br>

- ScoreManager :<br><br>

Son rôle est de gérer l'actualisation et les récupération des scores pour plus tard, les transférer au Leaderboard.<br>
Elle implémente l'interface IScoreManager.<br>
Nous avons décidé de ne pas mettre son contenu dans Player, car le Player recoit les scores grâce à currentScore mais Player ne les calcule pas et ne les stocke pas.<br>
ScoreManager dépend de Player pour pouvoir récupérer ou mettre à jour les scores liés à un joueur, dépend aussi de Score mais c'est déja implicite grâce à l'hériage de IScoreManager.<br><br>

- Leaderboard :<br><br>

Son rôle est d'afficher les scores des différents joueurs par taille de grille.<br>
Contient une List<Score>, car nous devons ordonner les scores ou les parcourir pour les afficher dans le classement<br>
Leaderboard est liée à GridSize qui permet de filtrer le leaderboard par différentes tailles de grilles. (4x4...)<br>
Leaderboard dépend de Player pour afficher les scores de ceux-ci.<br><br>

- Score : <br><br>

Son rôle est de stocker le score d'un joueur via ScoreValue et le nombre de parties jouées d'un joueur via gamesPlayed, elle référence Player car chaque score appartient à un joueur.<br><br>

- Card :<br><br>

Contient les attributs id (identifiant d'une carte) et isFaceUp (état de la carte).<br>
Association vers CardType pour comparer les cartes et les faire matcher.<br>
enum pour CardType, pour éviter de dupliquer les valeurs<br>
Association vers GridSize pour savoir comment placer une carte dans une grille.<br>
enum pour GridSize pour permettre de filtrer logiquement les tailles de grilles pour le leaderboard par exemple.<br>
Card dépénd de CardType <br>

