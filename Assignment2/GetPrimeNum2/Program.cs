using System;

namespace GetPrimeNum2
{

    class GetPrimeNum
    {
        const int N = 100;

        public static void GetPrime(bool[] primes)
        {
            {
                if (primes == null || primes.Length == 0) return;
                for (int i = 2; i * i < primes.Length; i++)
                {
                    for (int j = i * i; j < primes.Length; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool[] primes = new bool[N + 1];
            for (int i = 2; i < N + 1; i++)
            {
                primes[i] = true;
            }

            GetPrime(primes);

            for (int num = 2; num < N + 1; num++)
            {
                if (primes[num])
                {
                    Console.Write(" "+num);
                }
            }
        }
        
    }
}

