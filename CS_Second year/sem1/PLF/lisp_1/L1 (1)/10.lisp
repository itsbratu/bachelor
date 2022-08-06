(defun produs(l)
	(cond
		((null l) 1)
		((NUMBERP (CAR l)) (* (CAR l) (produs (CDR l))))
		(t (produs (CDR l)))
	)
)

(defun perechi(a b)
	(cond
		((null a) nil)
		((null (CADDR a)) (LIST (CAR a) (CADR a)))
		((null b) (perechi (CDR a) (CADDR a)))
		(t (LIST (LIST (CAR a) (CAR b)) (perechi a (CDR b))))
	)
)

