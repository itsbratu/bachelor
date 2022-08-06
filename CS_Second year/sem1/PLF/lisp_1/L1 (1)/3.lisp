; produs(l : list, k : list) (i, i)

(defun produs(l k)
	(cond
		((OR (null l) (null k)) nil)
		(t (cons (* (car l) (car k)) (produs (cdr l) (cdr k))))
	)
)

; Cazuri de testare
; > (produs '(2 3 4 5) '(3 4 5 6))
;   (6 12 20 30)
; > (produs '(2 3 4 5 6) '(3 4 5 6))
;   (6 12 20 30)
; > (produs '(0) '(100))
;   (0)

; adancime(l : list) (i)

(defun adancime(l)
	(cond
		((null l) 0)
		((ATOM (CAR l)) (adancime (CDR l)))
		((LISTP (CAR l)) (MAX (+ 1 (adancime (CAR l))) (adancime (CDR l))))
	)
)

; Cazuri de testare
; > (adancime '(1 2 3))
;   0
; > (adancime '(((1 2) 1 2 3) 1 2 3))
;   2
; > (adancime '(((1 2) 1 2 3) 1 (2 (3 (4))) 3))
;   3

; split(l : list, a : list, b : list) (i, o, o)

(defun split(l a b)
	(cond
		((null l) (LIST a b))
		(t (split (CDR l) b (append (list (CAR l)) a)))
	)
)

; ===============================================================

; split_wrapper(l : list) (i)

(defun split_wrapper(l)
	(split l () ())
)

; Cazuri de testare
; > (split_wrapper '(1 2 3 4 5))
;   ((4 2) (5 3 1))
; > (split_wrapper '(1))
;   (NIL (1))
; > (split_wrapper '())
;   (NIL NIL)

; ===============================================================

; interclasare(a : list, b : list)

(defun interclasare(a b)
	(cond
		((null a) (append b NIL))
		((null b) (append a NIL))
		((< (CAR a) (CAR b)) 
			(CONS (CAR a) (interclasare (CDR a) (append b NIL))))
		((> (CAR a) (CAR b))
			(CONS (CAR b) (interclasare (append a NIL) (CDR b))))
		((= (CAR a) (CAR b)) 
			(CONS (CAR a) (interclasare (CAR a) (CAR b))))
	)
)

; Cazuri de testare
; > (interclasare '(2 4 6) '(1 3 5))
;   (1 2 3 4 5 6)
; > (interclasare '(3) '(1 2))
;   (1 2 3)
; > (interclasare '(1 2 3) '())
;   (1 2 3)

; ===============================================================

; merge_sort(l : list)

(defun merge_sort(l)
	(cond
		((null l) NIL)
		((null (CDR l)) l)
		(t (interclasare 
			(merge_sort 
				(CAR (split_wrapper l))
			) 
			(merge_sort
				(CADR (split_wrapper l))
			)
		   )
		)
	)
)

; Cazuri de testare
; > (merge_sort '(1 5 3 2 4))
;   (1 2 3 4 5)
; > (merge_sort '(10 9 8))
;   (8 9 10)
; > (merge_sort '())
;   NIL

; apare(e : atom, l : list)

(defun apare(e l)
	(cond
		((null l) nil)
		((= (CAR l) e) t)
		(t (apare e (CDR l)))
	)	
)

; Cazuri de testare
; > (apare 1 '(1 2 3 4))
;   T
; > (apare 5 '(1 2 3 4))
;   NIL
; > (apare 1 '())
;   NIL

; ================================================================

; intersectie(l : list, m : list)

(defun intersectie (l m)
	(cond
		((null l) nil)
		((apare (CAR l) m) (CONS (CAR l) (intersectie (CDR l) m)))
		(t (intersectie (CDR l) m))
	)
)

; Cazuri de testare
; > (intersectie '(1 2 3 4) '(3 4 5 6))
;   (3 4)
; > (intersectie '(1 2 3) '())
;   NIL
; > (intersectie '(1 2 3) '(4 5 6))
;   NIL
