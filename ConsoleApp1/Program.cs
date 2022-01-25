using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("  Lütfen yapmak istediğiniz işlemi seçiniz \n*******************************************\n(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak");
            Board board1 = new Board();
            
            while (true){ int input = Convert.ToInt32(Console.ReadLine());

            switch (input)
            {
                case 1:
                    board1.boardListing();
                    break;
                case 2:
                    board1.cardAdding();
                    break;
                    case 3:
                        board1.cardRemove();
                        break;
                    case 4:
                        board1.cardMove();
                        break;
                        default:
                        Console.WriteLine("hatalı giriş yaptınız. 1-4 arası bir sayı giriniz");
                        break;
            }
            }
            Console.ReadLine();
        }
    }
}
