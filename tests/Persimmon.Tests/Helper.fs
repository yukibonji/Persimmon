﻿namespace Persimmon.Tests

open System.IO
open System.Diagnostics

open Persimmon
open Persimmon.Runner
open Persimmon.Output
open Persimmon.Internals

module Helper =

  let run (x: TestCase<_>) = x.Run()

  let shouldPassed<'T when 'T : equality> (expected: 'T) (x: TestCase<'T>) =
    let inner = function
      | Done (m, (Persimmon.Passed (actual: 'T), []), d) -> Done (m, (assertEquals expected actual, []), d)
      | Done (m, results, d) -> Done (m, results |> NonEmptyList.map (function
        | Passed _ -> Passed ()
        | NotPassed(l, x) -> NotPassed(l, x)), d)
      | Error (m, es, results, d) -> Error (m, es, results, d)
    TestCase.initForSynch x.Name x.Parameters (fun _ -> inner (run x))

  let shouldNotPassed<'T> (expectedMessages: NonEmptyList<string>) (x: TestCase<'T>) =
    let inner = function
      | Done (m, (Persimmon.Passed (actual: 'T), []), d) ->
        Done (m, (fail (sprintf "Expect: Failure\nActual: %A" actual), []), d)
      | Done (m, results, d) ->
        results
        |> NonEmptyList.map (function NotPassed(_, (Skipped x | Violated x)) -> x | Persimmon.Passed x -> sprintf "Expected is NotPased but Passed(%A)" x)
        |> fun actual -> Done (m, (assertEquals expectedMessages actual, []), d)
      | Error (m, es, results, d) -> Error (m, es, results, d)
    TestCase.initForSynch x.Name x.Parameters (fun _ -> inner (run x))

  let shouldEqualErrorCount expected xs =
    use printer = new Printer<_>(new StringWriter(), Formatter.ProgressFormatter.dot)
    (xs |> TestRunner.runAllTests printer.Print).Errors
    |> assertEquals expected

  let shouldFirstRaise<'T, 'U when 'T :> exn> (x: TestCase<'U>) =
    let inner = function
      | Done (m, (Persimmon.Passed (actual: 'U), []), d) ->
        Done (m, (fail (sprintf "Expect: raise %s\nActual: %A" (typeof<'T>.Name) actual), []), d)
      | Done (m, results, d) -> Done (m, results |> NonEmptyList.map (function
        | Passed _ -> Passed ()
        | NotPassed(l, x) -> NotPassed(l, x)), d)
      | Error (m, [], results, d) ->
        Done (m, (fail (sprintf "Expect: raise %s\nActual: not raise exception" (typeof<'T>.Name)), []), d)
      | Error (m, x::_, results, d) -> Done (m, (assertEquals typeof<'T> (x.GetType()), []), d)
    TestCase.initForSynch x.Name x.Parameters (fun _ -> inner (run x))
