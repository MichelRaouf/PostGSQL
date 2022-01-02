using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGSQL
{
    public partial class addDefense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // dateDefense.Text = DateTime.Now.ToString("dd/MM/yyyy");


        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGSQL"].ToString();

            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand checkThesis = new SqlCommand("checkThesisV4", conn);
            checkThesis.CommandType = CommandType.StoredProcedure;
            checkThesis.Parameters.Add(new SqlParameter("@thesisNumber", SqlDbType.Int)).Value = ThesisSSN.Text;
            SqlParameter sucess = checkThesis.Parameters.Add("@successBit", SqlDbType.Bit);
            sucess.Direction = System.Data.ParameterDirection.Output;


            SqlCommand GucianOrNon = new SqlCommand("checkThesisV5", conn);
            GucianOrNon.CommandType = CommandType.StoredProcedure;
            GucianOrNon.Parameters.Add(new SqlParameter("@serialNo", SqlDbType.Int)).Value = ThesisSSN.Text;
            SqlParameter valid = GucianOrNon.Parameters.Add("@isValid", SqlDbType.Bit);
            valid.Direction = System.Data.ParameterDirection.Output;
            conn.Open();
            checkThesis.ExecuteNonQuery();
            GucianOrNon.ExecuteNonQuery();
            conn.Close();



            if (sucess.Value.ToString() == "True")
            {
                Response.Write("<script>alert('Defense was already added for this thesis');</script>");

            }
            else
            {

                if (valid.Value.ToString() == "True")
                {

                    SqlCommand AddDefenseGucian = new SqlCommand("AddDefenseGucian", conn);
                    AddDefenseGucian.CommandType = CommandType.StoredProcedure;
                    AddDefenseGucian.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = ThesisSSN.Text;
                    AddDefenseGucian.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.VarChar)).Value = DateTime.ParseExact(dateDefense.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    AddDefenseGucian.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = host.Text;
                    conn.Open();
                    try
                    {
                        AddDefenseGucian.ExecuteNonQuery();
                        Response.Write("Gucian defense added");

                    }
                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Message.StartsWith("The INSERT statement conflicted with the FOREIGN KEY"))
                        {
                            Response.Write("<script>alert('Invalid Thesis ID ');</script>");

                        }
                        else
                        {
                            if (sqlEx.Message.StartsWith("Violation of PRIMARY"))
                            {
                                Response.Write("<script>alert('Defense with the samte date was already added to this thesis');</script>");

                            }
                            else
                            {
                                if (sqlEx.Message.StartsWith("Failed to convert parameter value from a String to a DateTime"))
                                {
                                    Response.Write("<script>alert('Date format should be mm/dd/yyyy ');</script>");

                                }

                            }

                        }

                    }
                    catch (System.FormatException sFe)
                    {
                        if (sFe.Message.StartsWith("Failed to convert parameter value from a String to a DateTime"))
                        {
                            Response.Write("<script>alert('Date must be written in mm/dd/yyyy format');</script>");

                        }
                    }
                    conn.Close();






                }
                else


                {

                    SqlCommand AddDefenseNonGucian = new SqlCommand("AddDefenseNonGucian", conn);
                    AddDefenseNonGucian.CommandType = CommandType.StoredProcedure;
                    AddDefenseNonGucian.Parameters.Add(new SqlParameter("@ThesisSerialNo", SqlDbType.Int)).Value = ThesisSSN.Text;
                    AddDefenseNonGucian.Parameters.Add(new SqlParameter("@DefenseDate", SqlDbType.DateTime)).Value = DateTime.ParseExact(dateDefense.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    AddDefenseNonGucian.Parameters.Add(new SqlParameter("@DefenseLocation", SqlDbType.VarChar)).Value = host.Text;
                    conn.Open();
                    try
                    {
                        AddDefenseNonGucian.ExecuteNonQuery();
                        Response.Write("NonGucian defense added");

                    }



                    catch (SqlException sqlEx)
                    {
                        if (sqlEx.Message.StartsWith("The INSERT statement conflicted with the FOREIGN KEY"))
                        {
                            Response.Write("<script>alert('Invalid Thesis ID ');</script>");

                        }
                        else
                        {
                            if (sqlEx.Message.StartsWith("Violation of PRIMARY"))
                            {
                                Response.Write("<script>alert('Defense with the samte date was already added to this thesis');</script>");

                            }
                            else
                            {
                                if (sqlEx.Message.StartsWith("Student course grade should be higher than 50 to add a defense"))
                                {
                                    Response.Write("<script>alert('Student course grade should be higher than 50 to add a defense ');</script>");

                                }
                            }

                        }

                    }
                    catch (System.FormatException sFe)
                    {
                        if (sFe.Message.StartsWith("Failed to convert parameter value from a String to a DateTime"))
                        {
                            Response.Write("<script>alert('Date must be written in mm/dd/yyyy format');</script>");

                        }
                    }
                    conn.Close();
                }





            }








        }


    }
}