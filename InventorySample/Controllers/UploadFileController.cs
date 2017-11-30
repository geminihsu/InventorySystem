using Excel;
using InventorySample.Models;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InventorySample.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HttpPostedFileBase uploadfile)
        {
            if (ModelState.IsValid)
            {
                if (uploadfile != null && uploadfile.ContentLength > 0)
                {
                    //ExcelDataReader works on binary excel file
                    Stream stream = uploadfile.InputStream;
                    //We need to written the Interface.
                    IExcelDataReader reader = null;
                    if (uploadfile.FileName.EndsWith(".xls"))
                    {
                        //reads the excel file with .xls extension
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (uploadfile.FileName.EndsWith(".xlsx"))
                    {
                        //reads excel file with .xlsx extension
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        //Shows error if uploaded file is not Excel file
                        ModelState.AddModelError("File", "This file format is not supported");
                        return View();
                    }
                    //treats the first row of excel file as Coluymn Names
                    reader.IsFirstRowAsColumnNames = true;
                    //Adding reader data to DataSet()
                    DataSet result = reader.AsDataSet();

                    var items = InventoryHelper.shippingFG(reader);
                    //insert data to into database
                    //DbHelper.InsertSN(items);

                    /*      var d = result.Tables[0].AsEnumerable().Select((x,index)=> new {
                              SN = x[0],
                          Location = x[1]
                      }).ToList();*/

                    //Sending result data to View
                    return View(items);
                    //return Json(d);

                    //Display data from database
                    //ItemDBContext db = new ItemDBContext();
                    //return View(db.InventoryItems.ToList());
                }
            }
            else
            {
                ModelState.AddModelError("File", "Please upload your file");
            }
            return View();
        }

        // GET: Items/Create
        public ActionResult Confirm([Bind(Include = "ID,SN,Location")] List<Item> items)
        {

            //insert data to into database
            DbHelper.InsertSN(items);
            
            //Display data from database
            ItemDBContext db = new ItemDBContext();
            return View(db.InventoryItems.ToList());
            //return View();
        }
    }
}