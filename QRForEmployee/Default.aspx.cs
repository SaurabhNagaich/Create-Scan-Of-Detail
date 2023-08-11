using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using QRForEmployee.Repository;
using ZXing;

namespace QRForEmployee
{
    public partial class Default : System.Web.UI.Page
    {

        UserRepository userRepository = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        private string GenrateCode(User user)
        {
            string path = $"{HttpContext.Current.Server.MapPath("\\")}Image\\UsersQR\\{user.FirstName+user.LastName}.png";
            File.Copy($"{HttpContext.Current.Server.MapPath("\\")}Image\\QR.png", path,true);

            string url = $"https://www.google.com/maps/@{user.Latitude},{user.Longitude},15z";
            string data = $"----------User Information-------\nFirst Name: {user.FirstName}\nLast Name: {user.LastName}\nDOB: {user.DateOfBirth}\nAddress\n\t\t\tLatitude: {user.Latitude}\n\t\t\tLongitude:{user.Longitude}\n\nGoogle Map Location: \n\t{url}";


            var writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            var result = writer.Write(data);
            //path = Server.MapPath(path);
            var QRCode = new Bitmap(result);
            using (MemoryStream ms = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    QRCode.Save(ms, ImageFormat.Jpeg);
                    byte[] bytes = ms.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            return $"~\\Image\\UsersQR\\{user.FirstName+user.LastName}.png";
        }
        protected void ShowQR(object sender, EventArgs e)
        {

            User user = new User();
            user.FirstName= TextBox1.Text;
            user.LastName= TextBox2.Text;
            user.DateOfBirth = TextBox3.Text;
            user.Latitude = TextBox4.Text;
            user.Longitude = TextBox5.Text;

            user.Img=GenrateCode(user);
            userRepository.CreateUser(user);
            

            Response.Redirect("ShowQR.aspx");
        }

    }
}