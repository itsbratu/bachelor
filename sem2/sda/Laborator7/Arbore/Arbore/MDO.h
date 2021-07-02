#pragma once

#include <vector>

typedef int TCheie;
typedef int TValoare;

#include <utility>
#include "Vector.h"

#define NULL_POS -1

typedef std::pair<TCheie, TValoare> TElem;

using namespace std;

class IteratorMDO;

typedef bool(*Relatie)(TCheie, TCheie);

class MDO {
	friend class IteratorMDO;
    private:
		int size;
		int capacity;
		TCheie* keys;
		TCheie* left;
		TCheie* right;
		Vector** values;
		Relatie r;
		void resizeInternal();
		int findKey(int k) const;
	/* aici e reprezentarea */
    public:

	// constructorul implicit al MultiDictionarului Ordonat
	MDO(Relatie r);

	//MDO(const MDO& d);

	// adauga o pereche (cheie, valoare) in MDO
	void adauga(TCheie c, TValoare v);

	//cauta o cheie si returneaza vectorul de valori asociate
	vector<TValoare> cauta(TCheie c) const;

	//sterge o cheie si o valoare 
	//returneaza adevarat daca s-a gasit cheia si valoarea de sters
	bool sterge(TCheie c, TValoare v);

	//returneaza numarul de perechi (cheie, valoare) din MDO 
	int dim() const;

	//verifica daca MultiDictionarul Ordonat e vid 
	bool vid() const;

	// se returneaza iterator pe MDO
	// iteratorul va returna perechile in ordine in raport cu relatia de ordine
	IteratorMDO iterator() const;

	vector<TValoare> colectiaValorilor() const;

	// destructorul 	
	~MDO();

};
