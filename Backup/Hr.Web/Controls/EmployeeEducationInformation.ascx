<%@ Control Language="C#"  AutoEventWireup="true" CodeBehind="EmployeeEducationInformation.ascx.cs" Inherits="Hr.Web.Controls.EmployeeEducationInformation" %>
<script src="<%= ResolveUrl("~/GridScripts/Hr_EmpEduDip.js" ) %>" type="text/javascript""></script>
<script src="<%= ResolveUrl("~/GridScripts/Hr_EmpEdu.js" ) %>" type="text/javascript"></script>
<div>
<div >
        <div  style="width:80%">
        <div>
                    <table id="grdEmpEdu">
                    </table>
                </div>
                <div id="grdEmpEdu_pager">
                </div>
                </div>
</div>
<br />
<div  style="width:100%">
        <div>
                    <table id="grdEmpEduDip">
                    </table>
                </div>
                <div id="grdEmpEduDip_pager">
                </div>
</div>
</div>