using System;
using System.Collections.Generic;

namespace Animals
{
    class Animal
    {
        public string Name;

        public Animal()
        { Name = "Animal"; }

        virtual public void say()
        { Console.WriteLine(""); }

        public override string ToString()
        {
            return "This is an animal";
        }
    }
    class Cat : Animal
    {
        public Cat() : base()
        { }

        public override void say()
        {
            base.say();
            Console.WriteLine("Meow");
        }
    }
}