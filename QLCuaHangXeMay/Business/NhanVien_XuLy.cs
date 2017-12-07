using System;
using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    public class NhanVienXuLy
    {
        DbConnection _db = new DbConnection();
        NhanVien _nv = new NhanVien();

        public DataTable NhanVien_SelectAll()
        {
            return _db.table_Select("SELECT * FROM NhanVien");
        }
        public DataTable FindItem(String item)
        {
            return _db.table_Select("SELECT * FROM NhanVien WHERE MaNV LIKE '%" + item + "%' OR TenNV LIKE N'%" + item + "%'");
        }
        public bool CheckId(String item)
        {
            DataTable dt = _db.table_Select("SELECT * FROM NhanVien WHERE MaNV='" + item + "'");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void NhanVien_Delete(NhanVien nv)
        {
            _db.table_Command("DELETE FROM NhanVien WHERE MaNV = '" + nv.MaNv + "'");
        }
        public void NhanVien_Insert(NhanVien nv)
        {
            _db.table_Command("INSERT INTO NhanVien VALUES('"+nv.MaNv+ "',N'" + nv.TenNv + "'," + nv.Luong + "," +
                "'" + nv.NgaySinh + "',N'" + nv.GioiTinh + "',N'" + nv.DiaChi + "','" + nv.DienThoai + "'," +
                "N'" + nv.ChucVu + "','" + nv.NgayVaoLam + "'," + nv.LuongCoBan + ")");
        }
        public void NhanVien_Update(NhanVien nv)
        {
            _db.table_Command("UPDATE NhanVien SET TenNV = N'" + nv.TenNv + "',Luong = " + nv.Luong + "," +
                "NgaySinh = '" + nv.NgaySinh + "',GioiTinh = N'" + nv.GioiTinh + "',DiaChi = N'" + nv.DiaChi + "',DienThoai = '" + nv.DienThoai + "'," +
                "ChucVu = N'" + nv.ChucVu + "',NgayVaoLam = '" + nv.NgayVaoLam + "',LuongCoBan = " + nv.LuongCoBan + " WHERE MaNV = '" + nv.MaNv + "'");
        }
    }
}
