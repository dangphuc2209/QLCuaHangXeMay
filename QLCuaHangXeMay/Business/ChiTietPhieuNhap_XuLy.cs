using QLCuaHangXeMay.DataAccess;
using System.Data;

namespace QLCuaHangXeMay.Business
{
    public class ChiTietPhieuNhapXuLy
    {
        DbConnection _db = new DbConnection();
        ChiTietPhieuNhap _ctpn = new ChiTietPhieuNhap();
        public DataTable CTPhieuNhap_SelectAll()
        {
            return _db.table_Select("SELECT * FROM ChiTietPhieuNhap");
        }
        public void CTPhieuNhap_Delete(ChiTietPhieuNhap ctpn)
        {
            _db.table_Command("DELETE FROM ChiTietPhieuNhap WHERE MaPhieuNhap='" + ctpn.MaPhieuNhap + "'");
        }
        public void CTPhieuNhap_Insert(ChiTietPhieuNhap ctpn)
        {
            _db.table_Command("INSERT INTO ChiTietPhieuNhap VALUES('" + ctpn.MaPhieuNhap + "','" + ctpn.MaXe + "'," + ctpn.SlNhap + "," + ctpn.DonGiaNhap + "," + ctpn.Thue + "," + ctpn.ThanhTien + ")");
        }
        public void CTPhieuNhap_Update(ChiTietPhieuNhap ctpn)
        {
            _db.table_Command("UPDATE ChiTietPhieuNhap SET MaXe='" + ctpn.MaXe + "',SLNhap = " + ctpn.SlNhap + ",DonGiaNhap = " + ctpn.DonGiaNhap + ",Thue = " + ctpn.Thue + ",ThanhTien = " + ctpn.ThanhTien + " WHERE MaPhieuNhap = '" + ctpn.MaPhieuNhap + "'");
        }
    }
}
