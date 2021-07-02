#include "SearchTree.h"
#include <algorithm>

void SearchTree::resizeInternal()
{
	int newCapacity = capacity * 2;
	realloc(keys, newCapacity);
	realloc(left, newCapacity);
	realloc(right, newCapacity);
	realloc(values, newCapacity);
	std::fill(keys + capacity, keys + newCapacity, NULL_POS);
	std::fill(left +capacity, left + newCapacity, NULL_POS);
	std::fill(right + capacity, right + newCapacity, NULL_POS);
	capacity = newCapacity;
}

int SearchTree::findKey(int k)
{
	if (size == 0) return -1;
	int currPos = 0;
	while (keys[currPos] != NULL_POS && keys[currPos] != k) {
		if (cmp(k, keys[currPos])) currPos = left[currPos];
		else currPos = right[currPos];
	}
	if (keys[currPos] == NULL_POS) return -1;
	return currPos;
}

SearchTree::SearchTree(Relatie cmp)
{
	this->capacity = 100;
	this->size = 0;
	this->keys = new int[capacity];
	this->left = new int[capacity];
	this->right = new int[capacity];
	this->values = new Vector [capacity];
	this->cmp = cmp;
	std::fill(left + 0, left + capacity, NULL_POS);
	std::fill(right + 0, right + capacity, NULL_POS);
	std::fill(keys + 0, keys + capacity, NULL_POS);
}

SearchTree::~SearchTree()
{
	delete[] keys;
	delete[] left;
	delete[] right;
	delete[] values;
}

void SearchTree::add(int k, int v)
{
	if (size == 0) {
		this->keys[0] = k;
		this->values[0].add(v);
		return;
	}
	// Key already exists
	int keyExistsPos = findKey(k);
	if (keyExistsPos != NULL_POS) {
		values[keyExistsPos].add(v);
		return;
	}
	// Key does not exist
	if (size == capacity) {
		resizeInternal();
	}
	int currPos = 0;
	while (true) {
		if (cmp(k, keys[currPos]) && left[currPos] == NULL_POS)
			break;
		if (cmp(k, keys[currPos]) && left[currPos] != NULL_POS)
			currPos = left[currPos];
		if (!cmp(k, keys[currPos]) && right[currPos] == NULL_POS)
			break;
		if (!cmp(k, keys[currPos]) && left[currPos] != NULL_POS)
			currPos = right[currPos];
	}
	if (cmp(k, keys[currPos]))
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
	values[size].add(v);
	size++;
}

bool SearchTree::remove(int k, int v)
{
	int keyExistsPos = findKey(k);
	if (keyExistsPos == NULL_POS) return false;
	return values[keyExistsPos].remove(v);
}

std::vector<int> SearchTree::find(int k)
{
	int keyExistsPos = findKey(k);
	if (keyExistsPos == NULL_POS) return std::vector<int>();
	return values[keyExistsPos].copy();
}
