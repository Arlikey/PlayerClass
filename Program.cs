namespace PlayerClass
{
    /*class MainTask
    {
        static void Main(string[] args)
        {
            Item[] items = {
                new Item("Меч", 10, 250m, 7f),
                new Item("Огненный меч", 10, 1200m, 11f),
                new Item("Легендарные ботинки быстроты", 60, 10_000m, 2f),
                new Item("Шлем", 6, 107m, 5f),
            };

            Player newPlayer = new Player("Олег", items);

            newPlayer.AddItem(new Item("Доспех шипов", 34, 4350m, 20f));

            foreach (Item item in newPlayer.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine("\n\nПОСЛЕ УДАЛЕНИЯ\n\n");

            newPlayer.RemoveItem(2);

            foreach (Item item in newPlayer.Inventory)
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine("\n\nСТАТИСТИКА\n\n");

            Console.WriteLine($"Общая ценность - {newPlayer.GetValue} зол.");
            Console.WriteLine($"Общий вес - {newPlayer.GetWeight} кг");

            Console.WriteLine("\n\nПОИСК ПО УРОВНЮ\n\n");

            foreach (Item item in newPlayer.FindItemsByLevel(10))
            {
                Console.WriteLine(item.Info());
            }

            Console.WriteLine("\n\nПОИСК ПО СТОИМОСТИ\n\n");

            foreach (Item item in newPlayer.FindItemsByValue(108m))
            {
                Console.WriteLine(item.Info());
            }
        }

        public class Item
        {
            public Item(string name, int level, decimal value, float weight)
            {
                Name = name;
                Level = level;
                Value = value;
                Weight = weight;
            }

            public string Info()
            {
                return $"Название - {Name}, Ур. - {Level}, Цена - {Value} зол., Вес - {Weight} кг";
            }

            public string Name { get; set; }
            public int Level { get; set; }
            public decimal Value { get; set; }
            public float Weight { get; set; }


        }

        public class Player
        {
            public string Name { get; set; }
            private Item[] inventory;

            public Item[] Inventory { get { return inventory; } }
            public float GetWeight
            {
                get
                {
                    float weight = 0f;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        weight += inventory[i].Weight;
                    }
                    return weight;
                }
            }
            public decimal GetValue
            {
                get
                {
                    decimal value = 0m;
                    for (int i = 0; i < inventory.Length; i++)
                    {
                        value += inventory[i].Value;
                    }
                    return value;
                }
            }
            public Player(string name, Item[] inventory)
            {
                Name = name;
                this.inventory = inventory;
            }

            public void AddItem(Item item)
            {
                Item[] newInventory = new Item[inventory.Length + 1];
                for (int i = 0; i < inventory.Length; i++)
                {
                    newInventory[i] = inventory[i];
                }
                newInventory[newInventory.Length - 1] = item;
                inventory = newInventory;
            }

            public void RemoveItem(int index)
            {
                Item[] newInventory = new Item[inventory.Length - 1];
                for (int i = 0, j = 0; i < inventory.Length; i++)
                {
                    if (i == index)
                    {
                        continue;
                    }
                    newInventory[j++] = inventory[i];
                }
                inventory = newInventory;
            }
            public Item[] FindItemsByLevel(int level)
            {
                int count = 0;
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].Level == level)
                    {
                        count++;
                    }
                }

                Item[] items = new Item[count];

                for (int i = 0, j = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].Level == level)
                    {
                        items[j++] = inventory[i];
                    }
                }

                return items;
            }
            public Item[] FindItemsByValue(decimal value)
            {
                int count = 0;
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].Value == value)
                    {
                        count++;
                    }
                }

                Item[] items = new Item[count];

                for (int i = 0, j = 0; i < inventory.Length; i++)
                {
                    if (inventory[i].Value == value)
                    {
                        items[j++] = inventory[i];
                    }
                }

                return items;
            }
        }
    }*/

    /*class AdditionalTask1
    {
        static void Main()
        {
            IntStats intStats = new IntStats(new int[] { 8, 4, 3, 2, 12, 5, 6, 18, 45 });

            Console.WriteLine(intStats.Count);
            Console.WriteLine(intStats.Sum);
            Console.WriteLine(intStats.Average);
            Console.WriteLine(intStats.Mode);
            Console.WriteLine(intStats.Median);
        }

        public class IntStats
        {
            public int Count { get; }
            public int Sum { get; }
            public double Average { get; }
            public int Mode { get; }
            public double Median { get; }

            public IntStats(int[] array)
            {
                if (array.Length == 0 || array == null)
                {
                    throw new Exception("Not valid data!");
                }
                Count = array.Length;

                for (int i = 0; i < array.Length; i++)
                {
                    Sum += array[i];
                }

                Average = (double)Sum / Count;

                Mode = FindMode(array);

                Median = FindMedian(array);
            }

            private int FindMode(int[] array)
            {
                int mode = array[0];
                int modeCount = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    int count = 1;

                    for (int j = i + 1; j < array.Length; j++)
                    {
                        if (array[i] == array[j])
                        {
                            count++;
                        }
                    }

                    if (count > modeCount || (count == modeCount && array[i] < mode))
                    {
                        mode = array[i];
                        modeCount = count;
                    }

                }
                return mode;
            }

            private double FindMedian(int[] array)
            {
                int[] tempArray = BubbleSort(array);

                int middleIndex = tempArray.Length / 2;

                if (tempArray.Length % 2 == 0)
                {
                    return (double)(tempArray[middleIndex] + tempArray[middleIndex - 1]) / 2;
                }
                return tempArray[middleIndex];

            }

            private int[] BubbleSort(int[] array)
            {
                int[] tempArray = new int[array.Length];
                Array.Copy(array, tempArray, array.Length);
                for (int i = 0; i < tempArray.Length - 1; i++)
                {
                    for (int j = 0; j < tempArray.Length - i - 1; j++)
                    {
                        if ((tempArray[j] > tempArray[j + 1]))
                        {
                            (tempArray[j], tempArray[j + 1]) = (tempArray[j + 1], tempArray[j]);
                        }
                    }
                }

                return tempArray;
            }
        }
    }*/

    /*public class AdditionalTask3
    {
        static void Main()
        {
            for (int i = 0; i < 12; i++)
            {
                Webinar webinar = new Webinar();
            }
        }

        public class Webinar
        {
            private static int countOfPlaces = 10;

            public Webinar()
            {
                RegisterParticipant();
            }

            private void RegisterParticipant()
            {
                if (countOfPlaces == 0)
                {
                    Console.WriteLine("Мест на вебинаре не осталось! Вы не были зарегистрированы.");
                    return;
                }
                countOfPlaces--;
                Console.WriteLine($"Вы были зарегистрированы на вебинар. Осталось мест - {countOfPlaces}");
            }
        }
    }*/

    /*public class AddditionalTask5
    {
        static void Main()
        {
            Circle circle = new Circle(1, 2, 3);

            Console.WriteLine(circle.IsInCircle(3, 5));
        }

        public class Circle
        {
            public Circle(int x, int y, double r)
            {
                X = x;
                Y = y;
                R = r;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public double R { get; set; }

            public bool IsInCircle(int x, int y)
            {
                double distance = Math.Pow(x - X, 2) + Math.Pow(y - Y, 2);
                if (distance <= Math.Pow(R, 2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }*/
}
