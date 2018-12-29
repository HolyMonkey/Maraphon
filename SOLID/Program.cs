using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * S - SRP
     * O - OCP 
     * L - LSP
     * I - ISP
     * D - DIP
     */ 
    class Program
    {
        static void Main(string[] args)
        {
            UserRepository repository = new UserRepository();
            repository.Add(new User("Test", 12));
            repository.Add(new User("Test2", 14));

            Console.WriteLine("Пользователи:");

            foreach (var user in repository.GetAll())
            {
                Console.WriteLine(user.Name);
            }
        }
    }

    class Player
    {
        private IInput _input;
        private int _x, _y;

        public Player(IInput input)
        {
            _input = input;
        }

        private void Update()
        {
            _x += _input.deltaX; 
            _y += _input.deltaY; 
        }
    }

    class UserRepository
    {
        private List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);

            PersistantHelper.SaveList(_users);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }
    }

    class User
    {
        public string Name;
        public int Age;

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    static class PersistantHelper
    {
        public static void SaveList(List<User> user)
        {
            Console.WriteLine("Save List");
        }
    }
}
