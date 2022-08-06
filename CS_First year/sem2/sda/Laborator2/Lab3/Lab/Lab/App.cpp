#include <iostream>
#include "TestScurt.h"
#include <assert.h>
#include "TestExtins.h"
#include "MD.h"

using namespace std;

int main() {

	testAll();
	//testAllExtins();

	MD m;
	m.adauga(1, 100);
	m.adauga(1, 200);
	m.adauga(1, 500);
	m.adauga(2, 2000);
	m.adauga(2, 500);
	m.adauga(7, 700);

	assert(m.dim() == 6);

	vector<TValoare> a;

	a = m.stergeValoriPentruCheie(1);
	assert(a.size() == 3);
	assert(m.dim() == 3);

	cout << "End";

}
