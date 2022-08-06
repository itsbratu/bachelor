%a. Sa se scrie un predicat care determina cel mai mic multiplu comun ale elementelor unei liste 
%	formate din numere intregi.

%GCD(X : Integer > 0 , Y : Integer > 0 , D : Integer > 0)
%(i,i,o) - determinist
%X - primul numar
%Y - al doilea numar
%D - cel mai mare divizor comun al lui X si Y
gcd(0 , D , D):-D > 0 , !.
gcd(X, Y, D):- X >= Y, X1 is X-Y, gcd(X1,Y,D).
gcd(X, Y, D):- X < Y, X1 is Y-X, gcd(X1,X,D).

%LCM(X : Integer , Y : Integer , M > 0 : Integer)
%(i , i , o) - determinist
%X - primul numar
%Y - al doilea numar
%M - cel mai mic multiplu comun al lui X si Y
lcm(X , Y , M):-gcd(abs(X) , abs(Y) , GCD) , M is abs(X*Y)/GCD.

%LIST_LENGTH(L = l1l2...ln : List , LUNG : Integer)
%(i , i , o) - determinist
%l1l2...ln - lista de numere intregi
%L - lungimea listei
list_length([] , 0).
list_length([_|T] , LUNG) :- list_length(T , LEN) , LUNG is LEN+1.

%LCM_LIST(L = l1l2l3...ln : List , M : Integer , R : Integer)
%(i , i , o) - determinist
%l1l2l3...ln - lista cu numere intregi
%M - variablia auxiliara pentru determinarea succesiva a cmmmc pentru lista data
%R - cel mai mic multiplu comun al numerelor l1l2...ln

lcm_list([] , _ , []):-false.
lcm_list([H|T] , M , R):- list_length(T , LEN) , LEN == 0 , M == 1 ,R is H.
lcm_list([H|T] , M , R):- list_length(T , LEN) , LEN == 0 , M \== 1 , lcm(H , M , CURR_LCM) , R is CURR_LCM.
lcm_list([H|T] , M , R):- lcm(H , M , REZ) , lcm_list(T , REZ , R).


%LCM_LIST_WRAPPER(L = l1l2l3...ln : List , MC : Integer)
%(i , i , o)  - determinist
%l1l2...ln - lista cu numere intregi
%MC - cel mai mic multiplu comun al elementelor l1,l2,...,ln
lcm_list_wrapper(L , MC):- lcm_list(L , 1 , R) , MC is R.
