using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Mainsite.Account
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            List<string> roles = new List<string>(System.Web.Security.Roles.GetAllRoles());

            foreach (var role in roles)
            {
                CheckBox box = new CheckBox();

                box.ID = role;
                box.Text = role;

                CheckBoxRoles.Controls.Add(box);

                LiteralControl control = new LiteralControl("<br />");

                CheckBoxRoles.Controls.Add(control);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateButton_OnClick(object sender, EventArgs e)
        {

            MembershipCreateStatus userStatus;
            Membership.CreateUser(UserNameText.Text, PassText.Text, EmailText.Text, null, null, ActiveUser.Checked,
                                    out userStatus);

            if (userStatus == MembershipCreateStatus.Success)
            {
                foreach (var control in CheckBoxRoles.Controls)
                {
                    if (control is CheckBox)
                    {
                        CheckBox box = (CheckBox)control;

                        if (box.Checked)
                        {
                            System.Web.Security.Roles.AddUserToRole(UserNameText.Text, box.ID);
                        }
                    }
                }

                NameText.Text = "";
                UserNameText.Text = "";
                PassText.Text = "";
                PassConfirmText.Text = "";
                EmailText.Text = "";

                foreach (var control in CheckBoxRoles.Controls)
                {
                    if (control is CheckBox)
                    {
                        CheckBox box = (CheckBox)control;

                        box.Checked = false;
                    }

                }

                LiteralControl literalControl = new LiteralControl("<p>Usuario agregado exitosamente.</p>");
                PopUpText.Controls.Add(literalControl);
                CreateButton_ModalPopupExtender.Show();
            }
            else if (userStatus == MembershipCreateStatus.InvalidPassword)
            {
                LiteralControl literalControl = new LiteralControl("<p>Contraseña debe tener un minimo de 6 caracteres.</p>");
                PopUpText.Controls.Add(literalControl);
                CreateButton_ModalPopupExtender.Show();
            }
            else if (userStatus == MembershipCreateStatus.DuplicateUserName)
            {
                LiteralControl literalControl = new LiteralControl("<p>El usuario ya se encuentra en uso.</p>");
                PopUpText.Controls.Add(literalControl);
                CreateButton_ModalPopupExtender.Show();
            }



        }

        protected void CancelButton_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/ManageUsers.aspx");
        }
    }
}