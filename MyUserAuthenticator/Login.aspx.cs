using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyUserAuthenticator
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                LoadRoles();
        }

        public void LoadRoles() {
            ListItem role1 = new ListItem("Admin");
            ListItem role2 = new ListItem("Manager");
            ListItem role3 = new ListItem("Employee");
            ListItem role4 = new ListItem("Viewer");
            ddlUserRoles.Items.Add(role1);
            ddlUserRoles.Items.Add(role2);
            ddlUserRoles.Items.Add(role3);
            ddlUserRoles.Items.Add(role4);

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            txtUserName.Text = "Hello" + txtUserNameInput.Text;
            txtUserRole.Text = "You are logged in as " + ddlUserRoles.SelectedItem.Text;
        }
    }
}