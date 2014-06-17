<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Game.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <script type="text/javascript">
    //Executes when the start game button is clicked.
    function onClickBtnStartGame() {

    }
  </script>
  <form>
    <input type="hidden" id="hddnGameSessionId" name="hddnGameSessionId" />
    <div id="divGameStart">
      <table>
        <tr>
          <td>Player 1 Name:</td>
          <td>
            <input type="text" id="Player1Name" />
          </td>
        </tr>
        <tr>
          <td>Player 2 Name:</td>
          <td>
            <input type="text" id="Player2Name" />
          </td>
        </tr>
        <tr style="text-align: center; vertical-align: central">
          <td colspan="2">
            <input type="button" id="btnStartGame" name="btnStartGame" onclick="onClickBtnStartGame()" />
          </td>
        </tr>
      </table>
    </div>
  </form>
</asp:Content>
