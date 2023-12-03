using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_10
{
    internal class ExtramuralStudent : Student
    {
        bool haveJob;
        public ExtramuralStudent()
        {
            formEducation = "Заочная";
            haveJob = false;
        }
        public bool HaveJob
        {
            get
            {
                return haveJob;
            }
            set
            {
                haveJob = value;
            }
        }
        public override void Init()
        {
            base.Init();

            HaveJob = CheckAndInput.InputIntNumber("\nВведите 0 - отсутствие работы\nЧисло отличное от нуля - наличие работы\n-> ") != 0;
        }
        public void NotVirtualInit()
        {
            base.Init();

            HaveJob = CheckAndInput.InputIntNumber("\nВведите 0 - отсутствие работы\nЧисло отличное от нуля - наличие работы\n-> ") != 0;
        }
        public override void RandomInit()
        {
            base.RandomInit();

            haveJob = random.Next(0, 2) == 1;
        }
        public void NotVirtualRandomInit()
        {
            base.RandomInit();

            haveJob = random.Next(0, 2) == 1;
        }
        public override void Show()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКурс: {course}\nНаличие работы: {haveJob}");
        }
        public void NotVirtualShow()
        {
            Console.WriteLine($"ФИО: {name}\nВозраст: {age}\nКурс: {course}\nНаличие работы: {haveJob}");
        }
        public override bool Equals(object? obj)
        {
            if (obj is ExtramuralStudent other)
            {
                if (age == other.age && name == other.name && course == other.course && haveJob == other.haveJob)
                    return true;
            }

            return false;
        }
    }
}
