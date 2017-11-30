using System;
using System.Data;
using System.Windows.Forms;
using QLCuaHangXeMay.Business;

namespace QLCuaHangXeMay.Presentation
{
    public partial class HoaDon : Form
    {
        KhachHangXuLy _khxl = new KhachHangXuLy();
        LoaiXeXuLy _lxxl = new LoaiXeXuLy();
        private String _maKhachHang;
        private String _maXe;
        private String _maHoaDon;
        private DateTime _ngayXuat;
        private int _donGia;
        private int _soLuong;
        private int _thue;
        private int _thanhTien;
        public HoaDon(String item1, String item2, String item3, DateTime item4, int item5, int item6, int item7, int item8)
        {
            InitializeComponent();
            _maKhachHang = item1;
            _maXe = item2;
            _maHoaDon = item3;
            _ngayXuat = item4;
            _donGia = item5;
            _soLuong = item6;
            _thue = item7;
            _thanhTien = item8;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            lbMaHoaDon.Text = _maHoaDon;
            lbNgayXuat.Text = _ngayXuat.ToShortDateString();
            lbMaKH.Text = _maKhachHang;
            DataTable dt = _khxl.LayThongTinKhachHang(_maKhachHang);
            lbTenKH.Text = dt.Rows[0][1].ToString();
            lbDiaChi.Text = dt.Rows[0][2].ToString();
            lbSDT.Text = dt.Rows[0][3].ToString();
            lbEmail.Text = dt.Rows[0][4].ToString();
            lbNgaySinh.Text = dt.Rows[0][5].ToString();
            DataTable dt2 = _lxxl.LayXe(_maXe);
            lbSTT.Text = @"1";
            lbTenXe.Text = dt2.Rows[0][4].ToString();
            lbSoLuong.Text = _soLuong.ToString();
            lbDonGia.Text = _donGia.ToString();
            lbThue.Text = _thue.ToString();
            lbThanhTien.Text = _thanhTien.ToString();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
