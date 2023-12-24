//Лаб 7 Высокий 14

using System.ComponentModel.Design;

try
{
    Console.Write("Введите количество работников: ");
    int n = int.Parse(Console.ReadLine());
    Worker[] workers = new Worker[n];

    for (int i = 0; i < n; i++)
    {
        if (n > 1) 
        Console.WriteLine($"\nСотрудник {i+1})");
        workers[i] = new Worker();
        Console.Write("Введите фамилию сотрудника: ");
        workers[i].lastName = Console.ReadLine();
        Console.Write("Введите должность работника: ");
        workers[i].position = Console.ReadLine();
        Console.Write("Введите дату подписания контракта YYYY.HH.DD: ");
        workers[i].dateSigning = DateOnly.Parse(Console.ReadLine());
        Console.Write("\tВведите срок действия контракта (Лет): ");
        workers[i].contractYears = int.Parse(Console.ReadLine());
        Console.Write("\tВведите срок действия контракта (Месяцев): ");
        workers[i].contractMonths = int.Parse(Console.ReadLine());
        Console.Write("\tВведите срок действия контракта (Дней): ");
        workers[i].contractDays = int.Parse(Console.ReadLine());
        Console.Write("Введите сумму оклада: ");
        workers[i].salary = int.Parse(Console.ReadLine());
        workers[i].dateEnd = workers[i].dateSigning.AddYears(workers[i].contractYears).AddMonths(workers[i].contractMonths).AddDays(workers[i].contractDays);
        Console.WriteLine($"Дата окончания контракта: {workers[i].dateEnd}");
    }
    DateOnly today = DateOnly.FromDateTime(DateTime.Now);
    DateOnly endDate = today.AddDays(5);
    Console.WriteLine("\nСотрудники, у которых истекает срок действия контракта в течение 5 дней: ");
    bool found = false;
    for (int i = 0;i < workers.Length;i++)
    {
        if (today <= workers[i].dateEnd && workers[i].dateEnd <= endDate)
        {
            Console.WriteLine($"Фамилия: {workers[i].lastName}");
            Console.WriteLine($"Должность: {workers[i].position}");
            Console.WriteLine($"Дата подписания контракта: {workers[i].dateSigning}");
            Console.WriteLine($"Дата окончания контракта: {workers[i].dateEnd}");
            Console.WriteLine($"Оклад: {workers[i].salary}");
            found = true;
        } 
    }
    if (!found)
    {
        Console.WriteLine("Таких сотрудников нет!");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
struct Worker
{
    public string lastName;
    public string position;
    public DateOnly dateSigning;
    public int contractYears;
    public int contractMonths;
    public int contractDays;
    public DateOnly dateEnd;
    public int salary;
}