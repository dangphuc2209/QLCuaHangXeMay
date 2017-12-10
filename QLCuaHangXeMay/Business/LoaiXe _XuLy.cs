using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    public class LoaiXeXuLy
    {
        DbConnection _db = new DbConnection();
        LoaiXe _lx = new LoaiXe();
        public DataTable Xe_SelectAll()
        {
            return _db.table_Select("SELECT * FROM Xe");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM Xe WHERE MaXe LIKE '%" + item + "%' OR TenXe LIKE N'%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM Xe WHERE MaXe='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void Xe_Delete(LoaiXe lx)
        {
            _db.table_Command("DELETE FROM Xe WHERE MaXe='" + lx.MaXe + "'");
        }
        public void Xe_Insert(LoaiXe lx)
        {
            _db.table_Command("INSERT INTO Xe VALUES('" + lx.MaXe + "','" + lx.TenHangXe + "'," + lx.SoLuong + ",N'" + lx.ThongTinBaoHanh + "','" + lx.TenXe + "','" + lx.NhaSx + "'," + lx.DonGia + ",N'" + lx.TinhTrang + "')");
        }
        public void Xe_Update(LoaiXe lx)
        {
            _db.table_Command("UPDATE Xe SET TenHangXe = '" + lx.TenHangXe + "',SoLuong = " + lx.SoLuong + ",ThongTinBaoHanh = N'" + lx.ThongTinBaoHanh + "',TenXe = '" + lx.TenXe + "',NhaSX = '" + lx.NhaSx + "',DonGia = " + lx.DonGia + ",TinhTrang = N'" + lx.TinhTrang + "' WHERE MaXe='" + lx.MaXe + "'");
        }
        public void Xe_UpdateSLNhap(String maXe, int soLuong, int donGia)
        {
            _db.table_Command("UPDATE Xe SET SoLuong=" + soLuong + ", DonGia=" + donGia + " WHERE MaXe ='" + maXe + "'");
        }
        public void Xe_UpdateSLXuat(String maXe, int soLuong)
        {
            _db.table_Command("UPDATE Xe SET SoLuong=" + soLuong + " WHERE MaXe ='" + maXe + "'");
        }
        public DataTable LayXe(String maXe)
        {
            return _db.table_Select("SELECT * FROM Xe WHERE MaXe='" + maXe + "'");
        }
    }
}
