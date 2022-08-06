%Fiind dat un numar natural n pozitiv , se cere sa se determine toate
%descompunerile sale ca suma de numere prime distincte

%DIVISIBLE(X : Integer , Y : Integer)
%(i , i) - determinist
%X - primul numar
%Y - al doilea numar
%Verifica daca toate numerele de la Y la X sunt divizible cu X
%Ajuta la determinarea naturii prime a unui numar
divisible(X,Y) :- 0 is X mod Y, !.
divisible(X,Y) :- X > Y+1, divisible(X, Y+1).

%ISPRIME(X : Integer)
%(i) - determinist
%X - numarul pentru care se verifica daca este prim sau nu
isPrime(2) :- true,!.
isPrime(X) :- X < 2,!,false.
isPrime(X) :- not(divisible(X, 2)).

%MEMBER(L : List , E : Integer)
%(o , i) - determinist
%L - lista la care se adauga un nou membru(candidat al solutiei)
%E - candidatul solutiei curente
member([E|_],E).
member([_|T],E):-member(T,E).

%DOLIST(N : Integer , L : List)
%(i , o) - determinist
%N - intreg care reprezinta maximul din lista formata
%L - lista formata cu toate numerele de la 2 la N
doList(N, L):- 
  findall(Num, between(2, N, Num), L).

%SOLUTION(L : List , N : Integer , R : List)
%(i , i , o) - nedeterminist
%L - lista din care extragem candidatii solutiei
%N - valoarea dorita pentru suma candidatiilor solutiei
%R - lista formata din numerele care compun solutia
solution(L,N,R):-
    member(L,E),
    isPrime(E),
    E=<N,
    solutionAux(L,N,R,[E],E).

%SOLUTIONAUX(L : List , N : Integer , R : List , Raux : List , S : Integer)
%(i , i , o , i , i) - nedeterminist
%L - lista din care extragem candidatii solutiei
%N - valoarea dorita pentru suma candidatiilor solutiei
%R - lista formata din numerele care compun solutia
%Raux - solutia de la pasul curent al bkt
%S - suma dorita a nr din solutia curent
solutionAux(_,N,R,R,N):-!.
solutionAux(L,N,R,[H|C],S):-
    member(L,E),
    isPrime(E),
	E < H,
    S1 is S+E,
    S1 =< N,
    solutionAux(L,N,R,[E|[H|C]],S1).

%SOLUTION_WRAPPER(N : Integer , R : List)
%(i , o) - nedeterminist
%N - numarul pentru care cautam solutii(sume de nr prime distincte)
%R - rezultatul problemei(lista)
solution_wrapper(N , R):-
    doList(N , L),
    solution(L , N , R).


