<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="primeira_solucao_em_asp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row">
        <br />

        <br />
        <asp:Button ID="Button1" runat="server" Text="Inserir" OnClick="Button1_Click" />

        <br />
        <br />

        funcionário:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" Height="30px" Width="487px" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />

        <div runat="server" id="MyDiv">

            Salário:
            <br />

            <asp:TextBox ID="SalarioText" runat="server" Width="364px" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            Horas:<br />

            <input ID="HorasExtras" type="number" runat="server"  placeholder="insira a quantidade de horas" prefix="2"/>
            <br />
            <br />

            <asp:Button ID="Button2" runat="server" Text="Calcular horas" OnClick="Button2_Click" />
            <br />
            <br />

            Cálculo:
            <asp:TextBox ID="Calculo" runat="server" Width="364px" ReadOnly="True"></asp:TextBox>
            <br />
            <br />

        </div>

        <asp:GridView ID="GridView1" runat="server" Height="164px" Width="1129px"></asp:GridView>
    </div>

</asp:Content>
