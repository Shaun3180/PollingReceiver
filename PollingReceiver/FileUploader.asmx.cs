using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PollingReceiver
{
    /// <summary>
    /// Summary description for FileUploader
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class FileUploader : System.Web.Services.WebService
    {

        [WebMethod]
        public string UploadFile(byte[] f, string fileName)
        {
            // the byte array argument contains the content of the file  
            // the string argument contains the name and extension  
            // of the file passed in the byte array  
            try
            {
                // instance a memory stream and pass the  
                // byte array to its constructor  
                MemoryStream ms = new MemoryStream(f);
                // instance a filestream pointing to the  
                // storage folder, use the original file name  
                // to name the resulting file  
                FileStream fs = new FileStream(System.Web.Hosting.HostingEnvironment.MapPath
                            ("~/TransientStorage/") + fileName, FileMode.Create);
                // write the memory stream containing the original  
                // file as a byte array to the filestream  
                ms.WriteTo(fs);
                // clean up  
                ms.Close();
                fs.Close();
                fs.Dispose();

                // return OK if we made it this far  
                return "OK";
            }
            catch (Exception ex)
            {
                // return the error message if the operation fails  
                return ex.Message.ToString();
            }
        }
    }
}
