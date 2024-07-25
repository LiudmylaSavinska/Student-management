namespace Student_management;

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Class? RelatedClass { get; private set; }
    public Dictionary<string, int> Subjects { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
        Subjects = new Dictionary<string, int>();
    }

    public void ChangeClass(Class classToJoin)
    {
        RelatedClass = classToJoin;
    }

    public string GetStudentDetails()
    {
        return $"Name: {Name}, Age: {Age}, Class: {GetClassName()}, AverageMark: {GetAverageMark()}";
    }

    private string GetClassName()
    {
        return RelatedClass == null ? "Missing" : RelatedClass.Name;
    }

    private double GetAverageMark()
    {
        double sum = 0;
        double result = 0;

        foreach (var subject in Subjects)
        {
            sum += subject.Value;
        }

        result = sum / Subjects.Count;
        
        return result;
    }
}