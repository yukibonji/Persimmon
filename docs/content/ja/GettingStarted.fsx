(*** hide ***)
// このコードブロックは生成された HTML ドキュメントでは省略されます。ドキュメントで
// 見せたくない補助的なものを定義するために使います。
#I "../../../Persimmon/bin/Release"
#I "../../../Persimmon.Runner/bin/Release"
#r "Persimmon"

(**
<div class="blog-post">

はじめに
========

Persimmon の概要、ダウンロードや使い方について。

プロジェクトの作成（またはサンプルプロジェクトの取得）
------------------------------------------------------

プロジェクトを作成する (そして NuGet パッケージの復元を有効化する) か、 [サンプルプロジェクト](https://github.com/persimmon-projects/Persimmon.Demo) をダウンロードしてください。

Persimmon コンソールランナーの入手
----------------------------------

以下のコマンドを実行しましょう。

    [lang=powershell]
    .\.nuget\NuGet.exe Install Persimmon.Console -OutputDirectory tools -ExcludeVersion

はじめの一歩
------------

 ``test`` コンピュテーション式とアサーションを用いてテストを書けます。

*)

open Persimmon

let ``some variable name`` = test "first test example" {
    do! assertEquals 0 (4 % 2)
}

(**

テストの実行
------------

以下のコマンドを実行しましょう。

    [lang=powershell]
    .\tools\Persimmon.Console\tools\Persimmon.Console.exe 'input file path'

例外テスト
----------

``trap`` は例外をキャッチできます。

*)

exception MyException

let ``exception test`` = test "exn test" {
  let f () =
    raise MyException
    42
  let! e = trap { it (f ()) }
  do! assertEquals "" e.Message
  do! assertEquals typeof<MyException> (e.GetType())
  do! assertEquals "" (e.StackTrace.Substring(0, 5))
}

(**

テストのパラメータ化
--------------------

Persimmon は パラメータ化されたテストに対応しています。

*)

let ``case parameterize test`` =
  parameterize {
    case (1, 1)
    case (1, 2) into (x, y)
    run (test "case parameterize test" {
      do! assertEquals x y
    })
  }

let inputs = [ 2 .. 2 .. 20 ]

let ``source parameterize test`` =
  let parameterizeTest x = test "source parameterize test" {
    do! assertEquals 0 (x % 2)
  }
  parameterize {
    source inputs into x
    run (parameterizeTest x)
  }

(**

テスト名の省略
--------------

``UseTestNameByReflection`` モジュールを open してください:

*)

open UseTestNameByReflection

(**

</div>
*)
