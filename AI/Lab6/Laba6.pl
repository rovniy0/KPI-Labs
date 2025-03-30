rearrange_lists(List1, List2, Res) :-
    length(List1, Len1), length(List2, Len2),
    Len1 mod 2 =:= 0, Len2 mod 2 =:= 0,
    Half1 is Len1 // 2,
    Half2 is Len2 // 2,
    
    split_list(List1, Half1, First1, Second1),
    split_list(List2, Half2, First2, Second2),
    
    append([Second1, Second2, First1, First2], Res).

% сплітер
split_list(List, N, FirstHalf, SecondHalf) :-
    length(FirstHalf, N),
    append(FirstHalf, SecondHalf, List).

% rearrange_lists([1,2,3,4], [5,6,7,8], Res).