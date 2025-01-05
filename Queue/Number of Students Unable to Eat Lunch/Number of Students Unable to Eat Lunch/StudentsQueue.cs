namespace Number_of_Students_Unable_to_Eat_Lunch;

public class StudentsQueue
{
    public StudentNode FirstStudent = null;

    public StudentNode LastStudent = null;

    public StudentsQueue(int[] ListStudents)
    {
        FirstStudent = new StudentNode(ListStudents[0]);
        LastStudent = FirstStudent;

        StudentNode currentStudent = FirstStudent;

        // Enqueue students into queue of a linked list
        for (int i = 1; i < ListStudents.Length; i++)
        {
            currentStudent.next = new StudentNode(ListStudents[i]);
            currentStudent = currentStudent.next;
        }
        LastStudent = currentStudent;
    }

    public void Enqueue(StudentNode enqueuedStudent)
    {
        LastStudent.next = enqueuedStudent;
        LastStudent = enqueuedStudent;
        enqueuedStudent.next = null;
    }

    public StudentNode Dequeue(StudentNode dequeuedStudent)
    {
        FirstStudent = dequeuedStudent.next;
        dequeuedStudent.next = null;

        return dequeuedStudent;
    }
}
