﻿using System.Web;
using System.Web.Mvc;

namespace DCSPCS.REST_Api
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
