using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork
{
    public static class Testing
    {
        // The function to minimize
        public static double Function(double x)
        {
            return x * x;
        }

        // The derivative of the function
        public static double Derivative(double x)
        {
            return 2 * x;
        }

        // Perform gradient descent to minimize the function
        public static void Minimize(double initialX, double learningRate, int maxIterations)
        {
            double x = initialX;
            for (int i = 0; i < maxIterations; i++)
            {
                double gradient = Derivative(x);
                x -= gradient * learningRate;
            }

            Console.WriteLine("Minimum found at x = " + x);
        }
    }
}
