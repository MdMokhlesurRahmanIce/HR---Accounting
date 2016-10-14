<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeBehind="ShiftPlan.aspx.cs" Inherits="Hr.Web.UI.Attendance.ShiftPlan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script src="<%= ResolveUrl("~/gridscripts/HR_ShiftBreak.js") %> " type="text/javascript"></script>
    <script src="../../src/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("input[id$='txtAbsentEndMargin'], .timepicker").timepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
               
                
            });
       
      
            $("input[id$='txtShiftInTime'],  .timepicker").timepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
               
               
                onClose: function (dateText, inst) {
                 
                   var dV = new Date();
                   var InTime =  dV.format('MM/dd/yyyy')+' '+ dateText;
                    var a = new Date(InTime);
                    a.setHours(a.getHours()- 1);
                 //   $("#cphBody_cphInfbody_txtShiftInStartMargin").val(a.format('hh:mm tt'));

                    var outTimeTextBox = $('#cphBody_cphInfbody_txtShiftOutTime').val();
                    var outTime =  dV.format('MM/dd/yyyy')+' '+ outTimeTextBox;
                   
                    if (outTimeTextBox.toString() != '') {
                        var outTime =  dV.format('MM/dd/yyyy')+' '+ outTimeTextBox;
                        if (new Date(outTime) >new Date(InTime)) {
                            var diff = Math.abs(new Date(outTime) - new Date(InTime));
                           //  alert(diff);
                            var seconds = Math.floor(diff / 1000);
                            var minutes = Math.floor(seconds / 60);
                           // seconds = seconds % 60;
                            var hours = Math.floor(minutes / 60);
                            //alert(hours);
                            minutes = minutes % 60;
                            $('#cphBody_cphInfbody_txtWorkingHour').val(hours + ":" + minutes);
                        }
                    }
                }
            });
            $("input[id$='txtShiftOutTime'],  .timepicker").timepicker({
                ampm: true,
                hourGrid: 4,
                minuteGrid: 10,
               
                showButtonPanel: true,
                changeMonth: true,
                changeYear: true,
               // dateFormat: 'dd/mm/yy',
                onClose: function (dateText, inst) {

                 var dV = new Date();
                   var Outtime =  dV.format('MM/dd/yyyy')+' '+ dateText;

                    var a = new Date(Outtime);
                    a.setHours(a.getHours()+ 1);
              
                    //  alert(a);
                //    $("#cphBody_cphInfbody_txtShiftOutEndMargin").val(a.format('hh:mm tt'));

                     var intimeTextBox = $('#cphBody_cphInfbody_txtShiftInTime').val();
                    var intime =  dV.format('MM/dd/yyyy')+' '+ intimeTextBox;

                    if (intimeTextBox.toString() != '') {

                        if (new Date(Outtime) >new Date(intime)) {
                            var diff = Math.abs(new Date(Outtime) - new Date(intime));
                          //  alert(diff);
                            var seconds = Math.floor(diff / 1000);
                            var minutes = Math.floor(seconds / 60);
                            seconds = seconds % 60;
                            var hours = Math.floor(minutes / 60);
                            minutes = minutes % 60;
                            $('#cphBody_cphInfbody_txtWorkingHour').val(hours + ":" + minutes);
                        }
                        else {
                        var ChngOutTime= new Date(intime).setDate(new Date(intime).getDay()+1);
                        var diff = Math.abs( new Date(ChngOutTime) -new Date(Outtime) );
                          //  alert(diff);
                            var seconds = Math.floor(diff / 1000);
                            var minutes = Math.floor(seconds / 60);
                            seconds = seconds % 60;
                            var hours = Math.floor(minutes / 60);
                            minutes = minutes % 60;
                            $('#cphBody_cphInfbody_txtWorkingHour').val(hours + ":" + minutes);
                        }
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="form-wrapper">
        <div class="form-details">
            <div>
                <div style="width: 30%; float: left">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Shift ID</a>
                        </div>
                        <div class="div80Px">
                            <div style="float: left; width: 80%">
                                <asp:TextBox ID="txtShiftID" runat="server" CssClass="txtwidth178px" ReadOnly="true"
                                    MaxLength="100"></asp:TextBox>
                            </div>
                            <div style="float: left;">
                                <asp:ImageButton ID="btnNew" runat="server" CssClass="btnImageStyle btn-enable" OnClientClick="enableControl()"
                                    OnClick="btnNew_Click" ImageUrl="~/images/new 20X20.png" />
                                <asp:ImageButton ID="btnFind" runat="server" CssClass="btnImageStyle btn-enable"
                                    OnClick="btnFind_Click" ImageUrl="~/images/Search 20X20.png" />
                            </div>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Shift Type</a>
                        </div>
                        <div class="div182Px">
                            <asp:DropDownList ID="ddlShiftType" runat="server" CssClass="drpwidth180px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddlShiftType"
                                runat="server" ForeColor="Red" ErrorMessage="Shift type is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div style="width: 70%; float: left">
                    <fieldset class="fieldset-panel">
                        <legend style="font-size: 12px">Shift In-Out Info</legend>
                        <div style="width: 50%; float: left">
                            <div style="width: 80%; float: left">
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl">
                                        <a>Shift In Time</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtShiftInTime" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl">
                                        <a>Shift Out Time</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtShiftOutTime" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="lblAndTxtStyle">
                                    <div class="divlblwidth100px bglbl">
                                        <a>Absent End Margin</a>
                                    </div>
                                    <div class="div80Px">
                                        <asp:TextBox ID="txtAbsentEndMargin" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div style="width: 40%; float: left">
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Shift In Start Margin</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtShiftInStartMargin" runat="server" CssClass="txtwidth178px timepicker"
                                        MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                            <div class="lblAndTxtStyle">
                                <div class="divlblwidth100px bglbl">
                                    <a>Shift Out End Margin</a>
                                </div>
                                <div class="div80Px">
                                    <asp:TextBox ID="txtShiftOutEndMargin" runat="server" CssClass="txtwidth178px timepicker"
                                        MaxLength="100"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </div>
            </div>
            <div>
                <div style="width: 30%; float: left">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Alias</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtAlise" runat="server" CssClass="txtwidth178px" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txtAlise"
                                runat="server" ForeColor="Red" ErrorMessage="Alias is required" ValidationGroup="Save">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px bglbl">
                            <a>Description</a>
                        </div>
                        <div class="div80Px">
                            <asp:TextBox ID="txtDescription" runat="server" CssClass="txtwidth178px allowEnter"
                                TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div style="width: 70%; float: left">
                    <div style="width: 100%; height: auto; margin-top: 5px">
                        <div>
                            <table id="grdShiftPlan">
                            </table>
                        </div>
                        <div id="grdShiftPlan_pager">
                        </div>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
            <div style="width: 100%">
                <div style="width: 35%; float: left">
                    <div style="width: 50%; float: left">
                        <div>
                            <a>
                                <asp:CheckBox ID="chkMakeItActive" Text="Make it active" Checked="true" runat="server" /></a>
                        </div>
                        <div>
                            <a>
                                <asp:CheckBox ID="chkMakeItDefault" Text="Make it default" runat="server" /></a>
                        </div>
                    </div>
                    <div style="width: 50%; float: left">
                        <div>
                            <a>
                                <asp:CheckBox ID="chkIsAutoCalculate" Text="Is auto calculate" runat="server" /></a>
                        </div>
                        <div>
                            <a>
                                <asp:CheckBox ID="chkIsProcessInSameDate" Text="Is process in same date" runat="server" /></a>
                        </div>
                    </div>
                </div>
                <div style="width: 65%; float: left">
                    <div style="float: left; width: 33%">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Working Hour</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtWorkingHour" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                    Enabled="false" Text="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 33%">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Late Margin</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtLateMargin" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                    Text="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div style="float: left; width: 33%">
                        <div class="lblAndTxtStyle">
                            <div class="divlblwidth100px bglbl">
                                <a>Early Out Margin</a>
                            </div>
                            <div class="div80Px">
                                <asp:TextBox ID="txtEarlyOutMargin" runat="server" CssClass="txtwidth178px" MaxLength="100"
                                    Text="0"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="clear:both"></div>
        <div class="form-bottom">
            <div class="btnRight">
                <asp:Button ID="btnSave" runat="server" CssClass="button" Text="Save" ValidationGroup="Save"
                    OnClick="btnSave_Click" OnClientClick="CheckValidity();" />
                &nbsp;&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="button" Text="Cancel" Visible="false" />
                &nbsp;&nbsp;
                <asp:Button ID="btnDelete" runat="server" CssClass="button" Text="Delete" OnClick="btnDelete_Click"
                    Visible="true" OnClientClick="return confirm('Are you sure you want to delete this record?')" />
            </div>
        </div>
    </div>
    <script>
        $(function () {
            if (isPostBack)
                $(".form-wrapper select, .form-wrapper input:not(.btn-enable)").attr('disabled', true);
        })
        function enableControl() {
            $(".form-wrapper input, .form-wrapper select").removeAttr('disabled');
            return false;
        }
    </script>
</asp:Content>
