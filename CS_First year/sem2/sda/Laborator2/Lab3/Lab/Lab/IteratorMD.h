#pragma once
#include "MD.h"

class MD;


class IteratorMD
{
	friend class MD;

private:

	static const int IT_BUCKET_COUNTER = 1;

	//constructorul primeste o referinta catre Container
	//iteratorul va referi primul element din container
	IteratorMD(const MD& c);

	//contine o referinta catre containerul pe care il itereaza
	const MD& md;

	void reinitialize(const MD& _md);

	Node* it_point = NULL;
	int it_bucket = 0;
	std::pair<Node*, int > save;

public:

	//reseteaza pozitia iteratorului la inceputul containerului
	void prim();

	//muta iteratorul in container
	// arunca exceptie daca iteratorul nu e valid
	void urmator();

	//verifica daca iteratorul e valid (indica un element al containerului)
	bool valid() const;

	//returneaza valoarea elementului din container referit de iterator
	//arunca exceptie daca iteratorul nu e valid
	TElem element() const;
};

