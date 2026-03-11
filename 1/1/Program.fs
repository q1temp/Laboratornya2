open System

let rec readList () =
    printf "Введите номер дня недели (1-7) или пустая строка для окончания: "
    match Console.ReadLine() with
    | null | "" -> []
    | s ->
        match Int32.TryParse(s.Trim()) with
        | true, n when n >= 1 && n <= 7 ->
            let rest = readList()
            n :: rest
        | _ ->
            printfn "Ошибка: введите целое число от 1 до 7."
            readList()

let getDayName = function
    | 1 -> "Понедельник"
    | 2 -> "Вторник"
    | 3 -> "Среда"
    | 4 -> "Четверг"
    | 5 -> "Пятница"
    | 6 -> "Суббота"
    | 7 -> "Воскресенье"
    | _ -> "Неверный день"

[<EntryPoint>]
let main argv =
    let numbers = readList()
    if numbers = [] then
        printfn "Список пуст."
    else
        let days = List.map getDayName numbers
        days |> List.iter (printfn "%s")
    0

