process_matrix(Matrix, Result) :-
    length(Matrix, N),
    N >= 2,
    I1 is 0,
    I2 is 1,
    J1 is N - 1,
    J2 is N - 2,
    I3 is N - 2,
    I4 is N - 1,
    J3 is 1,
    J4 is 0,

    get_elem(Matrix, I1, J1, E1),
    get_elem(Matrix, I2, J2, E2),
    get_elem(Matrix, I3, J3, E3),
    get_elem(Matrix, I4, J4, E4),

    % E1 <-> E2, E4 <-> E3
    set_elem(Matrix, I1, J1, E2, M1),
    set_elem(M1, I2, J2, E1, M2),
    set_elem(M2, I4, J4, E3, M3),
    set_elem(M3, I3, J3, E4, Result).

get_elem(Matrix, RowIdx, ColIdx, Elem) :-
    nth0(RowIdx, Matrix, Row),
    nth0(ColIdx, Row, Elem).

set_elem(Matrix, RowIdx, ColIdx, NewElem, NewMatrix) :-
    nth0(RowIdx, Matrix, Row),
    replace_in_list(Row, ColIdx, NewElem, NewRow),
    replace_in_list(Matrix, RowIdx, NewRow, NewMatrix).

replace_in_list([H|T], I, X, [H|R]) :-
    I > 0,
    I1 is I - 1,
    replace_in_list(T, I1, X, R).

% process_matrix(
%  [[11,12,13,14],
%   [15,16,17,18],
%   [19,20,21,22],
%   [23,24,25,26]], Res).

% process_matrix([[11,12,13,14],[15,16,17,18],[19,20,21,22],[23,24,25,26]], Res).


