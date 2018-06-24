using System;

namespace CalcModels
{
    /// <summary>
    /// Parameters for arithmetic operation
    /// </summary>
    public struct CalcOperationParam
    {
        public string arg; // current entered string which containing a number or a symbol of the operation
        public double leftOp;
        public double rightOp;
        public TypeOperation operation;

        public string result;
        public string history;
    }

    /// <summary>
    /// Calculates an arithmetic operations
    /// </summary>
    public static class Arithmometer
    {
        /// <summary>
        /// Execute of calculator operations by using parameters of arithmetic operation
        /// </summary>
        /// <param name="parameter"></param>
        public static void Calc(ref CalcOperationParam Cop)
        {
            try
            {
                if (Double.TryParse(Cop.arg, out double num)) // number
                {
                    if (Cop.operation == TypeOperation.None)
                        Cop.leftOp = Cop.leftOp * 10 + num;
                    else
                        if (double.IsNaN(Cop.rightOp))
                        Cop.rightOp = num;
                    else
                        Cop.rightOp = Cop.rightOp * 10 + num;
                }
                else // operation
                {
                    Cop.arg = CalcSymbol.TransformationArg(Cop.arg); // Transformation of operation symbol  into one of the elements of TypeOperation
                    if ((TypeOperation)Enum.Parse(typeof(TypeOperation), Cop.arg) == TypeOperation.Equally)
                    {
                        Calculate(ref Cop);
                    }
                    else if ((TypeOperation)Enum.Parse(typeof(TypeOperation), Cop.arg) == TypeOperation.ClearAll)
                    {
                        Clear(ref Cop);
                    }
                    else // "+" "-" "*" "/"
                    {
                        if (!double.IsNaN(Cop.rightOp))
                        {
                            Calculate(ref Cop);
                        }
                        Cop.operation = (TypeOperation)Enum.Parse(typeof(TypeOperation), Cop.arg);
                    }
                }

                Cop.result =
                    Cop.leftOp.ToString() +
                    CalcSymbol.Operation[Cop.operation].Symbol;
                if (!Double.IsNaN(Cop.rightOp))
                    Cop.result += Cop.rightOp.ToString();
            }
            catch (DivideByZeroException)
            {
                Clear(ref Cop);
                Cop.history = "Division by zero is impossible";
            }
        }

        /// <summary>
        /// Reset all parameters for arithmetic operation to their original state
        /// </summary>
        public static void Clear(ref CalcOperationParam Cop)
        {
            Cop.leftOp = 0;
            Cop.rightOp = Double.NaN;
            Cop.operation = TypeOperation.None;
            Cop.result = "0";
            Cop.history = "";
        }

        /// <summary>
        /// Calculation of the arithmetic operation
        /// </summary>
        private static void Calculate(ref CalcOperationParam Cop)
        {
            if (!double.IsNaN(Cop.rightOp))
            {
                Cop.history =
                    Cop.leftOp.ToString() +
                    CalcSymbol.Operation[Cop.operation].Symbol +
                    Cop.rightOp.ToString() +
                    CalcSymbol.Operation[TypeOperation.Equally].Symbol;

                Cop.leftOp = CalcSymbol.Operation[Cop.operation].Calc(Cop.leftOp, Cop.rightOp);
                Cop.rightOp = Double.NaN;
                Cop.operation = TypeOperation.None;
            }
        }
    }
}
