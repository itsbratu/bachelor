--1.Numarul utilizatorilor de pe fiecare strada din Cluj-Napoca
--Am folosit : WHERE , GROUP BY , INFO 2 sau mai multe TABELE 
SELECT Adrese.strada , 
	   COUNT(Useri.id_adresa) as numar_persoane
FROM Useri
INNER JOIN Adrese
ON Adrese.id = Useri.id_adresa
WHERE (Adrese.judet = 'Cluj') and (Adrese.localitate = 'Cluj-Napoca')
GROUP BY Adrese.strada

--2.Numarul soferilor asociati restaurantelor de un anumit tip cu rating > 7
--Am folosit : GROUP BY , HAVING , INFO 2 sau mai multe TABELE
SELECT Restaurante.tip as tip 
	, Restaurante.rating as rating 
	, COUNT(Soferi.id_sofer) as numar_soferi
From Soferi
INNER JOIN Restaurante
ON Soferi.id_sofer = Restaurante.id_livrator
GROUP BY tip , rating
HAVING (rating > 7)

--3.Numarul userilor cu valoarea tranzactiei> 100 
   --grupat pe data calendaristica si suma tranzactiei
--Am folosit : GROUP BY , HAVING , INFO 2 TABELE
SELECT COUNT(Useri.id_user) as numar_useri,
	   Tranzactii.data ,
	   Tranzactii.suma
FROM Tranzactii
INNER JOIN Useri
ON Tranzactii.id_user = Useri.id_user
GROUP BY Tranzactii.data , Tranzactii.suma
HAVING (Tranzactii.suma > 100)

--4.Toate perechile distincte judet-localitate unde numele localitatii incepe cu T/C
--Am folosit : DISTINCT , WHERE
SELECT DISTINCT Adrese.judet , Adrese.localitate
FROM Adrese
WHERE (Adrese.localitate LIKE 'C%' or Adrese.localitate LIKE 'T%')

--5.Toate modele distincte de masini care au marca 'Dacia' sau 'Tesla'
--Am folosit : DISTINCT , WHERE
SELECT DISTINCT Masini.marca , Masini.model
FROM Masini
WHERE (Masini.marca = 'Tesla' or Masini.marca = 'Dacia')
ORDER BY Masini.marca ASC , Masini.model DESC

--6.Numele soferilor , precum si date de start pentru comanda acestora
--iar prenumele incepe cu litera 'S'
--Am folosit : WHERE , INFO 2 TABELE , RELATIE M-N
SELECT s.nume 
	, s.prenume
	, c.locatie_initiala
	, c.timp_initial
From Soferi s
INNER JOIN ComenziActive ca on s.id_sofer = ca.id_livrator
INNER JOIN Comenzi c on ca.id_livrare = c.id_comanda
WHERE (s.prenume LIKE 'S%')

--7.Numele soferilor care au ca timp final pentru comanda o valoare intre 12 si 16
--Am folosit : WHERE , INFO 2 TABELE , RELATIE M-N
SELECT s.nume
	  ,s.prenume
	  ,c.timp_final
From Soferi s
INNER JOIN ComenziActive ca on s.id_sofer = ca.id_livrator
INNER JOIN Comenzi c on ca.id_livrare = c.id_comanda
WHERE (c.timp_final between '12:00:00.0000000' and '16:00:00.0000000')

--8.Numele soferilor ordonate impreuna cu masinile acestora inmatriculate in judetul Cluj
--Am folosit : INFO 2 TABELE , WHERE , ORDER BY
SELECT s.nume
	  ,s.prenume
	  ,m.marca
	  ,m.model
	  ,m.numar_inmatriculare
From Soferi s
INNER JOIN Masini m on s.id_sofer = m.id_sofer
WHERE m.numar_inmatriculare LIKE 'CJ%'
ORDER BY s.nume , s.prenume

--9.Soferii si numele restaurantelor de tip fast-food
--asociate acestora aflate la o distanta de maxim 5km
--Am folosit : INFO 2 TABELE , WHERE
SELECT s.id_sofer,
	   s.nume,
	   s.prenume,
	   r.nume,
	   r.distanta
From Soferi s
INNER JOIN Restaurante r on s.id_sofer = r.id_livrator
WHERE (r.tip = 'Fast food' and r.distanta < 5)

--10.Rating-urile de 4 si 5 stele oferite soferilor de catre utilizatori
--Am folosit : Relatie m-n , Info 2 tabele , WHERE
SELECT r.id_rating,
	   u.id_user,
	   s.id_sofer,
	   r.rating,
	   r.rating_msg
From Useri u
INNER JOIN Rating r on u.id_user = r.id_user
INNER JOIN Soferi s on r.id_sofer = s.id_sofer
WHERE (r.rating = 4 or r.rating = 5)

	   

