namespace Car_Fleet;

class Program
{
    private static (int target, int[] position, int[] speed) TestCase1() {
        return (target: 12, position: [10,8,0,5,3], speed: [2,4,1,1,3]);
    }

    private static (int target, int[] position, int[] speed) TestCase2() {
        return (target: 10, position: [3], speed: [3]);
    }

    private static (int target, int[] position, int[] speed) TestCase3() {
        return (target: 100, position: [0,2,4], speed: [4,2,1]);
    }

    private static (int target, int[] position, int[] speed) TestCase4() {
        return (target: 10, position: [6,8], speed: [3,2]);
    }

    private static (int target, int[] position, int[] speed) TestCase5() {
        return (target: 10, position: [4,6], speed: [3,2]);
    }

    private static (int target, int[] position, int[] speed) TestCase6() {
        return (target: 10, position: [0,4,2], speed: [2,1,3]);
    }

    // TC: O(nlogn), SC: O(n)
    private static int CarFleetMonotonicStack(int target, int[] position, int[] speed)
    {
        var mapCarSpeed = new Dictionary<int, int>();
        Stack<double> stack = new Stack<double>();

        for (int i = 0; i < position.Length; i++)
        {
            mapCarSpeed.Add(position[i], speed[i]);
        }

        // Sort array of cars in descending order to determine number of fleets
        Array.Sort(position, new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

        foreach (var carposition in position)
        {
            // Calculate number of times each car has to take in order to move to target
            double timeCarTaken = (double)(target - carposition) / mapCarSpeed[carposition];

            stack.Push(timeCarTaken);

            // If we already have a fleet, then we meet a new one
            // Then we proceed to remove a car of an old fleet and push a new fleet into stack
            if (stack.Count >= 2 && stack.Peek() <= stack.ElementAt(1)) {
                stack.Pop();
            }
        }

        return stack.Count;
    }

    // 3 Cases that might happen
    // 1. Cars that meet together and go to target position
    // 2. Cars that have formed a fleet before while traversing it meet a different car
    // and form a completely different fleet that goes at the speed at the minimum
    // 3. Car that only goes by itself and form it's own fleet to target.

    public static int CarFleet(int target, int[] position, int[] speed)
    {
        return CarFleetMonotonicStack(target, position, speed);
    }

    static void Main(string[] args)
    {
        (int target, int[] position, int[] speed) TestCase = TestCase6();

        Console.WriteLine(CarFleet(target: TestCase.target, position: TestCase.position, speed: TestCase.speed));
    }
}
