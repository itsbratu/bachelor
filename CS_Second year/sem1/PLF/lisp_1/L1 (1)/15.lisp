(defun apare(l e)
	(cond
		((null l) nil)
		((= (CAR l) e) t)
		(t (apare (CDR l) e))
	)
)

(defun reuniune(a b col)
	(cond
		((NOT (NULL a)) (reuniune (CDR a) b (APPEND col (LIST (CAR a)))))
		((NOT (NULL b))
			(cond
				((apare col (CAR b)) (reuniune a (CDR b) col))
				(t (reuniune a (CDR b) (APPEND col (LIST (CAR b)))))
			)
		)
		((NULL b) col)
	)
)

(defun produs(l)
	(cond
		((null l) 1)
		((LISTP (CAR l)) (* (produs (CAR l)) (produs (CDR l))))
		(t (* (CAR l) (produs (CDR l))))
	)
)

(defun interclasare(a b)
	(cond
		((null a) b)
		((null b) a)
		((eq b '(NIL)) a)
		((< (CAR a) (CAR b)) (CONS (CAR a) (interclasare (CDR a) b)))
		((> (CAR a) (CAR b)) (CONS (CAR b) (interclasare a (CDR b))))
		((= (CAR a) (CAR b)) (APPEND (CAR a) (CAR b) (interclasare (CDR a) (CDR b))))
	)
)

(defun split(l a b)
	(cond
		((null l) (LIST a b))
		(t (split (CDDR l) (APPEND a (LIST (CAR l))) (APPEND b (LIST (CADR l)))))
	)
)

(defun mergeSort(l)
	(cond
		((null l) nil)
		((null (CDR l)) l)
		(t (interclasare
				(mergeSort (CAR (split l '() '())))
				(mergeSort (CADR (split l '() '())))
			)
		)
	)
)

(defun minim(l m)
	(cond
		((null l) m)
		((< (CAR l) m) (minim (CDR l) (CAR l)))
		(t (minim (CDR l) m))
	)
)

(defun eliminare(l m)
	(cond
		((null l) nil)
		((= (CAR l) m) (eliminare (CDR l) m))
		(t (APPEND (LIST (CAR l)) (eliminare (CDR l) m)))
	)
)

(defun eliminare_wrapper(l)
	(eliminare l (minim l 2001))
)
