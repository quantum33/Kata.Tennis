﻿using Quantum33.Kata.Tennis;
using System;

namespace Quantum33.Kata.TennisGame3000
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Super Tennis Game 3000!");

            var tennisMatch = new TennisMatch();

            tennisMatch.Play();

            Console.ReadLine();
        }
    }
}
