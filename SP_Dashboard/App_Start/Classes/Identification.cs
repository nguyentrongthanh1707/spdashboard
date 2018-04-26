using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

public sealed class Identification : Page
{
    private static string UserData = "";
    private static Identification _manager;
    private Identification()
    {
        UserData = Security.DecryptStringCbc(HttpContext.Current.User.Identity.Name + "", "dashboard");
    }
    public static Identification GetInstance()
    {
        lock (typeof(Identification))
        {
            _manager = new Identification();
        }
        return _manager;
    }
    public bool Authenticated
    {
        get
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
    public bool IsAuthenticated
    {
        get { return this.Authenticated; }
    }
    public string GetUserEmail()
    {
        var data = UserData.Split(';');
        if (data.Length > 0)
        {
            return data[0];
        }
        return "";
    }
    public decimal GetUserId()
    {
        var data = UserData.Split(';');
        if (data.Length > 1)
        {
            return decimal.Parse(data[1]);
        }
        return -1;
    }
    public string GetFullName()
    {
        var data = UserData.Split(';');
        if (data.Length > 2)
        {
            return data[2];
        }
        return "";
    }
}