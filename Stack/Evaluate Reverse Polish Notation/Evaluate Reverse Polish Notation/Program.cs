namespace Evaluate_Reverse_Polish_Notation;

class Program
{
    private static string[] TestCase1() { 
        return ["2","1","+","3","*"];
    }

    private static string[] TestCase2() { 
        return ["4","13","5","/","+"];
    }

    private static string[] TestCase3() { 
        return ["10","6","9","3","+","-11","*","/","*","17","+","5","+"];
    }

    private static string[] TestCase4() { 
        return ["0","3","/"];
    }

    public static int EvalRPNStack(string[] tokens)
    {
        var stackOperands = new Stack<int>();

        foreach (var token in tokens)
        {
            // If the current token is an operand then add it to stack
            if (int.TryParse(token, out int operand))
            {
                stackOperands.Push(operand);
            }
            // If the current token is an operator then get two latest operands in stack and perform calculation
            else
            {
                if (
                    stackOperands.TryPop(out int operand1) && stackOperands.TryPop(out int operand2)
                )
                {
                    int result = token switch
                    {
                        "+" => operand2 + operand1,
                        "-" => operand2 - operand1,
                        "*" => operand2 * operand1,
                        "/" => operand2 / operand1,
                        _ => operand2 + operand1,
                    };

                    // Add to stack for further operator computation
                    stackOperands.Push(result);
                }
                else
                {
                    return 0;
                }
            }
        }

        return stackOperands.Peek();
    }

    public static int EvalRPN(string[] tokens)
    {
        return EvalRPNStack(tokens);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(EvalRPN(TestCase1()));
    }
}
