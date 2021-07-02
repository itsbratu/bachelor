#pragma once
#include<vector>
#include<utility>

using namespace std;

typedef int TCheie;
typedef int TValoare;

typedef std::pair<TCheie, TValoare> TElem;

class IteratorMD;

struct Node {
	TElem val;
	Node* next;

	Node(TElem val) {
		this->val = val;
		this->next = NULL;
	}
};

class MD
{
	friend class IteratorMD;

private:


public:

	static const int BUCKET_COUNT = 1;
	/* aici e reprezentarea */
	Node* buckets[BUCKET_COUNT];
	int size;

	void insert(int bucket, TCheie c, TValoare v);

	bool remove(int bucket_nmb, TCheie c, TValoare v);

	// constructorul implicit al MultiDictionarului
	MD();

	// adauga o pereche (cheie, valoare) in MD	
	void adauga(TCheie c, TValoare v);

	//cauta o cheie si returneaza vectorul de valori asociate
	vector<TValoare> cauta(TCheie c) const;

	//sterge o cheie si o valoare 
	//returneaza adevarat daca s-a gasit cheia si valoarea de sters
	bool sterge(TCheie c, TValoare v);

	//returneaza numarul de perechi (cheie, valoare) din MD 
	int dim() const;

	//elimina o cheie impreuna cu toate valorile sale
	//returneaza un vector cu valorile care au fost anterior asociate acestei chei(au fost eliminate)
	vector<TValoare> stergeValoriPentruCheie(TCheie cheie);

	//verifica daca MultiDictionarul e vid 
	bool vid() const;

	// se returneaza iterator pe MD
	IteratorMD iterator() const;

	// destructorul MultiDictionarului	
	~MD();

};

