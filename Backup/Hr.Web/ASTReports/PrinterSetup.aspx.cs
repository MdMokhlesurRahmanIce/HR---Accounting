using System;
using System.Web.UI.WebControls;

namespace Hr.Web.Reports
{
    public partial class PrinterSetup : System.Web.UI.Page
    {
        private PrinterSetup PrinterSettings
        {
            get
            {
                if (Session["PrinterSetup"]==null)
                    return new PrinterSetup();
                else
                    return (PrinterSetup)Session["PrinterSetup"];
            }
            set
            {
                Session["PrinterSetup"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrinterSettings = null;
                rbAllPages.Checked = true;
                GetAllPrinter();
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            PrinterSetup pageSetup = new PrinterSetup();
            pageSetup._PrinterName = ddlPrinterName.SelectedValue;
            if (rbAllPages.Checked)
            {
                pageSetup.AllPages = true;
                pageSetup.CurrentPage = false;
            }
            else if (rbCurrentPage.Checked)
            {
                pageSetup.AllPages = false;
                pageSetup.CurrentPage = true;
            }
            else
            {
                pageSetup.FromPage = Convert.ToInt32(txtFromPage.Text);
                pageSetup.ToPage = Convert.ToInt32(txtToPage.Text);
                pageSetup.CurrentPage = false;
                pageSetup.AllPages = false;
            }
            pageSetup.NoOfCopies = 1;
            PrinterSettings = pageSetup;

            // a code to be run in client-side
            string scriptStr = "<script>window.close();</script>";
            // send the script to output stream
            ClientScript.RegisterClientScriptBlock(typeof(string), "closing", scriptStr);
        }
        private void GetAllPrinter()
        {
            foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
            {
                ddlPrinterName.Items.Add(new ListItem(printer,printer));
            }
            ddlPrinterName.Items.Insert(0,new ListItem("Select Printer",""));
        }
    }

    public partial class PrinterSetup
    {
        private String _PrinterName;
        public String PrinterName
        {
            get
            {
                return _PrinterName;
            }
            set
            {
                _PrinterName = value;
            }
        }
        private short _NoOfCopies;
        public short NoOfCopies
        {
            get
            {
                return _NoOfCopies;
            }
            set
            {
                _NoOfCopies = value;
            }
        }
        private bool _allPages;
        public bool AllPages
        {
            get
            {
                return _allPages;
            }
            set
            {
                _allPages = value;
            }
        }
        private int _fromPage;
        public int FromPage
        {
            get
            {
                return _fromPage;
            }
            set
            {
                _fromPage = value;
            }
        }
        private int _toPage;
        public int ToPage
        {
            get
            {
                return _toPage;
            }
            set
            {
                _toPage = value;
            }
        }
        private bool _currentPage;
        public bool CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                _currentPage = value;
            }
        }
    }
}
