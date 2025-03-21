namespace Daily_Temperatures;

class Program
{
    private static int[] TestCase1() {
        return [73,74,75,71,69,72,76,73];
    }

    private static int[] TestCase2() {
        return [30,40,50,60];
    }

    private static int[] TestCase3() {
        return [30,60,90];
    }

    // TC: O(n^2), SC: O(n)
    private static int[] DailyTemperaturesBruteForce(int[] temperatures)
    {
        int[] answer = new int[temperatures.Length];

        for (int i = 0; i < temperatures.Length; i++)
        {
            int numberOfWaitingDays = 1;

            for (int j = i + 1; j < temperatures.Length; j++)
            {
                if (temperatures[j] > temperatures[i])
                {
                    answer[i] = numberOfWaitingDays;
                    break;
                }
                else {
                    numberOfWaitingDays++;
                }
            }
        }

        return answer;
    }

    // TC: O(n), SC: O(n)
    private static int[] DailyTemperaturesMonotonicDecreasingStack(int[] temperatures) {
        int[] answer = new int[temperatures.Length];

        Stack<(int element, int index)> monotonicDecreasingStack = new Stack<(int element, int index)>();

        // a monotonic stack than only contains element in decreasing order
        monotonicDecreasingStack.Push((temperatures[0], 0));

        // Traverse each element in original array and check the current element with element at top stack
        // if current element is larger then it doesn't suit the stack characteristic.
        // Then we continue to pop every single element in the stack until it matches decreasing order.
        for (int i = 0; i < temperatures.Length; i++)
        {
            // Pop to maintain the decreasing order of the stack
            while (monotonicDecreasingStack.Count > 0 && temperatures[i] > monotonicDecreasingStack.Peek().element) {
                var topStackElement = monotonicDecreasingStack.Pop();

                // Calculate the number of waiting days between the element at top stack and current iteration element
                answer[topStackElement.index] = i - topStackElement.index;
            }

            monotonicDecreasingStack.Push((temperatures[i], i));
        }

        return answer;
    }

    public static int[] DailyTemperatures(int[] temperatures)
    {
        return DailyTemperaturesMonotonicDecreasingStack(temperatures);
    }

    static void Main(string[] args)
    {
        var result = DailyTemperatures(TestCase1());

        return;
    }
}
