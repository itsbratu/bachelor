
%b. Sa se scrie un predicat care adauga dupa : 
%1-ul, al 2-lea, al 4-lea, al8-lea ...element al unei liste o valoare vdata.
%
%ADD_POW2(L = l1l2...ln : List , v : Integer , m (>=0) : Integer , p(>0) : Integer , R = l1l2...lm : List)
%(i , i , i , i , o) - determinist
%L - lista initiala de numere intregi
%v - valoarea intreaga care trebuie adaugata
%m - exponentul curent al puterii lui 2
%p - valoarea curenta a puterii
%R - lista obtinuta prin adaugarea valorii v
add_pow([] , _ , M , _ , _) :- M > 0, !.
add_pow([] , V , M , _ , R) :- M = 0 , R is V.
add_pow(L , V , M , P , [V|R]) :- M = 0 , P \= 0 , P1 is 2*P , add_pow(L , V , P1 , P1 ,R).
add_pow(L , V , M , P , [V|R]) :- M = 0 , P = 0 , add_pow(L , V , 1 , 1 , R).
add_pow([H|T] , V , M , P , [H|R]) :- M1 is M-1 , add_pow(T , V , M1 , P , R).

%POW_WRAPPER(L = l1l2...ln : List , v : Integer , R = l1l2l3...lm : List)
%(i , i , o) - determinist
%L - lista initiala de numere intregi
%v - valoarea intreaga care trebuie adaugata
%R - lista obtinuta prin adaugarea valorii v
pow_wrapper(L , v , REZ) :- add_pow(L , v , 1 , 0 , R) , REZ is R.
