namespace System
open System.Reflection
open System.Runtime.CompilerServices
open System.Runtime.InteropServices

[<assembly: AssemblyTitleAttribute("Persimmon.Core")>]
[<assembly: AssemblyDescriptionAttribute("")>]
[<assembly: InternalsVisibleToAttribute("Persimmon.Core.Tests")>]
[<assembly: GuidAttribute("F5EB6EEA-FA93-4F0D-9C23-60A91DB012DB")>]
[<assembly: AssemblyProductAttribute("Persimmon")>]
[<assembly: AssemblyVersionAttribute("2.0.0")>]
[<assembly: AssemblyFileVersionAttribute("2.0.0")>]
[<assembly: AssemblyInformationalVersionAttribute("2.0.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "2.0.0"
