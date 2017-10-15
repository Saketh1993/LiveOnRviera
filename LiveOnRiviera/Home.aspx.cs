using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using LiveOnRiviera.DAL;

namespace LiveOnRiviera
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (MasterData.GetHomeData().Rows.Count > 0)
                    {
                        string szDescription = MasterData.GetHomeData().Rows[0]["Description"].ToString().Trim();
                        PData.InnerHtml = "<h3>" + szDescription + "<br/><br/></h3>";
                    }

                    // PData.InnerText = szDescription;
                    DataTable dt = DAL.MasterData.GetData();
                    //List<string> list = new List<string>();
                    //DataTable dt1 = dt.DefaultView.ToTable(false, new String[] { "Images/0","SNO" });
                    //foreach (DataRow dr in dt1.Rows)
                    //{
                    //    list.Add(dr[0].ToString());
                    //}
                    int count = dt.Rows.Count;
                    //ContentPlaceHolder myPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                    //HtmlControl myControl = (HtmlControl)myPlaceHolder.FindControl("container");
                    Literal lit = new Literal();
                    container1.InnerHtml = "";
                    // lit.Text = @"<div class='container'><div class='row'> <div class='col-sm-4'> <div class='panel panel-primary'><div class='panel-heading'>BLACK FRIDAY DEAL</div> <div class='panel-body'><img src='https://placehold.it/150x80?text=IMAGE' class='img-responsive' style='width: 100%' alt='Image'></div><div class='panel-footer'>Buy 50 mobiles and get a gift card</div></div></div></div>";
                    container1.InnerHtml += "<div class='container-fluid'>";
                    //for (int j = 0; j < count; j++)
                    //{
                    //    if(j!=0)
                    //    j--;
                    //    container1.InnerHtml += @"<div class='row'>";
                    //    for (int i = 0; i < 3; i++)
                    //    {
                    //        if (j < count)
                    //        {
                    // container1.InnerHtml += @" <div class='col-lg-4 col-md-4 col-sm-4 col-xs-6'> <div class='panel panel-primary'><div class='panel-heading'>" + j + " BLACK FRIDAY DEAL</div> <div class='panel-body'><img src='https://placehold.it/150x80?text=IMAGE' class='img-responsive' style='width: 100%' alt='Image'></div><div class='panel-footer'>Buy 50 mobiles and get a gift card</div></div></div></div>";
                    try
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            container1.InnerHtml += @"<div class='col-xs-12 col-sm-6 col-md-4' height='200'><div class='panel single-blog'><img src=" + dr["Images/0"].ToString().Trim() + " class='img-responsive'  alt=''><div class='content'><ul class='list-unstyled list-inline'><li>By: Admin</li><li>Feb 01, 2017</li></ul><a href='PropertyDetail.aspx?ID=" + dr["HNO"].ToString().Trim() + "'><p style='font-size:16px;font-family: 'Times New Roman', Georgia, Serif;'>" + dr["Description"].ToString().Substring(0, 50) + "</p><a href='#' class='read-more' style='font-size:10px;font-family: 'Times New Roman', Georgia, Serif;' >Read more</a></div></div></div>";
                            // j++;
                            //Console.WriteLine(j);
                            //if (j == 50)
                            //    break;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                    REST ObjRest = new REST();

                    // data has been removed from this URL
                    ObjRest.endpoint = "https://app.flatio.com/cdn/export/housingAnywhere.json";
 

                    string strResponse = string.Empty;
                    strResponse = ObjRest.makerequest();
                   // txtResponse.Text = strResponse;



                    //        }
                    //    }
                }
            }
            catch (Exception)
            {

            }
        }
        //public void HomeText(string Text)
        //{
        //    container2.InnerHtml = "<p>" + Text + "</p>";
        //}
    }
}