﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StateManagement.Controllers
{
    public class HomeController : Controller
    {
       public ActionResult AddCookie()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCookie(string name)
        {
            HttpCookie c = new HttpCookie("x", name);
            c.Expires = DateTime.Now.AddDays(30);
            Response.Cookies.Add(c);
            ViewBag.msg = "Cookie Added";
            return View();
        }
        public ActionResult ReadCookie()
        {
            HttpCookie c = Request.Cookies["x"];
            if(c!=null)
            {
                ViewBag.msg = "Cookie Value : " + c.Value;
            }
            else
            {
                ViewBag.msg = "No Cookie Found";
            }
            return View();
        }
        public ActionResult AddTempData()
        {
            TempData["code"] = "1001";
            return View();
        }
        public ActionResult ReadTempData()
        {
            if(TempData["code"]!=null)
            {
                ViewBag.msg = TempData["code"].ToString();
            }
            else
            {
                ViewBag.msg = "No Temp Data";
            }
            return View();
        }
        public ActionResult ReadApplication()
        {
            ViewBag.msg = HttpContext.Application["prodlist"].ToString();
            //List<ProductModel> plist=HttpContext.Application["ProductList"] as List<ProductModel>();
            return View();
        }
        public ActionResult CreateSession()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSession(string employeeid)
        {
            Session["employeeid"] = employeeid;
            ViewBag.msg = "Session Created";
            return View();
        }
        public ActionResult ReadSession()
        {
            string str = Session["employeeid"].ToString();
            string sid = Session.SessionID;
            ViewBag.msg = "Employee ID : " + str + " , Session ID : " + sid;
            return View();
        }
    }
}