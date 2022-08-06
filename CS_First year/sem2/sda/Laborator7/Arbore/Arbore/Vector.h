#pragma once

#include <algorithm>
#include <vector>

class Vector
{
private:
	void resize();
	int capacity;
	int size;
	int* values;
public:
	Vector(int capacity);

	int& operator [] (int idx);

	int operator [] (int idx) const;

	Vector();

	~Vector();

	void add(int v);
	
	bool remove(int v);

	int find(int v);

	int dim() const;

	std::vector<int> copy() {
		return std::vector<int>(values + 0, values + size);
	}
};

