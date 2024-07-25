namespace Student_management;

public class University
{
    public List<Student> Students { get; set; }
    public List<Class> Classes { get; set; }
    public List<string> Subjects { get; set; }

    public University()
    {
        Classes = new List<Class>();
        Classes.Add(new Class("A"));
        Classes.Add(new Class("B"));
        Classes.Add(new Class("C"));

        Subjects = new List<string>();
        Subjects.Add("English");
        Subjects.Add("Math");
        Subjects.Add("Biology");
        Subjects.Add("Geography");

        Students = new List<Student>();
    }

    public void AddStudent()
    {
        Console.WriteLine("Please enter name.");
        var name = Console.ReadLine();
        
        Console.WriteLine("Please enter age.");
        var age = Console.ReadLine();

        if (int.TryParse(age, out int parsedAge))
        {
            var student = new Student(name, parsedAge);

            foreach (var subject in Subjects)
            {
                student.Subjects.Add(subject, 0);
            }

            Students.Add(student);
        }
    }

    public void RemoveStudent()
    {
        Console.WriteLine("Please enter name.");
        var name = Console.ReadLine();
        
        var studentToRemove = GetStudentByName(name);

        if (studentToRemove != null)
        {
            studentToRemove.RelatedClass.RemoveStudent(studentToRemove);
            Students.Remove(studentToRemove);
        }
    }

    public void AddStudentToClass()
    {
        Console.WriteLine("Please enter student name.");
        var studentName = Console.ReadLine();
        
        Console.WriteLine("Please enter class name (A, B or C).");
        var className = Console.ReadLine();
        
        Class selectedClass = null;
        var selectedStudent = GetStudentByName(studentName);
        
        foreach (var searchableClass in Classes)
        {
            if (searchableClass.Name == className)
            {
                selectedClass = searchableClass;
                break;
            }
        }

        if (selectedStudent != null && selectedClass != null)
        {
            selectedClass.AddStudent(selectedStudent);
            selectedStudent.ChangeClass(selectedClass);
        }
    }

    public void ManageStudentMarks()
    {
        Console.WriteLine("Please enter student name.");
        var name = Console.ReadLine();
        
        var student = GetStudentByName(name);

        if (student != null)
        {
            foreach (var subject in student.Subjects)
            {
                Console.WriteLine($"Enter mark for {subject.Key}");
                
                var input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    student.Subjects[subject.Key] = value;
                }
            }
        }
    }

    public void GetClassDetails()
    {
        Console.WriteLine("Please enter class name (A, B or C).");
        var name = Console.ReadLine();
        
        var selectedClass = GetClassByName(name);
        
        Console.WriteLine(selectedClass.GetStudentList());
    }

    public void GetGlobalAverageMark()
    {
        double sum = 0;
        int count = 0;
        double result = 0;

        foreach (var student in Students)
        {
            foreach (var subject in student.Subjects)
            {
                sum += subject.Value;
            }

            count += student.Subjects.Count;
        }

        result = sum / count;
        
        Console.WriteLine($"Global average mark is: {result}");
    }

    private Student? GetStudentByName(string name)
    {
        foreach (var searchableStudent in Students)
        {
            if (searchableStudent.Name == name)
            {
                return searchableStudent;
            }
        }

        return null;
    }
    
    private Class? GetClassByName(string name)
    {
        foreach (var searchableClass in Classes)
        {
            if (searchableClass.Name == name)
            {
                return searchableClass;
            }
        }

        return null;
    }
}