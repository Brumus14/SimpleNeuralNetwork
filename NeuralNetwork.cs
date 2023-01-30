using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ANDGateNeuralNetwork
{
    public class NeuralNetwork
    {
        private Random random;
        private int[] layers;
        private float[][] neurons;
        private float[][] biases;
        private float[][][] weights;
        private float learningRate = 0.6f;

        public float fitness = 0;

        public NeuralNetwork(int[] layers)
        {
            random = new Random();
            this.layers = layers;

            InitialiseNeurons();
            //InitialiseWeights();
            weights = new float[][][] { new float[][] { new float[] { 0.351f, 1.076f, 1.116f }, new float[] { -0.097f, -0.165f, 0.542f }, new float[] { 0.457f, -0.165f, -0.331f } }, new float[][] { new float[] { 0.383f, -0.327f, -0.329f } } };
            //InitialiseBiases();
            biases = new float[][] { new float[] { 0, 0, 0 }, new float[] { 0 } };

            /*foreach (float[][] weightLayer in weights)
            {
                foreach (float[] weightNeuron in weightLayer)
                {
                    foreach (float weight in weightNeuron)
                    {
                        Console.Write(weight + ", ");
                    }
                }
            }

            Console.WriteLine();

            foreach (float[] biasesLayer in biases)
            {
                foreach (float bias in biasesLayer)
                {
                    Console.Write(bias + ", ");
                }
            }*/
        }

        [MemberNotNull(nameof(neurons))]
        public void InitialiseNeurons()
        {
            List<float[]> neuronsList = new List<float[]>();

            for (int i = 0; i < layers.Length; i++)
            {
                neuronsList.Add(new float[layers[i]]);
            }

            neurons = neuronsList.ToArray();
        }

        [MemberNotNull(nameof(weights))]
        public void InitialiseWeights()
        {
            List<float[][]> weightsList = new List<float[][]>();

            for (int i = 1; i < layers.Length; i++)
            {
                List<float[]> layerWeightsList = new List<float[]>();
                int neuronsInPreviousLayer = layers[i - 1];

                for (int j = 0; j < neurons[i].Length; j++)
                {
                    float[] neuronWeightsList = new float[neuronsInPreviousLayer];

                    for (int k = 0; k < neuronsInPreviousLayer; k++)
                    {
                        neuronWeightsList[k] = (float)random.NextDouble() - 0.5f;
                    }

                    layerWeightsList.Add(neuronWeightsList);
                }

                weightsList.Add(layerWeightsList.ToArray());
            }

            weights = weightsList.ToArray();
        }

        [MemberNotNull(nameof(biases))]
        public void InitialiseBiases()
        {
            List<float[]> biasesList = new List<float[]>();

            for (int i = 0; i < layers.Length; i++)
            {
                float[] layerBiases = new float[layers.Length];

                for (int j = 0; j < neurons[i].Length; j++)
                {
                    layerBiases[j] = 0;
                }

                biasesList.Add(layerBiases);
            }

            biases = biasesList.ToArray();
        }

        public float[] FeedForward(float[] inputs)
        {
            for (int i = 0; i < inputs.Length; i++)
            {
                neurons[0][i] = inputs[i];
            }

            for (int i = 1; i < layers.Length; i++)
            {
                for (int j = 0; j < neurons[i].Length; j++)
                {
                    float value = 0;

                    for (int k = 0; k < neurons[i - 1].Length; k++)
                    {
                        //Console.WriteLine($"Value: {neurons[i - 1][k]}, Weight: {weights[i - 1][j][k]}, Result: {weights[i - 1][j][k] * neurons[i - 1][k]}");
                        value += weights[i - 1][j][k] * neurons[i - 1][k];
                        Console.Write($"{weights[i - 1][j][k]} * {neurons[i - 1][k]} + ");
                    }

                    float biasedValue = value + biases[i - 1][j];

                    Console.Write($"{biases[i - 1][j]} = {biasedValue}");
                    Console.Write($" : {(i != layers.Length - 1 ? HiddenLayerActivationFunction(biasedValue) : OutputLayerActivationFunction(biasedValue))}");
                    Console.WriteLine();

                    neurons[i][j] = i != layers.Length - 1 ? HiddenLayerActivationFunction(biasedValue) : OutputLayerActivationFunction(biasedValue);
                }
            }

            return neurons[neurons.Length - 1];
        }

        public float HiddenLayerActivationFunction(float input)
        {
            //return (float)Math.Max(0, input);
            return (float)(1 / (1 + Math.Pow(Math.E, -input)));
        }

        public float OutputLayerActivationFunction(float input)
        {
            //return input;
            return (float)(1 / (1 + Math.Pow(Math.E, -input)));
        }

        public float LossFunction(float[] outputs, int target)
        {
            return (float)-Math.Log(outputs[target]);
        }

        public float LossFunction(float[] outputs, int[] targets)
        {
            int target = Array.IndexOf(targets, 1);
            return LossFunction(outputs, target);
        }

        public float CalculateError(float[] outputs, float[] targets)
        {
            float error = 0;

            for (int i = 0; i < outputs.Length; i++)
            {
                error += (float)(Math.Pow(targets[i] - outputs[i], 2) / 2);
            }

            return error;
        }
    }
}
