using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class subir : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [System.Web.Services.WebMethod]
    public static int guardarImagen()
    {
        var request = HttpContext.Current.Request;
        if (request.Files.Count > 0)
        {
            foreach (string file in request.Files)
            {
                var postedFile = request.Files[file];
                var filePath = HttpContext.Current.Server.MapPath(string.Format("~/productos/{0}", postedFile.FileName));
                postedFile.SaveAs(filePath);
            }
            return 1;
        }
        else
            return 0;

    }

}