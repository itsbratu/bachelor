#pragma once
#include <iostream>

class DTO_type
{
private:
	std::string type;
	int count = 0;
public:
	DTO_type() = default;
	DTO_type(std::string type) : type{ type }, count{ 1 }{}
	void add() { count++; }
	int getCount() { return count; }
};