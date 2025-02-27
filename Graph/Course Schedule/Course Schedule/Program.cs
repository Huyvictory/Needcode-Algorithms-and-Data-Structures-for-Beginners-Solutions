namespace Course_Schedule;

class Program
{

    private (int numCourses, int[][] prerequisites) TestCase1() {
        return (2, [[1, 0]]);
    }

    private (int numCourses, int[][] prerequisites) TestCase2() {
        return (2, [[1, 0], [0, 1]]);
    }

    private (int numCourses, int[][] prerequisites) TestCase3() {
        return (1, []);
    }

    private (int numCourses, int[][] prerequisites) TestCase4() {
        return (20, [[0,10],[3,18],[5,5],[6,11],[11,14],[13,1],[15,1],[17,4]]);
    }

    private (int numCourses, int[][] prerequisites) TestCase5() {
        return (5, [[1,4],[2,4],[3,1],[3,2]]);
    }

    private bool CanFinishDFS(
        Dictionary<int, List<int>> scheduleGraph,
        int courseNeedToTake
    )
    {
        HashSet<int> visit = new HashSet<int>();

        bool DFS(int courseNeedToTake)
        {
            // Course that is not prerequisite by other course and can take it immediately
            if (scheduleGraph[courseNeedToTake].Count == 0)
            {
                return true;
            }

            // Cycle prerequisite detected
            if (visit.Contains(courseNeedToTake))
            {
                return false;
            }

            visit.Add(courseNeedToTake);

            // Iterate all of the prerequisite courses of the current course that needs to be taken first
            foreach (var prerequisiteCourse in scheduleGraph[courseNeedToTake])
            {
                if (!DFS(prerequisiteCourse)) {
                    return false;
                }
            }

            scheduleGraph[courseNeedToTake] = [];
            visit.Remove(courseNeedToTake);

            return true;
        }

        return DFS(courseNeedToTake);
    }

    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        if (prerequisites.Length == 0)
            return true;

        Dictionary<int, List<int>> scheduleGraph = new Dictionary<int, List<int>>();

        // Build schedule graph
        for (int i = 0; i < prerequisites.Length; i++)
        {
            if (!scheduleGraph.ContainsKey(prerequisites[i][0])) {
                scheduleGraph.Add(prerequisites[i][0], new List<int>() {prerequisites[i][1]});
            }
            else {
                scheduleGraph[prerequisites[i][0]].Add(prerequisites[i][1]);
            }

            if (!scheduleGraph.ContainsKey(prerequisites[i][1])) {
                scheduleGraph.Add(prerequisites[i][1], new List<int>());
            }
        }

        // Check for every course if all prerequisites courses are completed or not
        for (int i = 0; i < numCourses; i++)
        {
            if (scheduleGraph.ContainsKey(i) && !CanFinishDFS(scheduleGraph, i)) {
                return false;
            }
        }

        return true;
    }

    static void Main(string[] args)
    {
        Program testProgram = new Program();

        Console.WriteLine(testProgram.CanFinish(testProgram.TestCase1().numCourses, testProgram.TestCase1().prerequisites));
    }
}
