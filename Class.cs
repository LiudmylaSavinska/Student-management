using Student_management;

public class Class
{
    public string Name { get; set; }

    public List<Student> Students { get; set; }

    public Class(string name)
    {
        Students = new List<Student>();
        Name = name;
    }

    public void AddStudent(Student student)
    {
        var studentAlreadyAdded = false;
        
        foreach (var searchableStudent in Students)
        {
            if (student == searchableStudent)
            {
                studentAlreadyAdded = true;
                break;
            }
        }

        if (!studentAlreadyAdded)
        {
            Students.Add(student);
        }
    }

    public void RemoveStudent(Student student)
    {
        var studentAdded = false;
        
        foreach (var searchableStudent in Students)
        {
            if (student == searchableStudent)
            {
                studentAdded = true;
                break;
            }
        }

        if (studentAdded)
        {
            Students.Remove(student);
        }
    }

    public string GetStudentList()
    {
        var result = string.Empty;

        foreach (var student in Students)
        {
            result += $"Name: {student.Name}, Age: {student.Age} \n";
        }

        return result;
    }
}