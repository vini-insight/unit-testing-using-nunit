﻿using System;

namespace PrimeServices
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            // if (candidate == 1)
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Please create a test first.");
        }
    }
}