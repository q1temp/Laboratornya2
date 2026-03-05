let countNumbersWithKDigits numbers k =
    numbers 
    |> List.fold (fun count num -> 
        let digits = 
            if num = 0 then 1
            else string (abs num) |> String.length
        if digits = k then count + 1 else count
    ) 0

let rec readNumbers acc =
    printf "Введите число (или 'стоп' для завершения): "
    let input = System.Console.ReadLine()
    
    if input = "стоп" then
        List.rev acc
    else
        match System.Int32.TryParse(input) with
        | (true, v) -> readNumbers (v :: acc)
        | _ -> 
            printfn "Ошибка: введите целое число"
            readNumbers acc

[<EntryPoint>]
let main argv =
    printfn "Введите числа (для окончания введите 'стоп'):"
    let numbers = readNumbers []
    
    printf "Введите количество цифр (k): "
    let kInput = System.Console.ReadLine()
    
    match System.Int32.TryParse(kInput) with
    | (true, k) when k > 0 ->
        let result = countNumbersWithKDigits numbers k
        printfn "Результат: %d" result
    | _ ->
        printfn "Ошибка: введите положительное число"
    
    0