using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GameOfDronesWebUI
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute(
        name: "game",
        routeTemplate: "api/{controller}/{id}",
        defaults: new {controller = "Game", id = RouteParameter.Optional }
      );

      config.Routes.MapHttpRoute(
        name: "startGame",
        routeTemplate: "api/game/start/id",
        defaults: new {controller = "Game", action = "Start"}
      );

      config.Routes.MapHttpRoute(
        name: "play",
        routeTemplate: "api/game/makeplay/id",
        defaults: new {controller = "Game", action = "play"}
      );

      config.Routes.MapHttpRoute(
        name: "moves",
        routeTemplate: "api/game/moves/{sessionId}",
        defaults: new {controller = "Game", action = "moves"}
      );
    }
  }
}
