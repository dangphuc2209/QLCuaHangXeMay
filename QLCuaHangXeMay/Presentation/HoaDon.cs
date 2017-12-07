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
        ChiTietPhieuXuatXuLy _ctpxl = new ChiTietPhieuXuatXuLy();
        InHoaDon _hd = new InHoaDon();
        private String _maKhachHang;
        private String _maHoaDon;
        private DateTime _ngayXuat;
        public HoaDon(String item1, String item2, DateTime item3)
        {
            InitializeComponent();
            _maKhachHang = item1;
            _maHoaDon = item2;
            _ngayXuat = item3;
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            lbMaHoaDon.Text = _maHoaDon;
            lbNgayXuat.Text = _ngayXuat.ToShortDateString();
            lbMaKH.Text = _maKhachHang;
            DataTable layTtkh = _khxl.LayThongTinKhachHang(_maKhachHang);
            lbTenKH.Text = layTtkh.Rows[0][1].ToString();
            lbDiaChi.Text = layTtkh.Rows[0][2].ToString();
            lbSDT.Text = layTtkh.Rows[0][3].ToString();
            lbEmail.Text = layTtkh.Rows[0][4].ToString();
            lbNgaySinh.Text = layTtkh.Rows[0][5].ToString();
            DataTable layTtsp = _ctpxl.LayHoaDon(_maHoaDon);
            for (int i = 0; i < layTtsp.Rows.Count; i++)
            {
                string maXe = layTtsp.Rows[i][1].ToString();
                DataTable layTtxe = _lxxl.LayXe(maXe);
                for (int j = 0; j < layTtxe.Rows.Count; j++)
                {
                    _hd.TenXe = layTtxe.Rows[j][4].ToString();
                }
                _hd.Sl = int.Parse(layTtsp.Rows[i][2].ToString());
                _hd.DonGia = int.Parse(layTtsp.Rows[i][3].ToString());
                _hd.Thue = int.Parse(layTtsp.Rows[i][4].ToString());
                _hd.ThanhTien = int.Parse(layTtsp.Rows[i][5].ToString());
                inHoaDonBindingSource.Add(_hd);
            }
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgwDonHang_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            int i = e.Row.Index;
            int val = int.Parse(dgwDonHang.Rows[i - 1].Cells["STT"].Value.ToString());
            dgwDonHang.Rows[i].Cells["STT"].Value = val + 1;
        }
    }
}
