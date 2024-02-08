﻿namespace DynamicProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExpandoTests.RunTests();

            ReflectionTests.RunTests();

            ComInteropTests.RunTests();

            SerializationDeserializationTests.RunTests();

            DapperSqlTests.RunTests();
        }
    }
}
