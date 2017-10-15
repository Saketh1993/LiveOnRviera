using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiveOnRiviera.DAL;

namespace LiveOnRiviera
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

            }

        }

        public void btnsubmit_Click(object sender, EventArgs e)
        {

            //Home obj = new Home();
            //obj.HomeText(txtarea1.InnerText.Trim());
            try
            {
                MasterData.GetDescription(txtarea1.InnerHtml.ToString().Trim());
                Response.Redirect("~/Home.aspx");
            }
            catch (Exception)
            {
                
               ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please check the text entered')", true);
               txtarea1.InnerText = "";
            }
           


        }
    }
}