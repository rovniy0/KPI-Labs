
range(1). range(2). range(3). range(4). range(5). range(6). range(7). range(8). range(9).

in_range(N) :- range(N).


valid_position([], []).
valid_position([Row|Rows], [Col|Cols]) :-
    valid_position(Rows, Cols),
    in_range(Col),
    \+ member(Col, Cols), 
    safe(Row, Col, Rows, Cols).

safe(_, _, [], []).
safe(R1, C1, [R2|Rs], [C2|Cs]) :-
    abs(R1 - R2) =\= abs(C1 - C2),
    safe(R1, C1, Rs, Cs).

generate_positions(Positions) :-
    findall(N, in_range(N), Rows),
    valid_position(Rows, Cols),
    pairs(Rows, Cols, Positions).

pairs([], [], []).
pairs([R|Rs], [C|Cs], [(R,C)|Ps]) :- pairs(Rs, Cs, Ps).



neighbour((R,C), (R2,C2)) :-
    between(-1,1,DR), between(-1,1,DC),
    (DR =\= 0 ; DC =\= 0),
    R2 is R + DR, C2 is C + DC,
    in_range(R2), in_range(C2).



val_state(State, Score) :-
    findall((M1,M2), (select(M1, State, Rest), member(M2, Rest), conflict(M1, M2)), Conflicts),
    length(Conflicts, Score).

conflict((R1,C1), (R2,C2)) :-
    R1 =:= R2 ; C1 =:= C2 ; abs(R1 - R2) =:= abs(C1 - C2).



move(State, MoveIndex-MoveTo) :-
    nth1(Index, State, M),
    neighbour(M, MoveTo),
    \+ member(MoveTo, State),
    MoveIndex is Index.

update(State, Index-MoveTo, NewState) :-
    nth1(Index, State, _, Rest),
    nth1(Index, NewState, MoveTo, Rest).

legal(State) :-
    maplist(in_range_pos, State).

in_range_pos((R,C)) :- in_range(R), in_range(C).

% --- HILL CLIMBING ---

hill_climb(0-_, _, []) :- !.

hill_climb(_-State, History, [Move | Moves]) :-
    setof(Eval-NewState-Move, (
        move(State, Move),
        update(State, Move, NewState),
        legal(NewState),
        val_state(NewState, Eval)
    ), NextMoves),
    member(Val-State1-Move, NextMoves),
    \+ member(State1, History),
    hill_climb(Val-State1, [State1|History], Moves).


random_3_moves(State, NewState) :-
    random_permutation(State, [M1, M2, M3 | Rest]),
    neighbour(M1, M1New), \+ member(M1New, State),
    neighbour(M2, M2New), \+ member(M2New, State),
    neighbour(M3, M3New), \+ member(M3New, State),
    append(Rest, [M1New, M2New, M3New], NewState).


main(Initial, Moves) :-
    generate_positions(Solved),            % згенерувати ідеальний стан
    random_3_moves(Solved, Initial),       % зіпсувати його 3-ма випадковими мухи
    val_state(Initial, Score),
    Score > 0,                             % якщо є конфлікти — запускаємо пошук
    hill_climb(Score-Initial, [Initial], Moves).

%main(Initial, Moves).
