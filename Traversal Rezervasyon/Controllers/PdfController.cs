using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Traversal_Rezervasyon.Models;

namespace Traversal_Rezervasyon.Controllers
{
    public class PdfController : Controller
    {

        public IActionResult GuideList()
        {
            var FileName = Guid.NewGuid();
            using var c = new Context();


            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfDocumentation/" + FileName+ ".pdf");

            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);

            PdfWriter.GetInstance(document,stream);

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

            return File("/PdfDocumentation/" +FileName + ".pdf","application/pdf", FileName + ".pdf");
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
    }
}
