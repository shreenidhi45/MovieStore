using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Exceptions
{
    internal class NoMovieException : Exception
    {
        public NoMovieException(string message) : base(message)
        {
        }
    }
    internal class ListFullException : Exception
    {
        public ListFullException(string message) : base(message) { }
    }
}
