using System.Collections.Generic;
using System.IO;
using System.Text;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using vCardMaker_Web.Models;
using vCardMaker_Web.Repository;

namespace vCardMaker_Web.Controllers {
  public class HomeController : Controller{
    private CardRepo cardRepo;

    public HomeController(CardRepo cardRepo){
      this.cardRepo = cardRepo;
    }
    [HttpGet]
    public IActionResult Index() {
      Card card = new Card();
      cardRepo.GetAllCards();
      return View(cardRepo);
    }
    [HttpPost]
    public IActionResult SaveContact(Card card){
      cardRepo.SaveCard(card);
      return View("Index", cardRepo);
    }
    [HttpPost]
    [Route("home/deletecontact/{card}")]
    public IActionResult DeleteContact(string card){
      cardRepo.DeleteCard(card);
      return RedirectToAction("Index");
    }
    public IActionResult GenerateVcf(){
      List<Card> cards = cardRepo.GetAllCards();
      StringBuilder stringBuilder = new StringBuilder();
      byte[] bytes = null!;
      foreach (Card card in cards){
        stringBuilder.AppendLine(card.Header);
        stringBuilder.AppendLine($"N:{card.Name};");
        stringBuilder.AppendLine($"TEL;CELL:{card.Number}");
        stringBuilder.AppendLine(card.Footer);
        bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());        
      }
      return File(bytes, "application/octet-stream", "vCard.vcf");
    }
    public IActionResult DeleteAllCards(){
      cardRepo.DeleteAllCards();
      return RedirectToAction("Index");
    }
    public IActionResult GenerateExcel() {
      List<Card> cards = cardRepo.GetAllCards();
      using(FileStream fileStreamOnServer = new FileStream("vCardMakerExcel.xlsx", FileMode.Create)) {
        XLWorkbook xLWorkbook = new XLWorkbook();
        IXLWorksheet iXLWorksheet = xLWorkbook.Worksheets.Add("Sample Sheet");        
        iXLWorksheet.Cell(1, 1).Value = "Nama";
        iXLWorksheet.Cell(1, 2).Value = "Nomor HapE";
        iXLWorksheet.Range("A1:B1").Style.Font.Bold = true;
        foreach(var r in cards) {
          int index = cards.IndexOf(r) + 2;
          iXLWorksheet.Cell(index, 1).Value = r.Name;
          iXLWorksheet.Cell(index, 2).Value = r.Number;
        }
        iXLWorksheet.Columns().AdjustToContents();
        xLWorkbook.SaveAs(fileStreamOnServer);
      }
      FileStream fileStream = new FileStream("vCardMakerExcel.xlsx", FileMode.Open);
      return File(fileStream, "application/octet-stream", "vCardMakerExcel.xlsx");
    }
  }
}