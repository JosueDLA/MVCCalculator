﻿
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using calculadora.Models;
using System.Net;
using System.IO;
using System.Web.UI;

namespace calculadora.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CalculadoraModel model, string command)
        {
            if (command == "Suma")
            {
                model.Result = Suma(model.A, model.B).ToString();
                Console.WriteLine(model.Result);
            }
            if (command == "Resta")
            {
                model.Result = Resta(model.A, model.B).ToString();
}
            if (command == "Multiplicacion")
            {
                model.Result = Multi(model.A, model.B).ToString();
            }
            if (command == "Division")
            {
                model.Result = Divi(model.A, model.B).ToString();
            }
            return View(model);
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

        public double Suma(double a, double b) {
            double resultado = 0;
            var url = "https://iscalculadora.appspot.com/sumar?a=" + a + "&b=" + b;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                resultado = Convert.ToInt32(result);
            }

            return resultado;
        }

        public double Resta(double a, double b)
        {
            double resultado = 0;
            var url = "https://iscalculadora.appspot.com/restar?a=" + a + "&b=" + b;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                resultado = Convert.ToInt32(result);
            }

            return resultado;
        }

        public double Multi(double a, double b)
        {
            double resultado = 0;
            var url = "https://iscalculadora.appspot.com/multiplicar?a=" + a + "&b=" + b;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                resultado = Convert.ToInt32(result);
            }

            return resultado;
        }

        public double Divi(double a, double b)
        {
            double resultado = 0;
            var url = "https://iscalculadora.appspot.com/dividir?a=" + a + "&b=" + b;
            var webrequest = (HttpWebRequest)System.Net.WebRequest.Create(url);

            using (var response = webrequest.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                var result = reader.ReadToEnd();
                resultado = Convert.ToDouble(result);
            }

            return resultado;
        }
    }
}