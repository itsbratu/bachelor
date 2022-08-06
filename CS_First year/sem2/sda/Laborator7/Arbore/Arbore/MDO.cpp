#include "IteratorMDO.h"
#include "MDO.h"
#include <iostream>
#include <vector>

#include <exception>
using namespace std;

void MDO::resizeInternal()
{
	int newCapacity = capacity * 2;
	realloc(keys, newCapacity);
	realloc(left, newCapacity);
	realloc(right, newCapacity);
	realloc(values, newCapacity);
	std::fill(keys + capacity, keys + newCapacity, NULL_POS);
	std::fill(left + capacity, left + newCapacity, NULL_POS);
	std::fill(right + capacity, right + newCapacity, NULL_POS);
	for (int i = capacity; i < newCapacity; i++) {
		this->values[i] = new Vector(100);
	}
	capacity = newCapacity;
}


MDO::MDO(Relatie r) {
	this->capacity = 100;
	this->size = 0;
	this->keys = new int[capacity];
	this->left = new int[capacity];
	this->right = new int[capacity];
	this->values = new Vector * [capacity];
	for (int i = 0; i < capacity; i++)
		this->values[i] = new Vector(100);
	this->r = r;
	std::fill(left + 0, left + capacity, NULL_POS);
	std::fill(right + 0, right + capacity, NULL_POS);
	std::fill(keys + 0, keys + capacity, NULL_POS);
}

//cauta o anumita cheie in arbore si returneaza -1 daca nu s-a gasit sau pozitia acesteia(index_
//COMPLEX : O(n) - n este numarul de chei 
int MDO::findKey(int k) const
{
	if (size == 0) return -1;
	int currPos = 0;
	while (currPos != NULL_POS && keys[currPos] != k) {
		if (r(k, keys[currPos])) currPos = left[currPos];
		else currPos = right[currPos];
	}
	if (currPos == NULL_POS) return -1;
	return currPos;
}

//COMPLEX : O(n) - n este numarul de chei
void MDO::adauga(TCheie k, TValoare v) {
	if (size == 0) {
		this->keys[0] = k;
		this->values[0]->add(v);
		size++;
		return;
	}
	// Cheia deja exista
	int keyExistsPos = findKey(k);
	if (keyExistsPos != NULL_POS) {
		values[keyExistsPos]->add(v);
		return;
	}
	// Cheia nu exista
	if (size == capacity) {
		resizeInternal();
	}
	int currPos = 0;
	while (true) {
		if (r(k, keys[currPos]) && left[currPos] == NULL_POS)
			break;
		if (r(k, keys[currPos]) && left[currPos] != NULL_POS)
			currPos = left[currPos];
		if (!r(k, keys[currPos]) && right[currPos] == NULL_POS)
			break;
		if (!r(k, keys[currPos]) && left[currPos] != NULL_POS)
			currPos = right[currPos];
	}
	if (r(k, keys[currPos]))
	{
		left[currPos] = size;
	}
	else
	{
		right[currPos] = size;
	}
	keys[size] = k;
	left[size] = NULL_POS;
	right[size] = NULL_POS;
	values[size]->add(v);
	size++;
}

//COMPLEX : O(m) m - numarul de valori asociate cheilor
vector <TValoare> MDO::colectiaValorilor() const {
	IteratorMDO it = this->iterator();

	vector<TValoare> collection;

	while (it.valid()) {
		TElem curr_pereche = it.element();
		TValoare new_value = curr_pereche.second;
		collection.push_back(new_value);
		it.urmator();
	}
	return collection;

}

//COMPLEX : O(n)
vector<TValoare> MDO::cauta(TCheie c) const {
	int keyExistsPos = findKey(c);
	if (keyExistsPos == NULL_POS) return std::vector<TValoare>();
	return values[keyExistsPos]->copy();
}

//COMPLEX : O(max{n,kn}) n - cheia asociata si kn - nr de valori asociate acesteia
bool MDO::sterge(TCheie c, TValoare v) {
	int keyExistsPos = findKey(c);
	if (keyExistsPos == NULL_POS) return false;
	return values[keyExistsPos]->remove(v);
}

//COMPLEX : O(n) - n numarul de chei
int MDO::dim() const {
	int result = 0;
	for (int i = 0; i < size; i++) {
		result += values[i]->dim();
	}
	return result;
}

//COMPLEX : O(1)
bool MDO::vid() const {
	return dim() == 0;
}

//COMPLEX : O(1)
IteratorMDO MDO::iterator() const {
	return IteratorMDO(*this);
}

//COMPLEX : O(1)
MDO::~MDO() {
	delete[] keys;
	delete[] left;
	delete[] right;
	delete[] values;
}
