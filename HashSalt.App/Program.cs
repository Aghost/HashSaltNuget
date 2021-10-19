using System;
using static HashSalt.Lib.HashSalter;

using static System.Console;

namespace HashSalt.App
{
    class Program
    {
        static void Main(string[] args) {
            //TestOne();
            TestTwo();
        }

        static void TestOne() {
            string salt = GetSalt(24);
            string tmp = GetHash("henk", salt);

            WriteLine(tmp);
            WriteLine(ConfirmHash("henk", tmp, salt));
        }

        static void TestTwo() {
            string tmp = GetBHash("henk");
            WriteLine(tmp);
            WriteLine(ConfirmBHash("henk", tmp));
        }
    }
}
