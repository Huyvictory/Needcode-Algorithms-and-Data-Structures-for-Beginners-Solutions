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

    public static int[] DailyTemperatures(int[] temperatures)
    {
        return DailyTemperaturesBruteForce(temperatures);
    }

    static void Main(string[] args)
    {
        var result = DailyTemperatures(TestCase1());

        return;
    }
}
