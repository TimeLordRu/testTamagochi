using System;

class Tamagotchi
{
    private string name;
    private int health;
    private int hunger;
    private int fatigue;
    private int happiness;

    public Tamagotchi(string petName)
    {
        name = petName;
        health = 10;
        hunger = 0;
        fatigue = 0;
        happiness = 5;
    }

    public void Feed()
    {
        hunger--;
        if (hunger < 0)
        {
            health--;
        }
    }

    public void Play()
    {
        fatigue++;
        hunger++;
        if (fatigue > 10)
        {
            health--;
        }
    }

    public void Sleep()
    {
        fatigue = 0;
        health++;
        hunger++;
    }

    public void Treat()
    {
        health++;
    }

    public int GetHealth()
    {
        return health;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Имя: {name}");
        Console.WriteLine($"Здоровье: {health}");
        Console.WriteLine($"Голод: {hunger}");
        Console.WriteLine($"Усталость: {fatigue}");
        Console.WriteLine($"Счастье: {happiness}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите имя вашего питомца: ");
        string petName = Console.ReadLine();

        Tamagotchi pet = new Tamagotchi(petName);

        bool quit = false;

        while (!quit)
        {
            pet.DisplayStats();

            Console.WriteLine("Выберите действие: ");
            Console.WriteLine("1. Покормить");
            Console.WriteLine("2. Поиграть");
            Console.WriteLine("3. Поспать");
            Console.WriteLine("4. Лечение");
            Console.WriteLine("5. Выход");

            int action = Convert.ToInt32(Console.ReadLine());

            switch (action)
            {
                case 1:
                    pet.Feed();
                    break;
                case 2:
                    pet.Play();
                    break;
                case 3:
                    pet.Sleep();
                    break;
                case 4:
                    pet.Treat();
                    break;
                case 5:
                    Console.WriteLine("Игра окончена.");
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Ошибка!");
                    break;
            }

            if (pet.GetHealth() <= 0)
            {
                Console.WriteLine("Вы проиграли.");
                quit = true;
            }
        }
    }
}
