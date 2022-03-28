using System;

namespace VetorOrdenado
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] vetor = { 5, 3, 2, 4, 7, 1, 0, 6 };

            for (int i = 0; i < vetor.Length; i++)
            {

                for (int j = 0; j < (vetor.Length - 1); j++)
                {
                    var troca = vetor[j];
                    if (vetor[j] > vetor[j + 1])
                    {
                        vetor[j] = vetor[j + 1];
                        vetor[j + 1] = troca;
                    }
                }

            }

            foreach (int x in vetor)
            {
                Console.Write(x + " ");
            }
        }
    }
}
