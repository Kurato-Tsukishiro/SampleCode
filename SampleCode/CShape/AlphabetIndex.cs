// 記事本体 => https://qiita.com/Kurato-Tsukishiro/items/840a53d50863ace33820

namespace SampleCode;
public static class AlphabetIndex
{
    public static void main()
    {
        System.Console.WriteLine("Index?");
        string? rl = System.Console.ReadLine();
        if (int.TryParse(rl, out int count)) SampleMethod(count);
        else main();
    }
    public static void SampleMethod(int Count)
    {
        System.Text.StringBuilder text = new();
        char[] charArray = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        if (Count is <= 0 or > 26)
        {
            System.Console.WriteLine("Index Error");
            System.Console.ReadKey();
            main();
            return;
        }

        for (int i = 0; i < 26; i++)
        {
            int index = i + 1;
            text.AppendLine($"{index} => {charArray[i]}");
        }

        text.AppendLine();
        char result = charArray[Count - 1];
        string resultText = $"{Count}番目のアルファベットは \"{result}\" です";

        System.Console.WriteLine(text);
        System.Console.WriteLine(resultText);
        System.Console.ReadKey();
    }
}