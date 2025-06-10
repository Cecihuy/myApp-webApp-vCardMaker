using System;
using System.ComponentModel.DataAnnotations;

namespace vCardMaker_Web.Models{
  public class Card{
    public string Header { get; set; } = string.Empty;
    [Required]
    [MaxLength(15, ErrorMessage = "maksimal 15 karakter yang diperbolehkan")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(15, ErrorMessage = "maksimal 15 karakter yang diperbolehkan")]
    public string Number { get; set; } = string.Empty;
    public string Footer { get; set; } = "END:VCARD";
     
  }
}
