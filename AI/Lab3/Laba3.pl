% Якщо 1 < X < 2
f(X, F) :- 
    X > 1, X < 2, 
    sum_kx(X, 1, 7, F), !.
% Якщо X > 2
f(X, F) :- 
    X > 2, 
    factorial(X, FactX),
    sum_factorials(FactX, 1, 7, F), !.
% сума kX для 1<k<7
sum_kx(_, 8, _, 0) :- !.
sum_kx(X, K, Max, Sum) :-
    K =< Max,
    Term is K * X,
    K1 is K + 1,
    sum_kx(X, K1, Max, Sum1),
    Sum is Term + Sum1.

% Правило для факторіала
factorial(0, 1) :- !.
factorial(N, F) :- 
    N > 0, 
    N1 is N - 1,
    factorial(N1, F1),
    F is N * F1.

% сума факторіалів X! для для 1<k<7
sum_factorials(_, 8, _, 0) :- !.
sum_factorials(FactX, K, Max, Sum) :-
    K =< Max,
    K1 is K + 1,
    sum_factorials(FactX, K1, Max, Sum1),
    Sum is FactX + Sum1.
