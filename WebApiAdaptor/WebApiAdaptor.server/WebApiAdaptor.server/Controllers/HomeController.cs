using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestSample.Models;

namespace TestSample.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.datasource = OrdersDetails.GetAllRecords().ToList();
            ViewBag.data = new string[] { "1", "2" };
            return View();
        }

        public IActionResult GridDatasource([FromBody]DataManager dm)
        {
            var Data = OrdersDetails.GetAllRecords();
            int count = Data.Count();
            if (dm.skip != 0)
                Data = Data.Skip(dm.skip).ToList();
            if (dm.take != 0)
                Data = Data.Take(dm.take).ToList();
            return dm.requiresCounts ? Json(new { result = Data, count = count }) : Json(Data);
        }
            public ActionResult BatchUpdate(List<OrdersDetails> changed, List<OrdersDetails> added, List<OrdersDetails> deleted)
            {

                if (changed != null)
                {
                    var ord = changed[0];
                    OrdersDetails val = OrdersDetails.GetAllRecords().Where(or => or.OrderID == ord.OrderID).FirstOrDefault();

                    val.EmployeeID = ord.EmployeeID;
                    val.OrderID = ord.OrderID;
                    val.CustomerID = ord.CustomerID;
                }
                if (deleted != null)
                {
                    OrdersDetails.GetAllRecords().Remove(OrdersDetails.GetAllRecords().Where(or => or.EmployeeID == int.Parse(deleted[0].OrderID.ToString())).FirstOrDefault());
                }
                if (added != null)
                {
                    OrdersDetails.GetAllRecords().Insert(0, added[0]);
                }

                List<OrdersDetails> Data = OrdersDetails.GetAllRecords().ToList();
                return Json(new { result = Data, count = Data.Count });

                //  return Json(data, JsonRequestBehavior.AllowGet);
            }

        }

        public class DataResult
        {
            public List<OrdersDetails> result { get; set; }
            public int count { get; set; }
            public int skip { get; set; }
            public int Skip { get; set; }
        }

        public class DataManager
        {

            public int skip { get; set; }

            public int take { get; set; }
           public int id { get; set; }

        public string tab { get; set; }

            public int[] draggedRow { get; set; }
            public int position { get; set; }

            public bool requiresCounts { get; set; }

            public List<Wheres> where { get; set; }

            public List<Search> search { get; set; }

        }

        public class Wheres
        {
            public string field { get; set; }
            public bool ignoreCase { get; set; }

            public bool isComplex { get; set; }

            public string value { get; set; }
            public string Operator { get; set; }

        }
        public class Search
        {
            public string[] fields { get; set; }
            public bool ignoreCase { get; set; }
            public string key { get; set; }
            public string Operator { get; set; }
        }

    }

    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails()
        {

        }
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 2; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", i + 1, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", i + 2, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", i + 3, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                    code += 5;
                }
            }
            return order;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }

        public string ShipName { get; set; }

        public string ShipCountry { get; set; }

        public DateTime ShippedDate { get; set; }
        public string ShipAddress { get; set; }
    }