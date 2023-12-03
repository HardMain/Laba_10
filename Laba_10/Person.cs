using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal class Person : IInit, IComparable<Person>, ICloneable
    {
        public static Random random = new Random();

        Person? person;
        protected string? name;
        protected int age;

        protected string[] fullNameArray= {
            "Иванов Александр Петрович",
            "Петрова Екатерина Сергеевна",
            "Смирнов Иван Владимирович",
            "Кузнецова Анна Дмитриевна",
            "Михайлов Дмитрий Александрович",
            "Васнецова Ольга Николаевна",
            "Алексеев Николай Васильевич",
            "Сергеева Светлана Анатольевна",
            "Никитин Михаил Валентинович",
            "Тимофеева Татьяна Сергеевна",
            "Сидоров Сергей Игоревич",
            "Медведева Мария Александровна",
            "Попов Андрей Викторович",
            "Ефимова Елена Владимировна",
            "Павлов Павел Алексеевич"
        };

        public Person()
        {
            name = null;
            age = 0;
            person = null;
        }
        public string? Name { get { return name; } }
        public virtual int Age 
        { 
            get 
            { 
                return age;
            } 
            set
            { 
                if (value > 120 || value < 0)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 0 - 120!\n");
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
                if (value > 120 || value < 0)
                {
                    Console.WriteLine("\nВозраст должен быть в диапазоне 0 - 120!\n");
                    NotVirtualAge = CheckAndInput.InputIntNumber("Введите возраст: ");
                    return;
                }
                age = value;
            }
        }
        public Person PropPerson { get { return person; } set { person = value; } }

        public virtual void Init()
        {
            Console.Write("Введите ФИО: ");
            name = Console.ReadLine();
            Age = CheckAndInput.InputIntNumber("Введите возраст: ");
        }
        public void NotVirtualInit()
        {
            Console.Write("Введите ФИО: ");
            name = Console.ReadLine();

            NotVirtualAge = CheckAndInput.InputIntNumber("Введите Возраст: ");
        }
        public virtual void RandomInit()
        {
            name = fullNameArray[random.Next(fullNameArray.Length)];
            Age = random.Next(0, 121);
        }
        public void NotVirtualRandomInit()
        {
            name = fullNameArray[random.Next(fullNameArray.Length)];
            NotVirtualAge = random.Next(0, 121);
        }
        public virtual void Show()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}");
        }
        public void NotVirtualShow()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}");
        }
        public override bool Equals(object? obj)
        {
            if (obj is Person other)
            {
                if (age == other.age && name == other.name)
                    return true;
            }

            return false;
        }

        public int CompareTo(Person obj)
        {
            if (string.Compare(Name, obj.Name) > 0)
                return 1;
            if (string.Compare(Name, obj.Name) < 0)
                return -1;
            return 0;
        }
        public object Clone()
        {
            Person clonedPerson = new Person();
            clonedPerson.person = new Person();

            clonedPerson.age = age;
            clonedPerson.name = name;
            clonedPerson.person.age = person.age;
            clonedPerson.person.name = person.name;

            return clonedPerson;
        }
        public object ShallowCopy()
        {
            return MemberwiseClone();
        }
    }
}
