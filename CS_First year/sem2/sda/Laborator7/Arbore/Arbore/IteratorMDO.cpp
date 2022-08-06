#include "IteratorMDO.h"
#include "MDO.h"

//Functie care realizeaza un DFS la nivelul structural al arborelui pentru a adauga nodurile in ordine
//COMPLEX : O(n) n - numarul de chei(noduri in arbore)
void IteratorMDO::dfs(int currIdx)
{
	if (currIdx == NULL_POS) return;
	dfs(dict.left[currIdx]);
	keysInOrder->add(currIdx);
	dfs(dict.right[currIdx]);
}

//COMPLEX : O(n) n - numarul de chei(noduri in arbore)
IteratorMDO::IteratorMDO(const MDO& d) : dict(d) {
	keysInOrder = new Vector(100);
	dfs(0);
	prim();
}

//COMPLEX : O(1)
void IteratorMDO::prim(){
	currKeyIdx = 0;
	currValIdx = 0;
	currValues = dict.values[(*keysInOrder)[currKeyIdx]];
}

//COMPLEX : O(1)
void IteratorMDO::urmator() {
	if (!valid()) throw std::exception();
	if (currValIdx < currValues->dim()) {
		currValIdx++;
	}
	else {
		currKeyIdx++;
		if (!valid()) return;
		currValIdx = 0;
		currValues = dict.values[(*keysInOrder)[currKeyIdx]];
	}
}

//COMPLEX : O(1)
bool IteratorMDO::valid() const {
	return currKeyIdx < keysInOrder->dim();
}

//COMPLEX : O(1)
TElem IteratorMDO::element() const {
	if (!valid()) throw std::exception();
	return { dict.keys[(*keysInOrder)[currKeyIdx]], (*currValues)[currValIdx] };
}

//COMPLEX : O(1)
IteratorMDO::~IteratorMDO()
{
	delete currValues;
	delete keysInOrder;
}



