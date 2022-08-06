(defun cmmdc(a b)
	(cond
		((= b 0) a)
		(t (cmmdc b (mod a b)))
	)
)

(defun cmmmc(a b)
	(/ (* a b) (cmmdc a b))
)

(defun cmmmc_list(l)
	(cond
		((null (CADDR l)) (cmmmc (CAR l) (CADR l)))
		(t (cmmmc (CAR l) (cmmmc_list (CDR l))))
	)
)

(defun munte(l n)
	(cond
		((AND (null (CADDR l)) (= n 1)) t)
		((null (CADDR l)) nil)
		((AND (> (CAR l) (CADR l)) (< (CADR l) (CADDR l))) nil)
		((OR
			(AND (< (CAR l) (CADR l)) (< (CADR l) (CADDR l)))
			(AND (> (CAR l) (CADR l)) (> (CADR l) (CADDR l)))
			)
			(munte (CDR l) n)
		)
		((AND (< (CAR l) (CADR l)) (> (CADR l) (CADDR l))) (munte (CDR l) (+ n 1)))
	)
)

(defun maxim(l m)
	(cond
		((null l) m)
		((LISTP (CAR l)) (max (maxim (CAR l) m) (maxim (CDR l) m)))
		((> (CAR l) m) (maxim (CDR l) (CAR l)))
		(t (maxim (CDR l) m))
	)
)

(defun elimina(l m)
	(cond
		((null l) nil)
		((LISTP (CAR l)) (CONS (elimina (CAR l) m) (elimina (CDR l) m)))
		((= (CAR l) m) (elimina (CDR l) m))
		(t (APPEND (LIST (CAR l)) (elimina (CDR l) m)))
	)
)

(defun elimina_wrapper(l)
	(elimina l (maxim l -2001))
)

(defun produs(l)
	(cond 
		((null l) 1)
		((LISTP (CAR l)) (* (produs (CAR l)) (produs (CDR l))))
		(t (* (CAR l) (produs (CDR l))))
	)
)
