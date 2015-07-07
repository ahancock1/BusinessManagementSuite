using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.Web.LoginService;


namespace Restaurant.Web
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Console.WriteLine("default page loaded");

            // Initialise the wcf service and request a user
            LoginServiceClient client = new LoginServiceClient();
            User user = client.GetUser("username", "password");


            // Check user
            if (user != null)
            {
                Console.WriteLine("Success");
            }

        }
    }
}