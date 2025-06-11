using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using vCardMaker_Web.Models;
using vCardMaker_Web.Repository;

namespace vCardMaker_Web.Controllers{
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
  }
}
