using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace Змейка
{
    class Program
    {
        public static Walls walls; //Обьявление класса
        public static Snake snake;
        public static Food food;
        public static Timer time;

        static void Main()
        {
            Console.CursorVisible = false;

            int x = 0;
            int y = 0;
            int s = 0;
            Console.WriteLine("выберите уровень сложности:" +  //Выбор сложности
                "\n1 - Легко" +
                "\n2 - Средне" +
                "\n3 - Сложно");
            int D = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (D)
            {
                case 1: //Параметры поля для 1 сложности
                    x = 10;
                    y = 10;
                    s = 500;
                    break;
                case 2: //Параметры поля для 2 сложности
                    x = 15;
                    y = 15;
                    s = 200;
                    break;
                case 3: //Параметры поля для 3 сложности
                    x = 20;
                    y = 20;
                    s = 100;
                    break;
            }

            walls = new Walls(x, y, '@');     //Стены
            snake = new Snake(x / 2, y / 2, 3); //Змейка (ее спавн)

            food = new Food(x, y, 'O');  //Еда (ее спавн)
            food.CreateFood();

            time = new Timer(Moving.Move, null, 0, s);  //Скорость движения змейки

            while (true)  //Направление движения
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.Rotation(key.Key);
                }
            }
        }
    }
}
