using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for HotelsService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class HotelsService : System.Web.Services.WebService {

    public HotelsService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public void GetAllHotels()
    {
        List<Hotel> listHotels = new List<Hotel>();

        string cs = ConfigurationManager.ConnectionStrings["myCon56"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("Select * from tblHotels",con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Hotel hotel = new Hotel();
                hotel.Id = Convert.ToInt32(rdr["Id"]);
                hotel.Name = rdr["Name"].ToString();
                hotel.Location = rdr["Location"].ToString();
                hotel.Contact = rdr["Contact"].ToString();
                hotel.Rate = rdr["Rate"].ToString();

                listHotels.Add(hotel);
            }
        }

        JavaScriptSerializer jss = new JavaScriptSerializer();
        Context.Response.Write(jss.Serialize(listHotels));
    }
    
}
