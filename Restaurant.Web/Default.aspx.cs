using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Web.LoginService;

//
//using Restaurant.Service;
//using Restaurant.Data;


namespace Restaurant.Web
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("default page loaded");

            LoginServiceClient client = new LoginServiceClient();
            bool result = client.Login("admin", "password");

            if (result)
            {
                Console.WriteLine("login successful");
            }


        }
    }
}