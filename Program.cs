using System.IO.Pipes;

namespace Algorithm_12_1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            users.Add(new User("Ivanko", "Иван", true));
            users.Add(new User("Bianka", "Татьяна", false));
            users.Add(new User("Kzen", "Ксения", true));
            Console.Write("Введите логин: ");
            string Name = "";
            bool NameCheck = false;
            do
            {
                try
                {
                    Name = Console.ReadLine().Trim();
                    if (Name.Length == 0) throw new MyException("Поле Login пустое!");
                    else NameCheck = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Write("Введите логин:");
                }
            } while (!NameCheck);
            bool PersonCheck = false;
            foreach (var person in users)
            {
                if (person.Login == Name)
                {
                    Console.WriteLine(person.Name +", с возвращением!");
                    PersonCheck = true;
                    if (!person.IsPremium) ShowAds();
                    break;
                }
            }
            if (!PersonCheck) Console.WriteLine("Пользователь с таким логином не найден!");
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}