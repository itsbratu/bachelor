(defun element(l n)
	(cond
		((null l) nil)
		((= n 1) (CAR l))
		(t (element (CDR l) (- n 1)))
	)
)

(defun unic(l e)
	(cond
		((null l) t)
		((equal (CAR l) e) nil)
		(t (unic (CDR l) e))
	)
)

(defun multime(l)
	(cond
		((null l) nil)
		((unic (CDR l) (CAR l)) (APPEND (LIST (CAR l)) (multime (CDR l))))
		(t (multime (CDR l)))
	)
)

(defun atomi(l)
	(cond
		((null l) nil)
		((LISTP (CAR l)) (APPEND (atomi (CAR l)) (atomi (CDR l))))
		(t (APPEND (LIST (CAR l)) (atomi (CDR l))))
	)
)

(defun wrapper(l)
	(multime (atomi l))
)

(defun eMultime(l)
	(cond
		((null l) t)
		((NOT (unic (CDR l) (CAR l))) nil)
		(t (eMultime (CDR l)))
	)
)
