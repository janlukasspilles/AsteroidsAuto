using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class Neuron : INeuron
    {
        private NeuralFactor m_bias;
        private double m_biasWeight;
        private double m_error;
        private Dictionary<INeuronSignal, NeuralFactor> m_input;
        private double m_output;

        public NeuralFactor Bias { get => m_bias; set => m_bias = value; }
        public double BiasWeight { get => m_biasWeight; set => m_biasWeight = value; }
        public double Error { get => m_error; set => m_error = value; }
        public Dictionary<INeuronSignal, NeuralFactor> Input { get => m_input; set => m_input = value; }
        public double Output { get => m_output; set => m_output = value; }

        public void ApplyLearning(INeuralLayer layer)
        {
            throw new NotImplementedException();
        }

        public void Pulse(INeuralLayer layer)
        {
            lock (this)
            {
                m_output = 0;
                foreach (KeyValuePair<INeuronSignal, NeuralFactor> item in m_input)
                    m_output += item.Key.Output * item.Value.Weight;
                m_output += m_bias.Weight * BiasWeight;
                m_output = Sigmoid(m_output);
            }
        }
        public static double Sigmoid(double value)
        {
            return 1 / (1 + Math.Exp(-value));
        }
    }
}
