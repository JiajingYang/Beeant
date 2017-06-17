﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Beeant.Presentation.Admin.Configurator.Sys.Event.List" MasterPageFile="~/Main.Master" %>
 <%@ Register src="/Controls/Pager.ascx" tagname="Pager" tagprefix="uc1" %>
 <%@ Register src="/Controls/DataSearch.ascx" tagname="DataSearch" tagprefix="uc2" %>
  <%@ Register src="/Controls/Progress.ascx" tagname="Progress" tagprefix="uc3" %>
      <%@ Register src="/Controls/Message.ascx" tagname="Message" tagprefix="uc4" %>
   <asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
   <title>系统事件列表</title>  
 </asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="Body" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div id="Edit" class="edit">
             <input type="button" id="Hide" class="btn" value="隐藏"/>
    <table class="tb">
        <tr>
            <td class="font">名称</td>
            <td  class="mtext"><input id="txtName" runat="server" type="text" class="input"  BindName="Name" SaveName="Name"  /></td>
         <tr>
         <td class="font">地址</td>
            <td  class="mtext"><input id="txtUrl" runat="server" class="input long"  type="text"  BindName="Url" SaveName="Url"  /> </td>
        </tr>
         <tr>
         <td class="font">操作类</td>
            <td  class="mtext"><input id="txtClassName" runat="server" class="input long"  type="text"  BindName="ClassName" SaveName="ClassName"  /> </td>
        </tr>
         <tr>
            <td colspan="2" class="center"><asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn"   /></td>
        </tr>
    </table>
     <uc4:Message ID="Message1" runat="server" />
 <input id="IdControl" type="hidden" runat="server" />
</div>
        <div id="divSearch" class="search" runat="server" >
           <table class="tb">
               <uc2:DataSearch ID="DataSearch1" runat="server" />
     </table>
        </div>

        <div class="mainten">
       <a href='javascript:void(0);' id="Add" class="btn" >添加</a>
        <asp:Button ID="btnRemove" runat="server" Text="删除" CssClass="btn"></asp:Button>
       
            <asp:Button ID="btnSearch" runat="server" Text="搜索" CssClass="btn"  />
            <asp:DropDownList ID="ddlEventName" runat="server" DataValueField="Name" DataTextField="Name"></asp:DropDownList>
            <input ID="txtEventArgs" type="text" runat="server" class="input"/>
            <asp:Button ID="btnExcute" runat="server" Text="立即执行" CssClass="btn mbtn" OnClick="btnExcute_Click"  />
        </div>

        <div class="list">
          <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table" DataKeyNames="Url">
       <Columns>
             <asp:BoundField  HeaderText="序号" ItemStyle-CssClass="sequence"/>
        <asp:TemplateField ItemStyle-CssClass="center ckbox">
            <HeaderTemplate>
             <input id="ckSelectAll" type="checkbox" AllCheckName="selectall"  />
            </HeaderTemplate>
            <ItemTemplate>
               <input value='<%#Eval("Id") %>' id="ckSelect" runat="server" type="checkbox" SubCheckName="selectall"  ComfirmValidate="Remove,Clear" />
           </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="编辑" ItemStyle-CssClass="center operate">
            <ItemTemplate>
                <asp:LinkButton runat="server" CommandName="Modify" CommandArgument='<%#Eval("Id") %>'>编辑</asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="名称"  ItemStyle-CssClass="left name">
            <ItemTemplate>
                <%#Eval("Name")%>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="地址" ItemStyle-CssClass="left">
            <ItemTemplate>
                <%#Eval("Url")%>
            </ItemTemplate>
        </asp:TemplateField>
                   <asp:TemplateField HeaderText="操作类" ItemStyle-CssClass="left">
            <ItemTemplate>
                <%#Eval("ClassName")%>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="录入时间" ItemStyle-CssClass="center time">
            <ItemTemplate>
                <%#Eval("InsertTime","{0:yyyy-MM-dd HH:mm}")%>
            </ItemTemplate>
        </asp:TemplateField>
        </Columns>
     </asp:GridView>
        </div>
     <uc1:Pager ID="Pager1" runat="server" PageSize="10"   SelectExp="Id,Name,Url,InsertTime" FromExp="EventEntity" />

     <uc3:Progress ID="Progress1" runat="server" />
     </ContentTemplate>
 </asp:UpdatePanel>

 </asp:Content>