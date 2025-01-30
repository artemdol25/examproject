using System;
using System.Collections.Generic;

class Program
{
    static List<Task> tasks = new List<Task>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("To-Do List:");
            Console.WriteLine("1. Добавить задачу");
            Console.WriteLine("2. Удалить задачу");
            Console.WriteLine("3. Отобразить список задач");
            Console.WriteLine("4. Отметить задачу как выполненную");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    RemoveTask();
                    break;
                case "3":
                    ShowTasks();
                    break;
                case "4":
                    MarkTaskAsCompleted();
                    break;
                case "5":
                    if (ConfirmExit())
                        return;
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
    static bool ConfirmExit()
    {
        while (true)
        {
            Console.Write("Вы действительно хотите выйти из программы? (да/нет): ");
            string response = Console.ReadLine().Trim().ToLower();
            if (response == "да")
                return true;
            else if (response == "нет")
                return false;
            else
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите 'да' или 'нет'.");
        }
    }

    static void AddTask()
    {
        Console.Write("Введите название задачи: ");
        string title = Console.ReadLine();
        Console.Write("Введите описание задачи: ");
        string description = Console.ReadLine();

        tasks.Add(new Task(title, description));
        Console.WriteLine("Задача добавлена! Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }

    static void RemoveTask()
    {
        ShowTasks();
        Console.Write("Введите номер задачи для удаления: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks.RemoveAt(index - 1);
            Console.WriteLine("Задача удалена!");
        }
        else
        {
            Console.WriteLine("Некорректный номер задачи.");
        }
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }

    static void ShowTasks()
    {
        Console.Clear();
        if (tasks.Count == 0)
        {
            Console.WriteLine("Список задач пуст.");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }
        Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }

    static void MarkTaskAsCompleted()
    {
        ShowTasks();
        Console.Write("Введите номер задачи для отметки как выполненной: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
        {
            tasks[index - 1].IsCompleted = true;
            Console.WriteLine("Задача отмечена как выполненная!");
        }
        else
        {
            Console.WriteLine("Некорректный номер задачи.");
        }
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }
}

class Task
{
    public string Title { get; }
    public string Description { get; }
    public bool IsCompleted { get; set; }

    public Task(string title, string description)
    {
        Title = title;
        Description = description;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{Title} - {Description} [{(IsCompleted ? "Выполнено" : "Не выполнено")}]";
    }
}
