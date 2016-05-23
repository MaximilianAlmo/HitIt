using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HitIt.Models;
using System.IO;
using MySql.Data.MySqlClient;

namespace HitIt.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
       
        //public static IHtmlString Image(this HtmlHelper helper, string src)
        //{
        //    TagBuilder tb = new TagBuilder("img");
        //    tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
        //    return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));

        //}
        //public static IHtmlString Image(this HtmlHelper helper, ApplicationUser user, string src)
        //{
        //    string connectString = "SERVER= 195.178.232.16; PORT=3306; DATABASE=af6947;UID=af6947 ;PASSWORD=sexyKalle79;";
        //    MySqlConnection connection = new MySqlConnection(connectString);
        //    connection.Open();
        //    MySqlCommand cmd = connection.CreateCommand();
        //    cmd.CommandText = "SELECT picturePath FROM profile WHERE UserName ='" + User.Identity.Name + "'";
        //    Int32 userEdit = (Int32)cmd.ExecuteScalar();
        //    cmd.CommandText = "UPDATE profile SET picturePath=@picturePath WHERE UserName ='" + User.Identity.Name + "' AND id ='" + userEdit + "'";
        //    cmd.Parameters.Add("@UserName", userEdit);
        //    cmd.Parameters.Add("@picturePath", path);
        //    cmd.ExecuteNonQuery();
        //    connection.Close();
        //}
    }
}