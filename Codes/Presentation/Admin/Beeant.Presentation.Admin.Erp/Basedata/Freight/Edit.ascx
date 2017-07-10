<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Edit.ascx.cs" Inherits="Beeant.Presentation.Admin.Erp.Basedata.Freight.Edit" %>
<%@ Import Namespace="Winner.Persistence" %>
     

<%@ Register Src="/Controls/GeneralDropDownList.ascx" TagName="GeneralDropDownList" TagPrefix="uc8" %>
     

<div class="edit">
    <table class="tb">
        <tr>
            <td class="font">名称</td>
            <td class="mtext" colspan="3">
             <input id="txtName" runat="server"  type="text" class="input long"  BindName="Name" SaveName="Name"  /> 
            </td>
            
        </tr>
        
  
     <tr>
         <td class="font">类型</td>
         <td class="mtext"  >
             <uc8:GeneralDropDownList ID="ddlType" runat="server" SaveName="Type" BindName="Type" ObjectName="Beeant.Domain.Entities.Basedata.FreightType" IsEnum="True" />
         </td>
            <td class="font">满额包邮</td>
            <td class="text" >
             <input id="txtFullFreePrice" runat="server"  type="text" class="input"  BindName="FullFreePrice" SaveName="FullFreePrice"  /> 
            </td>
            
        </tr>
        <tr>
            <td class="font">默认价格</td>
            <td class="mtext" >
                <input id="txtDefaultPrice" runat="server"  type="text" class="input"  BindName="DefaultPrice" SaveName="DefaultPrice"  /> 
            </td>
            <td class="font">默认数量</td>
            <td class="mtext" >
                <input id="txtDefaultCount" runat="server"  type="text" class="input"  BindName="DefaultCount" SaveName="DefaultCount"  /> 
            </td>
        </tr>
        <tr>
            <td class="font">续件价格</td>
            <td class="mtext" >
                <input id="txtContinuePrice" runat="server"  type="text" class="input"  BindName="ContinuePrice" SaveName="ContinuePrice"  /> 
            </td>
            <td class="font">续件数量</td>
            <td class="mtext" >
                <input id="txtContinueCount" runat="server"  type="text" class="input"  BindName="ContinueCount" SaveName="ContinueCount"  /> 
            </td>
        </tr>
        <tr>
           <td class="font">描述</td>
           <td class="text"  colspan="3" >
                 <input id="txtDescription" runat="server"  type="text" class="input long"   BindName="Description" SaveName="Description"   />
                 
            </td>
        </tr>
         
        <tr>
            <td colspan="4" class="text">
                 <table class="intb" id="divRegion" >
                    <tr Instance="RegionTemplate">
                        <td class="infont" style="width: 300px;">默认运费
                        <input type="hidden" name="RegionRegion"/>
                        </td>
                        <td class="intext">
                            配送方式
                              <input type="text" name="RegionName"  class="input shortinput" value="5" /> 
                             开始<input type="text" name="RegionDefaultCount" filtername="int" class="input shortinput" value="1"/> 
                             件内，
                             <input type="text" name="RegionDefaultPrice" filtername="decimal" class="input shortinput" value="5" /> 元， 每增加
                              <input type="text" name="RegionContinueCount" filtername="int" class="input shortinput" value="1"/> 
                              <span name="UnitType"></span>， 增加运费
                              <input type="text" name="RegionContinuePrice" filtername="decimal" class="input shortinput" value="1"/> 元
                        </td>
                        <td class="intext" style="width: 30px;"></td>
                    </tr>
                    </table>
                    <a href="javascript:void(0);" id="btnRegionAddId">为指定地区城市设置运费</a>
            </td>
        </tr>
   
         <tr>
            <td colspan="4" class="center"><asp:Button ID="btnSave" runat="server" Text="保存" CssClass="btn"   />
             <input id="btnClose" type="button" value="关闭" class="btn"  /></td>
        </tr>
    </table>
 
</div>
<div id="divDistrict" class="freight" style="display: none;" >
    <div class="content">
        <%=GetDistrictHtml() %>
    </div>
    
    <div class="sure"><input type="button" value="确定"/></div>
</div>
<input id="hfRegion" runat="server"  type="hidden"   BindName="Region" SaveName="Region"   />
<script type="text/javascript" src="/Scripts/Winner/CheckBox/Winner.CheckBox.js"></script>
<script type="text/javascript" src="/Scripts/Freight.js"></script>
 <script type="text/javascript">
     function InitFreight() {
         var freight = new Freight("divRegion", "btnRegionAddId", "divDistrict");
         freight.Initialize();
         var carries = eval("<%=hfRegion.Value.Replace("\"","'") %>");
    
         if (carries != null && carries.length > 0) {
             for (var i = 0; i < carries.length; i++) {
                 if (<%=(SaveType==SaveType.Add).ToString().ToLower() %>) {
                     carries[i].Id = "";
                 }
                 freight.AddRegion(carries[i]);
             }
         }
     }

 </script>