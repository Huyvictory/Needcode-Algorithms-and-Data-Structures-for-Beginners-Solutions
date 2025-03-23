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

    private static (int target, int[] position, int[] speed) TestCase7() {
        return (target: 548316, 
        position: [93804,58951,280346,467697,68470,313439,383522,28369,445136,202920,109370,295564,351332,416919,75178,543998,261890,258739,299735,190499,68062,467322,543311,205807,507287,428095,100903,314472,356956,342100,430894,291202,174858,171115,251506,293650,177868,108878,130546,163890,522482,353322,252623,468839,409297,518052,70551,544273,473595,543298,487462,477369,26501,454369,87861,63238,342566,226818,276918,325552,253372,218159,398640,123034,339893,15088,392717,510602,146428,411252,411089,382369,399620,357127,82032,129184,15013,191635,469825,215919,8421,520838,332832,514415,404051,251808,218301,300716,496859,235083,267923,467919,395679,245084,326464,236350,158632,484527,306157,388454], 
        speed: [40371,595563,665604,412154,926012,46441,676135,64127,930294,228417,292547,736300,423489,449172,481540,759363,954246,338984,260385,142666,646690,59730,101287,672144,943203,918288,231511,911667,378587,106223,234953,276628,217367,777457,992337,208758,211838,851798,45033,369839,620830,73094,586072,941531,931213,144010,982180,334862,826457,765057,305300,114987,169055,932405,770234,829165,90332,846855,767587,904519,127870,644931,960672,413359,54014,481180,653521,753476,453542,617917,35480,327101,510622,826751,832456,783607,314438,952363,977001,402116,950815,636554,332154,384515,407610,759061,755019,761412,492615,194556,392856,247159,930782,192891,559602,939023,424367,31318,10961,516515]);
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

    // TC: O(nlogn), SC: O(n)
    private static int CarFleetIteration(int target, int[] position, int[] speed)
    {
        var mapCarSpeed = new Dictionary<int, int>();
        int res =  1;
        
        for (int i = 0; i < position.Length; i++)
        {
            mapCarSpeed.Add(position[i], speed[i]);
        }

        // Sort array of cars in descending order to determine number of fleets
        Array.Sort(position, (i1, i2) => i2.CompareTo(i1));

        // By Default we would have a latest fleet of a car that is near the target the most
        double latestFleet = (double)(target - position[0]) / mapCarSpeed[position[0]];

        for (int i = 1; i < position.Length; i++)
        {
            // Calculate number of times each car has to take in order to move to target
            double timeCarTaken = (double)(target - position[i]) / mapCarSpeed[position[i]];

            // If we already have a fleet, then we meet a new one
            // Then we add a new fleet to the result and update it
            if (timeCarTaken > latestFleet) {
                res++;
                latestFleet = timeCarTaken;
            }
        }

        return res;
    }

    // 3 Cases that might happen
    // 1. Cars that meet together and go to target position
    // 2. Cars that have formed a fleet before while traversing it meet a different car
    // and form a completely different fleet that goes at the speed at the minimum
    // 3. Car that only goes by itself and form it's own fleet to target.

    public static int CarFleet(int target, int[] position, int[] speed)
    {
        // return CarFleetMonotonicStack(target, position, speed);
        return CarFleetIteration(target, position, speed);
    }

    static void Main(string[] args)
    {
        (int target, int[] position, int[] speed) TestCase = TestCase7();

        Console.WriteLine(CarFleet(target: TestCase.target, position: TestCase.position, speed: TestCase.speed));
    }
}
