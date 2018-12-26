module Test

type RoomId = RoomId of string

type Room = 
    | Inactive of InactiveRoom 
    | Active of ActiveRoom

type InactiveRoom = {
    Id : RoomId
    StartDate : Date
    Players : WaitingPlayer list
}

type ActiveRoom = {
    Id : RoomId
    ActivationDate : Date
    Players : Players
    // CurrentQuestion : Question option
}

type CreateRoom = Date -> Result<InactiveRoom, RoomCreationError>

and CreationError = {
    ErrorDescription : string
}

type AddPlayer = (InactiveRoom -> WaitingPlayer) -> InactiveRoom

type RoomActivationInput = {
    Room : InactiveRoom
    Players : Players
}

type RoomActivationOutput = {
    Room : ActiveRoom
    PlayerOrder : PlayerOrder
}
// converts waitingplayers to activeplayers, assigns new activationdate, creates playerorder
type ActivateRoom = 
    RoomActivationInput -> Result<RoomActivationOutput, RoomActivationError>
// checks for min # of players
and ActivationError = {
    ErrorDescription : string
}

type PlayerId = PlayerId of int

type PlayerName = PlayerName of string

type Score = Score of int

type WaitingPlayer = {
    Id = PlayerId
    Name = PlayerName    
}

type ActivePlayer =
    | QuestionMaster of QuestionMaster
    | Respondent of Respondent

type QuestionMaster = {
    Id = PlayerId
    Name = PlayerName
    Score = Score
}

type Respondent = {
    Id = PlayerId
    Name = PlayerName
    Score = Score
}

type Players = Players of ActivePlayer[]

type PlayerOrder = PlayerOrder of PlayerId[]

type EstablishOrder = Players -> PlayerOrder

type Topic = Topic of string

type Question = {
    QuestionMaster : QuestionMaster
    Topic : Topic
}

// type UnansweredQuestion = {
//     QuestionMaster : Player
// }

// type AnsweredQuestion = {
//     QuestionMaster : Player
// }

type ResponseId = ResponseId of int

type Response = {
    Id = ResponseId
    PlayerId = PlayerId
}

type PoseQuestion = QuestionMaster -> Question

type SolicitResponse = 
    (Question -> Respondent) -> Response

type MasterSelectionInput = {
    PlayerOrder : PlayerOrder
    Players : Players
}

type SelectMaster = MasterSelectionInput -> Players

type AnswerMapping = {
    Answer : Response
    Player : Respondent // or ActivePlayer??
}

type MastersAnswers = AnswerMappings of AnswerMapping[]

type SolicitMastersAnswers = 
    (Players -> Response list) -> Result<MastersAnswers, MastersAnswersError>

and ScoringError = {
    ErrorDescription : string
}

// list of AnswerMappings??
type ScoreRound = MastersAnswers -> Result<Players, ScoringError>

and ScoringError = {
    ErrorDescription : string
}


// game is created

// people join waiting room

// game is instantiated

// -----

// question master is selected

// question master poses question

// all other players respond

// question master receives responses

// question master assigns responses

// score

// -----