using System.Collections.Generic;
using System.Linq;

namespace ToDoProject
{
    public class Line
    {
        public Line(string lineName)
        {
            _lineName = lineName;
        }
        
        private string _lineName;
        
        public List<Card> cardList = new List<Card>();


        public Card FindCard(string title)
        {
            return cardList.FirstOrDefault(card => card.Title == title);
        }

        public List<Card> FindAllCard(string title)
        {
            return  cardList.FindAll(card => card.Title == title);
        }

        public void CardCreate(Card card)
        {
                cardList.Add(card);
        }

        public bool CardDelete(string title)
        {
            bool success = false;
            foreach (Card card in cardList)
            {
                if(card.Title == title)
                {
                    cardList.Remove(card);
                    success = true;
                }
            }

            return success;
        }

        public bool CardUpdate(Card newCard)
        {
            bool success = false;

            foreach (Card card in cardList)
            {
                if(card.Title == newCard.Title)
                {
                    card.Title = newCard.Title;
                    card.Content = newCard.Content;
                    card.Size = newCard.Size;
                    card.Person = newCard.Person;

                    success = true;
                    break;
                }
            }

            return success;
        }


        public string LineName { get => _lineName; set => _lineName = value; }

    }
}