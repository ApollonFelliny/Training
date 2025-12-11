using System;
class Student
{
    protected string name;
    protected int age;
    protected string group;
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }
    public Student()
    {
        Name = "Студент";
        Age = 18;
        Group = "Группа";
    }
    public Student(string name, int age, string group)
    {
        Name = name;
        Age = age;
        Group = group;
    }
    public void Study()
    {
        Console.WriteLine($"Студент по имени {Name}, которому {Age} лет, учится в группе {Group}");
    }
}
class Master : Student
{
    public Master()
    {
        Name = "Магистр";
        Age = 200;
        Group = "Магистратура";
    }
    public void Defend()
    {
        Console.WriteLine($"Магистр {Name} защищает дипломную работу");
    }
}
class Bachelor : Student
{
    public Bachelor()
    {
        Name = "Бакалавр";
        Age = 500;
        Group = "Бакалавриат";
    }
    public void TakeExams()
    {
        Console.WriteLine($"Бакалавр {Name} сдает экзамены");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Master master = new Master();
        Bachelor bachelor = new Bachelor();
        master.Study();
        master.Defend();
        bachelor.Study();
        bachelor.TakeExams();
    }
}
