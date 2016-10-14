<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="DemoEmp.aspx.cs" Inherits="Hr.Web.UI.EmployeeBasicInfo.DemoEmp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">

  <script src="<%=ResolveUrl("~/GridScripts/DemoempGrd.js") %>" type="text/javascript"></script>

  <script type="text/javascript">
     
      // bind to accordion object
      $(document).ready(function () {
          $("input[id$='txtdojDate'], .date-picker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1950:2050'}) 
          $("input[id$='txtdocDate'], .date-picker").datepicker({ showButtonPanel: true, changeMonth: true, changeYear: true, dateFormat: 'mm/dd/yy', yearRange: '1950:2050'});
          //disabled shiftrule 
          
      });  
      
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div class="divLP5" style="width: 40%; float: left; padding-left: 15">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Employee Code</a>
                    </div>
                    <div class="div80Px" style="width: 36%;">
                        <asp:DropDownList ID="ddlempCodeKey" runat="server" Style="visibility: visible;"
                            CssClass="drpwidth157px" AutoPostBack="true" 
                            onselectedindexchanged="ddlempCodeKey_SelectedIndexChanged" >
                        </asp:DropDownList>
                        <div class="div80Px">
                            <asp:TextBox ID="txtempCode" runat="server" Style="visibility: visible;" CssClass="txtwidth155px">
                            </asp:TextBox>
                        </div>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle " 
                            ImageUrl="~/images/new 20X20.png" onclick="btnNew_Click" 
                             />
                        <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle" 
                            ImageUrl="~/images/Search 20X20.png" onclick="btnFind_Click"  />
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Empolyee Name</a>
                    </div>
                    <div class="div80Px">
                         <asp:TextBox ID="txtempName" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                        
                    </div>
                </div>
               <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Date of Join</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtdojDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Date of Confirm</a>
                    </div>
                    <div class="div80Px">
                        <asp:TextBox ID="txtdocDate" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div style="width: 100%; float: left">
                    <div style="float: left; width: 99%;">
                        <table id="grdempDetails">
                        </table>
                        <div id="grdempDetails_pager">
                    </div>
                    </div>
                    
                </div>
                <br />
                <br />
            </div>
            <div id="settings" style="width: 60%; float: left">
                <br />
            </div>
            <div style="width: 100%; float: left">
                <br />
            </div>
        </div>
        <div style="clear:both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                     OnClientClick="CheckValidity();" onclick="btnSave_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" 
                      />
                &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" 
                    Visible="true" 
                    
                    OnClientClick="return confirm('Are you sure you want to delete this record?')" onclick="btnDelete_Click" 
                     />
                &nbsp;&nbsp;
                <asp:Button ID="btnPrint" runat="server" CssClass="button" Text="Print" onclick="btnPrint_Click" 
                     />

            &nbsp;

            </div>
        </div>
    </div>
    
</asp:Content>
