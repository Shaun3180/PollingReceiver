using System;
using System.IO;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace PollingReceiver
{
    public partial class Hub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    // Check if a toggle cookie exists and retrieve its value
            //    HttpCookie toggleCookie = Request.Cookies["ToggleCookie"];
            //    if (toggleCookie != null)
            //    {
            //        // Parse the cookie value to a boolean and set it to the checkbox
            //        bool toggleState = bool.Parse(toggleCookie.Value);
            //        chkAlertShaun.Checked = toggleState;
            //    }
            //}


            // for kicks and giggles record the time the hub was last hit
            string hubFilePath = Server.MapPath("~/App_Data/hub.txt");
            string hubLastHit = DateTime.Now.ToString();
            File.WriteAllText(hubFilePath, hubLastHit);

            // check the client file to see when it was last hit
            string clientFilePath = Server.MapPath("~/App_Data/client.txt");
            string clientLastHit = File.ReadAllText(clientFilePath);
            DateTime dateTimeFromFile = DateTime.Parse(clientLastHit);

            // Calculate the difference between the client's last hit and now
            TimeSpan timeDifference = DateTime.Now - dateTimeFromFile;
            double minutesDifference = timeDifference.TotalMinutes;

            // Display the number of minutes since the client last hit the app
            lblLastHit.Text = $"Client last hit {minutesDifference} minutes ago.";

            
            var shouldWeSentAlerts = File.Exists(Server.MapPath("~/App_Data/send.txt"));
            
            // Check if the client has been inactive for more than 10 minutes and if the toggle is set to "yes"
            if ((minutesDifference >= 10) && (shouldWeSentAlerts))
            {
                // If conditions are met, send a text message to Shaun
                SendTextMessage();
            }
        }

        //protected void cbToggle_CheckedChanged(object sender, EventArgs e)
        //{
        //    // Create a cookie to store the toggle state
        //    HttpCookie toggleCookie = new HttpCookie("ToggleCookie");
        //    toggleCookie.Value = chkAlertShaun.Checked.ToString();
        //    toggleCookie.Expires = DateTime.Now.AddDays(30);
        //    Response.Cookies.Add(toggleCookie);
        //}

        protected void SendTextMessage()
        {
            // Twilio account information
            string accountSid = "AC18baf764215ff711caab61bc9698600d";
            string authToken = "ca658c0c98fd059a73edc296bfc78815";

            // Your Twilio phone number
            string twilioNumber = "+18555833072";

            // The phone number you want to send the message to 
            string toNumber = "+19706904544";

            // The message you want to send
            string body = "Oops your Pi has not connected to the net in 10+ minutes. To stop these alerts remove send.txt from \\\\wsnet2\\cwis199\\WWWROOT\\transit\\App_Data";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                 body: body,
                 from: new Twilio.Types.PhoneNumber(twilioNumber),
                 to: new Twilio.Types.PhoneNumber(toNumber)
            );

            txtSent.Text = message.Body + " sent!";
        }
    }
}