men([viktor, mykola, petro, leonid, dmytro]).
women([masha, olena, olga, natasha, anna]).

danced(mykola, natasha).
danced(mykola, masha).
danced(petro, olga).
danced(petro, olena).
danced(dmytro, masha).
danced(dmytro, anna).

% карти1: Віктор, Микола, Ольга, Анна
first_game([viktor, mykola, olga, anna]).

% карти2: Віктор, Микола, Маша, Петро
second_game([viktor, mykola, masha, petro]).

not_danced_with_wife(Husband, Wife) :-
    \+ danced(Husband, Wife).

not_played_with_wife(Husband, Wife) :-
    first_game(Game1),
    second_game(Game2),
    \+ (member(Husband, Game1), member(Wife, Game1)),
    \+ (member(Husband, Game2), member(Wife, Game2)).

solve(Pairs) :-
    men(Men),
    women(Women),
    permutation(Women, ShuffledWomen), 
    pairs(Men, ShuffledWomen, Pairs), 
    valid(Pairs).                     


pairs([], [], []).
pairs([M|Ms], [W|Ws], [(M,W)|Pairs]) :-
    pairs(Ms, Ws, Pairs).

valid([]).
valid([(Husband,Wife)|Rest]) :-
    not_danced_with_wife(Husband, Wife),
    not_played_with_wife(Husband, Wife),
    valid(Rest).

% ?- solve(Pairs).
