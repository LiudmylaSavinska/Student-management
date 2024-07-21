class Subject
{
    public string Name { get; set; }

    public Subject(string name)
    {
        Name = name;
    }
}

class Class
{
    public string Name { get; set; }

    public Class(string name)
    {
        Name = name;
    }

    public Class()
    {
    }
}

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Class Class { get; set; }
    public double AverageMark { get; set; }
    public Dictionary<Subject, int> Subjects { get; set; }

    public Student(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Student()
    {
    }
}

class University
{
    public List<Student> Students { get; set; }
    public List<Class> Classes { get; set; }
    public List<Subject> Subjects { get; set; }

    public University()
    {
        Classes = new List<Class>();
        Classes.Add(new Class("A"));
        Classes.Add(new Class("B"));
        Classes.Add(new Class("C"));

        Subjects = new List<Subject>();
        Subjects.Add(new Subject("English"));
        Subjects.Add(new Subject("Math"));
        Subjects.Add(new Subject("Biology"));
        Subjects.Add(new Subject("Geography"));

        Students = new List<Student>();
    }

    public void AddStudent(string name, int age)
    {
        var student = new Student(name, age);

        foreach (var subject in Subjects)
        {
            student.Subjects.Add(subject, 0);
        }
        
        Students.Add(student);
    }

    public void RemoveStudent(string name)
    {
        var studentToRemove = new Student();

        foreach (var student in Students)
        {
            if (student.Name == name)
            {
                studentToRemove = student;
            }
        }

        Students.Remove(studentToRemove);
    }

    public void AddClass(string studentName, string className)
    {
        var existingStudent = new Student();
        var studentClass = new Class();

        foreach (var student in Students)
        {
            if (student.Name == studentName)
            {
                existingStudent = student;
            }
        }

        foreach (var searchableClass in Classes)
        {
            if (searchableClass.Name == className)
            {
                studentClass = searchableClass;
            }
        }

        existingStudent.Class = studentClass;
    }
}