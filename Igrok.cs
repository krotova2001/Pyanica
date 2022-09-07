using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Pyanica
{
    internal class Igrok
    {
        public string Name { get; set; } // автоматическое свойство - имя
        Queue<Karta> Ruki; // карты на руках
        public Igrok (string name) // конструктор с именем
        {
            Name = name;
            Ruki = new Queue<Karta> ();
        }
        public void Vzyat (Karta K) // взять карту на руки
        {
            Ruki.Enqueue(K);
        }
        public Karta Hod() // сделать ход
        {
            return Ruki.Dequeue();
        }
        public void Show() // сколько карт на руках
        {
            Console.WriteLine($"{Name} - {Ruki.Count} карт");
        }
        public bool Is_alive() // проверить не вышел ли из игры
        {
            if (Ruki.Count>0)
                return true;
            else
                return false;
        }
    }
}
