using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLCuaHangXeMay.Business;

namespace QLCuaHangXeMay.Presentation
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }
        NhanVien _nv = new NhanVien();
        NhanVienXuLy _nvxl = new NhanVienXuLy();

        KhachHang _kh = new KhachHang();
        KhachHangXuLy _khxl = new KhachHangXuLy();

        NhaCungCap _ncc = new NhaCungCap();
        NhaCungCapXuLy _ncxl = new NhaCungCapXuLy();

        LoaiXe _lx = new LoaiXe();
        LoaiXeXuLy _lxxl = new LoaiXeXuLy();

        PhieuNhap _pn = new PhieuNhap();
        PhieuNhapXuLy _pnxl = new PhieuNhapXuLy();

        PhieuXuat _px = new PhieuXuat();
        PhieuXuatXuLy _pxxl = new PhieuXuatXuLy();

        ChiTietPhieuNhap _ctpn = new ChiTietPhieuNhap();
        ChiTietPhieuNhapXuLy _ctpnxl = new ChiTietPhieuNhapXuLy();

        ChiTietPhieuXuat _ctpx = new ChiTietPhieuXuat();
        ChiTietPhieuXuatXuLy _ctpxxl = new ChiTietPhieuXuatXuLy();

        private void TrangChu_Load(object sender, EventArgs e)
        {
            NhanVien_Load();
            KhachHang_Load();
            NhaCungCap_Load();
            LoaiXe_Load();
            PhieuNhap_Load();
            PhieuXuat_Load();
            CTPhieuNhap_Load();
            CTPhieuXuat_Load();
        }
        //function
        private String VietHoaChuoi(String s)
        {
            if (String.IsNullOrEmpty(s))
                return s;
            String result = "";
            String[] words = s.Split(' ');
            foreach(String word in words)
            {
                if(word.Trim() != "")
                {
                    if (word.Length > 1)
                        result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                    else
                        result += word.ToUpper() + " ";
                }
            }
            return result;
        }
        private bool IsEmail(string inputEmail)
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(strRegex);
            if (re.IsMatch(inputEmail))
                return (true);
            else
                return (false);
        }
        //function
