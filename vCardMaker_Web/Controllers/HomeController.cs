using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
      cardRepo.GetAllCards();
      return View(cardRepo);
    }
    [HttpPost]
    public IActionResult Index(Card card){
      cardRepo.SaveCard(card);
      return View("Index", cardRepo);
    }
    













    public IActionResult Privacy()
    {
      return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
