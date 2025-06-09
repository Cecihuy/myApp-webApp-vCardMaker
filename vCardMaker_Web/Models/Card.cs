using System;

namespace vCardMaker_Web.Models{
  public class Card{
    public string Header { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string Footer { get; set; } = "END:VCARD";
     
  }
}
