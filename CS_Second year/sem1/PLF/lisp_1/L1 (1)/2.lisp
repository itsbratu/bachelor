(defun selectare(l n)
	(cond
		((null l) nil)
		((= n 1) (CAR l))
		(t (selectare (CDR l) (- n 1)))
	)
)

(defun apare(l a)
	(cond
		((null l) nil)
		((equal (CAR l) a) t)
		((LISTP (CAR l)) (OR (apare (CAR l) a) (apare (CDR l) a)))
		((ATOM (CAR l)) (apare (CDR l) a))
	)
)

(defun subliste(l)
	(cond
		((null l) nil)
		((ATOM (CAR l)) (subliste (CDR l)))
		((LISTP (CAR l)) (APPEND (LIST (CAR l)) (subliste (CAR l)) (subliste (CDR l))))
	)
)

(defun subliste_wrapper(l)
	(subliste (LIST l))
)

(defun aparitii(l a)
	(cond
		((null l) 0)
		((equal (CAR l) a) (+ 1 (aparitii (CDR l) a)))
		(t (aparitii (CDR l) a))
	)
)

(defun multime(l)
	(cond
		((null l) nil)
		((= (aparitii (CDR l) (CAR l)) 1) (CONS (CAR l) (multime (CDR l))))
		(t (multime (CDR l)))
	)
)
