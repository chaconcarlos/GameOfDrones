/// <reference path="../knockout-2.1.0.js" />
/// <reference path="../jquery-1.7.1.min.js" />

//Declaration of the game object prototype.
function gameData(
  player1Name,
  player2Name,
  scorePlayer1,
  scorePlayer2,
  lastPlayWinnerName,
  gameWinnerName) {
  var self = this;
    
  self.Player1Name        = player1Name;
  self.Player2Name        = player2Name;
  self.ScorePlayer1       = scorePlayer1;
  self.ScorePlayer2       = scorePlayer2;
  self.LastPlayWinnerName = lastPlayWinnerName;
  self.GameWinnerName     = gameWinnerName;
}

function gameViewModel(){
  var self = this;

  self.gameSessionId = ko.observable();
}

