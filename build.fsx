#r "nuget: Fun.Build, 0.3.0"
#r "nuget: Fake.IO.FileSystem, 5.23.1"
#r "nuget: Fake.Core.Environment, 5.23.1"
#r "nuget: Fake.Tools.Git, 5.23.1"
#r "nuget: Fake.Api.GitHub, 5.23.1"
#r "nuget: SimpleExec, 11.0.0"
#r "nuget: BlackFox.CommandLine, 1.0.0"

open Fun.Build
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators

module Glob =

    open Fake.IO.FileSystemOperators

    let fableJs baseDir = baseDir </> "**/*.fs.js"
    let fableJsMap baseDir = baseDir </> "**/*.fs.js.map"
    let js baseDir = baseDir </> "**/*.js"
    let jsMap baseDir = baseDir </> "**/*.js.map"

module Stages =

    let clean =
        stage "Clean" {
            run (fun _ ->
                [
                    "Demo/bin"
                    "Demo/obj"
                    "Package/bin"
                    "Package/obj"
                ]
                |> Shell.cleanDirs
            )

            run (fun _ ->
                !!(Glob.fableJs "Demo")
                ++ (Glob.fableJsMap "Demo")
                ++ (Glob.fableJs "Package")
                ++ (Glob.fableJsMap "Package")
                |> Seq.iter Shell.rm
            )
        }

    let pnpmInstall = stage "Pnpm install" { run "pnpm install" }

pipeline "Dev" {

    Stages.clean
    Stages.pnpmInstall
    noPrefixForStep

    stage "Watch" {
        paralle
        workingDir "Demo"

        run "npx vite dev"
        run "dotnet fable --watch"
    }

    runIfOnlySpecified
}

tryPrintPipelineCommandHelp ()
