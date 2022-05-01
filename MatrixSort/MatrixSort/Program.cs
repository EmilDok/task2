﻿using System;
using System.Collections.Generic;

namespace MatrixSort
{

    

    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(new double[,] { {1, 2, 3}, { 3, 4, 5}, { 13, 2, 2 }, { 1, 1, 1 } });


            Console.WriteLine();
            ConcreteStrategyB strat = new ConcreteStrategyB();

            m1.SetStrategy(strat);
            m1.SetOrder(true);
            m1.Sort();
            m1.Show();
        }

    }
}
