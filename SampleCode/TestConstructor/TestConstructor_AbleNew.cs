using System;
using System.Collections.Generic;

namespace SampleCode.TestConstructor.AbleNew;
internal static class TestConstructor
{
    internal static void WriteConsole(string[] args)
    {
        // # テキストセット状態のインスタンスの生成及び初期化 & 出力

        // ## 引数有のコンストラクタを使用
        Console.WriteLine("## 引数有のコンストラクタを使用\n");

        // ### インスタンス生成時に初期化
        SampleData sample_1 = new(null);
        Console.WriteLine($"sample_1_1 : Type = {sample_1.Type}, Text = {sample_1.Text}"); // => 正常
        // ### 再生成
        sample_1 = new("ReCreate.");
        Console.WriteLine($"sample_1_2 : Type = {sample_1.Type}, Text = {sample_1.Text}"); // => 正常
        Console.Write("\n");

        // ## インスタンス生成時に new演算子を使用して, コンストラクタで初期化後, インスタンス変数に値を代入する。
        SampleData sample_2 = new("Created.")
        {
            Text = null,
        };
        Console.WriteLine($"sample_2 : Type = {sample_2.Type}, Text = {sample_2.Text}"); // => 異常
        Console.Write("\n");

        // ## 明示したデフォルト(引数無し)のコンストラクタを使用 ( 初期化が正常に行われない場合 及び 異常値が入る場合がある )
        Console.WriteLine("## 明示したデフォルト(引数無し)のコンストラクタを使用\n");

        // ### インスタンス作成後, 初期化無し。
        SampleData sample_3 = new();
        Console.WriteLine($"sample_3 : Type = {sample_3.Type}, Text = {sample_3.Text}"); // => 異常 (Textが正常に初期化されず, nullのまま)
        Console.Write("\n");

        // ### インスタンス作成後, インスタンス変数に個別で 代入して初期化する。(正常値 => Type : None, Text : Unedited.)
        SampleData sample_4 = new() // 手動で値を代入している為, 不斉な値の代入も可能
        {
            Type = SampleData.DataType.Saved,
            Text = null,
        };
        Console.WriteLine($"sample_4 : Type = {sample_4.Type}, Text = {sample_4.Text}"); // => 異常 (Textがnullで初期化される時に実行するコードを通過しない為, 正常な値にならない。)
        Console.Write("\n");

        // ## 再代入と出力
        SampleData sample_5 = new(null); // 初期化
        Console.WriteLine($"sample_5_1 : Type = {sample_5.Type}, Text = {sample_5.Text}"); // => 正常
        sample_5.Text = "Reassignment."; // インスタンス変数に再代入
        Console.WriteLine($"sample_5_2 : Type = {sample_5.Type}, Text = {sample_5.Text}"); // => 異常 (Textに代入されているのに, TypeがNoneのまま)
        Console.Write("\n");
    }
}

class SampleData
{
    // インスタンス変数をprivateで宣言すると, 外部クラスから代入(new演算子利用時も含む)によって初期化する事ができなくなる。
    public DataType Type;
    public string Text;

    // 引数無し コンストラクタ (new演算子による初期化有効. 引数有コンストラクタを定義している為, 引数無しコンストラクタは明示が必要になる)
    public SampleData()
    {
    }

    // 引数あり コンストラクタ ((new演算子による初期化有効. 与えられたtextを元にTypeとTextに保存する)
    public SampleData(string text)
    {
        this.Type = text is not null and not "" ? DataType.Saved : DataType.None;
        this.Text = this.Type == DataType.Saved ? text : "Unedited.";
    }

    public enum DataType
    {
        None,
        Saved,
    }
}