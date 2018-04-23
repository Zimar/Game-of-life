using System;

namespace game_of_life
{
	class game
    {
        public const int x = 10;
        public const int y = 10;
        private bool[,] arr = new bool[x, y];
        private bool[,] arr2 = new bool[x, y];
        public game()
        {
            for (int i = 0; i < x; ++i)
                for (int j = 0; j < y; ++j)
                    arr[i, j] = false;
            arr[0, 0] = true;
            arr[0, 1] = true;
            arr[0, 2] = true;
            arr[3, 0] = true;
            arr[3, 1] = true;
            arr[3, 2] = true;
        }

        public void print()
        {
            for (int i = 0; i < y; ++i)
            {
                for (int j = 0; j < x; ++j)
                {
                    if (arr[i, j] == true)
                        Console.Write("O");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine("");
            }

        }

        private int count_neighb(int i, int j)
        {
            int cnt = 0;

            if (i - 1 >= 0)                     // sprawdzanie lewego sąsiada
                if (arr[i - 1, j])
                    ++cnt;
            if (i + 1 <= y)                     // Sprawdzanie prawego sąsiada
                if (arr[i + 1, j])
                    ++cnt;
            if (j - 1 >= 0)                     // sprawdzanie górnego sąsiada
                if (arr[i, j - 1])
                    ++cnt;
            if (j + 1 <= x)                     // sprawdzanie dolnego sąsiada
                if (arr[i, j + 1])
                    ++cnt;
            if ((j + 1 <= x) && (i - 1 >= 0))   // sprawdzanie dolnego lewego sąsiada
                if (arr[i - 1, j + 1])
                    ++cnt;
            if ((j + 1 <= x) && (i + 1 <= y))   // sprawdzanie dolnego prawego sąsiada
                if (arr[i + 1, j + 1])
                    ++cnt;
            if ((j - 1 >= 0) && (i - 1 >= 0))   // sprawdzanie górnego lewgo sąsiada
                if (arr[i - 1, j - 1])
                    ++cnt;
            if ((j - 1 >= 0) && (i + 1 <= y))   // sprawdzanie górnego prawego sąsiada
                if (arr[i + 1, j - 1])
                    ++cnt;
            return cnt;

        }
        public void next_step()
        {
            for (int i = 0; i < y; ++i)
                for (int j = 0; j < x; ++j)
                {
                    if (arr[i, j] == true)
                    {
                        if (this.count_neighb(i, j) < 2 || this.count_neighb(i, j) > 3)
                            arr2[i, j] = false;
                        if (this.count_neighb(i, j) == 2 || this.count_neighb(i, j) == 3)
                            arr2[i, j] = true;

                    }
                    if (arr[i, j] == false)
                        if (this.count_neighb(i, j) == 3)
                            arr2[i, j] = true;
                }
            arr = arr2;
        }


    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            game g = new game();
			while (true)
			{
				g.next_step();
				g.print();
				Console.ReadKey();
				Console.Clear();
			}
        }
    }
}

