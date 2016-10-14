<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEmployeeSearch.ascx.cs"
    Inherits="Hr.Web.Controls.ucEmployeeSearch" %>
<script type="text/javascript">
    $(document).ready(function () {
        $("#<%= btnFind.ClientID %>").click(function (e) {
            if (($("#<%= ddlCompany.ClientID %>").val() == "") || ($("#<%= ddlCompany.ClientID %>").val() == null)) {
                ShowMessageBox("HR", "Please select a company.");
                return false;
            }
        });
        $("#<%= txtEmpID.ClientID %>").keyup(function (event) {
            var _empCode = $(this).val();
            employeeIdKeyup(event, _empCode);
        });
    });  
</script>
<div style="width: 100%;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 50%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Employee ID</a>
                    </div>
                    <div class="div182Px">
                        <asp:TextBox ID="txtEmpID" runat="server" CssClass="txtwidth178px"></asp:TextBox>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Company</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlCompany" runat="server" CssClass="drpwidth180px reload"
                            OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Branch</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="drpwidth180px reload" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Department</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="drpwidth180px reload"
                            OnSelectedIndexChanged="ddlDepartment_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div style="width: 50%; float: left">
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Grade</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlGrade" runat="server" CssClass="drpwidth180px reload" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="lblAndTxtStyle">
                    <div class="divlblwidth100px bglbl">
                        <a>Designation</a>
                    </div>
                    <div class="div182Px">
                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="drpwidth180px reload"
                            OnSelectedIndexChanged="ddlDesignation_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="lblAndTxtStyle" style="width: 50%">
        <div class="divlblwidth100px bglbl">
            <a>Employee Name</a>
        </div>
        <div class="div182Px">
            <div class="div80Px">
                <asp:TextBox ID="txtEmployeeName" runat="server" CssClass="txtwidth178px"></asp:TextBox>
            </div>
            <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                ImageUrl="~/images/Search 20X20.png" OnClick="btnFind_Click" />
        </div>
    </div>
    <asp:HiddenField ID="hfEmpCode" runat="server" />
    <asp:HiddenField ID="hfEmpKey" runat="server" />
</div>
