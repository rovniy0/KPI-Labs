% 16. Шурин (брат дружини)

% Факти про шлюби
marriage(mike, mary).  % Майк одружений з Мері

marriage(adam, ann).   % Адам одружений з Енн і у них є син ДІК і дочка МЕРІ
marriage(bob, kate).   % Боб одружений з Кейт і у них є син МАЙК

% Факти про батьківство
is_parent(adam, dick). % Адам - батько Діка
is_parent(ann, dick).  % Енн - мати Діка
is_parent(adam, mary). % Адам - батько Мері
is_parent(ann, mary).  % Енн - мати Мері
is_parent(bob, mike).  % Боб - батько Майка
is_parent(kate, mike). % Кейт - мати Майка



% Факти про стать
is_male(mike).  % Майк - чоловік
is_male(adam).  % Адам - чоловік
is_male(dick).  % Дік - чоловік
is_male(bob).   % Боб - чоловік
is_female(mary). % Мері - жінка
is_female(ann).  % Енн - жінка


% Шурин (брат дружини)
is_brother_in_law(Brother, Husband) :-
    marriage(Husband, Wife),          % Чоловік одружений з дружиною
    is_parent(Parent, Wife),         % Дружина має батька або матір
    is_parent(Parent, Brother),      % Брат має того ж батька або матір
    Brother \= Wife,                 % Брат не є дружиною
    is_male(Brother).                % Брат - чоловік


%?- is_brother_in_law(Brother, mike).
% Brother = dick ;  % Дік - шурин Майка

% ?- is_brother_in_law(dick, mike).
% true.