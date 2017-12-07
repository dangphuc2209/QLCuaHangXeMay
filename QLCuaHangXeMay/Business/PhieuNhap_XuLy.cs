using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    public class PhieuNhapXuLy
    {
        DbConnection _db = new DbConnection();
        PhieuNhap _pn = new PhieuNhap();
        public DataTable PhieuNhap_SelectAll()
        {
            return _db.table_Select("SELECT * FROM PhieuNhap");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM PhieuNhap WHERE MaPhieuNhap LIKE '%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM PhieuNhap WHERE MaPhieuNhap='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void PhieuNhap_Delete(PhieuNhap pn)
        {
            _db.table_Command("DELETE FROM PhieuNhap WHERE MaPhieuNhap='" + pn.MaPhieuNhap + "'");
        }
        public void PhieuNhap_Insert(PhieuNhap pn)
        {
            _db.table_Command("INSERT INTO PhieuNhap VALUES('" + pn.MaPhieuNhap + "','" + pn.NgayNhap + "','" + pn.MaNv + "','" + pn.MaNhaCc + "')");
        }
        public void PhieuNhap_Update(PhieuNhap pn)
        {
            _db.table_Command("UPDATE PhieuNhap SET NgayNhap='" + pn.NgayNhap + "',MaNV='" + pn.MaNv + "',MaNhaCC='" + pn.MaNhaCc + "' WHERE MaPhieuNhap='" + pn.MaPhieuNhap + "'");
        }
    }
}
