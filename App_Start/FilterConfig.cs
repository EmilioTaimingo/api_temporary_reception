﻿using System.Web;
using System.Web.Mvc;

namespace api_temporary_reception
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}