%  recordZ
add_points :-
    recordz(db, point(a, 1, 2)),
    recordz(db, point(b, 2, 4)),
    recordz(db, point(c, 3, 8)),
    recordz(db, point(d, 5, 7)),
    recordz(db, point(g, 10, 3)),
    recordz(db, point(e, 6, 10)).

inside_parabola(X0, Y0, P, X, Y) :-
    DX is X - X0,
    DY is Y - Y0,
    DX * DX < 2 * P * DY.

% Знаходимо всі точки всередині параболи
points_inside_parabola_records(X0, Y0, P, PointsInside) :-
    findall(Sign, 
        (recorded(db, point(Sign, X, Y), _), inside_parabola(X0, Y0, P, X, Y)), 
        PointsInside).

% ?- add_points, points_inside_parabola_records(0, 0, 2, Res).

