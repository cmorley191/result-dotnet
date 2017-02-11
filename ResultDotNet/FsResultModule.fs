namespace ResultDotNet.FSharp

module Result =
  open System
  open ResultDotNet
  open FuncTransforms
  
  let bind (onSuccess : 'tVal -> Result<'a, 'tErr>) (result:Result<'tVal, 'tErr>) = 
    result.Bind (toCSharpFunc onSuccess)

  let bind2 onSuccess result1 result2 =
    result1 |> bind (fun r1 -> 
      result2 |> bind (fun r2 -> 
        onSuccess r1 r2))

  let bind3 onSuccess result1 result2 result3 =
    result1 |> bind (fun r1 ->
      result2 |> bind (fun r2 -> 
        result3 |> bind (fun r3 ->
          onSuccess r1 r2 r3)))

  let bind4 onSuccess result1 result2 result3 result4 =
    result1 |> bind (fun r1 ->
      result2 |> bind (fun r2 ->
        result3 |> bind (fun r3 ->
          result4 |> bind (fun r4 ->
            onSuccess r1 r2 r3 r4))))

  let map (onSuccess : 'tVal -> 'a) (result:Result<'tVal, 'tErr>) = 
    result.Map (toCSharpFunc onSuccess)

  let map2 onSuccess result1 result2 = 
    result1 |> bind (fun r1 ->
      result2 |> map (fun r2 ->
        onSuccess r1 r2))

  let map3 onSuccess result1 result2 result3 = 
    result1 |> bind (fun r1 ->
      result2 |> bind (fun r2 ->
        result3 |> map (fun r3 ->
          onSuccess r1 r2 r3)))

  let map4 onSuccess result1 result2 result3 result4 =
    result1 |> bind (fun r1 ->
      result2 |> bind (fun r2 ->
        result3 |> bind (fun r3 ->
          result4 |> map (fun r4 ->
            onSuccess r1 r2 r3 r4))))