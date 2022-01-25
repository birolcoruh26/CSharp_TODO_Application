using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Board
    {
        Dictionary<int, string> Persons = new Dictionary<int, string>();
        List<Card> TODO = new List<Card>();
        List<Card> INPROGRESS = new List<Card>();
        List<Card> DONE = new List<Card>();
        List<Card> FoundCard = new List<Card>();

        public Board()
        {
            Persons.Add(0, "Birol Coruh");
            Persons.Add(1, "Mert Çelik");
            Persons.Add(2, "Kenan Saliha");
            Persons.Add(3, "Ali Derman");
            Persons.Add(4, "Serhan Çetin");
            TODO.Add(new Card("Cleaner", "Clean The Technical Office", "Mert Çelik", Card.size.l));
            TODO.Add(new Card("Engineer", "supervision of Reinforcements", "Birol Coruh", Card.size.xl));
            INPROGRESS.Add(new Card("General Manager", "Review the Construction Site", "Kenan Saliha", Card.size.xxl));
            INPROGRESS.Add(new Card("Engineer", "Sign the Bills of Concrete Producing Firm ", "Ali Derman", Card.size.m));
            DONE.Add(new Card("Chef", "Preparing the Lunch ", "Serhan Çetin", Card.size.s));

        }
        public void boardListing()
        {
            Console.WriteLine("ToDO \n *******************");
            for (int i = 0; i < TODO.Count; i++)
            {
                Console.WriteLine("Başlık : {0}", TODO[i].Title);
                Console.WriteLine("İçerik : {0}", TODO[i].Content);
                Console.WriteLine("Atanan Kişi : {0}", TODO[i].Person);
                Console.WriteLine("Büyüklük : {0}", TODO[i].Sizes);
                Console.WriteLine("\n");
            }
            Console.WriteLine("In Progress Line \n *******************");
            for (int i = 0; i < INPROGRESS.Count; i++)
            {
                Console.WriteLine("Başlık : {0}", INPROGRESS[i].Title);
                Console.WriteLine("İçerik : {0}", INPROGRESS[i].Content);
                Console.WriteLine("Atanan Kişi : {0}", INPROGRESS[i].Person);
                Console.WriteLine("Büyüklük : {0}", INPROGRESS[i].Sizes);
                Console.WriteLine("\n");
            }
            Console.WriteLine("Done \n *******************");
            for (int i = 0; i < DONE.Count; i++)
            {
                Console.WriteLine("Başlık : {0}", DONE[i].Title);
                Console.WriteLine("İçerik : {0}", DONE[i].Content);
                Console.WriteLine("Atanan Kişi : {0}", DONE[i].Person);
                Console.WriteLine("Büyüklük : {0}", DONE[i].Sizes);
                Console.WriteLine("\n");
            }




        }
        public void cardAdding()
        {

            string baslik;
            string icerik;
            string ad;
            int buyukluk;
            int kisi;

            Console.WriteLine("Baslik giriniz                                   : ");
            baslik = Console.ReadLine();
            Console.WriteLine("Icerik giriniz                                   : ");
            icerik = Console.ReadLine();
            Console.WriteLine("Buyukluk seciniz -> XS(1),S(2),M(3),L(4),XL(5)   :");
            buyukluk = int.Parse(Console.ReadLine());
            Console.WriteLine("Kisi adını giriniz giriniz                             : ");
            ad = Console.ReadLine();
            Console.WriteLine("Kisi ID'sini giriniz                             : ");
            kisi = int.Parse(Console.ReadLine());

            if (!Persons.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5)
            {
                Persons.Add(kisi, ad);
                TODO.Add(new Card(baslik, icerik, Persons[kisi], (Card.size)buyukluk));
            }
            else
            {
                Console.WriteLine("Hatali giris yaptiniz!");
            }

        }
        public void cardRemove()
        {
            bool control = false;
            string kartBaslıgı;
            Console.WriteLine(" Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor. \n Lütfen kart başlığını yazınız:     ");
            kartBaslıgı = Console.ReadLine();
            foreach (var i in TODO.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    TODO.Remove(i);
                    Console.WriteLine(" TODO'daki Kart silindi.");
                    control = true;
                }
            foreach (var i in INPROGRESS.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    INPROGRESS.Remove(i);
                    Console.WriteLine(" INPROGRESS'deki Kart silindi.");
                    control = true;
                }
            foreach (var i in DONE.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    DONE.Remove(i);
                    Console.WriteLine(" DONE'daki Kart silindi.");
                    control = true;
                }
            if (control == false)
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Silmeyi sonlandırmak için : (1) \n Yeniden denemek için : (2)");
                int cevap = Convert.ToInt32(Console.ReadLine());
                if (cevap == 2)
                {
                    cardRemove();
                }
                else
                {
                    Console.WriteLine("silme islemi sonlandi.");
                }
            }
        }
        public void cardMove()
        {
            bool control = false;
            string kartBaslıgı;
            Console.WriteLine(" Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor. \n Lütfen kart başlığını yazınız:     ");
            kartBaslıgı = Console.ReadLine();
            foreach (var i in TODO.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    control = true;
                    FoundCard.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                }
            foreach (var i in INPROGRESS.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    control = true;
                    FoundCard.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                }
            foreach (var i in DONE.ToArray())
                if (i.Title == kartBaslıgı)
                {
                    control = true;
                    FoundCard.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                }


            if (control == true)
            {
                Console.WriteLine("Bulunan Kart Bilgileri:");
                Console.WriteLine("*******************************************");
                foreach (var i in FoundCard.ToArray())
                {
                    Console.WriteLine("Baslik       :   {0}", i.Title);
                    Console.WriteLine("Icerik       :   {0}", i.Content);
                    Console.WriteLine("Atanan Kisi  :   {0}", i.Person);
                    Console.WriteLine("Buyukluk     :   {0}", i.Sizes);
                }
                Console.WriteLine("Lutfen tasimak istediginiz Line'i secin:");
                Console.WriteLine("(1) TODO");
                Console.WriteLine("(2) IN PROGRESS");
                Console.WriteLine("(3) DONE");
                int line = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Line         :   {0}", line);
                switch (line)
                {
                    case 1:
                        foreach (var i in FoundCard.ToArray())
                        {
                            TODO.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                            FoundCard.Remove(i);
                        }
                        break;
                    case 2:
                        foreach (var i in FoundCard.ToArray())
                        {
                            INPROGRESS.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                            FoundCard.Remove(i);
                        }
                        break;
                    case 3:
                        foreach (var i in FoundCard.ToArray())
                        {
                            DONE.Add(new Card(i.Title, i.Content, i.Person, i.Sizes));
                            FoundCard.Remove(i);
                        }
                        break;
                    default:
                        Console.WriteLine("Hatali bir secim yaptiniz!");
                        break;


                }
            }
            else
            {
                Console.WriteLine(" Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
                Console.WriteLine("Taşımayı sonlandırmak için : (1) \n Yeniden denemek için : (2)");
                int cevap = Convert.ToInt32(Console.ReadLine());
                if (cevap == 2)
                {
                    cardMove();
                }
                else
                {
                    Console.WriteLine("Tasıma islemi sonlandi.");
                }
            }
            }
        }
    }

   


