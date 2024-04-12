<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TextAdventureRpgWebApp.Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <h1 id="aspnetTitle">Text Adventure RPG WebApp</h1>
        </section>
        
        
        <div class="row">
            <asp:Label ID="ConsoleLabel" runat="server"> <%=this.GetConsoleOutput()%> </asp:Label>
            <asp:TextBox ID="UserInputTextBox" name="UserInput" autofocus="autofocus" runat="server"  />
            <asp:Button UseSubmitBehavior="true" runat="server" Text="Go"/>
        </div>
        
    </main>

</asp:Content>
