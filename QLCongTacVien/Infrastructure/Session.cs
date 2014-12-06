using QLCongTacVien.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCongTacVien.Infrastructure
{
    public class UserSession
    {
        public long UserId;
        public string SessionKey;
        public string UserName;
        public string UserFullName;
        public HashSet<string> Functions;
    }

    public class SessionData
    {
        public MenuType MenuId;
        public AppMenu Menu;
        public UserSession User;
        public string LoginBackUrl;
        public string SelectedMenuId;
        public string LastRawUrl;
        public bool IsLoggedin()
        {
            return (User != null);
        }
        public static SessionData GetAppSession(HttpSessionStateBase session)
        {
            if (session == null)
            {
                return null;
            }
            SessionData ss = session["AppSession"] as SessionData;
            if (ss != null)
            {
                return ss;
            }
            ss = new SessionData();
            ss.Menu = null;
            ss.MenuId = 0;
            ss.User = null;
            session["AppSession"] = ss;
            return ss;

        }
    }

    public class FunctionIds
    {
        public const string PhongBang_Search = "PhongBang_Search";
    }
}