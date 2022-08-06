#include "IteratorMD.h"
#include "MD.h"

using namespace std;

void IteratorMD::reinitialize(const MD& _md)
{
	int bucket_index = 0;

	while (bucket_index < IT_BUCKET_COUNTER)
	{
		Node* curr_bucket = _md.buckets[bucket_index];
		if (curr_bucket != NULL)
		{
			it_point = curr_bucket;
			save.first = curr_bucket;
			save.second = bucket_index;
			it_bucket = save.second;
			break;
		}
		bucket_index++;
	}
}

IteratorMD::IteratorMD(const MD& _md) : md(_md) {
	reinitialize(md);
}

TElem IteratorMD::element() const {
	if (valid() == false)
		throw exception();
	TElem el = it_point->val;
	return el;
}

bool IteratorMD::valid() const {
	return ((it_bucket < IT_BUCKET_COUNTER) && it_point != NULL) ;
}

void IteratorMD::urmator() {
	if (valid() == false)
		throw exception();
	else
	{
		if (it_point->next != NULL)
			it_point = it_point->next;
		else
		{
			int bucket_curr = it_bucket + 1; 
			while (bucket_curr < IT_BUCKET_COUNTER)
			{
				Node* b_curr = md.buckets[bucket_curr];
				if (b_curr != NULL)
				{
					it_point = b_curr;
					it_bucket = bucket_curr;
					break;
				}
				bucket_curr++;
			}
			it_bucket = bucket_curr;
		}
	}
}

void IteratorMD::prim() {
	reinitialize(md);
}

