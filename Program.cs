using Student_management;

var university = new University();
var exit = false;
while (!exit)
{
    Console.WriteLine("Please select an option: " +
                      "\n1. Add Student, \n2. Remove Student, \n3. Add Student To Class" +
                      "\n4. Manage Student Marks, \n5. Get Class Details, \n6. Get Global Average Mark");
    
    var userInput = Console.ReadLine();
    
    switch (userInput)
    {
        case "1":
            university.AddStudent();
            break;
        
        case "2":
            university.RemoveStudent();
            break;
        
        case "3":
            university.AddStudentToClass();
            break;
        
        case "4":
            university.ManageStudentMarks();
            break;
        
        case "5":
            university.GetClassDetails();
            break;
        
        case "6":
            university.GetGlobalAverageMark();
            break;
        
        default: Console.WriteLine("Please select the write option");
            break;
    }
}