using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal class Student : Person
    {
        protected int course;
        protected string? formEducation;

        public Student()
        {
            course = 0;
            formEducation = null;
        }
        public override int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value > 120 || value < 17)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 17 - 120!\n");
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
                if (value > 120 || value < 17)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 17 - 120!\n");
                    NotVirtualAge = CheckAndInput.InputIntNumber("Введите возраст: ");
                    return;
                }
                age = value;
            }
        }
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if (value > 6 || value < 1)
                {
                    Console.WriteLine("\nНомер курса должен быть в диапазоне 1 - 6!\n");
                    Course = CheckAndInput.InputIntNumber("Введите номер курса: ");
                    return;
                }
                course = value;
            }
        }
        public override void Init()
        {
            base.Init();

            Course = CheckAndInput.InputIntNumber("Введите номер курса: ");
        }
        public void NotVirtualInit()
        {
            base.Init();

            Course = CheckAndInput.InputIntNumber("Введите номер класса: ");
        }
        public override void RandomInit()
        {
            Age = random.Next(17, 121);
            name = fullNameArray[random.Next(fullNameArray.Length)];
            Course = random.Next(1, 7);
        }
        public void NotVirtualRandomInit()
        {
            NotVirtualAge = random.Next(17, 121);
            name = fullNameArray[random.Next(fullNameArray.Length)];
            Course = random.Next(1, 7);
        }
        public override void Show()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКурс: {course}");
        }
        public void NotVirtualShow()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКурс: {course}");
        }
        public override bool Equals(object? obj)
        {
            if (obj is Student other)
            {
                if (age == other.age && name == other.name && course == other.course)
                    return true;
            }

            return false;
        }
    }
}