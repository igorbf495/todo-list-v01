using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        LoadTasksFromFile(); // Carregar tarefas do arquivo no início do programa

        while (true)
        {
            Console.Clear();

            Console.WriteLine("Gerenciador de Tarefas:");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Marcar Tarefa como Concluída");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        ListTasks();
                        break;
                    case 3:
                        MarkTaskAsCompleted();
                        break;
                    case 4:
                        SaveTasksToFile();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    static void AddTask()
    {
        Console.Clear();

        Console.Write("Digite a descrição da tarefa: ");
        string task = Console.ReadLine();
        tasks.Add(task);
        Console.WriteLine("Tarefa adicionada com sucesso!");
    }

    static void ListTasks()
    {
        Console.Clear();

        Console.WriteLine("Lista de Tarefas:");
        for (int i = 0; i < tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {tasks[i]}");
        }
    }

    static void MarkTaskAsCompleted()
    {
        Console.Clear();

        Console.Write("Digite o número da tarefa a ser marcada como concluída: ");
        if (int.TryParse(Console.ReadLine(), out int taskNumber) && taskNumber >= 1 && taskNumber <= tasks.Count)
        {
            tasks.RemoveAt(taskNumber - 1);
            Console.WriteLine("Tarefa marcada como concluída!");
        }
        else
        {
            Console.WriteLine("Número de tarefa inválido. Tente novamente.");
        }
    }

    static void SaveTasksToFile()
    {
        File.WriteAllLines("tasks.txt", tasks);
    }
    
    static void LoadTasksFromFile()
    {
        if (File.Exists("tasks.txt"))
        {
            tasks = new List<string>(File.ReadAllLines("tasks.txt"));
        }
    }
}
