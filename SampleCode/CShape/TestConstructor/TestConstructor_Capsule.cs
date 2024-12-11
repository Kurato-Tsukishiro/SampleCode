using System;
using System.Collections.Generic;

namespace SampleCode.TestConstructor.Capsule;
internal static class TestConstructor
{
    internal static void WriteConsole(string[] args)
    {
        // 初期状態のインスタンスの生成 & 出力
        SampleData sample_1 = SampleData.Initialization();
        Console.WriteLine($"sample_1 : {sample_1.GetText()}");

        // テキストセット状態のインスタンスの生成 & 出力
        SampleData sample_2 = SampleData.SetText("Setting.");
        Console.WriteLine($"sample_2 : {sample_2.GetText()}");

        // 再代入と出力
        SampleData sample_3 = SampleData.Initialization();
        Console.WriteLine($"sample_3_1 : {sample_3.GetText()}");
        sample_3 = SampleData.SetText("Changed.");
        Console.WriteLine($"sample_3_2 : {sample_3.GetText()}");
    }
}

class SampleData
{
    public DataType Type { get; }
    private string Text { get; }

    // コンストラクタ (アクセス修飾子:privateを使用し, new演算子による初期化を無効にしている)
    private SampleData(DataType type, string text) // 未初期化を防ぐ為 & ラムダ式でのインスタンス生成を可能にする為 引数を使用して初期化
    {
        this.Type = type;
        this.Text = text;
    }

    /// <summary>初期化, 初期状態の作成</summary>
    /// <returns>text未保存のSampleData</returns>
    public static SampleData Initialization() => new(DataType.None, null);

    /// <summary>Textの保存を行う。</summary>
    /// <returns>textの中身がある場合は保存済みの, 無い場合は初期状態のSampleDataを返却する</returns>
    public static SampleData SetText(string text) => text is not null and not "" ? new(DataType.Saved, text) : Initialization();

    /// <summary> Textの取得 (初期状態の場合 Testを"Unedited."として取得する。) </summary>
    /// <returns>SampleDataのtext</returns>
    public string GetText() => this.Type == DataType.Saved ? this.Text : "Unedited.";

    public enum DataType
    {
        None,
        Saved,
    }
}