using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfDrones.Engine
{
  /// <summary>
  /// Represents a game of drones game.
  /// </summary>
  public class Game
  {
    private GameData  m_data;
    private GameRules m_rules;

    /// <summary>
    /// Gets the game Id.
    /// </summary>
    public int Id
    {
      get
      {
        return m_data.Id;
      }
    }

    /// <summary>
    /// Gets the score for player 1.
    /// </summary>
    public int ScorePlayer1
    {
      get
      {
        return m_data.ScorePlayer1;
      }
    }

    /// <summary>
    /// Gets the score for player 2.
    /// </summary>
    public int ScorePlayer2
    {
      get
      {
        return m_data.ScorePlayer2;
      }
    }

    /// <summary>
    /// Gets the player one's name.
    /// </summary>
    public string Player1Name
    {
      get 
      { 
        return m_data.Player1Name; 
      }
    }

    /// <summary>
    /// Gets the player two's name.
    /// </summary>
    public string Player2Name
    {
      get
      {
        return m_data.Player2Name;
      }
    }

    /// <summary>
    /// Gets the name of the player that won the last play.
    /// </summary>
    public string LastPlayWinnerName
    {
      get 
      { 
        return m_data.LastPlayWinnerName; 
      }
    }

    /// <summary>
    /// Gets the name of the game winner.
    /// </summary>
    public string WinnerName
    {
      get 
      { 
        return m_data.WinnerName; 
      }
    }

    /// <summary>
    /// Gets the list of available moves.
    /// </summary>
    public ICollection<string> AvailableMoves
    {
      get
      {
        return m_rules.GetMoves();
      }
    }

    public GameData Data
    {
      get
      {
        return m_data;
      }
    }

    /// <summary>
    /// Creates an instance of the Game class.
    /// </summary>
    public Game()
    {
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

      this.m_data             = new GameData();
      this.m_data.Player1Name = player1Name;
      this.m_data.Player2Name = player2Name;
      this.m_rules            = rules;
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

      Move       player1Move    = m_rules.GetMove(player1MoveName);
      PlayResult result         = player1Move.Play(player2MoveName);
      string     playWinnerName = string.Empty;

      switch (result)
      {
        case PlayResult.Draw:
          break;
        case PlayResult.Win:
          m_data.ScorePlayer1++;
          playWinnerName = Player1Name;
          break;
        case PlayResult.Lose:
          m_data.ScorePlayer2++;
          playWinnerName = Player2Name;
          break;
        default:
          throw new NotSupportedException(GameEngineMessages.PlayResultNotSupported);
      }

      if (HasWinner())
        m_data.WinnerName = playWinnerName;

      m_data.LastPlayWinnerName = playWinnerName;

      return playWinnerName;
    }

    /// <summary>
    /// Verifies if the current game has a winner.
    /// </summary>
    /// <returns>True, if the game has a winner. Otherwise, false.</returns>
    public bool HasWinner()
    {
      if ((ScorePlayer1 == this.m_rules.MaxWins) || (ScorePlayer2 == this.m_rules.MaxWins))
        return true;

      return false;
    }
  }
}
