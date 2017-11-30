using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    class ChiTietPhieuXuatXuLy
    {
        DbConnection _db = new DbConnection();
        ChiTietPhieuXuat _ctpx = new ChiTietPhieuXuat();
        public DataTable CTPhieuXuat_SelectAll()
        {
            return _db.table_Select("SELECT * FROM ChiTietPhieuXuat");
        }
        public void CTPhieuXuat_Delete(ChiTietPhieuXuat ctpx)
        {
            _db.table_Command("DELETE FROM ChiTietPhieuXuat WHERE MaPhieuXuat='" + ctpx.MaPhieuXuat + "'");
        }
        public void CTPhieuXuat_Insert(ChiTietPhieuXuat ctpx)
        {
            _db.table_Command("INSERT INTO ChiTietPhieuXuat VALUES('" + ctpx.MaPhieuXuat + "','" + ctpx.MaXe + "'," + ctpx.SlXuat + "," + ctpx.DonGiaXuat + "," + ctpx.Thue + "," + ctpx.ThanhTien + ")");
        }
        public void CTPhieuXuat_Update(ChiTietPhieuXuat ctpx)
        {
            _db.table_Command("UPDATE ChiTietPhieuXuat SET MaXe='" + ctpx.MaXe + "',SLXuat = " + ctpx.SlXuat + ",DonGiaXuat = " + ctpx.DonGiaXuat + ",Thue = " + ctpx.Thue + ",ThanhTien = " + ctpx.ThanhTien + " WHERE MaPhieuXuat = '" + ctpx.MaPhieuXuat + "'");
        }
    }
}
