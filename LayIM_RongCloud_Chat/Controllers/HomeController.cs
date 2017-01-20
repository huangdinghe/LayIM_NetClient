﻿using LayIM.Logger;
using LayIM.Queue.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayIM_RongCloud_Chat.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            try
            {
                var queue = LayIM.Container.LayIMGlobalServiceContainer.GlobalContainer.Resolve<ILayIMQueue>();
                for (var i = 0; i < 100; i++)
                {
                    queue.Publish(new LayIM.Model.Log.LayIMLogModel
                    {
                        Exception = null,
                        Message = "哈哈哈哈，日志出问题啦"
                    });
                }
            }
            catch (Exception ex) {
                LogHelper.WriteLog(ex);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}