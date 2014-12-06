using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCongTacVien.Infrastructure
{
    public class ErrorMsg
    {
        static Hashtable msgTbl = null;
        ///<aothor>Huong Nguyen</aothor>
        /// <summary>
        /// Lay noi dung bao loi tu ma loi.
        /// </summary>
        /// <param name="errorCode">Ma loi.</param>
        /// <returns>Noi dung bao loi.</returns>
        public static string GetErrorMsg(int errorCode)
        {
            if (msgTbl == null)
            {
                InitializeMsg();
            }
            if (msgTbl.ContainsKey(errorCode))
            {
                return msgTbl[errorCode].ToString();
            }
            return string.Format(MSG_COMMON_SYS_ERR, errorCode);
        }
        static void InitializeMsg()
        {
            msgTbl = new Hashtable();
            // DB common error
            msgTbl.Add(0, string.Format(MSG_COMMON_SYS_ERR, 0));

            // Bízervice
            // Common errors 100 - 199, 1999
            // exception
            msgTbl.Add(1999, string.Format(MSG_COMMON_SYS_ERR, 1999));
            // Loi ket noi/thuc thi DB
            msgTbl.Add(199, string.Format(MSG_COMMON_SYS_ERR, 199));
            //CustomerNotFound
            msgTbl.Add(100, string.Format(MSG_COMMON_SYS_ERR, 100));
            // UserID khong hop le BillerCodeNotMatchUserId
            //msgTbl.Add(-1000, string.Format(MSG_COMMON_SYS_ERR, -1000));
            msgTbl.Add(-1002, "Phiên làm việc của bạn đã bị hủy. Vui lòng đăng nhập lại.");
            msgTbl.Add(-1004, string.Format("Bạn đã không còn quyền thực hiện chức năng này ({0}). Vui lòng liên hệ quản trị hệ thống để được giải đáp.", 103));
            msgTbl.Add(-1005, string.Format("Bạn đã không còn quyền thực hiện chức năng này ({0}). Vui lòng liên hệ quản trị hệ thống để được giải đáp.", 104));
            // BillerCode & UserId khong match nhau

            // Quan ly giao dich 200 - 499

            // Account
            msgTbl.Add(-1000, "Thông tin đăng nhập không đúng. Vui lòng nhập lại.");
            msgTbl.Add(-1001, "Thông tin đăng nhập không đúng. Vui lòng nhập lại.");
            msgTbl.Add(-1003, "Mật khẩu mới và mật khẩu cũ trùng nhau.");
            msgTbl.Add(2003, "Thông tin đăng nhập không chính xác.");
            msgTbl.Add(3000, "User Không hợp lệ");
            msgTbl.Add(3001, "Mật khẩu cũ không đúng");


        }
        const string MSG_COMMON_SYS_ERR = "Hệ thống thực hiện yêu cầu không thành công ({0}). Vui lòng thử lại sau.";
        public static string MSG_NotSuccess_TaoPhongBan = "Hệ thống tạo phòng ban không thành công!";
        public static string MSG_Success_TaoPhongBan = "Hệ thống tạo phòng ban thành công!";
        public static string MSG_NotSuccess_TaoAccount = "Hệ thống tạo account không thành công!";
        public static string MSG_Success_TaoAccount = "Hệ thống tạo account thành công!";

    }
}