sum_middle_three(List, Sum) :-
    length(List, Len),
    Len mod 2 =:= 1, 
    MiddleIndex is Len // 2,
    nth0(MiddleIndex, List, Middle),       % Центральний елемент
    PrevIndex is MiddleIndex - 1,  
    NextIndex is MiddleIndex + 1,
    nth0(PrevIndex, List, Prev),           % Попередній елемент
    nth0(NextIndex, List, Next),           % Наступний елемент
    Sum is Prev + Middle + Next.           % Обчислюємо суму

% sum_middle_three([1, 3, 5, 7, 9], S).