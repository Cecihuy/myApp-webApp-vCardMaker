using System;
using System.Collections.Generic;
using vCardMaker_Web.Models;

namespace vCardMaker_Web.ViewModels{
  public class CardViewModel{
    private List<Card> cards;
    public CardViewModel()
    {
      cards = new List<Card>();
    }
    public string Header { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Footer { get; } = "END:VCARD";
  }
}
