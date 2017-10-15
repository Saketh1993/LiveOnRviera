using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LiveOnRiviera.DAL;

namespace LiveOnRiviera
{
    public partial class PropertyDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                container1.InnerHtml = "";
                string ID = Request.QueryString["ID"];
                DataTable dtMaster = MasterData.GetData();
                //  DataTable dtFilter = dtMaster.Select("HNO=" + ID).CopyToDataTable();
                var result = from r in dtMaster.AsEnumerable()
                             where r.Field<string>("HNO") == ID
                             select r;
                DataTable dtResult = result.CopyToDataTable();

                container1.InnerHtml += "<div class='bs-example'><div id='myCarousel' class='carousel slide' data-ride='carousel'><div class='carousel-inner'><div class='item active'><img class='img-responsive' src='" + dtResult.Rows[0]["Images/0"] + "'></div>";
                for (int j = 1; j < 12; j++)
                {
                    if (dtResult.Rows[0]["Images/" + j + ""].ToString() != null && dtResult.Rows[0]["Images/" + j + ""].ToString() != "")
                    {
                        container1.InnerHtml += "<div class='item'><img  class='img-responsive' src=" + dtResult.Rows[0]["Images/" + j + ""] + "> </div>";
                        if (j == 12)
                        {
                            break;
                        }
                        j++;
                    }
                }
                container1.InnerHtml += "<a class='carousel-control left' href='#myCarousel' data-slide='prev'><span class='glyphicon glyphicon-chevron-left'></span></a><a class='carousel-control right' href='#myCarousel' data-slide='next'><span class='glyphicon glyphicon-chevron-right'></span></a></div></div>";
                BindGrid(ID);
            }

        }
        protected void BindGrid(string ID)
        {

            DataTable dt = MasterData.GetData();
            DataTable dtFilter = dt.Select("HNO='" + ID + "'").CopyToDataTable().DefaultView.ToTable(false, new String[] { "Address", "City", "Price", "Currency", "Description", "Deposit", "AgencyFee", "Link", "Facilities/kitchenware", "Facilities/toilet", "Facilities/living_room", "Facilities/bedroom", "Facilities/bathroom", "Facilities/parking", "Facilities/wheelchair_accessible", "Facilities/smoking_allowed", "Facilities/bed", "Facilities/dishwasher", "Facilities/washing_machine", "Facilities/internet", "Facilities/dryer", "Facilities/ac", "Facilities/wifi", "Facilities/lroom_furniture", "Facilities/desk", "Facilities/tv", "Facilities/closet", "Facilities/balcony" });
            DataTable transposedTable = GenerateTransposedTable(dtFilter);
            GridViewData.DataSource = transposedTable;
            GridViewData.DataBind();

        }
        private DataTable GenerateTransposedTable(DataTable inputTable)
        {
            DataTable outputTable = new DataTable();

            // Add columns by looping rows

            // Header row's first column is same as in inputTable
            outputTable.Columns.Add(inputTable.Columns[0].ColumnName.ToString());

            // Header row's second column onwards, 'inputTable's first column taken
            foreach (DataRow inRow in inputTable.Rows)
            {
                string newColName = inRow[0].ToString();
                outputTable.Columns.Add(newColName);
            }

            // Add rows by looping columns        
            for (int rCount = 1; rCount <= inputTable.Columns.Count - 1; rCount++)
            {
                DataRow newRow = outputTable.NewRow();

                // First column is inputTable's Header row's second column
                newRow[0] = inputTable.Columns[rCount].ColumnName.ToString();
                for (int cCount = 0; cCount <= inputTable.Rows.Count - 1; cCount++)
                {
                    string colValue = inputTable.Rows[cCount][rCount].ToString();
                    newRow[cCount + 1] = colValue;
                }
                outputTable.Rows.Add(newRow);
            }

            return outputTable;
        }
    }
}