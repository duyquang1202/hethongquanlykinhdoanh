using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace QLCongTacVien.Infrastructure.Extension
{
    public class MenuItem
    {
        public string Name;
        public string Link;
        public string FuncId;
        public bool Shown;
        public MenuItem(string strName, string strLink, string strFuncId, bool bShown)
        {
            Name = strName;
            Link = strLink;
            FuncId = strFuncId;
            Shown = bShown;
        }

        public virtual bool IsPopup()
        {
            return false;
        }




    }

    public enum MenuType
    {
        NoMenu,
        Primary,
        BeforeLogin
    }

    public class PopupMenuItem : MenuItem
    {
        public List<MenuItem> Items;
        public PopupMenuItem(string strName, bool bShown, params MenuItem[] mnItems)
            : base(strName, null, null, bShown)
        {
            Items = new List<MenuItem>();
            foreach (MenuItem item in mnItems)
            {
                Items.Add(item);
            }
        }

        public override bool IsPopup()
        {
            return true;
        }
    }



    public class AppMenu
    {
        public List<MenuItem> Items = new List<MenuItem>();
        public AppMenu()
        {

        }
        static SortedDictionary<string, MenuType> dicOper2MenuType = null;
        public static MenuType GetMenuType(string controller, string operation)
        {
            if (dicOper2MenuType == null)
            {
                dicOper2MenuType = new SortedDictionary<string, MenuType>();
                dicOper2MenuType["Account.Login".ToLower()] = MenuType.NoMenu;
            }
            MenuType type;
            if (dicOper2MenuType.TryGetValue((controller + "." + operation).ToLower(), out type))
            {
                return type;
            }
            return MenuType.Primary;
        }

        public static AppMenu GetMenu(MenuType type, HashSet<string> lstFuncIds)
        {
            AppMenu mnu = null;
            if (type == MenuType.Primary)
            {
                mnu = new AppMenu();
                mnu.Items.Add(new PopupMenuItem("Quản lý phòng ban", true,
                    new MenuItem("Phòng Ban", "/PhongBan", FunctionIds.PhongBang_Search, true)
                 ));
            }
            if (lstFuncIds != null && mnu != null)
            {
                foreach (MenuItem puitm in mnu.Items)
                {
                    if (puitm.IsPopup())
                    {
                        PopupMenuItem popup = puitm as PopupMenuItem;
                        bool bShownPopup = false;
                        foreach (MenuItem itm in popup.Items)
                        {
                            if (!lstFuncIds.Contains(itm.FuncId))
                            {
                                itm.Shown = false;
                            }
                            else
                            {
                                bShownPopup = true;
                            }
                        }
                        popup.Shown = bShownPopup;
                    }
                    else if (!lstFuncIds.Contains(puitm.FuncId))
                    {
                        puitm.Shown = false;
                    }
                }
            }
            return mnu;
        }

        static SortedDictionary<string, string> dicOper2MenuId = null;
        public static string GetMenuId(string strRoute)
        {
            if (dicOper2MenuId == null)
            {
                dicOper2MenuId = new SortedDictionary<string, string>();
                dicOper2MenuId["phongban/search"] = FunctionIds.PhongBang_Search;

            }
            string strMenuId;
            if (dicOper2MenuId.TryGetValue(strRoute, out strMenuId))
            {
                return strMenuId;
            }
            return null;
        }


        public static void UpdateMenuSelection(ActionExecutingContext filterctx, SessionData ss)
        {
            if (ss == null)
            {
                return;
            }
            RouteValueDictionary routeVals = filterctx.RouteData.Values;
            string strUrl = (filterctx.RouteData.Route as Route).Url;
            foreach (string sKey in routeVals.Keys)
            {
                strUrl = strUrl.Replace("{" + sKey + "}", routeVals[sKey].ToString());
            }
            strUrl = strUrl.Split(new string[] { "/{" }, System.StringSplitOptions.None)[0].ToLower();
            string strMenuId = GetMenuId(strUrl);
            if (strMenuId != null)
            {
                ss.SelectedMenuId = strMenuId;
                ss.LastRawUrl = filterctx.HttpContext.Request.RawUrl;
            }
        }

        public static void UpdateMenuSelection(HttpRequest httpCtx)
        {
            SessionData ss = SessionData.GetAppSession(httpCtx.RequestContext.HttpContext.Session);
            if (ss == null)
            {
                return;
            }
            string strUrl = httpCtx.Path.ToLower().Remove(0, 1);
            string strMenuId = GetMenuId(strUrl);
            if (strMenuId != null)
            {
                ss.SelectedMenuId = strMenuId;
            }
        }
    }
}