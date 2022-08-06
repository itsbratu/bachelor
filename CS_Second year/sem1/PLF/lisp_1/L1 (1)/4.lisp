(defun suma(a b)
	(cond
		((AND (null a) (null b)) nil)
		((null a) b)
		((null b) a)
		(t (APPEND (LIST (+ (CAR a) (CAR b))) (suma (CDR a) (CDR b))))
	)
)

(defun normal(l)
	(cond
		((null l) nil)
		((ATOM (CAR l)) (APPEND (LIST (CAR l)) (normal (CDR l))))
		((LISTP (CAR l)) (APPEND (normal (CAR l)) (normal (CDR l))))
	)
)

(defun secv(l s c)
	(cond
		((null l) (append c s))
		((ATOM (CAR l)) 
			(secv (CDR l) 
				  (CONS (CAR l) s) 
				  c
			)
		)
		(t 
			(secv 
				(CDR l) 
				nil 
				(APPEND 
					s 
					(LIST (secv (CAR l) nil nil))
					c
				)
			)
		)
	)
)

(defun maxim(l v)
	(cond
		((null l) v)
		((AND (ATOM (CAR l)) (> (CAR l) v)) (maxim (CDR l) (CAR l)))
		(t (maxim (CDR l) v))
	)
)

(defun maxim_wrapper(l)
	(maxim l (CAR l))
)
