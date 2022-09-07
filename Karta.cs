using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//класс одной карты

/// <summary>
/// карта содежит в себе только достоитнство и масть
/// в принципе, масть для этой игры не имеет значения, но оставим ее для натуральности
/// </summary>
namespace Pyanica
{
    class Karta
    {
        string digit; // значение карты (туз, король..)
        string mast; // масть
        int dostoinstvo; // это что-то типа очка, по которому можн сравнивать карты
        public Karta(string d, string m, int ds) // конструктор с установка значений карты
        {
            digit = d;
            mast = m;
            dostoinstvo = ds;
        }
        public string Digit // вернуть значение
        { 
            get { return digit; } 
        }
        public string Mast //вернуть масть
        { 
            get { return mast; } 
        }
        public int DostoInstvo // вернуть достоинство
        {
            get { return dostoinstvo; }
        }
        public void Show() //показать карту
        {
            Console.WriteLine($"{Digit} {Mast}");
        }
        // для того, чтобы сравнивать карты между собой - удобно будет перегрузить операторы сравнения и ==
        public static bool operator > (Karta A, Karta B)
        {
            if (A.Digit == "6" && B.Digit == "A") // шестерка бьёт туза
                return true;
            else
                return A.DostoInstvo > B.DostoInstvo; // во всех остальных случаях сравниваем по достоинству
        }
        public static bool operator < (Karta A, Karta B)
        {
            if (A.Digit == "6" && B.Digit == "A") // шестерка бьёт туза
                return false;
            else
                return A.DostoInstvo < B.DostoInstvo; // во всех остальных случаях сравниваем по достоинству
        }
        // перегрузки оператора == и !=
        public static bool operator ==(Karta A, Karta B)
        {
            return (A.DostoInstvo == B.DostoInstvo);
        }
        public static bool operator !=(Karta A, Karta B)
        {
            return (A.DostoInstvo != B.DostoInstvo);
        }

        //необходимые перегрузки для перегрузки ==
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }


}
