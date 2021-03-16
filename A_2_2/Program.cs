using System;
using System.Collections.Generic;
namespace A_2_2
{
    public interface ISound
    {
        string Sound();
    }
    public abstract class Animal : ISound
    {
        // Fields
        private string name;
        private int age;
        private string gender;
 
        // Constructor
        public Animal(string name, int age, string gender)
        {
            this.name = name;
            this.age = age;
            this.gender = gender;
        }
 
        // Properties
        public string Name 
        {
            get { return this.name; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Animal name cannot be null!");
                else
                    this.name = value;
            }
        }
 
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Animal age cannot be negative or zero!");
                else
                    this.age = value;
            }
        }
 
        public string Gender 
        {
            get { return this.gender; }
            set
            {
                if (value == null || (value != "male" && value != "female"))
                    throw new ArgumentNullException("Animal gender cannot be null or different from male or female!");
                else
                    this.gender = value;
            }
        }
 
        // Methods
        public abstract string Sound();
 
    }
    public class Cat : Animal
    {
        // Fields
        private string catBreed;
 
        // Constructor
        public Cat(string name, int age, string gender, string catBreed)
            : base(name, age, gender)
        {
            this.catBreed = catBreed;
        }
 
        // Properties
        public string CatBreed 
        {
            get { return this.catBreed; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Cat breed cannot be null!");
                else
                    this.catBreed = value;
            }
        }
 
        //Methods
        public override string Sound()
        {
            return "Cat "+this.Name+" says: maiowwww";
        }
        public new string ToString()
        {
            return "Name: "+Name+"  Age: "+Age+"  Sound: "+Sound();
        }
    }
    public class Dog : Animal
    {
        // Fields
        private string dogBreed;
 
        // Constructor
        public Dog(string name, int age, string gender, string dogBreed)
            : base(name, age, gender)
        {
            this.dogBreed = dogBreed;
        }
 
        // Properties
        public string DogBreed 
        {
            get { return this.dogBreed; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Dog breed cannot be null!");
                else
                    this.dogBreed = value;
            }
        }
 
        //Methods
        public override string Sound()
        {
            return "Dog "+this.Name+" says: bow-bowwww";
        }
        public new string ToString()
        {
            return "Name: "+Name+"  Age: "+Age+"  Sound: "+Sound();
        }
    }
    public class Frog : Animal
    {
        // Fields
        private string frogBreed;
 
        // Constructor
        public Frog(string name, int age, string gender, string frogBreed)
            : base(name, age, gender)
        {
            this.frogBreed = frogBreed;
        }
 
        // Properties
        public string FrogBreed 
        {
            get { return this.frogBreed; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Frog breed cannot be null!");
                else
                    this.frogBreed = value;
            }
        }
 
        // Methods
        public override string Sound()
        {
            return "Frog "+this.Name+" says: ribbitttt";
        }
        public new string ToString()
        {
            return "Name: "+Name+"  Age: "+Age+"  Sound: "+Sound();
        }
    }
    public class Kitten : Cat
    {
        // Constructor
        public Kitten(string name, int age, string gender, string breed)
            : base(name, age, "female", breed){}
 
        // Methods
        public override string Sound()
        {
            return "Kitten "+this.Name+" says: maiowwww";
        }
        public new string ToString()
        {
            return "Name: "+Name+"  Age: "+Age+"  Sound: "+Sound();
        }
    }
    public class Tomcat : Cat
    {
        // Constructor
        public Tomcat(string name, int age, string gender, string breed)
            : base(name, age, "male", breed){}
 
        // Methods
        public override string Sound()
        {
            return "Tomcat "+this.Name+" says: maiowwww";
        }
        public new string ToString()
        {
            return "Name: "+Name+"  Age: "+Age+"  Sound: "+Sound();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Array of dogs
            Dog[] dogs = new Dog[] 
            {
                new Dog("Damon", 6, "male", "German Shepherd"),
                new Dog("Lassie", 4, "female", "Collie")
            };
 
            // Array of cats
            Cat[] cats = new Cat[]
            {
                new Cat("Tom", 2, "male", "Balinese"),
                new Cat("Iva", 1, "female", "Cymric"),
            };
 
            Tomcat tom = new Tomcat("Kiara", 9, "male", "Bombay");
            Kitten kitten = new Kitten("Sisi", 1, "female", "Cymric");
 
            // Array of frogs
            Frog[] frogs = new Frog[]
            {
                new Frog("Maria", 1, "female", "Arizona Toad"),
                new Frog("Michel", 3, "male", "Texas Toad"),
            };
            Console.WriteLine("******Dogs******");
            foreach(var dog in dogs)
            {
                Console.WriteLine(dog.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("******Cats******");
            foreach(var cat in cats)
            {
                Console.WriteLine(cat.ToString());
            }
            Console.WriteLine(tom.ToString());
            Console.WriteLine(kitten.ToString());
            Console.WriteLine();
            Console.WriteLine("******Frogs******");
            foreach(var frog in frogs)
            {
                Console.WriteLine(frog.ToString());
            }
            List<Animal> animalList=new List<Animal>()
            {
                    new Dog("Damon", 6, "male", "German Shepherd"),
                    new Frog("Maria", 1, "female", "Arizona Toad"),
                    new Cat("Tom", 2, "male", "Balinese"),
            };
            Console.WriteLine("******Animal List******");
             foreach(var animal in animalList)
            {
                Console.WriteLine("{0}= {1}",animal.GetType().Name,animal.Sound());
            }
        }
    }
}
