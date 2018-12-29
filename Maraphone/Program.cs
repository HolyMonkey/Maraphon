using System;
using System.Collections.Generic;

namespace Maraphone
{
    class Program
    {
        static void Main(string[] args)
        {
       
        }
    }

    class HumanEntity
    {
        public string Name { get; private set; } //Max 255
        public uint Age { get; private set; } //Не должно быть отрицательное

        //Должен быть валидный email (не факт что рабочий) 
        public Email Email { get; private set; }

        private string _email;
    }

    class Employer : HumanEntity
    {
        public float CostPerHour { get; private set; } //Не может быть отрицательным
    }

    class Customer : HumanEntity
    {
        public List<string> Accesses { get; private set; }
    }

    class Project
    {
        public Project(int fond, Email email)
        {
            Fond = fond;
            Email = email;
        }

        public int Fond { get; private set; }
        public Email Email { get; private set; }
    }

    public class Email
    {
        private string _value;

        public Email(string value)
        {
            if (value.Contains("@") == false)
                throw new ArgumentException("value must be email string with @");

            _value = value;
        }

        public string Value => _value;
    }
}
