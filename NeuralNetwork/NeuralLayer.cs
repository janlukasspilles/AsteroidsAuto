using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralNetwork
{
    public class NeuralLayer : INeuralLayer
    {
        private List<INeuron> m_neurons;
        public int Count { get; set; }
        public bool IsReadOnly { get; set; }
        public void ApplyLearning(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
                n.ApplyLearning(this);
        }

        public void Pulse(INeuralNet net)
        {
            foreach (INeuron n in m_neurons)
                n.Pulse(this);
        }
    }
}
