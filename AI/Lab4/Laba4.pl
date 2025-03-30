% Головна функція  Xmin --> Xmax
f(Xmin, Xmax, H, N, [F | Fs]) :-
    Xmin =< Xmax ->
    (X1min is Xmin + H,
     f_calculation(Xmin, N, F),
     f(X1min, Xmax, H, N, Fs));
    true.

% основний вираз
f_calculation(X, N, F) :-
    Base is (1 + X) / (1 + X**3),
    cycle_calculation(X, N, 3, 1, Prod),
    F is Base * Prod.

% рекурсія для i від 3 до N
cycle_calculation(_, N, I, Acc, Acc) :- I > N, !.
cycle_calculation(X, N, I, Acc, Prod) :-
    Term is I**0.5 - X,
    (Term =:= 0 -> Acc1 is Acc; Acc1 is Acc * Term),  % * 0 бо якшо i значення sqrt(i) - X дасть 0 то все стане 0
    I1 is I + 1,
    cycle_calculation(X, N, I1, Acc1, Prod).
