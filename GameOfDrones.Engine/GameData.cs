using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Engine
{
  /// <summary>
  /// Represents the game data.
  /// </summary>
  [Serializable]
  public class GameData
  {
    private int    m_id                 = 0;
    private int    m_scorePlayer1       = 0;
    private int    m_scorePlayer2       = 0;
    private string m_lastPlayWinnerName = string.Empty;
    private string m_winnerName         = string.Empty;
    private string m_player1Name;
    private string m_player2Name;

    /// <summary>
    /// Gets the game Id.
    /// </summary>
    public int Id
    {
      get
      {
        return m_id;
      }
      internal set
      {
        m_id = value;
      }
    }

    /// <summary>
    /// Gets the score for player 1.
    /// </summary>
    public int ScorePlayer1
    {
      get
      {
        return m_scorePlayer1;
      }
      internal set
      {
        m_scorePlayer1 = value;
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
      internal set
      {
        m_scorePlayer2 = value;
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
      internal set
      {
        m_player1Name = value;
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
      internal set
      {
        m_player2Name = value;
      }
    }

    /// <summary>
    /// Gets the name of the player that won the last play.
    /// </summary>
    public string LastPlayWinnerName
    {
      get 
      { 
        return m_lastPlayWinnerName; 
      }
      internal set
      {
        m_lastPlayWinnerName = value;
      }
    }

    /// <summary>
    /// Gets the name of the game winner.
    /// </summary>
    public string WinnerName
    {
      get 
      { 
        return m_winnerName; 
      }
      internal set
      {
        m_winnerName = value;
      }
    }
  }
}
