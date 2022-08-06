(defun intercalare(l e n)
	 (cond
	 	((null l) nil)
	 	((= n 1) (APPEND (LIST e) (intercalare l e (- n 1))))
	 	(t (APPEND (LIST (CAR l)) (intercalare (CDR l) e (- n 1))))
	 )
)

(defun suma(l)
	(cond
		((null l) 0)
		((LISTP (CAR l)) (+ (suma (CAR l)) (suma (CDR l))))
		(t (+ (CAR l) (suma (CDR l))))
	)
)

(defun subliste(l)
	(cond
		((null l) nil)
		((LISTP (CAR l)) (APPEND (LIST (CAR l)) (subliste (CAR l)) (subliste (CDR l))))
		(t (subliste (CDR l)))
	)
)

(defun lungime(l)
	(cond
		((null l) 0)
		(t (+ 1 (lungime (CDR l))))
	)
)

(defun apare (l e)
	(cond
		((null l) nil)
		((= (CAR l) e) t)
		(t (apare (CDR l) e))
	)
)

(defun intersectie(a b)
	(cond
		((null a) nil)
		((apare b (CAR a)) (APPEND (LIST (CAR a)) (intersectie (CDR a) b)))
		(t (intersectie (CDR a) b))
	)
)

(defun egale(a b)
	(cond
		((= (lungime (intersectie a b)) (lungime a) (lungime b)) t)
		(t nil)
	)
)
