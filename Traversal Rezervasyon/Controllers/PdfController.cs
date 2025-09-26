using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DTOs.PdfDTOs;
using EntityLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Areas.Admin.Models;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers
{
    public class PdfController : Controller
    {

        public IActionResult GuideList()
        {
            var FileName = Guid.NewGuid();
            using var c = new Context();


            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfDocumentation/" + FileName + ".pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(2);

            pdfTable.AddCell("Ad");
            pdfTable.AddCell("Açıklama");

            foreach (var item in pdfGuideModels())
            {
                pdfTable.AddCell(item.Name);
                pdfTable.AddCell(item.Description);
            }


            document.Add(pdfTable);

            document.Close();

            return File("/PdfDocumentation/" + FileName + ".pdf", "application/pdf", FileName + ".pdf");
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

        public List<PdfDestinationModel> pdfDestinationModels()
        {
            using var c = new Context();
            List<PdfDestinationModel> pdfDestinationModels = new List<PdfDestinationModel>();

            pdfDestinationModels = c.Destinations.Select(N => new PdfDestinationModel
            {
                City = N.City,

                Capacity = N.Capacity,

                Price = N.Price
            }).ToList();

            return pdfDestinationModels;
        }

        public IActionResult PdfDestination()
        {
            var FileName = Guid.NewGuid();

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfDocumentation/" + FileName + ".pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(3);

            pdfTable.AddCell("Şehir");
            pdfTable.AddCell("Fiyat");
            pdfTable.AddCell("Kapasite");

            foreach (var item in pdfDestinationModels())
            {
                pdfTable.AddCell(item.City);
                pdfTable.AddCell(item.Price.ToString());
                pdfTable.AddCell(item.Capacity.ToString());
            }

            document.Add(pdfTable);

            document.Close();

            return File("/PdfDocumentation/" + FileName + ".pdf", "application/pdf", FileName + ".pdf");
        }

        public List<ExcelCommentModel> pdfcommentmodels()
        {
            using var c = new Context();

            List<ExcelCommentModel> pdfcommentmodels = new List<ExcelCommentModel>();

            pdfcommentmodels = c.Comments.Select(n => new ExcelCommentModel
            {
                UserName = n.CommentUser,

                Destination = n.Destination.City,

                CommentDate = n.CommentDate,

                CommentContent = n.CommentContent



            }).ToList();

            return pdfcommentmodels;

        }

        public IActionResult PdfComment()
        {
            var FileName = Guid.NewGuid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfDocumentation/" + FileName + ".pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document, stream);

            document.Open();

            PdfPTable pdfTable = new PdfPTable(4);
            pdfTable.AddCell("Kullanıcı Adı");
            pdfTable.AddCell("Tarih");
            pdfTable.AddCell("Yorum");
            pdfTable.AddCell("Şehir");

            foreach (var item in pdfcommentmodels())
            {
                pdfTable.AddCell(item.UserName);
                pdfTable.AddCell(item.CommentDate.ToShortDateString());
                pdfTable.AddCell(item.CommentContent);
                pdfTable.AddCell(item.Destination);
            }
            document.Add(pdfTable);

            document.Close();

            return File("/PdfDocumentation/" + FileName + ".pdf", "application/pdf", FileName + ".pdf");
        }

        public List<ExcelGuestUserModel> pdfGuestUserModels()
        {
            using var c = new Context();

            List<ExcelGuestUserModel> excelGuestUserModels = new List<ExcelGuestUserModel>();

            excelGuestUserModels = c.Users.Select(n => new ExcelGuestUserModel
            {
                Name = n.Name,

                UserName = n.UserName,

                Surname = n.Surname,

                PhoneNumber = n.PhoneNumber,

                EMail = n.Email

            }).ToList();

            return excelGuestUserModels;
        }

        public IActionResult PdfUser()
        {
            var filename = Guid.NewGuid();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfDocumentation/"+filename+".pdf");

            var stream = new FileStream(path,FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document,stream);
            document.Open();

            PdfPTable pdfPTable = new PdfPTable(5);

            pdfPTable.AddCell("Ad");
            pdfPTable.AddCell("Soyad");
            pdfPTable.AddCell("Kullanıcı Ad");
            pdfPTable.AddCell("E-Mail");
            pdfPTable.AddCell("Telefon Numarası");

            foreach (var item in pdfGuestUserModels())
            {
                pdfPTable.AddCell(item.Name);
                pdfPTable.AddCell(item.Surname);
                pdfPTable.AddCell(item.UserName);
                pdfPTable.AddCell(item.EMail);
                pdfPTable.AddCell(item.PhoneNumber);
            }

            document.Add(pdfPTable);

            document.Close();

            return File("/PdfDocumentation/"+filename+".pdf","application/pdf",filename+".pdf");

        }

    }


}
