(defun duplicare(l n)
	(cond
		((null l) nil)
		((= n 1) (APPEND (LIST (CAR l)) (LIST (CAR l)) (duplicare (CDR l) (- n 1))))
		(t (APPEND (LIST (CAR l)) (duplicare (CDR l) (- n 1))))
	)
)

(defun asociere(a b)
	(cond
		((AND (null a) (null b)) nil)
		(t (APPEND (LIST (CONS (CAR a) (CAR b))) (asociere (CDR a) (CDR b))))
	)
)

(defun numarare(l)
	(cond
		((null l) 1)
		((ATOM (CAR l)) (numarare (CDR l)))
		((LISTP (CAR l)) (+ (numarare (CAR l)) (numarare (CDR l))))
	)
)

(defun atomi(l)
	(cond
		((null l) 0)
		((ATOM (CAR l)) (+ 1 (atomi (CDR l))))
		((LISTP (CAR l)) (atomi (CDR l)))
	)
)
