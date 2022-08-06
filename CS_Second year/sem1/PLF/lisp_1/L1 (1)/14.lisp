(defun eliminare(l n i)
	(cond
		((null l) nil)
		((= (mod i n) 0) (eliminare (CDR l) n (+ i 1)))
		(t (APPEND (LIST (CAR l)) (eliminare (CDR l) n (+ i 1))))
	)
)

(defun vale(l n)
	(cond
		((AND (null (CADDR l)) (= n 1)) t)
		((null (CADDR l)) nil)
		((AND (< (CAR l) (CADR l)) (> (CADR l) (CADDR l))) nil)
		((OR
			(AND (< (CAR l) (CADR l)) (< (CADR l) (CADDR l)))
			(AND (> (CAR l) (CADR l)) (> (CADR l) (CADDR l)))
			)
			(vale (CDR l) n)
		)
		((AND (> (CAR l) (CADR l)) (< (CADR l) (CADDR l))) (vale (CDR l) (+ n 1)))
	)
)

(defun minim(a m)
	(cond
		((null a) m)
		((LISTP (CAR a)) (min (minim (CAR a) m) (minim (CDR a) m)))
		((< (CAR a) m) (minim (CDR a) (CAR a)))
		(t (minim (CDR a) m))
	)
)

(defun maxim(a m)
	(cond
		((null a) m)
		((> (CAR a) m) (maxim (CDR a) (CAR a)))
		(t (maxim (CDR a) m))
	)
)

(defun stergere(a m)
	(cond
		((null a) nil)
		((= (CAR a) m) (stergere (CDR a) m))
		(t (APPEND (LIST (CAR a)) (stergere (CDR a) m)))
	)
)

(defun stergere_wrapper(a)
	(stergere a (maxim a -2001))
)
