% Завдання: 9 мух на дошці 9x9, без конфліктів (як 9 ферзів),
% потім 3 з них переміщуються у сусідні клітинки, і знову всі без конфліктів

% Допоміжні предикати
range(1).
range(2).
range(3).
range(4).
range(5).
range(6).
range(7).
range(8).
range(9).

% Генерація числа від 1 до 9
in_range(N) :- range(N).

% Генерація валідної розстановки 9 мух
valid_position([], []).
valid_position([Row|Rows], [Col|Cols]) :-
    valid_position(Rows, Cols),
    in_range(Col),
    \+ member(Col, Cols), % унікальні колонки
    safe(Row, Col, Rows, Cols).

% Перевірка діагоналей
safe(_, _, [], []).
safe(R1, C1, [R2|Rs], [C2|Cs]) :-
    abs(R1 - R2) =\= abs(C1 - C2),
    safe(R1, C1, Rs, Cs).

% Генерація всієї розстановки: список мух у вигляді (Row, Col)
generate_positions(Positions) :-
    findall(N, in_range(N), Rows),
    valid_position(Rows, Cols),
    pairs(Rows, Cols, Positions).

pairs([], [], []).
pairs([R|Rs], [C|Cs], [(R,C)|Ps]) :- pairs(Rs, Cs, Ps).

% Сусідні клітинки (включно по діагоналі)
neighbour((R,C), (R2,C2)) :-
    between(-1,1,DR), between(-1,1,DC),
    (DR =\= 0 ; DC =\= 0),
    R2 is R + DR, C2 is C + DC,
    in_range(R2), in_range(C2).

% Замінити 3 мух на інші клітинки
move_three(Original, New) :-
    select(M1, Original, Rest1),
    select(M2, Rest1, Rest2),
    select(M3, Rest2, Fixed),
    neighbour(M1, N1), \+ member(N1, Original),
    neighbour(M2, N2), \+ member(N2, Original),
    neighbour(M3, N3), \+ member(N3, Original),
    append(Fixed, [N1,N2,N3], New),
    no_conflicts(New).

% Перевірка, що мухи не конфліктують
no_conflicts(Positions) :-
    maplist(arg(1), Positions, Rows),
    maplist(arg(2), Positions, Cols),
    all_unique(Cols),
    safe_all(Positions).

all_unique([]).
all_unique([X|Xs]) :- \+ member(X, Xs), all_unique(Xs).

safe_all([]).
safe_all([(R,C)|Rest]) :-
    maplist(no_diag_conflict((R,C)), Rest),
    safe_all(Rest).

no_diag_conflict((R1,C1), (R2,C2)) :- abs(R1 - R2) =\= abs(C1 - C2).

% Основний предикат для пошуку розв'язку
solve(Initial, Moved) :-
    generate_positions(Initial),
    move_three(Initial, Moved).

% Запит: ?- solve(I, M).
