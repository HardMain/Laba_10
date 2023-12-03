using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal static class Demonstration
    {
        static Person[] people = new Person[8];
        public static void Part1()
        {
            string[] strings = new string[8];
            strings[0] = "\tРандомное заполнение массива объектом Person"; people[0] = new Person();
            strings[1] = "\tРучное заполнение массива объектом Person"; people[1] = new Person();
            strings[2] = "\tРандомное заполнение массива объектом Pupil"; people[2] = new Pupil();
            strings[3] = "\tРучное заполнение массива объектом Pupil"; people[3] = new Pupil();
            strings[4] = "\tРандомное заполнение массива объектом Student"; people[4] = new Student();
            strings[5] = "\tРучное заполнение массива объектом Student"; people[5] = new Student();
            strings[6] = "\tРандомное заполнение массива объектом ExtramuralStudent"; people[6] = new ExtramuralStudent();
            strings[7] = "\tРучное заполнение массива объектом ExtramuralStudent"; people[7] = new ExtramuralStudent();

            Person[] people2 = new Person[8];
            people2[0] = new Person();
            people2[1] = new Person();
            people2[2] = new Pupil();
            people2[3] = new Pupil();
            people2[4] = new Student();
            people2[5] = new Student();
            people2[6] = new ExtramuralStudent();
            people2[7] = new ExtramuralStudent();

            ShowArray(people, people2, strings);
        }
        public static void ShowArray(Person[] people, Person[] people2, string[] strings)
        {
            Console.WriteLine("\t[ЧАСТЬ 1]\n\nВИРТУЛЬНЫЕ МЕТОДЫ\n");

            for (int i = 0; i < people.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(strings[i]);
                    people[i].Init();
                    Console.WriteLine();
                }
                else
                    people[i].RandomInit();
            }

            Console.WriteLine("----Заполненные объекты----\n");
            for (int i = 0; i < people.Length; i++)
            {
                Console.WriteLine(strings[i]);
                people[i].Show();
                Console.WriteLine();
            }

            // -----------------------------------------------------------------------------
            Console.WriteLine("\tНЕ ВИРТУЛЬНЫЕ МЕТОДЫ\n");

            for (int i = 0; i < people2.Length; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(strings[i]);
                    people2[i].NotVirtualInit();
                    Console.WriteLine();
                }
                else
                    people2[i].NotVirtualRandomInit();
            }

            Console.WriteLine("----Заполненные объекты----\n");
            for (int i = 0; i < people2.Length; i++)
            {
                Console.WriteLine(strings[i]);
                people2[i].NotVirtualShow();
                Console.WriteLine();
            }


        }
        public static void Part2()
        {
            Console.WriteLine("\t[ЧАСТЬ 2]\n\n----Заполненные объекты----\n");
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Show();
                Console.WriteLine();
            }

            Console.WriteLine("Первый запрос: вывести имена студентов указанного курса\n");
            Func<int, bool> condition = (course) => (course < 1 || course > 6);
            int course = CheckAndInput.InputIntNumberByCondition("Введите номер курса: ", "\nТакого номера не существует!\n", condition);
  
            bool wasFound = false;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] is Student other)
                {
                    if (other.Course == course)
                    {
                        Console.WriteLine($"ФИО студента с курсом - {course}: {other.Name}");
                        wasFound = true;
                    }
                }
            }
            if (!wasFound)
                Console.WriteLine($"\nСтудент с курсом - {course} не был найден!");

            Console.Write("\nВторой запрос: вывести номер класса школьника с определенным ФИО\n\nВведите ФИО: ");
            string? fullName = Console.ReadLine();

            wasFound = false;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] is Pupil other)
                {
                    if (other.Name == fullName)
                    {
                        Console.WriteLine($"Школьник {other.Name} в {other.Class} классе");
                        wasFound = true;
                    }
                }
            }
            if (!wasFound)
                Console.WriteLine($"\nШкольник с именем \"{fullName}\" не был найден!");

            Console.WriteLine("\nТретий запрос: вывести имена и курс заочников, которые не имеют работы\n");

            wasFound = false;
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i] is ExtramuralStudent other)
                {
                    if (!other.HaveJob)
                    {
                        Console.WriteLine($"Студент {other.Name} на {other.Course} курсе не имеет работы");
                        wasFound = true;
                    }
                }
            }
            if (!wasFound)
                Console.WriteLine($"\nВсе студенты имеют работу!");
        }
        public static void Part3()
        {
            Console.WriteLine("\t[ЧАСТЬ 3]\n\n----Заполненные объекты----\n");
            for (int i = 0; i < people.Length; i++)
            {
                people[i].Show();
                Console.WriteLine();
            }

            Console.WriteLine("----Отсортированные объекты по имени----\n");
            Array.Sort(people);
            foreach (var item in people)
            {
                item.Show();
                Console.WriteLine();
            }

            Console.WriteLine("----Отсортированные объекты по возрасту----\n");
            Array.Sort(people, new SortByAge());
            foreach (var item in people)
            {
                item.Show();
                Console.WriteLine();
            }

            Console.WriteLine("----Нахождение индекса элемента по заданному возрасту при помощи бинарного поиска----\n");
            Func<int, bool> condition = (age) => (0 > age || 120 < age);
            int age = CheckAndInput.InputIntNumberByCondition("Введите возраст: ", "\nВозраст должен быть в диапазоне 0 - 120!\n", condition);
            Person personForSearch = new Person() { Age = age };

            int index = Array.BinarySearch(people, personForSearch, new BinarySearchByAge());

            if (index < 0)
                Console.WriteLine($"Человек с возрастом равным {age} не был найден!\n");
            else
                Console.WriteLine($"Индекс элемента с возрастом равным {age} - {index}\n");

            Console.WriteLine("----Массив типа IInit----\n");
            IInit[] inits = new IInit[people.Length + 2];
            inits[0] = new Person();
            inits[1] = new Person();
            inits[2] = new Pupil();
            inits[3] = new Pupil();
            inits[4] = new Student();
            inits[5] = new Student();
            inits[6] = new ExtramuralStudent();
            inits[7] = new ExtramuralStudent();
            inits[8] = new ClassToImplementInit();
            inits[9] = new ClassToImplementInit();

            for (int i = 0; i < inits.Length; i++)
            {
                if (i % 2 != 0)
                {
                    inits[i].Init();
                    Console.WriteLine();
                }
                else
                    inits[i].RandomInit();
            }

            Console.WriteLine("----Клонирование объектов----\n\nЗадайте объект:\n");

            Person original = new Person();
            original.Init();

            Person clon = new Person();
            original.PropPerson = clon;

            Person copy = (Person)original.Clone();

            Console.WriteLine("\nОригинальный объект");
            original.Show();
            Console.Write("Ссылочный тип:\n");
            original.PropPerson.Show();

            Console.WriteLine("\nКлонированный объект");
            copy.Show();
            Console.Write("Ссылочный тип:\n");
            copy.PropPerson.Show();

            Console.WriteLine("\nИзменение полей оригинального объекта");
            original.Age = 100;
            original.PropPerson.RandomInit();
            original.Show();
            Console.Write("Ссылочный тип:\n");
            original.PropPerson.Show();

            Console.WriteLine("\nКлонированный объект после изменения оригинального");
            copy.Show();
            Console.Write("Ссылочный тип:\n");
            copy.PropPerson.Show();

            // ------------------------

            Console.WriteLine("\n\n----Поверхностное копирование----");
            Person copy2 = (Person)original.ShallowCopy();

            Console.WriteLine("\nОригинальный объект");
            original.Show();
            Console.Write("Ссылочный тип: ");
            original.PropPerson.Show();

            Console.WriteLine("\nПоверхностноскопированный объект");
            copy2.Show();
            Console.Write("Ссылочный тип: ");
            copy2.PropPerson.Show();

            Console.WriteLine("\nИзменение полей оригинального объекта");
            original.Age = 80;
            original.PropPerson.RandomInit();
            original.Show();
            Console.Write("Ссылочный тип: ");
            original.PropPerson.Show();

            Console.WriteLine("\nПоверхностноскопированный объект после изменения оригинального");
            copy2.Show();
            Console.Write("Ссылочный тип: ");
            copy2.PropPerson.Show();
        }
    }
}
