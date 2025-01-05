namespace Number_of_Students_Unable_to_Eat_Lunch;

class Program
{
    public static int[][] TestCase1() { 

        return [[1,1,0,0], [0,1,0,1]];
    }

    public static int[][] TestCase2() {
        return [[1,1,1,0,0,1], [1,0,0,0,1,1]];
    }

    public static int[][] TestCase3() {
        return [[0,0,0,1,0,1,1,1,1,0,1], [0,0,0,1,0,0,0,0,0,1,0]];
    }

    public static int[][] TestCase4() {
        return [[0,0,1,1,0,0,0,0,1,0,0,1,1,0,1,1], [1,0,0,0,0,0,0,1,0,0,1,0,1,1,1,0]];
    }

    public static int[][] TestCase5() {
        return [[1,1], [0,1]];
    }

    public static bool ShouldSkipLoop(StudentNode student, SandwichNode sandwich) {
        StudentNode currentTraversalStudent = student;
        SandwichNode currentTraversalSandwich = sandwich;

        if (student == null) return false;

        if (currentTraversalStudent.val != currentTraversalSandwich.val) {
            while (currentTraversalStudent.next != null) {
                if ( currentTraversalStudent.val == currentTraversalStudent.next.val) {
                    currentTraversalStudent = currentTraversalStudent.next;
                }
                else {
                    break;
                }
            }
        }

        return currentTraversalStudent.next == null ? true : false;
    }

    public static int CountStudents(int[] students, int[] sandwiches) { 
        StudentsQueue StudentsQueue  = new StudentsQueue(students);

        SandwichesQueue SandwichesQueue = new SandwichesQueue(sandwiches);

        SandwichNode Sandwich = SandwichesQueue.FirstSandwich;
        StudentNode Student = StudentsQueue.FirstStudent;

        int count = 0;

        while (Sandwich != null && Student != null) {
            if (Student.val != Sandwich.val) {
                StudentNode RemovedStudentQueue = StudentsQueue.Dequeue(Student);
                StudentsQueue.Enqueue(RemovedStudentQueue);
                Student = StudentsQueue.FirstStudent;

                if (Student != null && Sandwich != null && ShouldSkipLoop(Student, Sandwich)) {
                    break;
                }
            }
            else {
                SandwichesQueue.Dequeue(Sandwich);
                Sandwich = SandwichesQueue.FirstSandwich;
                StudentsQueue.Dequeue(Student);
                Student = StudentsQueue.FirstStudent;
            }
        }

        if (Sandwich == null && Student == null) return 0;

        StudentNode curStudentTraversal = StudentsQueue.FirstStudent;
        SandwichNode curSandwichTraversal = SandwichesQueue.FirstSandwich;

        while (curStudentTraversal != null) {
            count++;
            curStudentTraversal = curStudentTraversal.next;
        }

        while (curSandwichTraversal != null 
        && ShouldSkipLoop(StudentsQueue.FirstStudent, SandwichesQueue.FirstSandwich) == false) {
            count++;
            curSandwichTraversal = curSandwichTraversal.next;
        }

        return count;
        
    }

    public static int CountStudents2(int[] students, int[] sandwiches) {
        var StudentsPreferences = new Dictionary<int, int>{
            {1, 0}, 
            {0, 0}
            };

        foreach (int student in students)
        {
            StudentsPreferences[student] = StudentsPreferences[student] + 1;
        }

        foreach (int sandwich in sandwiches)
        {
            if (StudentsPreferences[sandwich] > 0) {
                StudentsPreferences[sandwich] = StudentsPreferences[sandwich] - 1;
            }
            else {
                break;
            }
        }

        return StudentsPreferences[0] + StudentsPreferences[1];
    }

    static void Main(string[] args)
    {
        Console.WriteLine(CountStudents(TestCase1()[0], TestCase1()[1]));
        Console.WriteLine(CountStudents(TestCase2()[0], TestCase2()[1]));
        Console.WriteLine(CountStudents(TestCase3()[0], TestCase3()[1]));
        Console.WriteLine(CountStudents(TestCase4()[0], TestCase4()[1]));
        Console.WriteLine(CountStudents(TestCase5()[0], TestCase5()[1]));

        Console.WriteLine("-------------------------------------------------");

        Console.WriteLine(CountStudents2(TestCase1()[0], TestCase1()[1]));
        Console.WriteLine(CountStudents2(TestCase2()[0], TestCase2()[1]));
        Console.WriteLine(CountStudents2(TestCase3()[0], TestCase3()[1]));
        Console.WriteLine(CountStudents2(TestCase4()[0], TestCase4()[1]));
        Console.WriteLine(CountStudents2(TestCase5()[0], TestCase5()[1]));
        return;
    }
}