#region tabNhaVien
        //begin tabNhanVien
        private void NhanVien_Load()
        {
            dgwNhanVien.DataSource = _nvxl.NhanVien_SelectAll();
            txtMaNV.Focus();
            btnSuaNV.Enabled = false;
        }

        private void dgwNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            dtpkNgaySinh.DataBindings.Clear();
            cmbGioiTinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtDienThoai.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            dtpkNgayVaoLam.DataBindings.Clear();
            txtLuongCoBan.DataBindings.Clear();
            txtLuong.DataBindings.Clear();

            txtMaNV.DataBindings.Add("Text", dgwNhanVien.DataSource, "MaNV");
            txtTenNV.DataBindings.Add("Text", dgwNhanVien.DataSource, "TenNV");
            dtpkNgaySinh.DataBindings.Add("Text", dgwNhanVien.DataSource, "NgaySinh");
            cmbGioiTinh.DataBindings.Add("Text", dgwNhanVien.DataSource, "GioiTinh");
            txtDiaChi.DataBindings.Add("Text", dgwNhanVien.DataSource, "DiaChi");
            txtDienThoai.DataBindings.Add("Text", dgwNhanVien.DataSource, "DienThoai");
            txtChucVu.DataBindings.Add("Text", dgwNhanVien.DataSource, "ChucVu");
            dtpkNgayVaoLam.DataBindings.Add("Text", dgwNhanVien.DataSource, "NgayVaoLam");
            txtLuongCoBan.DataBindings.Add("Text", dgwNhanVien.DataSource, "LuongCoBan");
            txtLuong.DataBindings.Add("Text", dgwNhanVien.DataSource, "Luong");

            txtMaNV.Enabled = false;
            btnThemNV.Enabled = false;
            btnSuaNV.Enabled = true;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

            if (txtMaNV.Text == "" || txtMaNV.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng mã nhân viên", "Thông báo");
                txtMaNV.Focus();
            }
            else
            {
                if (txtTenNV.Text == "" || txtTenNV.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập đúng tên nhân viên", "Thông báo");
                    txtTenNV.Focus();
                }
                else
                {
                    if(dtpkNgaySinh.Value == DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                        dtpkNgaySinh.Focus();
                    }
                    else
                    {
                        if (cmbGioiTinh.SelectedIndex == -1)
                        {
                            MessageBox.Show("Vui lòng chọn giới tính", "Thông báo");
                            cmbGioiTinh.Focus();
                        }
                        else
                        {
                            if (txtDiaChi.Text == "")
                            {
                                MessageBox.Show("Vui lòng nhập đúng địa chỉ", "Thông báo");
                                txtDiaChi.Focus();
                            }
                            else
                            {
                                if (txtDienThoai.Text == "" || txtDienThoai.TextLength < 1 || txtDienThoai.TextLength > 11)
                                {
                                    MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                                    txtDienThoai.Focus();
                                }
                                else
                                {
                                    if(txtChucVu.Text == "")
                                    {
                                        MessageBox.Show("Vui lòng nhập đúng chức vụ", "Thông báo");
                                        txtChucVu.Focus();
                                    }
                                    else
                                    {
                                        if (dtpkNgayVaoLam.Value == DateTime.Now)
                                        {
                                            MessageBox.Show("Vui lòng chọn ngày vào làm", "Thông báo");
                                            dtpkNgayVaoLam.Focus();
                                        }
                                        else
                                        {
                                            if(txtLuongCoBan.Text == "" || txtLuongCoBan.TextLength < 1)
                                            {
                                                MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                                                txtLuongCoBan.Focus();
                                            }
                                            else
                                            {
                                                if(txtLuong.Text == "" || txtLuong.TextLength < 1)
                                                {
                                                    MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                                                    txtLuong.Focus();
                                                }
                                                else
                                                {
                                                    try
                                                    {
                                                        _nv.MaNv = txtMaNV.Text.ToUpper();
                                                        _nv.TenNv = VietHoaChuoi(txtTenNV.Text);
                                                        _nv.Luong = int.Parse(txtLuong.Text);
                                                        _nv.NgaySinh = dtpkNgaySinh.Value;
                                                        if (cmbGioiTinh.Text.CompareTo("Nam") == 0)
                                                        {
                                                            _nv.GioiTinh = "Nam";
                                                        }
                                                        else
                                                        {
                                                            _nv.GioiTinh = "Nữ";
                                                        }
                                                        _nv.DiaChi = VietHoaChuoi(txtDiaChi.Text);
                                                        _nv.DienThoai = txtDienThoai.Text;
                                                        _nv.ChucVu = txtChucVu.Text;
                                                        _nv.NgayVaoLam = dtpkNgayVaoLam.Value;
                                                        _nv.LuongCoBan = int.Parse(txtLuongCoBan.Text);
                                                        if (!(_nvxl.CheckId(_nv.MaNv)))
                                                        {
                                                            _nvxl.NhanVien_Insert(_nv);
                                                            Clear_NV();
                                                            NhanVien_Load();
                                                            MessageBox.Show("Thêm nhân viên thành công !", "Thông báo", MessageBoxButtons.OK);
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("Mã nhân viên " + _nv.MaNv + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        }
                                                    }
                                                    catch(Exception)
                                                    {
                                                        MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên", "Thông báo");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _nv.MaNv = txtMaNV.Text;
                        _nvxl.NhanVien_Delete(_nv);
                        Clear_NV();
                        NhanVien_Load();
                        MessageBox.Show("Xóa nhân viên " + _nv.MaNv + " thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch(Exception)
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            _nv.MaNv = txtMaNV.Text.ToUpper();
            if (txtTenNV.Text == "" || txtTenNV.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng tên nhân viên", "Thông báo");
                txtTenNV.Focus();
            }
            else
            {
                if (dtpkNgaySinh.Value == DateTime.Now)
                {
                    MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                    dtpkNgaySinh.Focus();
                }
                else
                {
                    if (cmbGioiTinh.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn giới tính", "Thông báo");
                        cmbGioiTinh.Focus();
                    }
                    else
                    {
                        if (txtDiaChi.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập đúng địa chỉ", "Thông báo");
                            txtDiaChi.Focus();
                        }
                        else
                        {
                            if (txtDienThoai.Text == "" || txtDienThoai.TextLength < 1 || txtDienThoai.TextLength > 11)
                            {
                                MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                                txtDienThoai.Focus();
                            }
                            else
                            {
                                if (txtChucVu.Text == "")
                                {
                                    MessageBox.Show("Vui lòng nhập đúng chức vụ", "Thông báo");
                                    txtChucVu.Focus();
                                }
                                else
                                {
                                    if (dtpkNgayVaoLam.Value == DateTime.Now)
                                    {
                                        MessageBox.Show("Vui lòng chọn ngày vào làm", "Thông báo");
                                        dtpkNgayVaoLam.Focus();
                                    }
                                    else
                                    {
                                        if (txtLuongCoBan.Text == "" || txtLuongCoBan.TextLength < 1)
                                        {
                                            MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                                            txtLuongCoBan.Focus();
                                        }
                                        else
                                        {
                                            if (txtLuong.Text == "" || txtLuong.TextLength < 1)
                                            {
                                                MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                                                txtLuong.Focus();
                                            }
                                            else
                                            {
                                                _nv.TenNv = VietHoaChuoi(txtTenNV.Text);
                                                _nv.Luong = int.Parse(txtLuong.Text);
                                                _nv.NgaySinh = dtpkNgaySinh.Value;
                                                if (cmbGioiTinh.Text.CompareTo("Nam") == 0)
                                                {
                                                    _nv.GioiTinh = "Nam";
                                                }
                                                else
                                                {
                                                    _nv.GioiTinh = "Nữ";
                                                }
                                                _nv.DiaChi = VietHoaChuoi(txtDiaChi.Text);
                                                _nv.DienThoai = txtDienThoai.Text;
                                                _nv.ChucVu = txtChucVu.Text;
                                                _nv.NgayVaoLam = dtpkNgayVaoLam.Value;
                                                _nv.LuongCoBan = int.Parse(txtLuongCoBan.Text);
                                                _nvxl.NhanVien_Update(_nv);
                                                Clear_NV();
                                                NhanVien_Load();
                                                MessageBox.Show("Cập nhật nhân viên thành công !", "Thông báo", MessageBoxButtons.OK);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnLamMoiNV_Click(object sender, EventArgs e)
        {
            Clear_NV();
        }
        public void Clear_NV()
        {
            txtMaNV.DataBindings.Clear();
            txtTenNV.DataBindings.Clear();
            dtpkNgaySinh.DataBindings.Clear();
            cmbGioiTinh.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtDienThoai.DataBindings.Clear();
            txtChucVu.DataBindings.Clear();
            dtpkNgayVaoLam.DataBindings.Clear();
            txtLuongCoBan.DataBindings.Clear();
            txtLuong.DataBindings.Clear();

            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            dtpkNgaySinh.Value = DateTime.Now;
            cmbGioiTinh.SelectedIndex = -1;
            txtDiaChi.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            dtpkNgayVaoLam.Value = DateTime.Now;
            txtLuongCoBan.Text = string.Empty;
            txtLuong.Text = string.Empty;

            txtMaNV.Focus();
            txtMaNV.Enabled = true;
            btnThemNV.Enabled = true;
            btnSuaNV.Enabled = false;
        }
        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuongCoBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemNV_TextChanged(object sender, EventArgs e)
        {
            String item = txtTimKiemNV.Text;
            dgwNhanVien.DataSource = _nvxl.FindItem(item);
        }
        //end tabNhanVien
        #endregion
#region tabKhachHang
        //begin tabKhachHang
        private void KhachHang_Load()
        {
            dgwKhachHang.DataSource = _khxl.KhachHang_SelectAll();
            txtMaKH.Focus();
            btnSuaKH.Enabled = false;
        }

        private void dgwKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            dtpkNgaySinhKH.DataBindings.Clear();
            txtDiaChiKH.DataBindings.Clear();
            txtDienThoaiKH.DataBindings.Clear();
            txtEmailKH.DataBindings.Clear();
            txtTinhTrang.DataBindings.Clear();

            txtMaKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "MaKH");
            txtTenKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "TenKH");
            dtpkNgaySinhKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "NgaySinh");
            txtDiaChiKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "DiaChi");
            txtDienThoaiKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "DienThoai");
            txtEmailKH.DataBindings.Add("Text", dgwKhachHang.DataSource, "Email");
            txtTinhTrang.DataBindings.Add("Text", dgwKhachHang.DataSource, "TinhTrang");

            txtMaKH.Enabled = false;
            btnThemKH.Enabled = false;
            btnSuaKH.Enabled = true;
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "" || txtMaKH.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng mã khách hàng", "Thông báo");
                txtMaKH.Focus();
            }
            else
            {
                if (txtTenKH.Text == "" || txtTenKH.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập đúng tên khách hàng", "Thông báo");
                    txtTenKH.Focus();
                }
                else
                {
                    if (dtpkNgaySinhKH.Value == DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                        dtpkNgaySinhKH.Focus();
                    }
                    else
                    {
                        if (txtDiaChiKH.Text == "")
                        {
                            MessageBox.Show("Vui lòng đúng địa chỉ", "Thông báo");
                            txtDiaChiKH.Focus();
                        }
                        else
                        {
                            if (txtDienThoaiKH.Text == "" || txtDienThoaiKH.TextLength < 1 || txtDienThoaiKH.TextLength > 11)
                            {
                                MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                                txtDienThoaiKH.Focus();
                            }
                            else
                            {
                                if (txtEmailKH.Text == "" || IsEmail(txtEmailKH.Text) == false)
                                {
                                    MessageBox.Show("Vui lòng nhập đúng email", "Thông báo");
                                    txtEmailKH.Focus();
                                }
                                else
                                {
                                    if (txtTinhTrang.Text == "")
                                    {
                                        MessageBox.Show("Vui lòng nhập đúng tình trạng", "Thông báo");
                                        txtTinhTrang.Focus();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            _kh.MaKh = txtMaKH.Text.ToUpper();
                                            _kh.TenKh = VietHoaChuoi(txtTenKH.Text);
                                            _kh.NgaySinh = dtpkNgaySinhKH.Value;
                                            _kh.DiaChi = VietHoaChuoi(txtDiaChiKH.Text);
                                            _kh.DienThoai = txtDienThoaiKH.Text;
                                            _kh.Email = txtEmailKH.Text;
                                            _kh.TinhTrang = txtTinhTrang.Text;
                                            if (!(_khxl.CheckId(_kh.MaKh)))
                                            {
                                                _khxl.KhachHang_Insert(_kh);
                                                Clear_KH();
                                                KhachHang_Load();
                                                MessageBox.Show("Thêm khách hàng thành công", "Thông báo", MessageBoxButtons.OK);
                                            }
                                            else
                                            {
                                                MessageBox.Show("Mã khách hàng " + _kh.MaKh + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        catch(Exception)
                                        {
                                            MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng", "Thông báo");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _kh.MaKh = txtMaKH.Text;
                        _khxl.KhachHang_Delete(_kh);
                        Clear_KH();
                        KhachHang_Load();
                        MessageBox.Show("Xóa khách hàng " + _kh.MaKh + " thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            _kh.MaKh = txtMaNV.Text.ToUpper();
            if (txtTenKH.Text == "" || txtTenKH.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng tên khách hàng", "Thông báo");
                txtTenKH.Focus();
            }
            else
            {
                if (dtpkNgaySinhKH.Value == DateTime.Now)
                {
                    MessageBox.Show("Vui lòng chọn ngày sinh", "Thông báo");
                    dtpkNgaySinhKH.Focus();
                }
                else
                {
                    if (txtDiaChiKH.Text == "")
                    {
                        MessageBox.Show("Vui lòng đúng địa chỉ", "Thông báo");
                        txtDiaChiKH.Focus();
                    }
                    else
                    {
                        if (txtDienThoaiKH.Text == "" || txtDienThoaiKH.TextLength < 1 || txtDienThoaiKH.TextLength > 11)
                        {
                            MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                            txtDienThoaiKH.Focus();
                        }
                        else
                        {
                            if (txtEmailKH.Text == "" || !IsEmail(txtEmailKH.Text))
                            {
                                MessageBox.Show("Vui lòng nhập đúng email", "Thông báo");
                                txtEmailKH.Focus();
                            }
                            else
                            {
                                if (txtTinhTrang.Text == "")
                                {
                                    MessageBox.Show("Vui lòng nhập đúng tình trạng", "Thông báo");
                                    txtTinhTrang.Focus();
                                }
                                else
                                {
                                    _kh.TenKh = VietHoaChuoi(txtTenKH.Text);
                                    _kh.NgaySinh = dtpkNgaySinhKH.Value;
                                    _kh.DiaChi = VietHoaChuoi(txtDiaChiKH.Text);
                                    _kh.DienThoai = txtDienThoaiKH.Text;
                                    _kh.Email = txtEmailKH.Text;
                                    _kh.TinhTrang = txtTinhTrang.Text;
                                    _khxl.KhachHang_Update(_kh);
                                    Clear_KH();
                                    KhachHang_Load();
                                    MessageBox.Show("Cập nhật khách hàng thành công !", "Thông báo", MessageBoxButtons.OK);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnLamMoiKH_Click(object sender, EventArgs e)
        {
            Clear_KH();
        }
        private void Clear_KH()
        {
            txtMaKH.DataBindings.Clear();
            txtTenKH.DataBindings.Clear();
            dtpkNgaySinhKH.DataBindings.Clear();
            txtDiaChiKH.DataBindings.Clear();
            txtDienThoaiKH.DataBindings.Clear();
            txtEmailKH.DataBindings.Clear();
            txtTinhTrang.DataBindings.Clear();

            txtMaKH.Text = String.Empty;
            txtTenKH.Text = String.Empty;
            dtpkNgaySinhKH.Value = DateTime.Now;
            txtDiaChiKH.Text = String.Empty;
            txtDienThoaiKH.Text = String.Empty;
            txtEmailKH.Text = String.Empty;
            txtTinhTrang.Text = String.Empty;

            txtMaKH.Focus();
            txtMaKH.Enabled = true;
            btnThemKH.Enabled = true;
            btnSuaKH.Enabled = false;
        }

        private void txtDienThoaiKH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemKH_TextChanged(object sender, EventArgs e)
        {
            String item = txtTimKiemKH.Text;
            dgwKhachHang.DataSource = _khxl.FindItem(item);
        }
        //end tabKhachHang
        #endregion
#region tabNhaCungCap
        //begin tabNhaCungCap
        private void NhaCungCap_Load()
        {
            dgwNhaCC.DataSource = _ncxl.NhaCungCap_SelectAll();
            txtMaNhaCC.Focus();
            btnSuaNhaCC.Enabled = false;
        }

        private void dgwNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhaCC.DataBindings.Clear();
            txtNhaCC.DataBindings.Clear();
            txtDiaChiNhaCC.DataBindings.Clear();
            txtDienThoaiNhaCC.DataBindings.Clear();
            txtEmailNhaCC.DataBindings.Clear();

            txtMaNhaCC.DataBindings.Add("Text", dgwNhaCC.DataSource, "MaNhaCC");
            txtNhaCC.DataBindings.Add("Text", dgwNhaCC.DataSource, "TenNhaCC");
            txtDiaChiNhaCC.DataBindings.Add("Text", dgwNhaCC.DataSource, "DiaChi");
            txtDienThoaiNhaCC.DataBindings.Add("Text", dgwNhaCC.DataSource, "DienThoai");
            txtEmailNhaCC.DataBindings.Add("Text", dgwNhaCC.DataSource, "Email");

            txtMaNhaCC.Enabled = false;
            btnThemNhaCC.Enabled = false;
            btnSuaNhaCC.Enabled = true;
        }

        private void btnThemNhaCC_Click(object sender, EventArgs e)
        {
            if (txtMaNhaCC.Text == "" || txtMaNhaCC.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng mã nhà cung cấp", "Thông báo");
                txtMaNhaCC.Focus();
            }
            else
            {
                if (txtNhaCC.Text == "" || txtNhaCC.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập đúng tên nhà cung cấp", "Thông báo");
                    txtNhaCC.Focus();
                }
                else
                {
                    if (txtDiaChiNhaCC.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đúng địa chỉ", "Thông báo");
                        txtDiaChiNhaCC.Focus();
                    }
                    else
                    {
                        if (txtDienThoaiNhaCC.Text == "" || txtDienThoaiNhaCC.TextLength < 1 || txtDienThoaiNhaCC.TextLength > 11)
                        {
                            MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                            txtDienThoaiNhaCC.Focus();
                        }
                        else
                        {
                            if (txtEmailNhaCC.Text == "" || !IsEmail(txtEmailNhaCC.Text))
                            {
                                MessageBox.Show("Vui lòng nhập đúng email", "Thông báo");
                                txtEmailNhaCC.Focus();
                            }
                            else
                            {
                                try
                                {
                                    _ncc.MaNhaCc = txtMaNhaCC.Text.ToUpper();
                                    _ncc.TenNhaCc = VietHoaChuoi(txtNhaCC.Text);
                                    _ncc.DiaChi = txtDiaChiNhaCC.Text;
                                    _ncc.DienThoai = txtDienThoaiNhaCC.Text;
                                    _ncc.Email = txtEmailNhaCC.Text;
                                    if (!(_ncxl.CheckId(_ncc.MaNhaCc)))
                                    {
                                        _ncxl.NhaCungCap_Insert(_ncc);
                                        Clear_NhaCC();
                                        NhaCungCap_Load();
                                        MessageBox.Show("Thêm nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Nhà cung cấp " + _ncc.MaNhaCc + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnXoaNhaCC_Click(object sender, EventArgs e)
        {
            if (txtMaNhaCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp", "Thông báo");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _ncc.MaNhaCc = txtMaNhaCC.Text;
                        _ncxl.NhaCungCap_Delete(_ncc);
                        Clear_NhaCC();
                        NhaCungCap_Load();
                        MessageBox.Show("Xóa nhà cung cấp " + _ncc.MaNhaCc + " thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaNhaCC_Click(object sender, EventArgs e)
        {
            _ncc.MaNhaCc = txtMaNhaCC.Text.ToUpper();
            if (txtNhaCC.Text == "" || txtNhaCC.Text.IndexOfAny(@"0123456789!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng tên nhà cung cấp", "Thông báo");
                txtNhaCC.Focus();
            }
            else
            {
                if (txtDiaChiNhaCC.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đúng địa chỉ", "Thông báo");
                    txtDiaChiNhaCC.Focus();
                }
                else
                {
                    if (txtDienThoaiNhaCC.Text == "" || txtDienThoaiNhaCC.TextLength < 1 || txtDienThoaiNhaCC.TextLength > 11)
                    {
                        MessageBox.Show("Vui lòng nhập đúng số điện thoại", "Thông báo");
                        txtDienThoaiNhaCC.Focus();
                    }
                    else
                    {
                        if (txtEmailNhaCC.Text == "" || !IsEmail(txtEmailNhaCC.Text))
                        {
                            MessageBox.Show("Vui lòng nhập đúng email", "Thông báo");
                            txtEmailNhaCC.Focus();
                        }
                        else
                        {
                            _ncc.TenNhaCc = VietHoaChuoi(txtNhaCC.Text);
                            _ncc.DiaChi = VietHoaChuoi(txtDiaChiNhaCC.Text);
                            _ncc.DienThoai = txtDienThoaiNhaCC.Text;
                            _ncc.Email = txtEmailNhaCC.Text;
                            _ncxl.NhaCungCap_Update(_ncc);
                            Clear_NhaCC();
                            NhaCungCap_Load();
                            MessageBox.Show("Cập nhật nhà cung cấp thành công", "Thông báo", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void btnLamMoiNhaCC_Click(object sender, EventArgs e)
        {
            Clear_NhaCC();
        }
        private void Clear_NhaCC()
        {
            txtMaNhaCC.DataBindings.Clear();
            txtNhaCC.DataBindings.Clear();
            txtDiaChiNhaCC.DataBindings.Clear();
            txtDienThoaiNhaCC.DataBindings.Clear();
            txtEmailNhaCC.DataBindings.Clear();

            txtMaNhaCC.Text = String.Empty;
            txtNhaCC.Text = String.Empty;
            txtDiaChiNhaCC.Text = String.Empty;
            txtDienThoaiNhaCC.Text = String.Empty;
            txtEmailNhaCC.Text = String.Empty;

            txtMaNhaCC.Focus();
            txtMaNhaCC.Enabled = true;
            btnThemNhaCC.Enabled = true;
            btnSuaNhaCC.Enabled = false;
        }

        private void txtDienThoaiNhaCC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemNhaCC_TextChanged(object sender, EventArgs e)
        {
            String item = txtTimKiemNhaCC.Text;
            dgwNhaCC.DataSource = _ncxl.FindItem(item);
        }
        //end tabNhaCunCap
        #endregion
#region tabXe
        //begin tabXe
        private void LoaiXe_Load()
        {
            dgwXe.DataSource = _lxxl.Xe_SelectAll();
            txtMaXe.Focus();
            btnSuaXe.Enabled = false;
        }

        private void dgwXe_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaXe.DataBindings.Clear();
            txtTenXe.DataBindings.Clear();
            txtHangXe.DataBindings.Clear();
            numSoLuong.DataBindings.Clear();
            txtTTBH.DataBindings.Clear();
            txtNhaSX.DataBindings.Clear();
            txtDonGiaXe.DataBindings.Clear();
            cmbTinhTrang.DataBindings.Clear();

            txtMaXe.DataBindings.Add("Text", dgwXe.DataSource, "MaXe");
            txtTenXe.DataBindings.Add("Text", dgwXe.DataSource, "TenXe");
            txtHangXe.DataBindings.Add("Text", dgwXe.DataSource, "TenHangXe");
            numSoLuong.DataBindings.Add("Text", dgwXe.DataSource, "SoLuong");
            txtTTBH.DataBindings.Add("Text", dgwXe.DataSource, "ThongTinBaoHanh");
            txtNhaSX.DataBindings.Add("Text", dgwXe.DataSource, "NhaSX");
            txtDonGiaXe.DataBindings.Add("Text", dgwXe.DataSource, "DonGia");
            cmbTinhTrang.DataBindings.Add("Text", dgwXe.DataSource, "TinhTrang");

            txtMaXe.Enabled = false;
            btnThemXe.Enabled = false;
            btnSuaXe.Enabled = true;
        }

        private void btnThemXe_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text == "" || txtMaXe.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng mã xe", "Thông báo");
                txtMaXe.Focus();
            }
            else
            {
                if (txtTenXe.Text == "" || txtTenXe.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập đúng tên xe", "Thông báo");
                    txtTenXe.Focus();
                }
                else
                {
                    if (txtNhaSX.Text == "" || txtNhaSX.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                    {
                        MessageBox.Show("Vui lòng nhập đúng nhà sản xuất", "Thông báo");
                        txtNhaSX.Focus();
                    }
                    else
                    {
                        if (txtHangXe.Text == "" || txtHangXe.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                        {
                            MessageBox.Show("Vui lòng nhập đúng hãng xe", "Thông báo");
                            txtHangXe.Focus();
                        }
                        else
                        {
                            if (txtTTBH.Text == "")
                            {
                                MessageBox.Show("Vui lòng nhập đúng thông tin bảo hành", "Thông báo");
                                txtTTBH.Focus();
                            }
                            else
                            {
                                if (cmbTinhTrang.SelectedIndex == -1)
                                {
                                    MessageBox.Show("Vui lòng chọn đúng", "Thông báo");
                                    cmbTinhTrang.Focus();
                                }
                                else
                                {
                                    if (txtDonGiaXe.Text == "" || txtDonGiaXe.TextLength < 1)
                                    {
                                        MessageBox.Show("Vui lòng nhập đúng đơn giá", "Thông báo");
                                        txtDonGiaXe.Focus();
                                    }
                                    else
                                    {
                                        if (numSoLuong.Value == 0)
                                        {
                                            MessageBox.Show("Vui lòng nhập số lượng", "Thông báo");
                                            numSoLuong.Focus();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _lx.MaXe = txtMaXe.Text.ToUpper();
                                                _lx.TenXe = VietHoaChuoi(txtTenXe.Text);
                                                _lx.NhaSx = VietHoaChuoi(txtNhaSX.Text);
                                                _lx.TenHangXe = VietHoaChuoi(txtHangXe.Text);
                                                _lx.ThongTinBaoHanh = txtTTBH.Text;
                                                if (cmbTinhTrang.Text.CompareTo("Còn") == 0)
                                                {
                                                    _lx.TinhTrang = "Còn";
                                                }
                                                else
                                                {
                                                    _lx.TinhTrang = "Hết";
                                                }
                                                _lx.DonGia = int.Parse(txtDonGiaXe.Text);
                                                _lx.SoLuong = Convert.ToInt16(numSoLuong.Value.ToString());
                                                if (!(_lxxl.CheckId(_lx.MaXe)))
                                                {
                                                    _lxxl.Xe_Insert(_lx);
                                                    Clear_Xe();
                                                    LoaiXe_Load();
                                                    MessageBox.Show("Thêm xe thành công !", "Thông báo", MessageBoxButtons.OK);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Mã xe " + _lx.MaXe + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            catch(Exception ex)
                                            {
                                                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnXoaXe_Click(object sender, EventArgs e)
        {
            if (txtMaXe.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã xe", "Thông báo");
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Bạn có muốn xóa không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _lx.MaXe = txtMaXe.Text;
                        _lxxl.Xe_Delete(_lx);
                        Clear_Xe();
                        LoaiXe_Load();
                        MessageBox.Show("Xóa xe " + _lx.MaXe + " thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaXe_Click(object sender, EventArgs e)
        {
            _lx.MaXe = txtMaXe.Text.ToUpper();
            if (txtTenXe.Text == "" || txtTenXe.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng tên xe", "Thông báo");
                txtTenXe.Focus();
            }
            else
            {
                if (txtNhaSX.Text == "" || txtNhaSX.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                {
                    MessageBox.Show("Vui lòng nhập đúng nhà sản xuất", "Thông báo");
                    txtNhaSX.Focus();
                }
                else
                {
                    if (txtHangXe.Text == "" || txtHangXe.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
                    {
                        MessageBox.Show("Vui lòng nhập đúng hãng xe", "Thông báo");
                        txtHangXe.Focus();
                    }
                    else
                    {
                        if (txtTTBH.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập đúng thông tin bảo hành", "Thông báo");
                            txtTTBH.Focus();
                        }
                        else
                        {
                            if (cmbTinhTrang.SelectedIndex == -1)
                            {
                                MessageBox.Show("Vui lòng chọn đúng", "Thông báo");
                                cmbTinhTrang.Focus();
                            }
                            else
                            {
                                if (txtDonGiaXe.Text == "" || txtDonGiaXe.TextLength < 1)
                                {
                                    MessageBox.Show("Vui lòng nhập đúng đơn giá", "Thông báo");
                                    txtDonGiaXe.Focus();
                                }
                                else
                                {
                                    if (numSoLuong.Value == 0)
                                    {
                                        MessageBox.Show("Vui lòng nhập số lượng", "Thông báo");
                                        numSoLuong.Focus();
                                    }
                                    else
                                    {
                                        _lx.TenXe = VietHoaChuoi(txtTenXe.Text);
                                        _lx.NhaSx = VietHoaChuoi(txtNhaSX.Text);
                                        _lx.TenHangXe = VietHoaChuoi(txtHangXe.Text);
                                        _lx.ThongTinBaoHanh = txtTTBH.Text;
                                        if (cmbTinhTrang.Text.CompareTo("Còn") == 0)
                                        {
                                            _lx.TinhTrang = "Còn";
                                        }
                                        else
                                        {
                                            _lx.TinhTrang = "Hết";
                                        }
                                        _lx.DonGia = int.Parse(txtDonGiaXe.Text);
                                        _lx.SoLuong = Convert.ToInt16(numSoLuong.Value.ToString());
                                        _lxxl.Xe_Update(_lx);
                                        Clear_Xe();
                                        LoaiXe_Load();
                                        MessageBox.Show("Cập nhật xe thành công !", "Thông báo", MessageBoxButtons.OK);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnLamMoiXe_Click(object sender, EventArgs e)
        {
            Clear_Xe();
        }
        private void Clear_Xe()
        {
            txtMaXe.DataBindings.Clear();
            txtTenXe.DataBindings.Clear();
            txtHangXe.DataBindings.Clear();
            numSoLuong.DataBindings.Clear();
            txtTTBH.DataBindings.Clear();
            txtNhaSX.DataBindings.Clear();
            txtDonGiaXe.DataBindings.Clear();
            cmbTinhTrang.DataBindings.Clear();

            txtMaXe.Text = String.Empty;
            txtTenXe.Text = String.Empty;
            txtHangXe.Text = String.Empty;
            numSoLuong.Value = 0;
            txtTTBH.Text = String.Empty;
            txtNhaSX.Text = String.Empty;
            txtDonGiaXe.Text = String.Empty;
            cmbTinhTrang.Text = String.Empty;

            txtMaXe.Focus();
            txtMaXe.Enabled = true;
            btnThemXe.Enabled = true;
            btnSuaXe.Enabled = false;
        }
        private void txtDonGiaXe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTimKiemXe_TextChanged(object sender, EventArgs e)
        {
            String item = txtTimKiemXe.Text;
            dgwXe.DataSource = _lxxl.FindItem(item);
        }
        //end tabXe
        #endregion
#region tabPhieuNhap
        //begin tabPhieuNhap/ChiTietPhieuNhap
        private void PhieuNhap_Load()
        {
            dgwPhieuNhap.DataSource = _pnxl.PhieuNhap_SelectAll();

            cmbMaNhanVienNhap.DataSource = _nvxl.NhanVien_SelectAll();
            cmbMaNhanVienNhap.ValueMember = "MaNV";

            cmbMaNhaCCN.DataSource = _ncxl.NhaCungCap_SelectAll();
            cmbMaNhaCCN.ValueMember = "MaNhaCC";
        }
        private void CTPhieuNhap_Load()
        {
            dgwCTPhieuNhap.DataSource = _ctpnxl.CTPhieuNhap_SelectAll();

            cmbMaXeNhap.DataSource = _lxxl.Xe_SelectAll();
            cmbMaXeNhap.ValueMember = "MaXe";

            btnThemPNCT.Enabled = false;
            btnLuuPN.Enabled = false;
            btnSuaPNCT.Enabled = false;
            btnXoaPNCT.Enabled = false;
        }

        private void dgwPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemNhap.Enabled = false;
            btnThemPNCT.Enabled = true;
            txtMaPN.Enabled = false;

            txtMaPN.DataBindings.Clear();
            cmbMaNhanVienNhap.DataBindings.Clear();
            cmbMaNhaCCN.DataBindings.Clear();
            dtpkNgayNhap.DataBindings.Clear();

            txtMaPN.DataBindings.Add("Text", dgwPhieuNhap.DataSource, "MaPhieuNhap");
            cmbMaNhanVienNhap.DataBindings.Add("Text", dgwPhieuNhap.DataSource, "MaNV");
            cmbMaNhaCCN.DataBindings.Add("Text", dgwPhieuNhap.DataSource, "MaNhaCC");
            dtpkNgayNhap.DataBindings.Add("Text", dgwPhieuNhap.DataSource, "NgayNhap");
        }

        private void dgwCTPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaPhieuNhapCT.Enabled = false;
            btnSuaPNCT.Enabled = true;
            btnXoaPNCT.Enabled = true;

            txtMaPhieuNhapCT.DataBindings.Clear();
            cmbMaXeNhap.DataBindings.Clear();
            numSoLuongNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Clear();
            txtThueNhap.DataBindings.Clear();

            txtMaPhieuNhapCT.DataBindings.Add("Text", dgwCTPhieuNhap.DataSource, "MaPhieuNhap");
            cmbMaXeNhap.DataBindings.Add("Text", dgwCTPhieuNhap.DataSource, "MaXe");
            numSoLuongNhap.DataBindings.Add("Text", dgwCTPhieuNhap.DataSource, "SLNhap");
            txtDonGiaNhap.DataBindings.Add("Text", dgwCTPhieuNhap.DataSource, "DonGiaNhap");
            txtThueNhap.DataBindings.Add("Text", dgwCTPhieuNhap.DataSource, "Thue");
        }

        private void btnThemNhap_Click(object sender, EventArgs e)
        {
            if(txtMaPN.Text == "" || txtMaPN.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                txtMaPN.Focus();
            }
            else
            {
                if(cmbMaNhanVienNhap.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo");
                    cmbMaNhanVienNhap.Focus();
                }
                else
                {
                    if(cmbMaNhaCCN.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn nhà cung cấp");
                        cmbMaNhaCCN.Focus();
                    }
                    else
                    {
                        if(dtpkNgayNhap.Value == DateTime.Now)
                        {
                            MessageBox.Show("Vui lòng chọn ngày nhập");
                        }
                        else
                        {
                            try
                            {
                                _pn.MaPhieuNhap = txtMaPN.Text.ToUpper();
                                _pn.MaNv = cmbMaNhanVienNhap.SelectedValue.ToString().Trim();
                                _pn.MaNhaCc = cmbMaNhaCCN.SelectedValue.ToString().Trim();
                                _pn.NgayNhap = dtpkNgayNhap.Value;
                                if (!(_pnxl.CheckId(_pn.MaPhieuNhap)))
                                {
                                    _pnxl.PhieuNhap_Insert(_pn);
                                    Clear_Nhap();
                                    PhieuNhap_Load();
                                    MessageBox.Show("Thêm phiếu nhập thành công !", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    MessageBox.Show("Phiếu nhập " + _pn.MaPhieuNhap + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnSuaNhap_Click(object sender, EventArgs e)
        {
            _pn.MaPhieuNhap = txtMaPN.Text.ToUpper();
            if (cmbMaNhanVienNhap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                cmbMaNhanVienNhap.Focus();
            }
            else
            {
                if (cmbMaNhaCCN.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    cmbMaNhaCCN.Focus();
                }
                else
                {
                    if (dtpkNgayNhap.Value == DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng chọn ngày nhập","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        _pn.MaNv = cmbMaNhanVienNhap.SelectedValue.ToString().Trim();
                        _pn.MaNhaCc = cmbMaNhaCCN.SelectedValue.ToString().Trim();
                        _pn.NgayNhap = dtpkNgayNhap.Value;
                        _pnxl.PhieuNhap_Update(_pn);
                        Clear_Nhap();
                        PhieuNhap_Load();
                        MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnLamMoiNhap_Click(object sender, EventArgs e)
        {
            Clear_Nhap();
            Clear_PNCT();
        }
        private void Clear_Nhap()
        {
            btnThemNhap.Enabled = true;
            txtMaPN.Enabled = true;
            //txtMaXePN.Enabled = true;

            txtMaPN.DataBindings.Clear();
            cmbMaNhanVienNhap.DataBindings.Clear();
            cmbMaNhaCCN.DataBindings.Clear();
            dtpkNgayNhap.DataBindings.Clear();

            txtMaPN.Text = String.Empty;
            cmbMaNhanVienNhap.SelectedIndex = -1;
            cmbMaNhaCCN.SelectedIndex = -1;
            dtpkNgayNhap.Value = DateTime.Now;

        }

        private void btnThemPNCT_Click(object sender, EventArgs e)
        {
            btnThemNhap.Enabled = false;
            btnSuaNhap.Enabled = false;
            txtMaPhieuNhapCT.Enabled = false;
            btnLuuPN.Enabled = true;
            txtMaPhieuNhapCT.DataBindings.Add("Text", dgwPhieuNhap.DataSource, "MaPhieuNhap");
            Clear_Nhap();
        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            _ctpn.MaPhieuNhap = txtMaPhieuNhapCT.Text;
            if (cmbMaXeNhap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (numSoLuongNhap.Value == 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtDonGiaNhap.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đơn giá","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtThueNhap.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập thuế", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }
                        else
                        {
                            _ctpn.MaXe = cmbMaXeNhap.SelectedValue.ToString();
                            _ctpn.SlNhap = int.Parse(numSoLuongNhap.Value.ToString());
                            _ctpn.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                            _ctpn.Thue = int.Parse(txtThueNhap.Text);
                            _ctpn.ThanhTien = _ctpn.DonGiaNhap * _ctpn.SlNhap * _ctpn.Thue;

                            int slHienTai = int.Parse(_lxxl.LayXe(_ctpn.MaXe).Rows[0][2].ToString());
                            int tongSl = slHienTai + _ctpn.SlNhap;
                            _lxxl.Xe_UpdateSLNhap(_ctpn.MaXe, tongSl, _ctpn.DonGiaNhap);

                            _ctpnxl.CTPhieuNhap_Insert(_ctpn);
                            Clear_PNCT();
                            CTPhieuNhap_Load();

                        }
                    }
                }
            }
        }

        private void btnXoaPNCT_Click(object sender, EventArgs e)
        {
            _ctpn.MaPhieuNhap = txtMaPhieuNhapCT.Text;
            _pn.MaPhieuNhap = txtMaPhieuNhapCT.Text;
            _ctpnxl.CTPhieuNhap_Delete(_ctpn);
            _pnxl.PhieuNhap_Delete(_pn);
            Clear_PNCT();
            CTPhieuNhap_Load();
            PhieuNhap_Load();
        }

        private void btnSuaPNCT_Click(object sender, EventArgs e)
        {
            if (cmbMaXeNhap.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (numSoLuongNhap.Value == 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtDonGiaNhap.Text == "")
                    {
                        MessageBox.Show("Vui lòng nhập đơn giá", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txtThueNhap.Text == "")
                        {
                            MessageBox.Show("Vui lòng nhập thuế", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            _ctpn.MaPhieuNhap = txtMaPhieuNhapCT.Text;
                            _ctpn.MaXe = cmbMaXeNhap.SelectedValue.ToString().Trim();
                            _ctpn.SlNhap = int.Parse(numSoLuongNhap.Value.ToString());
                            _ctpn.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                            _ctpn.Thue = int.Parse(txtThueNhap.Text);
                            _ctpn.ThanhTien = _ctpn.DonGiaNhap * _ctpn.SlNhap * _ctpn.Thue;

                            int slHienTai = int.Parse(_lxxl.LayXe(_ctpn.MaXe).Rows[0][2].ToString());
                            int tongSl = slHienTai + _ctpn.SlNhap;
                            _lxxl.Xe_UpdateSLNhap(_ctpn.MaXe, tongSl, _ctpn.DonGiaNhap);

                            _ctpnxl.CTPhieuNhap_Update(_ctpn);
                            Clear_PNCT();
                            CTPhieuNhap_Load();
                        }
                    }
                }
            }
        }

        private void Clear_PNCT()
        {
            txtMaPhieuNhapCT.DataBindings.Clear();
            cmbMaXeNhap.DataBindings.Clear();
            numSoLuongNhap.DataBindings.Clear();
            txtDonGiaNhap.DataBindings.Clear();
            txtThueNhap.DataBindings.Clear();

            txtMaPhieuNhapCT.Text = String.Empty;
            cmbMaXeNhap.SelectedIndex = -1;
            numSoLuongNhap.Value = 0;
            txtDonGiaNhap.Text = String.Empty;
            txtThueNhap.Text = String.Empty;

            txtMaPhieuNhapCT.Enabled = true;
            btnThemPNCT.Enabled = false;
            btnLuuPN.Enabled = false;
            btnSuaPNCT.Enabled = false;
            btnXoaPNCT.Enabled = false;
        }

        private void txtDonGiaNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThueNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //end tabPhieuNhap/ChiTietPhieuNhap
        #endregion
#region tabPhieuXuat
        //begin tabPhieuXuat/ChiTietPhieuXuat
        private void PhieuXuat_Load()
        {
            dgwHoaDon.DataSource = _pxxl.PhieuXuat_SelectAll();

            cmbMaNhaVienXuat.DataSource = _nvxl.NhanVien_SelectAll();
            cmbMaNhaVienXuat.ValueMember = "MaNV";

            cmbMaKHXuat.DataSource = _khxl.KhachHang_SelectAll();
            cmbMaKHXuat.ValueMember = "MaKH";
        }
        private void CTPhieuXuat_Load()
        {
            dgwCTHoaDon.DataSource = _ctpxxl.CTPhieuXuat_SelectAll();

            cmbMaXeXuat.DataSource = _lxxl.Xe_SelectAll();
            cmbMaXeXuat.ValueMember = "MaXe";

            btnThemCTHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = false;
            btnSuaCTHoaDon.Enabled = false;
            btnXoaCTHoaDon.Enabled = false;
        }

        private void dgwHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemHoaDon.Enabled = false;
            btnThemCTHoaDon.Enabled = true;
            txtMaHoaDon.Enabled = false;

            txtMaHoaDon.DataBindings.Clear();
            cmbMaNhaVienXuat.DataBindings.Clear();
            cmbMaKHXuat.DataBindings.Clear();
            dtpkNgayXuat.DataBindings.Clear();

            txtMaHoaDon.DataBindings.Add("Text", dgwHoaDon.DataSource, "MaPhieuXuat");
            cmbMaNhaVienXuat.DataBindings.Add("Text", dgwHoaDon.DataSource, "MaNV");
            cmbMaKHXuat.DataBindings.Add("Text", dgwHoaDon.DataSource, "MaKH");
            dtpkNgayXuat.DataBindings.Add("Text", dgwHoaDon.DataSource, "NgayXuat");
        }

        private void dgwCTHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaHoaDonCT.Enabled = false;
            btnSuaCTHoaDon.Enabled = true;
            btnXoaCTHoaDon.Enabled = true;

            txtMaHoaDonCT.DataBindings.Clear();
            cmbMaXeXuat.DataBindings.Clear();
            numSoLuongXuat.DataBindings.Clear();
            txtDonGiaXuat.DataBindings.Clear();
            txtThueXuat.DataBindings.Clear();

            txtMaHoaDonCT.DataBindings.Add("Text", dgwCTHoaDon.DataSource, "MaPhieuXuat");
            cmbMaXeXuat.DataBindings.Add("Text", dgwCTHoaDon.DataSource, "MaXe");
            numSoLuongXuat.DataBindings.Add("Text", dgwCTHoaDon.DataSource, "SLXuat");
            txtDonGiaXuat.DataBindings.Add("Text", dgwCTHoaDon.DataSource, "DonGiaXuat");
            txtThueXuat.DataBindings.Add("Text", dgwCTHoaDon.DataSource, "Thue");
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            if (txtMaHoaDon.Text == "" || txtMaHoaDon.Text.IndexOfAny(@"!@#$%^&*()_+=|\{}[]?><.,';:".ToCharArray()) != -1)
            {
                MessageBox.Show("Vui lòng nhập đúng", "Thông báo");
                txtMaPN.Focus();
            }
            else
            {
                if (cmbMaNhaVienXuat.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo");
                    cmbMaNhanVienNhap.Focus();
                }
                else
                {
                    if (cmbMaKHXuat.SelectedIndex == -1)
                    {
                        MessageBox.Show("Vui lòng chọn khách hàng");
                        cmbMaNhaCCN.Focus();
                    }
                    else
                    {
                        if (dtpkNgayXuat.Value == DateTime.Now)
                        {
                            MessageBox.Show("Vui lòng chọn ngày");
                        }
                        else
                        {
                            try
                            {
                                _px.MaPhieuXuat = txtMaHoaDon.Text.ToUpper();
                                _px.MaNv = cmbMaNhaVienXuat.SelectedValue.ToString();
                                _px.MaKh = cmbMaKHXuat.SelectedValue.ToString();
                                _px.NgayXuat = dtpkNgayXuat.Value;
                                if (!(_pxxl.CheckId(_px.MaPhieuXuat)))
                                {
                                    _pxxl.PhieuXuat_Insert(_px);
                                    Clear_Xuat();
                                    PhieuXuat_Load();
                                    MessageBox.Show("Thêm hóa đơn thành công !", "Thông báo", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    MessageBox.Show("Hóa đơn " + _px.MaPhieuXuat + " đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Thêm không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void btnSuaHoaDon_Click(object sender, EventArgs e)
        {
            _px.MaPhieuXuat = txtMaHoaDon.Text.ToUpper();
            if (cmbMaNhaVienXuat.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhân viên", "Thông báo");
                cmbMaNhanVienNhap.Focus();
            }
            else
            {
                if (cmbMaKHXuat.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp");
                    cmbMaNhaCCN.Focus();
                }
                else
                {
                    if (dtpkNgayXuat.Value == DateTime.Now)
                    {
                        MessageBox.Show("Vui lòng chọn ngày nhập");
                    }
                    else
                    {
                        _px.MaNv = cmbMaNhaVienXuat.SelectedValue.ToString();
                        _px.MaNv = cmbMaNhaVienXuat.SelectedValue.ToString();
                        _px.NgayXuat = dtpkNgayXuat.Value;
                        _pxxl.PhieuXuat_Update(_px);
                        Clear_Xuat();
                        PhieuXuat_Load();
                        MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void btnLamMoiHoaDon_Click(object sender, EventArgs e)
        {
            Clear_Xuat();
            Clear_HDCT();
        }
        private void Clear_Xuat()
        {
            btnThemHoaDon.Enabled = true;
            txtMaHoaDon.Enabled = true;

            txtMaHoaDon.DataBindings.Clear();
            cmbMaNhaVienXuat.DataBindings.Clear();
            cmbMaKHXuat.DataBindings.Clear();
            dtpkNgayXuat.DataBindings.Clear();

            txtMaHoaDon.Text = String.Empty;
            cmbMaNhaVienXuat.SelectedIndex = -1;
            cmbMaKHXuat.SelectedIndex = -1;
            dtpkNgayXuat.Value = DateTime.Now;

        }

        private void btnThemCTHoaDon_Click(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = false;
            btnSuaHoaDon.Enabled = false;
            txtMaHoaDonCT.Enabled = false;
            btnLuuHoaDon.Enabled = true;
            txtMaHoaDonCT.DataBindings.Add("Text", dgwHoaDon.DataSource, "MaPhieuXuat");
            Clear_Xuat();
        }

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            _ctpx.MaPhieuXuat = txtMaHoaDonCT.Text;
            if (cmbMaXeXuat.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (numSoLuongXuat.Value == 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _ctpx.MaXe = cmbMaXeXuat.SelectedValue.ToString();
                    _ctpx.SlXuat = int.Parse(numSoLuongXuat.Value.ToString());
                    int slHienTai = int.Parse(_lxxl.LayXe(_ctpx.MaXe).Rows[0][2].ToString());
                    int slConLai = slHienTai - _ctpx.SlXuat;
                    if (slConLai < 0)
                    {
                        MessageBox.Show("Không đủ số lượng, Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _lxxl.Xe_UpdateSLXuat(_ctpx.MaXe, slConLai);

                        _ctpx.DonGiaXuat = int.Parse(txtDonGiaXuat.Text);
                        _ctpx.Thue = int.Parse(txtThueXuat.Text);
                        _ctpx.ThanhTien = _ctpx.DonGiaXuat * _ctpx.SlXuat * _ctpx.Thue;
                        _ctpxxl.CTPhieuXuat_Insert(_ctpx);
                        Clear_HDCT();
                        CTPhieuXuat_Load();
                        PhieuXuat_Load();
                    }
                }
            }
            
        }

        private void btnSuaCTHoaDon_Click(object sender, EventArgs e)
        {
            _ctpx.MaPhieuXuat = txtMaHoaDonCT.Text;
            if (cmbMaXeXuat.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn mã xe", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (numSoLuongXuat.Value == 0)
                {
                    MessageBox.Show("Vui lòng chọn số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _ctpx.MaXe = cmbMaXeXuat.SelectedValue.ToString();
                    _ctpx.SlXuat = int.Parse(numSoLuongXuat.Value.ToString());
                    int slHienTai = int.Parse(_lxxl.LayXe(_ctpx.MaXe).Rows[0][2].ToString());
                    int slConLai = slHienTai - _ctpx.SlXuat;
                    if (slConLai < 0)
                    {
                        MessageBox.Show("Không đủ số lượng, Vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        _lxxl.Xe_UpdateSLXuat(_ctpx.MaXe, slConLai);

                        _ctpx.DonGiaXuat = int.Parse(txtDonGiaXuat.Text);
                        _ctpx.Thue = int.Parse(txtThueXuat.Text);
                        _ctpx.ThanhTien = _ctpx.DonGiaXuat * _ctpx.SlXuat * _ctpx.Thue;
                        _ctpxxl.CTPhieuXuat_Update(_ctpx);
                        Clear_HDCT();
                        CTPhieuXuat_Load();
                    }
                }
            }
        }

        private void btnXoaCTHoaDon_Click(object sender, EventArgs e)
        {
            _ctpx.MaPhieuXuat = txtMaHoaDonCT.Text;
            _px.MaPhieuXuat = txtMaHoaDonCT.Text;
            _ctpxxl.CTPhieuXuat_Delete(_ctpx);
            _pxxl.PhieuXuat_Delete(_px);
            Clear_HDCT();
            PhieuXuat_Load();
            CTPhieuXuat_Load();
        }
        private void Clear_HDCT()
        {
            txtMaHoaDonCT.DataBindings.Clear();
            cmbMaXeXuat.DataBindings.Clear();
            numSoLuongXuat.DataBindings.Clear();
            txtDonGiaXuat.DataBindings.Clear();
            txtThueXuat.DataBindings.Clear();

            txtMaHoaDonCT.Text = String.Empty;
            cmbMaXeXuat.SelectedIndex = -1;
            numSoLuongXuat.Value = 0;
            txtDonGiaXuat.Text = String.Empty;
            txtThueXuat.Text = String.Empty;

            txtMaHoaDonCT.Enabled = true;
            btnThemCTHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = false;
            btnSuaCTHoaDon.Enabled = false;
            btnXoaCTHoaDon.Enabled = false;
        }

        private void txtDonGiaXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThueXuat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //end tabPhieuXuat/ChiTietPhieuXuat
        #endregion
        private void TrangChu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            String maKhachHang = cmbMaKHXuat.SelectedValue.ToString();
            String maHoaDon = txtMaHoaDon.Text;
            DateTime ngayXuat = dtpkNgayXuat.Value;
            HoaDon hd = new HoaDon(maKhachHang, maHoaDon, ngayXuat);
            hd.Show();
        }
    }
}
