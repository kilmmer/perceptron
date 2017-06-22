using System;

namespace perceptron{ 
    class Program{
        static void Main(string[] args){
            int[,] entrada = new int[,] { { 1, 0 }, { 1, 1 }, { 0, 1 }, { 0, 0 } };
            int[] saidas = { 0, 1, 0, 0 };

            Random r = new Random();

            double[] pesos = { r.NextDouble(), r.NextDouble(), r.NextDouble() };

            double aprendizado = 1;
            double totalErro = 1;

            while (totalErro > 0.2){
                totalErro = 0;
                for (int i = 0; i < 4; i++){
                    int saida = calcularSaida(entrada[i, 0], entrada[i, 1], pesos);

                    int error = saidas[i] - saida;

                    pesos[0] += aprendizado * error * entrada[i, 0];
                    pesos[1] += aprendizado * error * entrada[i, 1];
                    pesos[2] += aprendizado * error * 1;

                    totalErro += Math.Abs(error);
                }

            }

            Console.WriteLine("Resultados: ");
            for (int i = 0; i < 4; i++)
                Console.WriteLine(calcularSaida(entrada[i, 0], entrada[i, 1], pesos));

            Console.ReadLine();

        }

        private static int calcularSaida(double input1, double input2, double[] pesos){
            double sum = input1 * pesos[0] + input2 * pesos[1] + 1 * pesos[2];
            return (sum >= 0) ? 1 : 0;
        }
    }
}