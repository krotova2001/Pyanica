using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Так как тип данных заранее известен, и он один единственный (карта) - будем использовать
//шаблонные классы

namespace Pyanica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Koloda koloda = new Koloda(); // берем новую колоду
            koloda.Shuffle();
            Igrok Vasya = new Igrok("Вася"); // создаем двух игроков
            Igrok Tolya = new Igrok("Толя");

            //раздадим карты
            while (!koloda.Is_Empty()) // пока колода не опустеет
            {
                Vasya.Vzyat(koloda.Sdat()); // Вася берет карту
                Tolya.Vzyat(koloda.Sdat()); // Толя берет карту
            }
            //представимся
            Vasya.Show();
            Tolya.Show();
            Console.WriteLine("РЫба - карась, игра началась");
            Console.WriteLine();
            Console.WriteLine();
           
            do
            {
                Tolya.Show(); Console.WriteLine("Толя ходит");
                var temp1 = Tolya.Hod(); // Толя положил карту на стол
                temp1.Show();
                Vasya.Show(); Console.WriteLine("Вася ходит");
                var temp2 = Vasya.Hod(); // Вася походил
                temp2.Show();
                Console.WriteLine();
                if (temp1 > temp2) // если Толина карта больше, то обе карты забирает Толя
                {
                    Console.WriteLine("Толя берет");
                    Tolya.Vzyat(temp1);
                    Tolya.Vzyat(temp2);
                }
                if (temp2 > temp1) // Либо Вася побеждает в это ходе
                {
                    Console.WriteLine("Вася берет");
                    Vasya.Vzyat(temp1);
                    Vasya.Vzyat(temp2);
                }
                
                if (temp1 == temp2)// если достоинство карт одинаковое - пропускаем
                {
                    Console.WriteLine("Карты равны");
                    continue;
                }
            }
            while (Vasya.Is_alive()||Tolya.Is_alive()); // пока хоть кто-то не выйграет, делаем ходы)
            
        }
    }
}
