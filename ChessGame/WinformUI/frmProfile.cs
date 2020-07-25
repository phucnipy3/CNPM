using Common.Enums;
using Common.Models;
using Data.BusinessLogic;
using Data.Common;
using Data.Entities;
using Helper.Client;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinformUI
{
    public partial class frmProfile : Form
    {
        public frmProfile()
        {
            InitializeComponent();
        }

        private void frmProfile_Load(object sender, EventArgs e)
        {
            UserModel user = ClientHelper.Client.User;
            lblIngame.Text = user.Username;
            txtName.Text = user.Name;
            txtPhone.Text = user.Phone;
            lblExperince.Text = user.Experience.ToString();
            txtEmail.Text = user.Email;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var name = txtName.Text.Trim();
            var phone = txtPhone.Text.Trim();
            var email = txtEmail.Text.Trim();

            if(string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập tên");
                return;
            }

            Regex regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

            if (!string.IsNullOrEmpty(email) && !regex.IsMatch(email))
            {
                MessageBox.Show("Địa chỉ email không hợp lệ");
                return;
            }

            UserModel oldUser = ClientHelper.Client.User;
            UserModel newUser = new UserModel
            {
                Avatar = oldUser.Avatar,
                Experience = oldUser.Experience,
                Id = oldUser.Id,
                Permission = oldUser.Permission,
                Username = oldUser.Username,
                Name = name,
                Phone = phone,
                Email = email
            };

            var result = await ClientHelper.UpdateProfileAsync(newUser);

            if(result.Code == (int)MessageCode.Error)
            {
                MessageBox.Show(result.Data.ToString());
            }
            else if (result.Code == (int)MessageCode.Success)
            {
                MessageBox.Show("Cập nhật thông tin thành công");
                ClientHelper.Client.User = JsonConvert.DeserializeObject<UserModel>(result.Data.ToString());
                frmProfile_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
