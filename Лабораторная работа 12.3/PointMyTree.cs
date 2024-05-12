using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа_12._3
{
    public class Point<T> : IKeyProvider, IComparable where T : IComparable
    {
        public T Data { get; set; }
        public Point<T> Right { get; set; }
        public Point<T>? Left { get; set; }

        

        public Point(T data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }
       
        
        public override bool Equals(object obj)
        {
            if (obj is Point<T> p)
            {
                return this.Data.Equals(p.Data) && this.Right.Equals(p.Right) && this.Left.Equals(p.Left);

            }
            else { return false; }
        }

        public string GetKey()
        {
            return Data.ToString();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null || !(obj is Point<T>))
            {
                throw new ArgumentException("Object is not a Point<T>.");
            }

            return ((IComparable)Left).CompareTo(obj);
        }

    }
}
