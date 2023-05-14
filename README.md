## When "publishing" from Visual Studio, "Global Use" is not added under certain conditions.

## Summary

When using the Publish function from the Visual Studio GUI, publishing fails under at least the following conditions

1. WPF project
2. contains MainWindow.xaml (App.xaml is fine)
3. it references a NuGet package that automatically adds "global using
4. using class 3 without explicitly specifying "using".
5. not specifying RuntimeIdentifier in WPF project.
6. you issue the target runtime specifying something other than "portable

If any one of the above conditions is different, the issue will succeed.

If RuntimeIdentifiers is specified instead of RuntimeIdentifier, it will fail.

## Direct Cause

GlobalUsings.g.cs is not passed as an argument to csc.exe when all of the above conditions are met.

! [](resources/diff.png)

Please refer to the logs stored under the resources folder.

## Workaround

The workaround is as follows:

1. use the "dotnet publish" command from the console.
2. specify RuntimeIdentifier on the WPF side
3. specify RuntimeIdentifier or RuntimeIdentifiers on the WPF side and publish using the MSBuild command.

If you want to issue both win-x86 and win-x64, 2 is not available and 1 or 3 must be used.

MSBuild requires that the RuntimeIdentifier or RuntimeIdentifiers be specified in .csproj if the target runtime is specified when issuing. However, Visual Studio does not check for its existence, and the execution itself is possible. I feel there is another problem here.

## How to reproduce

Open the solution in this repository.

1. MainWindowXamlExists
2. MainWindowXamlNotExists

1 will result in an error on issue, while 2 will not. The only difference is the presence or absence of MainWindow.xaml, except for the project name, which causes an error if MainWindow.xaml is present.

! [](resources/diff2.png)

## Desired Countermeasure

- Publishing should work with the target runtime specified in RuntimeIdentifiers.

Currently, you can publish without RuntimeIdentifier without MainWindow.xaml, but MSBuild cannot publish without RuntimeIdentifier or RuntimeIdentifiers. Why don't you adjust to the same specification?

Translated with www.DeepL.com/Translator (free version)