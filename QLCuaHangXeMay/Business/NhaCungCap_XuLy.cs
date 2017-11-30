using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    class NhaCungCapXuLy
    {
        DbConnection _db = new DbConnection();
        NhaCungCap _ncc = new NhaCungCap();
        public DataTable NhaCungCap_SelectAll()
        {
            return _db.table_Select("SELECT * FROM NhaCungCap");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM NhaCungCap WHERE MaNhaCC LIKE '%" + item + "%' OR TenNhaCC LIKE N'%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM NhaCungCap WHERE MaNhaCC='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void NhaCungCap_Delete(NhaCungCap ncc)
        {
            _db.table_Command("DELETE FROM NhaCungCap WHERE MaNhaCC='" + ncc.MaNhaCc + "'");
        }
        public void NhaCungCap_Insert(NhaCungCap ncc)
        {
            _db.table_Command("INSERT INTO NhaCungCap VALUES('" + ncc.MaNhaCc + "','" + ncc.TenNhaCc + "','" + ncc.DiaChi + "','" + ncc.DienThoai + "','" + ncc.Email + "')");
        }
        public void NhaCungCap_Update(NhaCungCap ncc)
        {
            _db.table_Command("UPDATE NhaCungCap SET TenNhaCC = '" + ncc.TenNhaCc + "',DiaChi = '" + ncc.DiaChi + "',DienThoai = '" + ncc.DienThoai + "',Email = '" + ncc.Email + "' WHERE MaNhaCC = '" + ncc.MaNhaCc + "'");
        }
    }
}
