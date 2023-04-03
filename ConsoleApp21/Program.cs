using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public interface IItem
    {
        int GetCost();
        void Print();
    }

    public class Leaf : IItem
    {
        private string Name;
        private int Cost;
        public Leaf(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
        public void Print()
        {
            Console.WriteLine(Name);
        }
        public int GetCost()
        {
            return Cost;
        }
    }

    public class Composite : IItem
    {
        private string Name;
        private int Cost;
        private List<IItem> Items = new List<IItem>();

        public Composite(string name)
        {
            Name = name;
        }

        public void Add(IItem Leaf)
        {
            Items.Add(Leaf);
        }

        public int GetCost()
        {
            int total = 0;
            foreach (var item in Items)
                total += item.GetCost();
            return total;
        }

        public void Print()
        {
            Console.WriteLine(Name);
            foreach (var item in Items)
                item.Print();
        }
    }
    public class Client
    {
        public static Composite Build()
        {
            var root = new Composite("Office");
            var reception = new Composite("Reception");
            reception.Add(new Leaf("Should be done in warm colors", 150));
            var table = new Composite("Coffee table");
            table.Add(new Leaf("10-20 magazines like \"computer world", 50));
            reception.Add(table);
            reception.Add(new Leaf("Soft sofa", 250));
            reception.Add(new Leaf("Secretary's desk", 200));
            var computer = new Composite("Computer");
            computer.Add(new Leaf("It is important to have a large hard drive", 500));
            computer.Add(new Leaf("office toolkit", 350));
            reception.Add(computer);
            reception.Add(new Leaf("Cooler with warm and cold water", 100));
            root.Add(reception);
            return root;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var room = Client.Build();
            room.Print();
            Console.WriteLine();
            Console.WriteLine($"Total cost: {room.GetCost()} $");
        }
    }
}