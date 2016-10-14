<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasedOnSalaryCalculation.ascx.cs"
    Inherits="Hr.Web.Controls.BasedOnSalaryCalculation" %>
<script type="text/javascript">
    $(document).ready(function () {
        $(".tmp5").hide();
        $(".tmp6").hide();
        $("#cphBody_cphInfbody_ucSalaryRule_rdoPercentage").live("click", function () {
            $(".tmp4").hide();
            $(".tmp").show();
            $(".tmp1").hide();
            $(".tmp2").hide();
            $(".tmp3").show();
        });
        $("#cphBody_cphInfbody_ucSalaryRule_rdoFixed").live("click", function () {
            $(".tmp4").hide();
            $(".tmp").hide();
            $(".tmp1").hide();
            $(".tmp2").hide();
            $(".tmp3").show();
        });
        $("#cphBody_cphInfbody_ucSalaryRule_rdoPartial").live("click", function () {
            $(".tmp4").hide();
            $(".tmp").show();
            $(".tmp1").show();
            $(".tmp2").show();
            $(".tmp3").show();
        });
        $("#cphBody_cphInfbody_ucSalaryRule_rdoFormula").live("click", function () {
            $(".tmp").hide();
            $(".tmp1").hide();
            $(".tmp2").hide();
            $(".tmp3").hide();
            $(".tmp4").show();

        });
        //        $("#cphBody_cphInfbody_ucSalaryRule_ddlSalaryHead").change(function () {
        $(".tmp5").show();
        $(".tmp6").show();
        //        });
    });
</script>
<style>
    .width
    {
        width: 58%;
    }
</style>
<div style="width: 100%;">
    <div class="lblAndTxtStyle payment">
        <div class="divlblwidth100px bglbl">
            <a>Salary Head</a>
        </div>
        <div class="div182Px">
            <asp:DropDownList ID="ddlSalaryHead" runat="server" CssClass="drpwidth180px">
            </asp:DropDownList>
        </div>
    </div>
    <div class="tmp5">
        <div style="width: 25%; float: left">
            <a>
                <asp:RadioButton GroupName="SalaryRule" ID="rdoFixed" runat="server" Text="Fixed"
                    Checked="true" />
            </a>
        </div>
        <div style="width: 25%; float: left">
            <a>
                <asp:RadioButton GroupName="SalaryRule" ID="rdoPercentage" runat="server" Text="Percentage" />
            </a>
        </div>
        <div style="width: 25%; float: left">
            <a>
                <asp:RadioButton GroupName="SalaryRule" ID="rdoPartial" runat="server" Text="Partial" />
            </a>
        </div>
        <div id="Formula" style="width: 25%; float: left">
            <a>
                <asp:RadioButton GroupName="SalaryRule" ID="rdoFormula" runat="server" Text="Formula Editor" />
            </a>
        </div>
    </div>
    <div  class="tmp6" style="width: 100%">
        <div style="width: 50%; float: left">
            <div class="lblAndTxtStyle tmp tmp4" style="display: none">
                <div class="divlblwidth100px bglbl">
                    <a>1st Head</a>
                </div>
                <div class="div182Px width">
                    <asp:DropDownList ID="ddlParentHead" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <div id="parentAmount" class="lblAndTxtStyle tmp3">
                <div class="divlblwidth100px bglbl">
                    <a>Amount</a>
                </div>
                <div class="div80Px width">
                    <asp:TextBox ID="txtParentHeadAmount" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
        </div>
        <div style="width: 50%; float: left">
            <div class="lblAndTxtStyle tmp tmp1" style="display: none">
                <div class="divlblwidth100px bglbl">
                    <a>2nd Head</a>
                </div>
                <div class="div182Px width">
                    <asp:DropDownList ID="ddlPartialHead" runat="server" CssClass="drpwidth180px">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="lblAndTxtStyle tmp tmp1" style="display: none">
                <div class="divlblwidth100px bglbl">
                    <a>Amount</a>
                </div>
                <div class="div80Px width">
                    <asp:TextBox ID="txtPartialHeadValue" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                </div>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="tmp2" style="display: none; margin-left:5px">
            <div style="width: 20%; float: left">
                <div style="width: 10px; height: 10px; background-color: Green; float: left">
                </div>
                <div style="width: 80%; float: left">
                    <a>&nbsp;&nbsp; Which is </a>
                </div>
            </div>
            <div style="width: 25%; float: left">
                <a>
                    <asp:RadioButton GroupName="partial" ID="rdoHigher" runat="server" Text="Higher"
                        Checked="true" />
                </a>
            </div>
            <div style="width: 10%; float: left">
                <a>or </a>
            </div>
            <div style="width: 25%; float: left">
                <a>
                    <asp:RadioButton GroupName="partial" ID="rdoLower" runat="server" Text="Lower" />
                </a>
            </div>
        </div>
        <div style="clear: both">
        </div>
        <div class="tmp4" style="display:none; margin-left:5px">
            <a>Manual Formula Editor Only For Advance User </a>
            <asp:TextBox ID="txtFormulaEditor" runat="server" CssClass="txtwidth178px allowEnter"
                TextMode="MultiLine"></asp:TextBox>
        </div>
        <div style="margin-left:5px">
            <div style="width: 35%; float: left">
                <div style="width: 10px; height: 10px; background-color: Green; float: left">
                </div>
                <div style="width: 80%; float: left">
                    <a>&nbsp;&nbsp; This salary head is </a>
                </div>
            </div>
            <div style="width: 15%; float: left">
                <a>
                    <asp:RadioButton GroupName="partial1" ID="rdoFixed1" runat="server" Text="Fixed" />
                </a>
            </div>
            <div style="width: 10%; float: left">
                <a>or </a>
            </div>
            <div style="width: 20%; float: left">
                <a>
                    <asp:RadioButton GroupName="partial1" ID="rdoProportionate" runat="server" Text="Proportionate"
                        Checked="true" />
                </a>
            </div>
        </div>
    </div>
</div>