% 16
% До збірки завдань контрольної роботи можуть увійти три завдання
% які відносяться до різних розділів однієї і тієї ж навчальної дисципліни

% Факти: завдання належать до різних розділів
task(algorithms, task1).
task(algorithms, task2).
task(algorithms, task3).
task(data_structures, task4).
task(data_structures, task5).
task(data_structures, task6).
task(databases, task7).
task(databases, task8).
task(databases, task9).

% Факти: розділи належать до конкретної дисципліни
section_discipline(algorithms, computer_science).
section_discipline(data_structures, computer_science).
section_discipline(databases, computer_science).

% Правило для створення збірки завдань
exam_collection(Discipline, Task1, Task2, Task3) :-
    task(Section1, Task1), task(Section2, Task2), task(Section3, Task3),
    section_discipline(Section1, Discipline),
    section_discipline(Section2, Discipline),
    section_discipline(Section3, Discipline),
    dif(Section1, Section2), dif(Section2, Section3), dif(Section1, Section3).

% ?- exam_collection(Discipline, Task1, Task2, Task3).
