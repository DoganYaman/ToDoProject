using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ToDoProject
{
    public class Board
    {
        
        public Line ToDoLine = new Line("TODO");
        public Line InProgressLine = new Line("IN PROGRESS");
        public Line DoneLine = new Line("DONE");
        public List<Line> boardLineList = new List<Line>();
        public List<Person> PersonList = new List<Person>();
        
        public Board()
        {
            PersonList.AddRange( new List<Person> {
                new Person { Name = "Doğan", Surname = "Yaman"},
                new Person { Name = "Kerem", Surname = "Aktürkoğlu"},
                new Person { Name = "Fernando", Surname = "Muslera"},
                new Person { Name = "Sacha", Surname = "Boey"},
                new Person { Name = "Mauro", Surname = "Icardi"},
                new Person { Name = "Doğan", Surname = "Yaman"},
                new Person { Name = "Ferdi", Surname = "Kadıoğlu"},
                new Person { Name = "İsmail", Surname = "Yüksek"},
                new Person { Name = "Dominik", Surname = "Livakovic"},
                new Person { Name = "Dusan", Surname = "Tadic"},
                new Person { Name = "Edin", Surname = "Dzeko"},
                new Person { Name = "Necip", Surname = "Uysal"},
                new Person { Name = "Mert", Surname = "Günok"},
                new Person { Name = "Gedson", Surname = "Fernandez"},
                new Person { Name = "Vincent", Surname = "Aboubakar"},
            });

            Person person1 = PersonList.FirstOrDefault(person => person.Card == null);
            Card card1 = new Card {Title = "MaviKart_1", Content = "MaviKart_1 içerik", Person = person1, Size = Size.XS};
            person1.Card = card1;
            ToDoLine.cardList.Add(card1);

            Person person2 = PersonList.FirstOrDefault(person => person.Card == null);
            Card card2 = new Card {Title = "MaviKart_2", Content = "MaviKart_2 içerik", Person = person2, Size = Size.S};
            person2.Card = card2;
            ToDoLine.cardList.Add(card2);

            Person person3 = PersonList.FirstOrDefault(person => person.Card == null);
            Card card3 = new Card {Title = "İndirimliKart_1", Content = "İndirimliKart_1 içerik", Person = person3, Size = Size.M};
            person3.Card = card3;
            InProgressLine.cardList.Add(card3);

            boardLineList.Add(ToDoLine);
            boardLineList.Add(InProgressLine);
            boardLineList.Add(DoneLine);
        }

        public void Index()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine(" (1) Board Listelemek");
            Console.WriteLine(" (2) Board'a Kart Eklemek");
            Console.WriteLine(" (3) Board'dan Kart Silmek");
            Console.WriteLine(" (4) Kart Taşımak");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1" : 
                    ListBoard();
                    break;
                case "2" : 
                    CardCreate();
                    break;
                case "3" : 
                    CardDelete();
                    break;
                case "4" : 
                    CardMove();
                    break;
                default :
                    Console.WriteLine("Hatalı Seçim Yaptınız..");
                    break;
            }

            Console.WriteLine();
        }

        public void ListBoard()
        {
            Console.WriteLine();

            foreach (Line line in boardLineList)
            {
                Console.WriteLine(line.LineName + " Line");
                Console.WriteLine("************************");
                if( line.cardList.Count > 0)
                {
                    foreach (Card card in line.cardList)
                    {
                        Console.WriteLine("Başlık      : " + card.Title);
                        Console.WriteLine("İçerik      : " + card.Content);
                        Console.WriteLine("Atanan Kişi : " + card.Person.Name + " " + card.Person.Surname + " " + card.Person.ID);
                        Console.WriteLine("Büyüklük    : " + card.Size);

                        if(line.cardList.IndexOf(card) < line.cardList.Count - 1)
                        {
                            Console.WriteLine("-");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("~ BOŞ ~");
                }
                Console.WriteLine();
            }

            Index();

        }
    
        public void CardCreate()
        {
            Console.Write("Başlık Giriniz                                  : ");
            string title = Console.ReadLine().Trim();
            Console.Write("İçerik Giriniz                                  : ");
            string content = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
            int size = int.Parse(Console.ReadLine());
            Console.Write("Kişi Seçiniz                                    : ");
            int personId = int.Parse(Console.ReadLine());

            Card card = new Card();
            card.Title = title;
            card.Content = content;

            switch(size)
            {
                case (int)Size.XS : 
                    card.Size = Size.XS;
                    break;
                case (int)Size.S : 
                    card.Size = Size.S;
                    break;
                case (int)Size.M : 
                    card.Size = Size.M;
                    break;
                case (int)Size.L : 
                    card.Size = Size.L;
                    break;
                case (int)Size.XL : 
                    card.Size = Size.XL;
                    break;
            }

            Person person = PersonList.FirstOrDefault(person => person.ID == personId);

            if(person != null)
            {
                
                if(person.Card == null)
                {
                    card.Person = person;
                    person.Card = card;
                    ToDoLine.cardList.Add(card);

                    Console.WriteLine();
                    Console.WriteLine("Kart Eklendi !!!");
                }
                else
                {
                    Console.WriteLine("{0} ID'li üyeye zaten kart tanımlı", person.ID);
                }
            }
            else
            {
                Console.WriteLine("Hatalı girişler yaptınız!");
            }

            Console.WriteLine();

            Index();

        }
        
        public void CardDelete()
        {
            Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:");
            string title = Console.ReadLine().Trim();

            bool checkCardInList = CheckCardInList(title);

            do
            {
            if(checkCardInList)
            {
                foreach (Line line in boardLineList)
                {
                    line.cardList.RemoveAll(card => card.Title == title);  
                }

                Console.WriteLine();
                Console.WriteLine("Kart Silindi !!!");
            }
            else
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1 : 
                        checkCardInList = true;
                        break;
                    case 2 :
                        Console.WriteLine("Lütfen kart başlığını yazınız:");
                        title = Console.ReadLine().Trim();
                        checkCardInList = CheckCardInList(title);
                        break;
                }
            }
    
            } while (!checkCardInList);
            
            Console.WriteLine();
            
            Index();
            
        }

        public void CardMove()
        {
            Console.WriteLine("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.");
            Console.Write("Lütfen kart başlığını yazınız:");
            string title = Console.ReadLine().Trim();

            bool checkCardInList = CheckCardInList(title);

            do
            {
            if(checkCardInList)
            {
                foreach (Line line in boardLineList)
                {
                    Card card = line.cardList.FirstOrDefault(card => card.Title == title);

                    if( card != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Bulunan Kart Bilgileri:");
                        Console.WriteLine("**************************************");
                        Console.WriteLine("Başlık : " + card.Title);
                        Console.WriteLine("İçerik : " + card.Content);
                        Console.WriteLine("Atanan Kişi : " + card.Person.Name + card.Person.Surname);
                        Console.WriteLine("Büyüklük : " + card.Size);
                        Console.WriteLine("Line : " + line.LineName);
                        Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz: (1) TODO (2) IN PROGRESS (3) DONE");
                        int lineSelect = int.Parse(Console.ReadLine());
                        switch (lineSelect)
                        {
                            case (int)Lines.ToDo : 
                                ToDoLine.cardList.Add(card);
                                line.cardList.Remove(card);
                                ListBoard();
                                break;
                            case (int)Lines.InProgress : 
                                InProgressLine.cardList.Add(card);
                                line.cardList.Remove(card);
                                ListBoard();
                                break;
                            case (int)Lines.Done : 
                                DoneLine.cardList.Add(card);
                                line.cardList.Remove(card);
                                ListBoard();
                                break;
                            default :
                                Console.WriteLine("Hatalı Line seçimi yaptınız!");
                                break;
                        }

                        break;
                    }

                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                Console.WriteLine("* Yeniden denemek için : (2)");
                int secim = int.Parse(Console.ReadLine());
                switch (secim)
                {
                    case 1 : 
                        checkCardInList = true;
                        break;
                    case 2 :
                        Console.WriteLine("Lütfen kart başlığını yazınız:");
                        title = Console.ReadLine().Trim();
                        checkCardInList = CheckCardInList(title);
                        break;
                }
            }
    
            } while (!checkCardInList);
            
            Console.WriteLine();

            Index();
        }

        public bool CheckCardInList(string title)
        {
            bool isThere = false;

            foreach (Line line in boardLineList)
            {
                foreach (Card card in line.cardList)
                {
                    if(card.Title == title)
                    {
                        isThere = true;
                        break;
                    }
                }    
            }

            return isThere;
        }

 
    }
}