using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MVCtop10XML.Models;

namespace MVCtop10XML.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<kelimeModel> kelimeler = new List<kelimeModel>();

            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XML/kitap.xml"));

            //Loop through the selected Nodes.
            foreach (XmlNode node in doc.SelectNodes("/words/word"))
            {
                //Fetch the Node values and assign it to Model.
                kelimeler.Add(new kelimeModel
                {
                    //CustomerId = int.Parse(node["Id"].InnerText),
                    Text1 = node.Attributes["text"].Value,
                    Count1 = Convert.ToInt32(node.Attributes["count"].Value),
                });
            }

            return View(kelimeler.OrderByDescending(x => x.Count1).Take(10));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Created by: Murat Kızmış.";

            return View();
        }

        public ContentResult CountPartial()
        {
            List<kelimeModel> kelimeler = new List<kelimeModel>();

            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/XML/kitap.xml"));

            //Loop through the selected Nodes.
            foreach (XmlNode node in doc.SelectNodes("/words/word"))
            {
                //Fetch the Node values and assign it to Model.
                kelimeler.Add(new kelimeModel
                {
                    //CustomerId = int.Parse(node["Id"].InnerText),
                    Text1 = node.Attributes["text"].Value,
                    Count1 = Convert.ToInt32(node.Attributes["count"].Value),
                });
            }

            
            return Content(kelimeler.Count.ToString());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}