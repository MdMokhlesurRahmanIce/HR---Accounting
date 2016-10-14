<%@ Page Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="Hr.Web.Home" Title="Lotus-12 :: Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(function () {
            $('.dragbox')
	.each(function () {
	    $(this).hover(function () {
	        $(this).find('h2').addClass('collapse');
	    }, function () {
	        $(this).find('h2').removeClass('collapse');
	    })
		.find('h2').hover(function () {
		    $(this).find('.configure').css('visibility', 'visible');
		}, function () {
		    $(this).find('.configure').css('visibility', 'hidden');
		})
		.click(function () {
		    $(this).siblings('.dragbox-content').toggle();
		})
		.end()
		.find('.configure').css('visibility', 'hidden');
	});
            $('.column').sortable({
                connectWith: '.column',
                handle: 'h2',
                cursor: 'move',
                placeholder: 'placeholder',
                forcePlaceholderSize: true,
                opacity: 0.4,
                stop: function (event, ui) {
                    $(ui.item).find('h2').click();
                    var sortorder = '';
                    $('.column').each(function () {
                        var itemorder = $(this).sortable('toArray');
                        var columnId = $(this).attr('id');
                        sortorder += columnId + '=' + itemorder.toString() + '&';
                    });
                    /*alert('SortOrder: ' + sortorder);*/
                    /*Pass sortorder variable to server using ajax to save state*/
                }
            })
	.disableSelection();
        });
    </script>
    <style type="text/css">
        .column
        {
            width: 32.8%;
            margin-right: .5%;
            min-height: 300px;
            /*background: #fff;*/
            float: left;
        }
        .column .dragbox
        {
            margin: 5px 2px 20px;
            background: #fff;
            position: relative;
            border: 1px solid #ddd;
            /*-moz-border-radius: 5px;
            -webkit-border-radius: 5px;*/
            border-bottom-left-radius: 6px;
            border-bottom-right-radius: 6px;
            border-top-left-radius: 6px;
            border-top-right-radius: 6px;
            background:#D2D1D0 ;
            color : #000000;
            /*color:#F3F6F8*/
        }
        .column .dragbox h2
        {
            margin: 0;
            font-size: 12px;
            padding: 5px;
            /*background: #f0f0f0;
            color: #000;*/
            background-color:#DEEDF7;
            border-bottom: 1px solid #eee;
            font-family: Verdana;
            cursor: move;
            margin:0.3em;
            border-bottom-right-radius: 6px;
            border-bottom-right-radius: 6px;
            border-top-right-radius: 6px;
            border-top-left-radius: 6px;
        }
        .dragbox-content
        {
            background: #fff;
            min-height: 100px;
            margin: 5px;
            font-family: 'Lucida Grande' , Verdana;
            font-size: 0.8em;
            line-height: 1.5em;
        }
        .column .placeholder
        {
            background: #f0f0f0;
            border: 1px dashed #ddd;
        }
        .dragbox h2.collapse
        {
            background: #f0f0f0 url('/images/collapse.png') no-repeat top right;
        }
        .dragbox h2 .configure
        {
            font-size: 11px;
            font-weight: normal;
            margin-right: 30px;
            float: right;
        }
        .underLine
        {
          text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
      <div class="form-wrapper">
    <div class="form-details">
    <div>
        <div class="column" id="column1">
            <div class="dragbox" id="item1">
                <h2>
                    My Information</h2>
                <div class="dragbox-content">
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Employee Code:</a>
                        </div>
                        <div class="div80Px">
                            <a><asp:Literal ID="ltlEmpCode" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Employee Name:</a>
                        </div>
                        <div class="div80Px">
                            <a><asp:Literal ID="ltlEmpName" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Employee Type:</a>
                        </div>
                        <div class="div80Px">
                            <a><asp:Literal ID="ltlEmpType" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Department:</a>
                        </div>
                        <div class="div80Px">
                            <a><asp:Literal ID="ltlDepartment" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Grade:</a>
                        </div>
                        <div class="div80Px">
                           <a><asp:Literal ID="ltlGrade" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Designation:</a>
                        </div>
                        <div class="div80Px">
                           <a><asp:Literal ID="ltlDesignation" runat="server"></asp:Literal></a> 
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <div class="divlblwidth100px2">
                            <a>Unit:</a>
                        </div>
                        <div class="div80Px">
                           <a><asp:Literal ID="ltlUnit" runat="server"></asp:Literal></a>
                        </div>
                    </div>
                    <div style="clear:both"></div>
                </div>
            </div>
        </div>
        <div class="column" id="column2">
            <div class="dragbox" id="item2">
                <h2>
                    Alarts</h2>
                <div class="dragbox-content">
                    <div style="margin-left:5px; padding-top:5px;">
                        <div style="float:left">
                            <img src="/images/messagebox.gif" height="16px"; width="20px"/>
                         </div>
                         <div style="float:left; padding-left:5px">
                              <a class="underLine" href="#">You have 0 unread inbox messages.</a>
                         </div>
                      </div><br /><br />
                      <div  style="margin-left:5px; padding-top:5px;">
                          <div style="float:left">
                            <img src="/images/birthday_cake_icon.jpg" height="16px"; width="20px"/>
                          </div>
                          <div style="float:left; padding-left:5px">
                             <a  class="underLine" href="#">No Birthdays Today</a>
                          </div>
                      </div>
                </div>
            </div>
            <div class="dragbox" id="item3">
                <h2>
                    Today's Tasks</h2>
                <div class="dragbox-content">
                        <div  style="margin-left:5px; padding-top:5px;">
                         <img src="/images/task.jpg" height="25px"; width="25px"/>
                        <a>No Tasks Today</a>
                        </div>
                        <div  style="margin-left:5px; padding-top:5px;">
                         <img src="/images/Calendar-Icon.jpg" height="25px"; width="25px"/>
                        <a>My Calendar</a>
                        </div>
                </div>
            </div>
            <div class="dragbox" id="item4">
                <h2>
                    Things To Do</h2>
                <div class="dragbox-content">
                      <div  style="margin-left:5px; padding-top:5px;">
                         <img src="/images/Thinking.jpeg" height="25px"; width="25px"/>
                        <a>Things To Do</a>
                        </div>
                </div>
            </div>
        </div>
        <div class="column" id="column3">
            <div class="dragbox" id="item5">
                <h2>
                    Changes</h2>
                <div class="dragbox-content">
                         <div style="margin-left:5px; padding-top:5px;">
                         <img src="/images/change.jpg" height="20px"; width="20px"/>
                         <asp:LinkButton ID="lnkProfile" runat="server" OnClick="lnkProfile_Click" Visible="true">Profile</asp:LinkButton>
                        </div>
                        <div style="margin-left:5px; padding-top:5px;">
                         <img src="/images/change.jpg" height="20px"; width="20px"/>
                         <asp:LinkButton ID="lnkLeave" runat="server" OnClick="lnkLeave_Click" Visible="true">Leave</asp:LinkButton>
                        </div>
                        <div style="margin-left:5px; padding-top:5px;">
                         <img src="/images/change.jpg" height="20px"; width="20px"/>
                         <asp:LinkButton ID="lnkLeaveApproval" runat="server" OnClick="lnkLeaveApproval_Click" Visible="true">Leave Approval</asp:LinkButton>
                        </div>
                </div>
            </div>
            <div class="dragbox" id="Div1">
                <h2>
                    Download</h2>
                <div class="dragbox-content">
                         <div style="margin-left:5px; padding-top:5px;">
                             <asp:LinkButton ID="lnkPersonalContent" runat="server" OnClick="lnkPersonalContent_Click" Visible="true">Personal Content</asp:LinkButton>
                        </div>
                        <div style="margin-left:5px; padding-top:5px;">
                         <asp:LinkButton ID="lnkCompanyPolicies" runat="server" OnClick="lnkCompanyPolicies_Click" Visible="true">Company Policies</asp:LinkButton>
                        </div>
                        <div style="margin-left:5px; padding-top:5px;">
                         <asp:LinkButton ID="lnkReports" runat="server" OnClick="lnkReports_Click" Visible="true">Reports</asp:LinkButton>
                        </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div style="clear:both"></div>
    </div>
</asp:Content>
