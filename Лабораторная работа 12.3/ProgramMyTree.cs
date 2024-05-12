using ClassLibrary10lab;

namespace Лабораторная_работа_12._3
{
    internal class Program
    {
        static void PrintMenu()
        {
            Console.WriteLine("1. Напечатать дерево");
            Console.WriteLine("2. Поиск минимального элемента в дереве");
            Console.WriteLine("3. Преобразовать дерево в дерево поиска");
            Console.WriteLine("4. Удалить из дерева поиска элемент с заданным ключом");
            Console.WriteLine("5. Удалить дерево");
        }

        static int IsInt(int min, int max) //функция для проверки на минимальное и максимальное значение
        {
            bool isConvert;
            int number;
            do
            {
                string buf = Console.ReadLine();
                isConvert = int.TryParse(buf, out number);
                if (!isConvert || number < min || number > max)
                {
                    Console.WriteLine($"Неправильно введено число. Введите значение от {min} до {max}");
                }
            } while (!isConvert || number < min || number > max);
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину дерева:");
            int length = IsInt(1, 17);
            MyTree<MusicalInstrument> tree = new MyTree<MusicalInstrument>(length);
            Console.WriteLine("Дерево создано!");
            Console.WriteLine("Выберите действие");

            int answer = 1;

            while (answer != 5)
            {
                try
                {
                    PrintMenu();
                    answer = IsInt(1, 5);
                    switch (answer)
                    {
                        case 1:
                            tree.ShowTree();
                            break;

                        case 2:
                            MusicalInstrument minInstrument = tree.FindMin();
                            Console.WriteLine($"Минимальный инструмент: {minInstrument}");
                            break;

                        case 3:
                            Console.WriteLine("Дерево до преобразования:");
                            tree.ShowTree();

                            tree.TransformToFindTree();

                            Console.WriteLine("\nДерево после преобразования в дерево поиска:");
                            tree.ShowTree();
                            break;

                        case 4:
                            Console.WriteLine("Введите ключ - имя, чтобы удалить элемент");
                            string name = Console.ReadLine();
                            tree.RemoveByName(name);

                            Console.WriteLine("Элемент удален");
                            tree.ShowTree();

                            break;

                        case 5:
                            tree.RemoveTree();
                            break;

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }

}
