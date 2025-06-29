using System;
using System.Collections.Generic;
using vCardMaker_Web.Models;

namespace vCardMaker_Web.Repository{
  public class CardRepo {
    private List<Card> cards;
    public CardRepo(){
      cards = new List<Card>();
    }
    public List<Card> GetAllCards(){
      return cards;
    }
    public void SaveCard(Card data){
      cards.Add(data);
    }
    public void DeleteCard(string data){
      Card? cardFound = cards.Find(x => x.Name == data);
      cards.Remove(cardFound!);
    }
    public void DeleteAllCards(){
      cards.Clear();
    }
  }
}
