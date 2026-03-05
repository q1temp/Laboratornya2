let rec readNumber () =
    printf "Введите номер дня недели (1-7): "
    match System.Int32.TryParse(System.Console.ReadLine()) with
    | true, number -> 
        if number >= 1 && number <= 7 then
            number
        else
            printfn "Ошибка: число должно быть в диапазоне от 1 до 7"
            readNumber()
    | false, _ -> 
        printfn "Ошибка: введите корректное число"
        readNumber()

let getDayName number =
    match number with
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
    let number = readNumber()
    let day = getDayName number
    
    printfn "День недели: %s" day
    0