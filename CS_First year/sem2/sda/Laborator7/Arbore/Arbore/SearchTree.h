#pragma once
#include "Vector.h"

#define NULL_POS -1

typedef int TCheie;
typedef int TValoare;
typedef std::pair<TCheie, TValoare> TElem;
typedef bool(*Relatie)(TCheie, TCheie);

class SearchTree
{
private:
	int size;
	int capacity;
	int* keys;
	int* left;
	int* right;
	Vector* values;
	Relatie cmp;
	void resizeInternal();
	int findKey(int k);
public:
	SearchTree(Relatie cmp);

	~SearchTree();

	void add(int k, int v);

	bool remove(int k, int v);

	std::vector<int> find(int k);
};

