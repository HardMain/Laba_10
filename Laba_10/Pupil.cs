using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal class Pupil : Person
    {
        protected int _class;

        public Pupil() 
        {
            _class = 0;
        }
        public override int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 19 || value < 6)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 6 - 19!\n");
                    Age = CheckAndInput.InputIntNumber("Введите возраст: ");
                    return;
                }
                age = value;
            }
        }
        public int NotVirtualAge
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 19 || value < 6)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 6 - 19!\n");
                    NotVirtualAge = CheckAndInput.InputIntNumber("Введите возраст: ");
                    return;
                }
                age = value;
            }
        }
        public int Class
        {
            get
            {
                return _class;
            }
            set
            {
                if (value > 11 || value < 1)
                {
                    Console.WriteLine("\nНомер класса должен быть в диапазоне 1 - 11!\n");
                    Class = CheckAndInput.InputIntNumber("Введите класс: ");
                    return;
                }
                _class = value;
            }
        }
        public override void Init()
        {
            base.Init();

            Class = CheckAndInput.InputIntNumber("Введите номер класса: ");
        }
        public void NotVirtualInit()
        {
            base.Init();

            Class = CheckAndInput.InputIntNumber("Введите номер класса: ");
        }
        public override void RandomInit()
        {
            Age = random.Next(6, 19);
            name = fullNameArray[random.Next(fullNameArray.Length)];
            Class = random.Next(1, 12);
        }
        public void NotVirtualRandomInit()
        {
            NotVirtualAge = random.Next(6, 19);
            name = fullNameArray[random.Next(fullNameArray.Length)];
            Class = random.Next(1, 12);
        }
        public override void Show()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКласс: {_class}");
        }
        public void NotVirtualShow()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКласс: {_class}");
        }
        public override bool Equals(object? obj)
        {
            if (obj is Pupil other)
            {
                if (age == other.age && name == other.name && _class == other._class)
                    return true;
            }

            return false;
        }
    }
}
