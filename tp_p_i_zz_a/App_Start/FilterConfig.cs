﻿using System.Web;
using System.Web.Mvc;

namespace tp_p_i_zz_a
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
