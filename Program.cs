using System;

public class Task
{
    public int Id { get; set; }        // Identificador único da tarefa
    public string Title { get; set; }  // Título da tarefa
    public string Description { get; set; } // Descrição da tarefa
    public DateTime DueDate { get; set; }  // Data de vencimento da tarefa
    public bool IsCompleted { get; set; }  // Indica se a tarefa está concluída

    public Task(int id, string title, string description, DateTime dueDate, bool isCompleted)
    {
        Id = id;
        Title = title;
        Description = description;
        DueDate = dueDate;
        IsCompleted = isCompleted;
    }
}