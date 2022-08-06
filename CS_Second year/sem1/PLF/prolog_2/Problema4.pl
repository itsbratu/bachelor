%intercalate(List1:list,List2:list, Rez:list)
%List1: prima lista de numere intregi care trebuie interclasata
%List2: a doua lista de numere intregi care trebuie interclasata
%Rez : lista formata prin interclasarea list1 cu list2
%(i,i,0) - determinist

%Cazurile in care am terminat de parcurs o lista din cele doua.
intercalate([],L,L):-!.
intercalate(L,[],L):-!.

%Cazurile in care exista dubluri pe primele doua pozitii macar intr-o lista.
intercalate([H1,H1|T1],[H1,H1|T2],Rez):-!,intercalate([H1|T1],[H1|T2],Rez).
intercalate([H1 ,H1 | T1],[H2|T2],Rez):- H1 < H2,!,intercalate([H1|T1],[H2|T2],Rez).
intercalate([H1|T1],[H2 ,H2 | T2],Rez):- H1 > H2,!,intercalate([H1|T1],[H2|T2],Rez).

%Cazurile in care am eliminat toate dublurile precedente si putem adauga cu siguranta in lista finala.
intercalate([H1|T1],[H1|T2],Rez):- !,intercalate([H1|T1],T2,Rez).
intercalate([H1|T1],[H2|T2],[H1|Rez]):- H1 < H2,!,intercalate(T1,[H2|T2],Rez).
intercalate([H1|T1],[H2|T2],[H2|Rez]):- H1 > H2,!,intercalate([H1|T1],T2,Rez).

%intercalate_sublists(Lista1:List,Rez:List)
%lista1-lista de numere intregi 
%Rez- lista formata din interclasarea tuturor sublistelor din lista1
%(i,o) - determinist
intercalate_sublists([],[]).
intercalate_sublists([H|T],Rez):-number(H),!,intercalate_sublists(T,Rez).
intercalate_sublists([H|T],Rez1):-is_list(H),!,intercalate_sublists(T,Rez),intercalate(H,Rez,Rez1).










