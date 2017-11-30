using QLCuaHangXeMay.DataAccess;

namespace QLCuaHangXeMay.Business
{
    class UserXuLy
    {
        DbConnection _db = new DbConnection();
        User _user = new User();
        public int CheckUser(User user)
        {
            return _db.table_Reader("select * from TaiKhoan where username='" + user.UserName + "' and password='" + user.PassWord + "'");
        }
    }
}
