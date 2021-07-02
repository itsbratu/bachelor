#include "Domain.h"
#include <assert.h>
#include <iostream>

bool cmpTitle(const Activity& a1, const Activity& a2)
{
	return a1.getTitle() < a2.getTitle();
}

bool cmpDescription(const Activity& a1, const Activity& a2)
{
	return a1.getDescription() < a2.getDescription();
}

void test_get()
{
	Activity act{"a" , "b" , "c" , 100 };
	std::string t = act.getTitle();
	std::string d = act.getDescription();
	std::string ty = act.getType();
	const int l = act.getLength();
	assert(t.compare("a") == 0);
	assert(d.compare("b") == 0);
	assert(ty.compare("c") == 0);
	assert(l == 100);
}

void test_cmp()
{
	Activity a1{ "abc" , "xyz" , "c" , 10 };
	Activity a2{ "xyz" , "abc" , "d" , 100 };
	assert(cmpTitle(a1, a2) == 1);
	assert(cmpDescription(a1, a2) == 0);
}

void test_domain()
{
	test_get();
	test_cmp();
}
