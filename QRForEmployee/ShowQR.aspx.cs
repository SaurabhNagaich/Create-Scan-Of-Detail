using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;
using QRForEmployee.Repository;
using ZXing;
using static System.Net.WebRequestMethods;

namespace QRForEmployee
{
    public partial class ShowQR : System.Web.UI.Page
    {
        UserRepository userRepository= new UserRepository();
        List<User> users;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            users =userRepository.GetUserDetails();
           
            
            BindGridList();

            

        }
        protected void BindGridList()
        {
            foreach(var user in users)
            {
                
                GridView1.DataSource = users;
               
            GridView1.DataBind();
            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}