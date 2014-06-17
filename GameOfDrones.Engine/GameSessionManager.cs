using GameOfDrones.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfDrones.Engine
{
  /// <summary>
  /// Represents the class that holds manages a set of games.
  /// </summary>
  public static class GameSessionManager
  {
    private static IDictionary<string, Game> m_games =
      new Dictionary<string, Game>();

    /// <summary>
    /// Starts a new game.
    /// </summary>
    /// <param name="rules">The rules of the game.</param>
    /// <param name="player1Name">The name for player 1.</param>
    /// <param name="player2Name">The name for player 2.</param>
    /// <returns>The Game Session Id.</returns>
    public static string StartGame
      (GameRules rules, string player1Name, string player2Name)
    {
      Game   game          = new Game(rules, player1Name, player2Name);
      string gameSessionId = Guid.NewGuid().ToString();

      m_games.Add(gameSessionId, game);

      return gameSessionId;
    }

    /// <summary>
    /// Returns an started game by session Id.
    /// </summary>
    /// <param name="sessionId">The game session id.</param>
    /// <returns>The instance of the game.</returns>
    public static Game GetGame(string sessionId)
    {
      bool gameExists = false;
      Game game;

      gameExists = m_games.TryGetValue(sessionId, out game);

      if (!gameExists)
        throw new ElementNotFoundException(
          string.Format(GameEngineMessages.GameNotFoundError, sessionId));

      return game;
    }

    /// <summary>
    /// Gets the current started game count.
    /// </summary>
    /// <returns>The current started games count.</returns>
    public static int GetCurrentStartedCount()
    {
      return m_games.Count;
    }

    /// <summary>
    /// Finishes a game session.
    /// </summary>
    /// <param name="sessionId">The game session id.</param>
    public static void FinishGame(string sessionId)
    {
      if (!IsGameStarted(sessionId))
        throw new GameNotStartedException(
          string.Format(GameEngineMessages.FinishGameNotStartedError, sessionId));

      m_games.Remove(sessionId);
    }

    /// <summary>
    /// Finishes all games.
    /// </summary>
    public static void FinishAllGames()
    {
      m_games.Clear();
    }

    /// <summary>
    /// Verifies if a game is started.
    /// </summary>
    /// <param name="sessionId">Game session Id.</param>
    /// <returns>True, if the game is started. Otherwise, false.</returns>
    public static bool IsGameStarted(string sessionId)
    {
      return m_games.ContainsKey(sessionId);
    }
  }
}
