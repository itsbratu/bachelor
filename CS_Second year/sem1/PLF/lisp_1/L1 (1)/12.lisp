(defun produs(a b)
	(cond
		((OR (null a) (null b)) 0)
		(t (+ (* (CAR a) (CAR b)) (produs (CDR a) (CDR b))))
	)
)

(defun maxim(a m)
	(cond
		((null a) m)
		((LISTP (CAR a)) (max (maxim (CAR a) m) (maxim (CDR a) m)))
		((> (CAR a) m) (maxim (CDR a) (CAR a)))
		(t (maxim (CDR a) m))
	)
)

(defun lungime(a)
	(cond
		((null a) t)
		((null (CDR a)) nil)
		(t (lungime (CDDR a)))
	)
)
