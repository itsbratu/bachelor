(defun apare(e l)
	(cond
		((null l) nil)
		((equal (CAR l) e) t)
		(t (apare e (CDR l)))
	)
)

(defun diferenta(a b)
	(cond
		((null a) nil)
		((apare (CAR a) b) (diferenta (CDR a) b))
		(t (APPEND (LIST (CAR a)) (diferenta (CDR a) b)))
	)
)

(defun invers(l)
	(cond
		((null l) nil)
		((ATOM (CAR l)) (APPEND (invers (CDR l)) (LIST (CAR l))))
		((LISTP (CAR l)) (APPEND (invers (CDR l)) (LIST (invers (CAR l)))))
	)
)

(defun count(l)
	(cond
		((null l) 0)
		(t (+ 1 (count (CDR l))))
	)
)

(defun primele(l)
	(cond
		((null l) nil)
		((AND (LISTP (CAR l)) (= (mod (count (CAR l)) 2) 1)) (APPEND (LIST (CAAR l)) (primele (CDR l))))
		(t (primele (CDR l)))
	)
)

(defun primele_wrapper(l)
	(cond
		((= (mod (count l) 2) 1) (APPEND (LIST (CAR l)) (primele l)))
		(t (primele l))
	)
)

(defun suma(l)
	(cond
		((null l) 0)
		((NUMBERP (CAR l)) (+ (CAR l) (suma (CDR l))))
		(t (suma (CDR l)))
	)
)
