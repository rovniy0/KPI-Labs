% Динамічна декларація
:- dynamic point/3.

% Додати точки
add_points :-
    assert(point(a, 1, 2)),
    assert(point(b, 2, 4)),
    assert(point(c, 3, 8)),
    assert(point(d, 5, 7)),
    assert(point(e, 6, 10)),
    assert(point(g, -1, -3)).


inside_parabola(X0, Y0, P, X, Y) :-
    DX is X - X0,
    DY is Y - Y0,
    DX * DX < 2 * P * DY.

points_inside_parabola(X0, Y0, P, PointsInside) :-
    findall(Sign, 
        (point(Sign, X, Y), inside_parabola(X0, Y0, P, X, Y)), 
        PointsInside).

% ?- add_points, points_inside_parabola(0, 0, 2, Res).
