﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PostGSQL
{
    public partial class CoursesPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["PostGSQL"].ToString();

            SqlConnection conn = new SqlConnection(connStr);


            SqlCommand ViewCoursesGrades = new SqlCommand("ViewCoursesGrades", conn);
            ViewCoursesGrades.CommandType = CommandType.StoredProcedure;
            ViewCoursesGrades.Parameters.Add(new SqlParameter("@studentID", SqlDbType.Int)).Value = Session["user"];


            conn.Open();
            SqlDataReader rdr = ViewCoursesGrades.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
            }
        }
    }
    }
