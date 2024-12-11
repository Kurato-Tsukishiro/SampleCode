using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampleCode;
internal static class SampleCode
{
    /// <summary> 実行を固定したいサンプルコードの選択 </summary>
    internal const SampleType ConstType = SampleType.None;
    /// <summary> タイプを固定するか </summary>
    internal const bool IsTypeFixed = false;
    /// <summary> main処理終了後, コンソールを閉じる時にキー入力を待機するか </summary>
    internal const bool IsWaitingEnd = true; // VSCodeのデバッグコンソールでは, 入力が対応されていない為 エラーが出る。このエラーはVSCの問題の為, コードには問題が無い。此処をfalseに変える事でエラーを防止できる

    /// <summary>Typeで指定されているコードを実行する</summary>
    static void Main(string[] args)
    {
        SampleType type;
        if (IsTypeFixed) type = ConstType;
        else
        {
            int maxValue = Enum.GetValues(typeof(SampleType)).Cast<int>().Max();
            StringBuilder typeText = new();
            for (int i = 0; i <= maxValue; i++) typeText.AppendLine($"{i} => {(SampleType)i}");
            typeText.AppendLine();

            Console.WriteLine(typeText.ToString());
            Console.WriteLine("Type?");
            if (int.TryParse(Console.ReadLine(), out int typeNumber) && 0 < typeNumber && typeNumber < maxValue) type = (SampleType)typeNumber;
            else
            {
                Main(args);
                return;
            }
        }

        switch (type)
        {
            case SampleType.None:
                Console.WriteLine($"未選択です");
                break;
            case SampleType.TestConstructor_Capsule:
                TestConstructor.Capsule.TestConstructor.WriteConsole(args);
                break;
            case SampleType.TestConstructor_AbleNew:
                TestConstructor.AbleNew.TestConstructor.WriteConsole(args);
                break;
            default:
                Console.WriteLine($"Typeが正常に登録されていません。");
                break;
        }

        Console.WriteLine($"\nキー操作で終了");

        // VSCodeのデバッグコンソールでは, 入力が対応されていない為 エラーが出る。このエラーはVSCの問題の為, コードには問題が無い。
        if (IsWaitingEnd) Console.ReadKey();
    }

    internal enum SampleType
    {
        None,
        TestConstructor_Capsule,
        TestConstructor_AbleNew,
    }
}
