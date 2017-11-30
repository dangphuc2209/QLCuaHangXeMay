using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    class KhachHangXuLy
    {
        DbConnection _db = new DbConnection();
        KhachHang _kh = new KhachHang();

        public DataTable KhachHang_SelectAll()
        {
            return _db.table_Select("SELECT * FROM KhachHang");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM KhachHang WHERE MaKH LIKE N'%" + item + "%' OR TenKH LIKE N'%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM KhachHang WHERE MaKH='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void KhachHang_Delete(KhachHang kh)
        {
            _db.table_Command("DELETE FROM KhachHang WHERE MaKH='" + kh.MaKh + "'");
        }
        public void KhachHang_Insert(KhachHang kh)
        {
            _db.table_Command("INSERT INTO KhachHang VALUES('" + kh.MaKh + "',N'" + kh.TenKh + "',N'" + kh.DiaChi + "','" + kh.DienThoai + "',N'" + kh.Email + "','" + kh.NgaySinh + "','" + kh.TinhTrang + "')");
        }
        public void KhachHang_Update(KhachHang kh)
        {
            _db.table_Command("UPDATE KhachHang SET TenKH = N'" + kh.TenKh + "',DiaChi = N'" + kh.DiaChi + "',DienThoai = '" + kh.DienThoai + "',Email = '" + kh.Email + "',NgaySinh = '" + kh.NgaySinh + "',TinhTrang = '" + kh.TinhTrang + "' WHERE MaKH='" + kh.MaKh + "'");
        }
        public DataTable LayThongTinKhachHang(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM KhachHang WHERE MaKH='" + item + "'");
            return dt;
        }
    }
}
