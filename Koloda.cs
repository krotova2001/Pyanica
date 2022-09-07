using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/// <summary>
/// Класс колоды, содержит в себе карты (класс - Карта)
/// </summary>

namespace Pyanica
{
    internal class Koloda
    {
        Stack<Karta> K;
        public Koloda() // конструктор по умолчанию - создание колоды на 36 карт
        {
            K = new Stack<Karta>(36);
            string[] Masti = new string[] { "Черви", "Крести", "Буби", "Пики" }; // возможные масти
            string[] Znaki = new string[] { "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; // возможные значения
            for (int i=0; i<9;i++) // во внешнем цикле присваиваем значения
            {
                for (int j = 0; j<4;j++) // во внутреннем  - масти
                {
                    Karta A = new Karta(Znaki[i], Masti[j], i); // создается новая карта
                    K.Push(A); // Запихивается в колоду
                }
            }
        }
        public void Show() // служебная функция - посмотреть 
        {
            int i=0;
            foreach (Karta A in K)
            {
                Console.Write($"{i+1} - {A.Digit} - {A.Mast} - {A.DostoInstvo}");
                Console.WriteLine();
                i++;
            }
        }

        public void Shuffle() // перетусовать колоду
        {
            Random random = new Random(); // создадим объект класса Random
            List<Karta> list = K.ToList(); // преобразуем колоду из стэка в список
            for (int i = 0; i < list.Count; i++) // перетусуем список
            {
                int t = random.Next(list.Count); //соучайное число от 0 до размера списка
                var temp = list[t]; // и по калссике - обмен элемента со случайным элементом через временную переменную
                list[t] = list[i];
                list[i] = temp;
            }
            K.Clear(); // очистим стэк
            for (int i = 0; i < list.Count; i++)
            {
                K.Push(list[i]); // и заново занесем туда перетусованную колоду
            }
        }

        public bool Is_Empty() // проверить есть ли еще карты в колоде
        {
            if (K.Count == 0)
                return true;
            else
                return false;
        }

        public Karta Sdat() // сдать карту
        {
            return K.Pop();
        }
    }
}
