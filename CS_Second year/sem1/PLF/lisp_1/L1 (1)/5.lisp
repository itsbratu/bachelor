(defun interclasare(a b)
	(cond
		((null a) b)
		((null b) a)
		((< (CAR a) (CAR b)) (CONS (CAR a) (interclasare (CDR a) b)))
		((> (CAR a) (CAR b)) (CONS (CAR b) (interclasare a (CDR b))))
		((= (CAR a) (CAR b)) (APPEND (CAR a) (CAR b) (interclasare (CDR a) (CDR b))))
	)
)

(defun inlocuire(l e l1)
	(cond
		((null l) nil)
		((equal (CAR l) e) (APPEND l1 (inlocuire (CDR l) e l1)))
		((LISTP (CAR l)) (CONS (inlocuire (CAR l) e l1) (inlocuire (CDR l) e l1)))
		(t (CONS (CAR l) (inlocuire (CDR l) e l1)))
	)
)

(defun suma(a b tr)
	(cond
		((AND (NULL a) (NULL b) (= tr 0)) NIL)
		((AND (NULL a) (NULL b) (= tr 1)) 1)
		((NULL a) (APPEND (LIST (mod (+ (CAR b) tr) 10)) (suma a (CDR b) (floor (+ (CAR b) tr) 10))))
		((NULL b) (APPEND (LIST (mod (+ (CAR a) tr) 10)) (suma (CDR a) b (floor (+ (CAR a) tr) 10))))
		(t (APPEND (LIST (mod (+ (CAR a) (CAR b) tr) 10)) (suma (CDR a) (CDR b) (floor (+ (CAR a) (CAR b) tr) 10))))
	)
)

(defun transforma(l p rez)
	(cond
		((null l) rez)
		(t (transforma (CDR l) (* p 10) (+ rez (* (CAR l) p))))
	)
)

(defun cmmdc(a b)
	(cond
		((= b 0) a)
		(t (cmmdc b (mod a b)))
	)
)

(defun cmmdc_list(l)
	(cond
		((null l) 0)
		(t (cmmdc (CAR l) (cmmdc_list (CDR l))))
	)
)
