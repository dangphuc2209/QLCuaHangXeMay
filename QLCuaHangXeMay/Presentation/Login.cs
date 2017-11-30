using System;
using System.Windows.Forms;
using QLCuaHangXeMay.Business;

namespace QLCuaHangXeMay.Presentation
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }
        User _user = new User();
        UserXuLy _userXuly = new UserXuLy();

        private void btnDN_Click(object sender, EventArgs e)
        {
            if(txtName.Text==""||txtName.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
                txtName.Focus();
            }
            else
            {
                if(txtPass.Text==""||txtPass.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu");
                    txtPass.Focus();
                }
                else
                {
                    _user.UserName = txtName.Text;
                    _user.PassWord = txtPass.Text;
                    int count = _userXuly.CheckUser(_user);
                    if (count == 1)
                    {
                        MessageBox.Show("Đăng nhập thành công!","Thông báo",MessageBoxButtons.OK);
                        TrangChu tc = new TrangChu();
                        this.Hide();
                        tc.Show();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    }
                }
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn thoát không ?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnDN.PerformClick();
            }
        }
    }
}
