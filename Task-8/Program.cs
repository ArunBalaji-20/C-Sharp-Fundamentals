using System;
using System.Collections.Generic;

namespace GenericRepositoryDemo
{
    // IEntity Interface
    public interface IEntity
    {
        int Id { get; set; }
    }

    // IRepository Interface
    //T is a placeholder for any type (like Product), and we restrict it to be a class that implements IEntity
    public interface IRepository<T> where T : class, IEntity
    {
        void Add(T item);
        T Get(int id);
        IEnumerable<T> GetAll();
        void Update(int id, T updatedItem);
        void Delete(int id);
    }

    // InMemoryRepository Implementation 
    //concrete class
    public class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly Dictionary<int, T> _storage = new();
        private int _currentId = 1;

        public void Add(T item)
        {
            item.Id = _currentId++;
            _storage[item.Id] = item;
        }

        public T Get(int id)
        {
            _storage.TryGetValue(id, out var item);
            return item;
        }

        public IEnumerable<T> GetAll() => _storage.Values;

        public void Update(int id, T updatedItem)
        {
            if (_storage.ContainsKey(id))
            {
                updatedItem.Id = id;
                _storage[id] = updatedItem;
            }
        }

        public void Delete(int id) => _storage.Remove(id);
    }

    // Product Entity
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString() => $"ID: {Id}, Name: {Name}, Price: {Price}";
    }

    // Console UI
    class Program
    {
        static void Main()
        {
            IRepository<Product> productRepo = new InMemoryRepository<Product>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n1. Add Product\n2. Get Product by ID\n3. Get All Products\n4. Update Product\n5. Delete Product\n6. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter name: ");
                        var name = Console.ReadLine();
                        Console.Write("Enter price: ");
                        var price = double.Parse(Console.ReadLine());

                        productRepo.Add(new Product { Name = name, Price = price });
                        Console.WriteLine(" Product added.");
                        break;

                    case "2":
                        Console.Write("Enter ID: ");
                        var id = int.Parse(Console.ReadLine());
                        var product = productRepo.Get(id);

                        if (product != null)
                            Console.WriteLine(product);
                        else
                            Console.WriteLine(" Product not found.");
                        break;


                    case "3":
                        foreach (var p in productRepo.GetAll())
                            Console.WriteLine(p);
                        break;

                    case "4":
                        Console.Write("Enter ID to update: ");
                        var updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        var newName = Console.ReadLine();
                        Console.Write("Enter new price: ");
                        var newPrice = double.Parse(Console.ReadLine());

                        productRepo.Update(updateId, new Product { Name = newName, Price = newPrice });
                        Console.WriteLine(" Product updated.");
                        break;

                    case "5":
                        Console.Write("Enter ID to delete: ");
                        var deleteId = int.Parse(Console.ReadLine());
                        productRepo.Delete(deleteId);
                        Console.WriteLine(" Product deleted.");
                        break;

                    case "6":
                        running = false;
                        break;

                    default:
                        Console.WriteLine(" Invalid choice.");
                        break;
                }
            }
        }
    }
}
