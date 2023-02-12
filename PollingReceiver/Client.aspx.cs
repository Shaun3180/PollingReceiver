using System;
using System.IO;

namespace PollingReceiver
{
    public partial class Receiver : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string filePath = Server.MapPath("~/App_Data/client.txt");
            string now = DateTime.Now.ToString();
            File.WriteAllText(filePath, now);
            Response.Write("Current date and time: " + now);
        }
    }
}