using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Net;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace forgetpasswordportal
{
    public partial class phone : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
		
		DataTable dt = new DataTable();
        static int sentOtp = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {
			if (sentOtp == Convert.ToInt32(txtOTP.Text))
			{
				Session["Result"] = "Successful";
				Response.Redirect("~/Admin.aspx");
			}
			else
			{
				lblMessage.Text = "OTP does not matches";
				lblMessage.ForeColor = System.Drawing.Color.Red;
			}
			Session["Result"] = "Successful";
			Response.Redirect("~/Admin.aspx");
		}

        protected void btnSend_Click(object sender, EventArgs e)
        {
			using (SqlConnection con = new SqlConnection(CS))
			{
				Random rand = new Random();
				string apikey = "NGE0OTVhNjM2YjQ1NWE0ZjQyNzA2ZTY0NzI2ODc3NGU= ";
				long numbers = Convert.ToInt64(txtPhone.Text);
				sentOtp = rand.Next(1000, 9999);
				string senders = "TXTLCL";
				SqlCommand cmd = new SqlCommand("select * from Users where Phone ='" + numbers + "'", con);
				con.Open();
				SqlDataAdapter sda = new SqlDataAdapter(cmd);
				sda.Fill(dt);
				if (dt.Rows.Count != 0)
				{
					String url = "https://api.textlocal.in/send/?apikey=" + apikey + "&numbers=" + numbers + "&message=" + sentOtp + "&sender=" + senders;

					StreamWriter mywriter = null;
					HttpWebRequest objrequest = (HttpWebRequest)WebRequest.Create(url);

					objrequest.Method = "POST";
					objrequest.ContentLength = Encoding.UTF8.GetByteCount(url);
					objrequest.ContentType = "application/x-www-form-urlencoded";

					try
					{
						mywriter = new StreamWriter(objrequest.GetRequestStream());
						mywriter.Write(url);

						lblMessage.Text = "OTP Sent Successfully";
						lblMessage.ForeColor = System.Drawing.Color.Green;

						txtOTP.Visible = true;
						btnVerify.Visible = true;
					}

					catch (Exception)
					{
						lblMessage.Text = "OTP could not sent";
						lblMessage.ForeColor = System.Drawing.Color.Red;
					}

					finally
					{
						mywriter.Close();
					}
				}
				else
				{
					lblMessage.Text = "This Phone Number is not present in our database";
					lblMessage.ForeColor = System.Drawing.Color.Red;
				}
			}
		}
    }
}