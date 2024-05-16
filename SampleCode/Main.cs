using System;
using System.Collections.Generic;

namespace SampleCode;
internal static class SampleCode
{
    /// <summary> 実行死体サンプルコードの選択 </summary>
    internal const SampleType Type = SampleType.TestConstructor_AbleNew;
    /// <summary> main処理終了後, コンソールを閉じる時にキー入力を待機するか </summary>
    // VSCodeのデバッグコンソールでは, 入力が対応されていない為 エラーが出る。このエラーはVSCの問題の為, コードには問題が無い。此処をfalseに変える事でエラーを防止できる。
    internal const bool IsWaitingEnd = true;

    /// <summary>Typeで指定されているコードを実行する</summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
        switch (Type)
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
