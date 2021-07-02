#include "Vector.h"
#include <iostream>

void Vector::resize()
{
	realloc(values, capacity * 2);
	capacity *= 2;
}

Vector::Vector(int capacity)
{
	this->capacity = capacity;
	this->size = 0;
	values = new int[capacity];
}

int& Vector::operator[](int idx)
{
	return values[idx];
}

int Vector::operator[](int idx) const
{
	return values[idx];
}


Vector::Vector()
{
	this->capacity = 5;
	this->size = 0;
	values = new int[capacity];
}

Vector::~Vector()
{
	delete[] values;
}

void Vector::add(int v)
{
	if (size == capacity) resize();
	values[size++] = v;
}

bool Vector::remove(int v)
{
	int idx = find(v);
	if (idx == -1) return false;
	if (idx != size - 1) {
		for (int i = idx + 1; i < size; i++)
			values[i - 1] = values[i];
	}
	size -= 1;
	return true;
}

int Vector::find(int v)
{
	int idx;
	for (idx = 0; idx < size; idx++) {
		if (values[idx] == v) break;
	}
	return (idx == size) ? -1 : idx;
}

int Vector::dim() const
{
	return size;
}
