<%@ Page Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true" CodeBehind="ReportPrint.aspx.cs"
    Inherits="Hr.Web.Reports.ReportPrint" Title="Report viewer" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms,Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%--<%@ Register Assembly="printButtonDLL" Namespace="printButtonDLL" TagPrefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="chpInfHead" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".menuDivMasterBody").hide();
            $("#UpdateProgressMaster").hide();

            // Setting position of Print Button
            var p = $("#ctl00_cphBody_rpViewer_ctl01_ctl05_ctl00");
            var position = p.position();
            $("#PrintButton1_printButton").offset({ top: position.top - 5, left: position.left + 250 })
        });
        //    Script for printing
        function $_create(elem, tag, target) { return addElem(elem, target, tag) }
        function $_add(elem, target) { return addElem(elem, target) }
        function $_GB() { return GetBrowser(); }

        function GetBrowser() {
            if ($.browser.mozilla)
                return 'FF';
            else if ($.browser.msie)
                return 'IE';
            else if ($.browser.webkit)
                return 'OP';
            else if ($.browser.opera)
                return 'WK';
            else
                return 'FF';
        }

        function addElem(elem, target, tag) {
            if (typeof elem === 'string') {
                var el = document.getElementById(elem);
                if (!el) {

                    el = document.createElement(tag);

                    el.id = elem;
                }
                elem = el;
            }

            if (target) {

                var dest;
                if (typeof target === 'string')
                    dest = document.getElementById(target);
                else
                    dest = target;


                dest.appendChild(elem);

            }

            return elem;
        }

        function insert(elem, target) {
            if (typeof target === 'string')
                target = document.getElementById(target);

            var myDoc = target.contentWindow || target.contentDocument;

            if (myDoc.document) {
                myDoc = myDoc.document;
            }
            var headLoc = myDoc.getElementsByTagName("head").item(0);
            var scriptObj = myDoc.createElement("script");
            scriptObj.setAttribute("type", "text/javascript");
            scriptObj.innerHTML = 'window.print();';
            if (elem)
                elem = document.getElementById(elem);

            if (elem)
                headLoc.appendChild(elem);
            else
                headLoc.appendChild(scriptObj);
        }
        //end printing
    </script>
    <%--    <script type="text/javascript" src="<%# ResolveUrl("../js/PrinterSetup.js") %>"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphInfbody" runat="server">
    <div class="Reportpage">
        <%--<cc1:PrintButton ID="PrintButton1" runat="server" ReportName="ctl00_cphBody_rpViewer" />--%>
        <rsweb:ReportViewer ID="rpViewer" runat="server" CssClass="rpView" Width="1370px"
            Height="700px" ProcessingMode="Remote">
        </rsweb:ReportViewer>
    </div>
    <div id="dialog-modal" style="display: none;">
        <div id="divLoginUpper">
            <div class="divLoginContent1">
                <div class="lblAndTxtStyle1">
                    <div class="divlblwidth100px bglbl">
                        <span class="lblChkBox1">Select Printer</span>
                    </div>
                    <div class="divtxtwidth145px1">
                        <div>
                            <asp:DropDownList CssClass="txtwidth132px" ID="ddlPrinterName" runat="server" ValidationGroup="login">
                            </asp:DropDownList>
                            <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                runat="server" ControlToValidate="ddlPrinterName" ErrorMessage="Please specify a username"
                                ValidationGroup="login" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="divLoginContent1">
                <div class="lblAndTxtStyle1">
                    <div class="divlblwidth100px bglbl">
                        <span class="lblChkBox1">No of Copies</span>
                    </div>
                    <div class="divtxtwidth145px1">
                        <div>
                            <asp:TextBox ID="txtNoofCopies" runat="server" CssClass="txtwidth132px" ValidationGroup="login">1</asp:TextBox>
                            <span class="r2">*</span><asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                runat="server" ControlToValidate="txtNoofCopies" ValidationGroup="login" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>
            <div class="divLoginContent1">
                <fieldset class="fsPadding5px fs">
                    <legend><span class="lblChkBox1">Layout</span> </legend>
                    <div class="lblAndTxtStyle1">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbPortrait" runat="server" Text="Portrait" Checked="true" GroupName="layout"
                                Style="font-size: 12px" />
                        </div>
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbLandscape" runat="server" Text="Landscape" GroupName="layout"
                                Style="font-size: 12px" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle">
                        <asp:HiddenField ID="hfIsPrint" runat="server" />
                    </div>
                </fieldset>
                <br />
                <fieldset class="fsPadding5px fs">
                    <legend><span class="lblChkBox1">Print Range</span> </legend>
                    <div class="lblAndTxtStyle1">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbAllPages" runat="server" Text="All Pages" GroupName="PrintRange"
                                Checked="true" Style="font-size: 12px" />
                        </div>
                    </div>
                    <br />
                    <div class="lblAndTxtStyle1">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="rbCurrentPage" runat="server" Text="Current Pages" GroupName="PrintRange"
                                Style="font-size: 12px" />
                        </div>
                    </div>
                    <div class="lblAndTxtStyle1">
                        <div class="divlblwidth100px bglbl">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="From Page" GroupName="PrintRange"
                                Style="font-size: 12px" />
                        </div>
                        <div class="divtxtwidth145px1">
                            <div>
                                <asp:TextBox ID="txtFromPage" runat="server" CssClass="txtwidth132px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="lblAndTxtStyle1">
                        <div class="divlblwidth100px bglbl">
                            <span class="lblChkBox1">To</span>
                        </div>
                        <div class="divtxtwidth145px1">
                            <div>
                                <asp:TextBox ID="txtToPage" runat="server" CssClass="txtwidth132px"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
