// For more information see https://aka.ms/fsharp-console-apps
// printfn "Hello from F#"


open CppAst
open Utils

let rec convType (t: string) =
    match t with
    | "State*" -> "IntPtr"
    | "real_T" -> "double"
    | "real32_T" -> "float"
    | "int32_T" -> "int"
    | "uint32_T" -> "uint"
    | _ when t.EndsWith("*") -> (convType t[..t.Length - 2]) + "[]"
    | _ -> t

let convParam (param: CppParameter) =
    sprintf "%s %s" (convType param.Type.FullName) param.Name


let convFun (fn: CppFunction) =
    let parameters =
        fn.Parameters
        |> Seq.map convParam
        |> String.concat ", "
    printfn "[DllImport(LibName, CallingConvention = CallingConvention.Cdecl, EntryPoint = \"%s\")]" fn.Name
    printfn "public static extern %s %s(%s);" (convType fn.ReturnType.FullName) (snake2pascal fn.Name) parameters

let compilation = CppParser.ParseFile("somelib.h")
for fn in compilation.Functions do
    convFun fn
