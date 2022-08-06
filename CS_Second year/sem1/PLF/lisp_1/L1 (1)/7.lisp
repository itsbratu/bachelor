(defun liniara(l)
	(cond
		((null l) t)
		((LISTP (CAR l)) nil)
		(t (liniara (CDR l)))
	)
)

(defun inlocuire(l a b n)
	(cond
		((null l) nil)
		((AND (equal (CAR l) a) (= n 1)) 
			(APPEND (LIST b) (inlocuire (CDR l) a b 0))
		)
		(t (APPEND (LIST (CAR l)) (inlocuire (CDR l) a b n)))
	)
)

(defun interclasare(a b)
	(cond
		((null a) b)
		((null b) a)
		((< (CAR a) (CAR b)) (CONS (CAR a) (interclasare (CDR a) b)))
		((> (CAR a) (CAR b)) (CONS (CAR b) (interclasare a (CDR b))))
		((= (CAR a) (CAR b)) (APPEND (LIST (CAR a)) (interclasare (CDR a) (CDR b))))
	)
)
