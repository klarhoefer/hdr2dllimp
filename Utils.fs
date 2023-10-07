module Utils

let capitalize (name: string) =
    name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower()

let snake2pascal (name: string) =
    name.Split('_')
    |> Array.map capitalize
    |> String.concat ""
