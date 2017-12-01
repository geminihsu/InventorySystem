using Excel;
using InventorySample.Entities;
using InventorySample.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

                    var guid = InventoryHelper.AddShippingFG(reader);
                    Container container = InventoryHelper.CheckAndGetContainerModel(guid);

                    return View(container);
                }
            }
            else
            {
                ModelState.AddModelError("File", "Please upload your file");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Confirm(Guid id)
        {
            Container container = InventoryHelper.CheckAndGetContainerModel(id);

            //clear Table
            //DbHelper.DeleteSN(container.items);
            //insert data to into database
            DbHelper.InsertSN(container.items);

            //Display data from database
            SampleDBContext db = new SampleDBContext();

            var model = new Container()
            {
                Id = Guid.NewGuid(),
                items = db.Items.ToList()
            };

            return View(model);
            //return View();
        }
    }
}