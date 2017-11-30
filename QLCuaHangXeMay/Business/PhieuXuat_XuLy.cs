using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    class PhieuXuatXuLy
    {
        DbConnection _db = new DbConnection();
        PhieuXuat _px = new PhieuXuat();
        public DataTable PhieuXuat_SelectAll()
        {
            return _db.table_Select("SELECT * FROM PhieuXuat");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM PhieuXuat WHERE MaPhieuXuat LIKE '%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM PhieuXuat WHERE MaPhieuXuat='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void PhieuXuat_Delete(PhieuXuat px)
        {
            _db.table_Command("DELETE FROM PhieuXuat WHERE MaPhieuXuat = '" + px.MaPhieuXuat + "'");
        }
        public void PhieuXuat_Insert(PhieuXuat px)
        {
            _db.table_Command("INSERT INTO PhieuXuat VALUES('" + px.MaPhieuXuat + "','" + px.NgayXuat + "','" + px.MaNv + "','" + px.MaKh + "')");
        }
        public void PhieuXuat_Update(PhieuXuat px)
        {
            _db.table_Command("UPDATE PhieuXuat SET NgayXuat='" + px.NgayXuat + "',MaNV='" + px.MaNv + "',MaKH='" + px.MaKh + "' WHERE MaPhieuXuat='" + px.MaPhieuXuat + "'");
        }
    }
}
