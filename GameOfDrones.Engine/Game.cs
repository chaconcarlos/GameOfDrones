using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Engine
{
  /// <summary>
  /// Represents a game of drones game.
  /// </summary>
  public class Game : IGame
  {
    private int       m_scorePlayer1 = 0;
    private int       m_scorePlayer2 = 0;
    private string    m_player1Name;
    private string    m_player2Name;
    private GameRules m_rules;

    /// <summary>
    /// Gets the score for player 1.
    /// </summary>
    public int ScorePlayer1
    {
      get
      {
        return m_scorePlayer1;
      }
    }

    /// <summary>
    /// Gets the score for player 2.
    /// </summary>
    public int ScorePlayer2
    {
      get
      {
        return m_scorePlayer2;
      }
    }

    /// <summary>
    /// Gets the player one's name.
    /// </summary>
    public string Player1Name
    {
      get 
      { 
        return m_player1Name; 
      }
    }

    /// <summary>
    /// Gets the player two's name.
    /// </summary>
    public string Player2Name
    {
      get
      {
        return m_player2Name;
      }
    }

    /// <summary>
    /// Gets the rules for the current game.
    /// </summary>
    public GameRules Rules
    {
      get 
      { 
        return m_rules; 
      }
    }

    /// <summary>
    /// Creates an instance of the Game class.
    /// </summary>
    /// <param name="rules">The rules for the current game.</param>
    /// <param name="player1Name">The player one's name.</param>
    /// <param name="player2Name">The player two's name.</param>
    public Game(GameRules rules, string player1Name, string player2Name)
    {
      if (rules.GetMoves().Count < 1)
        throw new ArgumentException(GameEngineMessages.CreateGameEmptyMovesError);

      if ((string.IsNullOrEmpty(player1Name)) || (string.IsNullOrEmpty(player2Name)))
        throw new ArgumentException(GameEngineMessages.PlayerNameEmptyError);

      this.m_player1Name = player1Name;
      this.m_player2Name = player2Name;
      this.m_rules       = rules;
    }

    /// <summary>
    /// Makes a play in the current game.
    /// </summary>
    /// <param name="player1MoveName">The player 1's move.</param>
    /// <param name="player2MoveName">The player 2's move.</param>
    /// <returns>The name of the player that won the play.
    /// If there is a Draw, returns empty.</returns>
    public string Play(string player1MoveName, string player2MoveName)
    {
      if (this.HasWinner())
        throw new InvalidOperationException(GameEngineMessages.PlayHasWinnerError);

      if ((string.IsNullOrEmpty(player1MoveName)) || (string.IsNullOrEmpty(player2MoveName)))
        throw new ArgumentException(GameEngineMessages.PlayEmptyMoveNameError);

      Move player1Move  = Rules.GetMove(player1MoveName);
      PlayResult result = player1Move.Play(player2MoveName);

      switch (result)
      {
        case PlayResult.Draw:
          return string.Empty;
        case PlayResult.Win:
          m_scorePlayer1++;
          return Player1Name;
        case PlayResult.Lose:
          m_scorePlayer2++;
          return Player2Name;
        default:
          throw new NotSupportedException(GameEngineMessages.PlayResultNotSupported);
      }
    }

    /// <summary>
    /// Verifies if the current game has a winner.
    /// </summary>
    /// <returns>True, if the game has a winner. Otherwise, false.</returns>
    public bool HasWinner()
    {
      if ((ScorePlayer1 == this.Rules.MaxWins) || (ScorePlayer2 == this.Rules.MaxWins))
        return true;

      return false;
    }

    /// <summary>
    /// Returns the name of the winner.
    /// </summary>
    /// <returns>The name of the winner. If there is no winner yet,
    /// returns empty.</returns>
    public string getWinnerName()
    {
      if (!HasWinner())
        return string.Empty;

      if (ScorePlayer1 == Rules.MaxWins)
        return Player1Name;

      return Player2Name;
    }
  }
}
