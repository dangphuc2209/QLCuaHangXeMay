using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QLCuaHangXeMay.Business;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        #region ChiTietPhieuNhap
        ChiTietPhieuNhapXuLy _ctpnXl;
        [TestMethod]
        //test select
        public void TestCTPhieuNhap_SelectAll()
        {
            _ctpnXl = new ChiTietPhieuNhapXuLy();
            DataTable dt = _ctpnXl.CTPhieuNhap_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1,actual);
        }

        [TestMethod]
        //test insert true
        public void TestCTPhieuNhap_Insert()
        {
            _ctpnXl = new ChiTietPhieuNhapXuLy();
            bool actual;
            try
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = "PN9";
                ctpn.MaXe = "SO1";
                ctpn.SlNhap = 2;
                ctpn.DonGiaNhap = 30000000;
                ctpn.Thue = 1;
                ctpn.ThanhTien = 60000000;
                _ctpnXl.CTPhieuNhap_Insert(ctpn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            ChiTietPhieuNhap ctpn1 = new ChiTietPhieuNhap();
            ctpn1.MaPhieuNhap = "PN9";
            _ctpnXl.CTPhieuNhap_Delete(ctpn1);
        }

        [TestMethod]
        //test insert false
        public void TestCTPhieuNhap_InsertFalse()
        {
            _ctpnXl = new ChiTietPhieuNhapXuLy();
            bool actual;
            try
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = "PN1";
                _ctpnXl.CTPhieuNhap_Insert(ctpn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test delete
        public void TestCTPhieuNhap_Delete()
        {
            _ctpnXl = new ChiTietPhieuNhapXuLy();
            bool actual;
            try
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = "PN9";
                _ctpnXl.CTPhieuNhap_Delete(ctpn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestCTPhieuNhap_Update()
        {
            _ctpnXl = new ChiTietPhieuNhapXuLy();
            bool actual;
            try
            {
                ChiTietPhieuNhap ctpn = new ChiTietPhieuNhap();
                ctpn.MaPhieuNhap = "PN1";
                ctpn.MaXe = "SO2";
                ctpn.SlNhap = 2;
                ctpn.DonGiaNhap = 30000000;
                ctpn.Thue = 1;
                ctpn.ThanhTien = 60000000;
                _ctpnXl.CTPhieuNhap_Update(ctpn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region ChiTietPhieuXuat
        ChiTietPhieuXuatXuLy _ctpxXl;
        [TestMethod]
        //test select
        public void TestCTPhieuXuat_SelectAll()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            DataTable dt = _ctpxXl.CTPhieuXuat_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test select true
        public void TestCTPhieuXuat_SelectTrue()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            String maHoaDon = "HD1";
            DataTable dt = _ctpxXl.LayHoaDon(maHoaDon);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test select false
        public void TestCTPhieuXuat_SelectFalse()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            String maHoaDon = "HD9";
            DataTable dt = _ctpxXl.LayHoaDon(maHoaDon);
            int actual;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert true
        public void TestCTPhieuXuat_Insert()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            bool actual;
            try
            {
                ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                ctpx.MaPhieuXuat = "HD4";
                ctpx.MaXe = "SO1";
                ctpx.SlXuat = 2;
                ctpx.DonGiaXuat = 30000000;
                ctpx.Thue = 1;
                ctpx.ThanhTien = 60000000;
                _ctpxXl.CTPhieuXuat_Insert(ctpx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            ChiTietPhieuXuat ctpx1 = new ChiTietPhieuXuat();
            ctpx1.MaPhieuXuat = "HD4";
            _ctpxXl.CTPhieuXuat_Delete(ctpx1);
        }

        [TestMethod]
        //test insert flase
        public void TestCTPhieuXuat_InsertFalse()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            bool actual;
            try
            {
                ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                ctpx.MaPhieuXuat = "HD1";
                ctpx.MaXe = "SO1";
                ctpx.SlXuat = 2;
                ctpx.DonGiaXuat = 30000000;
                ctpx.Thue = 1;
                ctpx.ThanhTien = 60000000;
                _ctpxXl.CTPhieuXuat_Insert(ctpx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test delete
        public void TestCTPhieuXuat_Delete()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            bool actual;
            try
            {
                ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                ctpx.MaPhieuXuat = "HD4";
                _ctpxXl.CTPhieuXuat_Delete(ctpx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestCTPhieuXuat_Update()
        {
            _ctpxXl = new ChiTietPhieuXuatXuLy();
            bool actual;
            try
            {
                ChiTietPhieuXuat ctpx = new ChiTietPhieuXuat();
                ctpx.MaPhieuXuat = "HD1";
                ctpx.MaXe = "SO1";
                ctpx.SlXuat = 1;
                ctpx.DonGiaXuat = 30000000;
                ctpx.Thue = 1;
                ctpx.ThanhTien = 60000000;
                _ctpxXl.CTPhieuXuat_Update(ctpx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region PhieuNhap
        PhieuNhapXuLy _pnxl;
        [TestMethod]
        //test select
        public void TestPhieuNhap_SelectAll()
        {
            _pnxl = new PhieuNhapXuLy();
            DataTable dt = _pnxl.PhieuNhap_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestPhieuNhap_FindItem()
        {
            _pnxl = new PhieuNhapXuLy();
            string item = "N";
            DataTable dt = _pnxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestPhieuNhap_CheckId()
        {
            _pnxl = new PhieuNhapXuLy();
            string item = "PN1";
            bool check = _pnxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid false
        public void TestPhieuNhap_CheckIdFalse()
        {
            _pnxl = new PhieuNhapXuLy();
            string item = "PN11";
            bool check = _pnxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestPhieuNhap_InsertFalse()
        {
            _pnxl = new PhieuNhapXuLy();
            bool actual;
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = "PN1";
                pn.NgayNhap = DateTime.Now;
                pn.MaNv = "NV1";
                pn.MaNhaCc = "NCC1";
                _pnxl.PhieuNhap_Insert(pn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestPhieuNhap_Insert()
        {
            _pnxl = new PhieuNhapXuLy();
            bool actual;
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = "PN10";
                pn.NgayNhap = DateTime.Now;
                pn.MaNv = "NV1";
                pn.MaNhaCc = "NCC1";
                _pnxl.PhieuNhap_Insert(pn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            PhieuNhap pn1 = new PhieuNhap();
            pn1.MaPhieuNhap = "PN10";
            _pnxl.PhieuNhap_Delete(pn1);
        }

        [TestMethod]
        //test delete
        public void TestPhieuNhap_Delete()
        {
            _pnxl = new PhieuNhapXuLy();
            bool actual;
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = "PN10";
                _pnxl.PhieuNhap_Delete(pn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestPhieuNhap_Update()
        {
            _pnxl = new PhieuNhapXuLy();
            bool actual;
            try
            {
                PhieuNhap pn = new PhieuNhap();
                pn.MaPhieuNhap = "PN1";
                pn.NgayNhap = DateTime.Now;
                pn.MaNv = "NV2";
                pn.MaNhaCc = "NCC1";
                _pnxl.PhieuNhap_Update(pn);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region PhieuXuat
        PhieuXuatXuLy _pxxl;
        [TestMethod]
        //test select
        public void TestPhieuXuat_SelectAll()
        {
            _pxxl = new PhieuXuatXuLy();
            DataTable dt = _pxxl.PhieuXuat_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestPhieuXuat_FindItem()
        {
            _pxxl = new PhieuXuatXuLy();
            string item = "HD";
            DataTable dt = _pxxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestPhieuXuat_CheckId()
        {
            _pxxl = new PhieuXuatXuLy();
            string item = "HD1";
            bool check = _pxxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestPhieuXuat_CheckIdFalse()
        {
            _pxxl = new PhieuXuatXuLy();
            string item = "HD11";
            bool check = _pxxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestPhieuXuat_InsertFalse()
        {
            _pxxl = new PhieuXuatXuLy();
            bool actual;
            try
            {
                PhieuXuat px = new PhieuXuat();
                px.MaPhieuXuat = "HD1";
                px.MaNv = "NV1";
                px.NgayXuat=DateTime.Now;
                px.MaKh = "KH1";
                _pxxl.PhieuXuat_Insert(px);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestPhieuXuat_Insert()
        {
            _pxxl = new PhieuXuatXuLy();
            bool actual;
            try
            {
                PhieuXuat px = new PhieuXuat();
                px.MaPhieuXuat = "HD5";
                px.MaNv = "NV1";
                px.NgayXuat = DateTime.Now;
                px.MaKh = "KH1";
                _pxxl.PhieuXuat_Insert(px);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            PhieuXuat px1 = new PhieuXuat();
            px1.MaPhieuXuat = "HD5";
            _pxxl.PhieuXuat_Delete(px1);
        }

        [TestMethod]
        //test delete
        public void TestPhieuXuat_Delete()
        {
            _pxxl = new PhieuXuatXuLy();
            bool actual;
            try
            {
                PhieuXuat px = new PhieuXuat();
                px.MaPhieuXuat = "HD5";
                _pxxl.PhieuXuat_Delete(px);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestPhieuXuat_Update()
        {
            _pxxl = new PhieuXuatXuLy();
            bool actual;
            try
            {
                PhieuXuat px = new PhieuXuat();
                px.MaPhieuXuat = "HD1";
                px.MaNv = "NV2";
                px.NgayXuat = DateTime.Now;
                px.MaKh = "KH2";
                _pxxl.PhieuXuat_Update(px);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region KhachHang
        KhachHangXuLy _khxl;
        [TestMethod]
        //test select
        public void TestKhachHang_SelectAll()
        {
            _khxl = new KhachHangXuLy();
            DataTable dt = _khxl.KhachHang_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestKhachHang_FindItem()
        {
            _khxl = new KhachHangXuLy();
            string item = "KH";
            DataTable dt = _khxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestKhachHang_CheckId()
        {
            _khxl = new KhachHangXuLy();
            string item = "KH1";
            bool check = _khxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestKhachHang_CheckIdFalse()
        {
            _khxl = new KhachHangXuLy();
            string item = "KH11";
            bool check = _khxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestKhachHang_InsertFalse()
        {
            _khxl = new KhachHangXuLy();
            bool actual;
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKh = "KH1";
                kh.TenKh = "Test";
                kh.DiaChi = "Test";
                kh.DienThoai = "123456789";
                kh.Email = "Test";
                kh.NgaySinh = DateTime.Now;
                kh.TinhTrang = "Test";
                _khxl.KhachHang_Insert(kh);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestKhachHang_Insert()
        {
            _khxl = new KhachHangXuLy();
            bool actual;
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKh = "KH9";
                kh.TenKh = "Test";
                kh.DiaChi = "Test";
                kh.DienThoai = "123456789";
                kh.Email = "Test";
                kh.NgaySinh = DateTime.Now;
                kh.TinhTrang = "Test";
                _khxl.KhachHang_Insert(kh);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            KhachHang kh1 = new KhachHang();
            kh1.MaKh = "KH9";
            _khxl.KhachHang_Delete(kh1);
        }

        [TestMethod]
        //test delete
        public void TestKhachHang_Delete()
        {
            _khxl = new KhachHangXuLy();
            bool actual;
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKh = "KH9";
                _khxl.KhachHang_Delete(kh);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestKhachHang_Update()
        {
            _khxl = new KhachHangXuLy();
            bool actual;
            try
            {
                KhachHang kh = new KhachHang();
                kh.MaKh = "KH8";
                kh.TenKh = "Test";
                kh.DiaChi = "Test";
                kh.DienThoai = "123456789";
                kh.Email = "Test";
                kh.NgaySinh = DateTime.Now;
                kh.TinhTrang = "Test";
                _khxl.KhachHang_Update(kh);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test laythongtinkh
        public void TestKhachHang_LayTT()
        {
            _khxl = new KhachHangXuLy();
            string item = "KH1";
            DataTable dt = _khxl.LayThongTinKhachHang(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }
        #endregion

        #region NhanVien
        NhanVienXuLy _nvxl;
        [TestMethod]
        //test select
        public void TestNhanVien_SelectAll()
        {
            _nvxl = new NhanVienXuLy();
            DataTable dt = _nvxl.NhanVien_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestNhanVien_FindItem()
        {
            _nvxl = new NhanVienXuLy();
            string item = "V";
            DataTable dt = _nvxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestNhanVien_CheckId()
        {
            _nvxl = new NhanVienXuLy();
            string item = "NV1";
            bool check = _nvxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestNhanVien_CheckIdFalse()
        {
            _nvxl = new NhanVienXuLy();
            string item = "NV11";
            bool check = _nvxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestNhanVien_InsertFalse()
        {
            _nvxl = new NhanVienXuLy();
            bool actual;
            try
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = "NV1";
                nv.TenNv = "Test";
                nv.Luong = 1;
                nv.NgaySinh = DateTime.Now;
                nv.GioiTinh = "Test";
                nv.DiaChi = "Test";
                nv.DienThoai = "123456789";
                nv.ChucVu = "Test";
                nv.LuongCoBan = 2;
                nv.NgayVaoLam = DateTime.Now;
                _nvxl.NhanVien_Insert(nv);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestNhanVien_Insert()
        {
            _nvxl = new NhanVienXuLy();
            bool actual;
            try
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = "NV10";
                nv.TenNv = "Test";
                nv.Luong = 1;
                nv.NgaySinh = DateTime.Now;
                nv.GioiTinh = "Test";
                nv.DiaChi = "Test";
                nv.DienThoai = "123456789";
                nv.ChucVu = "Test";
                nv.LuongCoBan = 2;
                nv.NgayVaoLam = DateTime.Now;
                _nvxl.NhanVien_Insert(nv);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            NhanVien nv1 = new NhanVien();
            nv1.MaNv = "NV10";
            _nvxl.NhanVien_Delete(nv1);
        }

        [TestMethod]
        //test delete
        public void TestNhanVien_Delete()
        {
            _nvxl = new NhanVienXuLy();
            bool actual;
            try
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = "NV10";
                _nvxl.NhanVien_Delete(nv);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestNhanVien_Update()
        {
            _nvxl = new NhanVienXuLy();
            bool actual;
            try
            {
                NhanVien nv = new NhanVien();
                nv.MaNv = "NV9";
                nv.TenNv = "Test";
                nv.Luong = 1;
                nv.NgaySinh = DateTime.Now;
                nv.GioiTinh = "Test";
                nv.DiaChi = "Test";
                nv.DienThoai = "123456789";
                nv.ChucVu = "Test";
                nv.LuongCoBan = 2;
                nv.NgayVaoLam=DateTime.Now;
                _nvxl.NhanVien_Update(nv);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region NhaCungCap
        NhaCungCapXuLy _nccxl;
        [TestMethod]
        //test select
        public void TestNhaCungCap_SelectAll()
        {
            _nccxl = new NhaCungCapXuLy();
            DataTable dt = _nccxl.NhaCungCap_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestNhaCungCap_FindItem()
        {
            _nccxl = new NhaCungCapXuLy();
            string item = "C";
            DataTable dt = _nccxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestNhaCungCap_CheckId()
        {
            _nccxl = new NhaCungCapXuLy();
            string item = "NCC1";
            bool check = _nccxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestNhaCungCap_CheckIdFalse()
        {
            _nccxl = new NhaCungCapXuLy();
            string item = "NCC11";
            bool check = _nccxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestNhaCungCap_InsertFalse()
        {
            _nccxl = new NhaCungCapXuLy();
            bool actual;
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCc = "NCC1";
                ncc.TenNhaCc = "Test";
                ncc.DiaChi = "Test";
                ncc.DienThoai = "012331456";
                ncc.Email = "Test";
                _nccxl.NhaCungCap_Insert(ncc);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestNhaCungCap_Insert()
        {
            _nccxl = new NhaCungCapXuLy();
            bool actual;
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCc = "NCC10";
                ncc.TenNhaCc = "Test";
                ncc.DiaChi = "Test";
                ncc.DienThoai = "012331456";
                ncc.Email = "Test";
                _nccxl.NhaCungCap_Insert(ncc);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            NhaCungCap ncc1 = new NhaCungCap();
            ncc1.MaNhaCc = "NCC10";
            _nccxl.NhaCungCap_Delete(ncc1);
        }

        [TestMethod]
        //test delete
        public void TestNhaCungCap_Delete()
        {
            _nccxl = new NhaCungCapXuLy();
            bool actual;
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCc = "NCC10";
                _nccxl.NhaCungCap_Delete(ncc);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestNhaCungCap_Update()
        {
            _nccxl = new NhaCungCapXuLy();
            bool actual;
            try
            {
                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNhaCc = "NCC8";
                ncc.TenNhaCc = "Test";
                ncc.DiaChi = "Test";
                ncc.DienThoai = "012331456";
                ncc.Email = "Test";
                _nccxl.NhaCungCap_Update(ncc);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }
        #endregion

        #region Xe
        LoaiXeXuLy _lxxl;
        [TestMethod]
        //test select
        public void TestXe_SelectAll()
        {
            _lxxl = new LoaiXeXuLy();
            DataTable dt = _lxxl.Xe_SelectAll();
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test Find true
        public void TestXe_FindItem()
        {
            _lxxl = new LoaiXeXuLy();
            string item = "S";
            DataTable dt = _lxxl.FindItem(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestXe_CheckId()
        {
            _lxxl = new LoaiXeXuLy();
            string item = "SO1";
            bool check = _lxxl.CheckId(item);
            int actual = 0;
            if (check)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test checkid true
        public void TestXe_CheckIdFalse()
        {
            _lxxl = new LoaiXeXuLy();
            string item = "SO11";
            bool check = _lxxl.CheckId(item);
            int actual;
            if (check)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        //test insert false
        public void TestXe_InsertFalse()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                LoaiXe lx = new LoaiXe();
                lx.MaXe = "SO1";
                lx.TenHangXe = "Test";
                lx.SoLuong = 1;
                lx.ThongTinBaoHanh = "Test";
                lx.TenXe = "Test";
                lx.NhaSx = "Test";
                lx.DonGia = 1;
                lx.TinhTrang = "Test";
                _lxxl.Xe_Insert(lx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        //test insert true
        public void TestXe_Insert()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                LoaiXe lx = new LoaiXe();
                lx.MaXe = "SO10";
                lx.TenHangXe = "Test";
                lx.SoLuong = 1;
                lx.ThongTinBaoHanh = "Test";
                lx.TenXe = "Test";
                lx.NhaSx = "Test";
                lx.DonGia = 1;
                lx.TinhTrang = "Test";
                _lxxl.Xe_Insert(lx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
            LoaiXe lx1 = new LoaiXe();
            lx1.MaXe = "SO10";
            _lxxl.Xe_Delete(lx1);
        }

        [TestMethod]
        //test delete
        public void TestXe_Delete()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                LoaiXe lx = new LoaiXe();
                lx.MaXe = "SO10";
                _lxxl.Xe_Delete(lx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test update
        public void TestXe_Update()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                LoaiXe lx = new LoaiXe();
                lx.MaXe = "XE";
                lx.TenHangXe = "Test";
                lx.SoLuong = 1;
                lx.ThongTinBaoHanh = "Test";
                lx.TenXe = "Test";
                lx.NhaSx = "Test";
                lx.DonGia = 1;
                lx.TinhTrang = "Test";
                _lxxl.Xe_Update(lx);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //Update SLNhap
        public void TestXe_UpdateSLNhap()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                string maXe = "XE";
                int soLuong = 10;
                int donGia = 10;
                _lxxl.Xe_UpdateSLNhap(maXe, soLuong, donGia);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //Update SLXuat
        public void TestXe_UpdateSLXuat()
        {
            _lxxl = new LoaiXeXuLy();
            bool actual;
            try
            {
                string maXe = "XE";
                int soLuong = 10;
                _lxxl.Xe_UpdateSLXuat(maXe, soLuong);
                actual = true;
            }
            catch (Exception)
            {
                actual = false;
            }
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        //test laythongtinxe
        public void TestXe_LayTT()
        {
            _lxxl = new LoaiXeXuLy();
            string item = "SO1";
            DataTable dt = _lxxl.LayXe(item);
            int actual = 0;
            if (dt.Rows.Count != 0)
            {
                actual = 1;
            }
            Assert.AreEqual(1, actual);
        }
        #endregion

        #region User
        UserXuLy _uxl;
        [TestMethod]
        //test co user
        public void TestUser()
        {
            _uxl = new UserXuLy();
            int actual;
            User user = new User();
            user.UserName = "admin";
            user.PassWord = "123";
            int kq = _uxl.CheckUser(user);
            if (kq == 1)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(1, actual);
        }

        [TestMethod]
        //test khong co user
        public void TestNotUser()
        {
            _uxl = new UserXuLy();
            int actual;
            User user = new User();
            user.UserName = "test";
            user.PassWord = "test";
            int kq = _uxl.CheckUser(user);
            if (kq == 1)
            {
                actual = 1;
            }
            else
            {
                actual = 0;
            }
            Assert.AreEqual(0, actual);
        }
        #endregion
    }
}
