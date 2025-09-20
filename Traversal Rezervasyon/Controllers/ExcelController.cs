using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Bibliography;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ExcelDestinationModel> ExcelDestinationModels()
        {
            List<ExcelDestinationModel> excelDestinationModels = new List<ExcelDestinationModel>();

            using (var c = new Context())
            {
                excelDestinationModels = c.Destinations.Select(n => new ExcelDestinationModel
                {
                    DayNight = n.DayNight,
                    Capacity = n.Capacity,
                    Description = n.Description,
                    City = n.City
                }).ToList();
            }

            return excelDestinationModels;
        }

        public List<ExcelCommentModel> excelCommentModels()
        {
            List<ExcelCommentModel> excelCommentModels = new List<ExcelCommentModel>();

            using (var c = new Context())
            {
                excelCommentModels = c.Comments.Select(n => new ExcelCommentModel
                {
                    UserName = n.CommentUser,

                    CommentDate = n.CommentDate,

                    CommentContent = n.CommentContent,

                    Destination = n.Destination.City
                }).ToList();
            }
            return excelCommentModels;


        }

        public IActionResult ExcelDestination()
        {
            using (var c = new XLWorkbook())
            {
                var worksheet = c.Worksheets.Add("Tur Listesi");

                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Kaç Gün Kaç Gece";
                worksheet.Cell(1, 3).Value = "Açıklama";
                worksheet.Cell(1, 4).Value = "Kapasite";

                int rowcount = 2;

                foreach (var item in ExcelDestinationModels())
                {
                    worksheet.Cell(rowcount, 1).Value = item.City;
                    worksheet.Cell(rowcount, 2).Value = item.DayNight;
                    worksheet.Cell(rowcount, 3).Value = item.Description;
                    worksheet.Cell(rowcount, 4).Value = item.Capacity;

                    rowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    c.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheethml.sheet", Guid.NewGuid() + ".xlsx");
                }
            }
        }

        public IActionResult ExcelComment()
        {
            using (var c = new XLWorkbook())
            {
                var worksheet = c.Worksheets.Add("Yorum Listesi");

                worksheet.Cell(1, 1).Value = "Kullanıcı Adı";

                worksheet.Cell(1, 2).Value = "Tarih";
                worksheet.Cell(1, 3).Value = "Yorum";
                worksheet.Cell(1, 4).Value = "Şehir";

                int rowcount = 2;

                foreach (var item in excelCommentModels())
                {
                    worksheet.Cell(rowcount, 1).Value = item.UserName;
                    worksheet.Cell(rowcount, 2).Value = item.CommentDate.ToShortDateString();
                    worksheet.Cell(rowcount, 3).Value = item.CommentContent;
                    worksheet.Cell(rowcount, 4).Value = item.Destination;

                    rowcount++;
                }

                using (var stream = new MemoryStream())
                {
                    c.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheethml.sheet", Guid.NewGuid() + ".xlsx");

                }
            }

        }

        public List<PdfGuideModel> pdfGuideModels()
        {
            using var c = new Context();
            List<PdfGuideModel> pdfGuideModels = new List<PdfGuideModel>();

            pdfGuideModels = c.Guides.Select(N => new PdfGuideModel
            {
                Name = N.Name,

                Description = N.Description
            }).ToList();

            return pdfGuideModels;
        }
        public IActionResult ExcelGuide()
        {
            using (var c = new XLWorkbook())
            {
                var worksheets = c.Worksheets.Add("Rehber Listesi");

                worksheets.Cell(1, 1).Value = "Ad-Soyad";
                worksheets.Cell(1, 2).Value = "Açıklama";

                int rowcount = 2;

                foreach (var item in pdfGuideModels())
                {
                    worksheets.Cell(rowcount, 1).Value = item.Name;
                    worksheets.Cell(rowcount, 2).Value = item.Description;

                    rowcount++;
                }

                using (var stream = new MemoryStream())
                {
                     c.SaveAs(stream);

                    var contant = stream.ToArray();

                    return File(contant, "application/vnd.openxmlformats-officedocument.spreadsheethml.sheet",Guid.NewGuid()+".xlsx");
                }

            }
        }

    }
}
