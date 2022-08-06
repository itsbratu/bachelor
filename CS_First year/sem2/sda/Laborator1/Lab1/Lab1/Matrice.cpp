#include <exception>
#include <iostream>
#include "Matrice.h"

using namespace std;void resize(TElem*& mod_list, int capacity, int nmbVals){	TElem* new_list = new TElem[capacity * 2];	for (int i = 0; i < nmbVals; ++i)		new_list[i] = mod_list[i];	delete[] mod_list;		mod_list = new_list;}
Matrice::Matrice(int m, int n) {	if (m < 0 || n < 0)
		throw exception();
	nmbRows = m;
	nmbCols = n;
	nmbVals = 0;
	capacity = 10;
	rows = new TElem[nmbRows+1];
	for (int i = 0; i < nmbRows+1; ++i)
		rows[i] = 0;
	cols = new TElem[capacity];
	vals = new TElem[capacity];
}
int Matrice::nrLinii() const {	return nmbRows;
}

int Matrice::nrColoane() const {	return nmbCols;
}

TElem Matrice::element(int i, int j) const {	if (i < 0 || j < 0 || i > nmbRows - 1 || j > nmbCols - 1)
		throw exception();
	for (int k = rows[i]; k < rows[i + 1]; ++k)
	{
		if (cols[k] == j)
			return vals[k];
	}
	return NULL_TELEMENT;
}
TElem Matrice::modifica(int i, int j, TElem e) {
	if (i < 0 || j < 0 || i > nmbRows - 1 || j > nmbCols - 1)
		throw exception();
	int curr_el = element(i, j);
	if (curr_el == NULL_TELEMENT && e == NULL_TELEMENT)
		return NULL_TELEMENT;
	if (curr_el != NULL_TELEMENT && e != NULL_TELEMENT) //O(n)
	{
		int prev = 0;
		for (int k = rows[i]; k < rows[i + 1]; ++k)
		{
			if (cols[k] == j)
			{
				prev = vals[k];
				vals[k] = e;
				return prev;
			}
		}
	}
	if (curr_el == NULL_TELEMENT && e != NULL_TELEMENT)
	{
		if (nmbVals == capacity)
		{
			resize(cols, capacity, nmbVals);
			resize(vals, capacity, nmbVals);
			capacity = capacity * 2;
		}
		vals[nmbVals] = e;
		cols[nmbVals] = j;
		for (int l = i + 1; l < nmbRows + 1; ++l)
			rows[l]++;
		nmbVals++;
		return NULL_TELEMENT;
	}
	if (curr_el != NULL_TELEMENT && e == NULL_TELEMENT)
	{
		int index_move = 0;
		int prev = 0;
		for (int k = rows[i]; k < rows[i + 1]; ++k)
		{
			if (cols[k] == j)
			{
				index_move = k;
				prev = vals[k];
				break;
			}

		}
		for (int next = index_move + 1; next < nmbVals; ++next)
		{
			cols[next - 1] = cols[next];
			vals[next - 1] = vals[next];
		}
		for (int l = i + 1; l < nmbRows + 1; ++l)
			rows[l] --;
		nmbVals--;
		return prev;
	}
}

