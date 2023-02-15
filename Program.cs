using SimpleNeuralNetwork;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Numerics;
using System.Xml;

namespace ANDGateNeuralNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Dictionary<float, float> trainingData = new Dictionary<float, float>() { { 0.5f, 1f }, { 0.9f, 0f }, { 0.2f, 0f }, { 0.7f, 0f }, { 0.1f, 0f }, { 0.8f, 0f }, { 0.3f, 0f } };

            NeuralNetwork network = new NeuralNetwork(new int[] { 1, 2, 1 });*/

            /*NeuralNetwork network = new NeuralNetwork(new int[] { 4, 1 });

            Console.WriteLine();

            //float[] outputs = network.FeedForward(new float[] { 0.5f });
            float[] outputs = network.FeedForward(new float[] { 1, 2, 2.1f, 1.2f });

            foreach (float output in outputs)
            {
                Console.Write(output + ", ");
            }*/

            /*NeuralNetwork network = new NeuralNetwork(new int[] { 3, 3, 1 });

            //float[] output = new float[3] { 0.7f, 0.1f, 0.2f };
            //int[] target = new int[3] { 1, 0, 0 };

            float[] targets = new float[] { 0.5065095f };
            float[] outputs = network.FeedForward(new float[] { 0, 1, 1 });

            Console.Write("Targets: ");
            foreach (float target in targets)
            {
                Console.Write(target + ", ");
            }
            Console.WriteLine();

            Console.Write("Outputs: ");
            foreach (float output in outputs)
            {
                Console.Write(output + ", ");
            }
            Console.WriteLine();

            Console.Write("Total Error: ");
            Console.Write(network.CalculateError(outputs, targets));
            Console.WriteLine();*/
            /*float[][] o = { new float[] {  } };
            float[][] t = { new float[] { 3, 7 }, new float[] { 5, 1 } };

            float[] VectorProduct(float[] vector1, float[] vector2)
            {
                float[] vectorProduct = new float[vector1.Length];

                for (int i = 0; i < vector1.Length; i++)
                {
                    vectorProduct[i] = vector1[i] * vector2[i];
                }

                return vectorProduct;
            }

            float[][] DotProduct(float[][] matrix1, float[][] matrix2)
            {
                float[][] dotProduct = new float[matrix1.Length][];

                for (int i = 0; i < matrix1.Length; i++)
                {
                    float[] vectorProduct = VectorProduct(matrix1[i], matrix2[i]);
                    dotProduct[i] = vectorProduct;
                }

                return dotProduct;
            }

            float[][] matri = DotProduct(new float[][] { new float[] { 3, 4, 1 }, new float[] { 6, 7, 3 }, new float[] { 7, 9, 0 } }, new float[][] { new float[] { 5, 4, 3 }, new float[] { 2, 1, 1 }, new float[] { 4, 6, 1 } });

            foreach (float[] item1 in matri)
            {
                foreach (float item in item1)
                {
                    Console.WriteLine(item);
                }
            }*/

            //Testing.Minimize(-0.999, 0.0001d, 99999);
            //Console.WriteLine(Testing.Derivative(x => Math.Pow(x, 2) + (3 * x) - 2, -1));

            //average cost for many feed forwards


            NeuralNetwork network = new NeuralNetwork(new int[] { 10, 4, 2 });

            float[] outputs = new float[10] { 0.02f, 0.03f, 0.06f, 0.97f, 0.07f, 0.02f, 0.05f, 0.06f, 0.08f, 0.04f };
            float[] expected = new float[10] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };

            Console.WriteLine(network.CostFunction(outputs, expected));
            double[] gradients = new double[outputs.Length];

            for (int i = 0; i < outputs.Length; i++)
            {

            }
        }
    }
}