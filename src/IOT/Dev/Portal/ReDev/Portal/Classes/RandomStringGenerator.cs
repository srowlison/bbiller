using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Classes
{
    public class RandomStringGenerator
    {
        private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public string Create(int size)
        {
            char[] buffer = new char[size];
            Random _rng = new Random();
            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}