using System;
using System.Security.Cryptography;
using System.Text;

namespace TripWay.Library
{
    public class Vertex
    {
        public string Name { get; private set; }

        public Vertex(string name)
        {
            this.Name = name;
        }

    }
}