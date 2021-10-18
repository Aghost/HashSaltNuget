using System;

using static System.Console;
using static HashSalt.Lib.HashSalter;

namespace HashSalt.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string salt = GetSalt(24);
            string tmp = GetHash("henk", salt);

            WriteLine(tmp);
            WriteLine( ConfirmHash("henk", tmp, salt));
        }
    }
}
