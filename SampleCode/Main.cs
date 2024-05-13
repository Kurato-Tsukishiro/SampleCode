using System;
using System.Collections.Generic;

namespace SampleCode;
internal static class SampleCode
{
    internal const SampleType Type = SampleType.None;

    static void Main(string[] args)
    {
        switch (Type)
        {
            default:
                Console.WriteLine($"Typeが正常に登録されていません。");
                break;
        }

        Console.WriteLine($"\nキー操作で終了");
        Console.ReadKey();
    }

    internal enum SampleType
    {
        None,
    }
}
