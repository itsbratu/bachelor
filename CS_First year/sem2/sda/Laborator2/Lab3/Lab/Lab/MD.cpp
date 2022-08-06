#include <exception>
#include <iostream>
#include "MD.h"
#include "IteratorMD.h"

using namespace std;

void MD::insert(int bucket, TCheie c, TValoare v) {
	Node* ptr = buckets[bucket];
	if (!ptr) {
		buckets[bucket] = new Node({ c, v });
		size++;
		return;
	}
	while (ptr->next != NULL) {
		ptr = ptr->next;
	}
	ptr->next = new Node({ c, v });
	size++;
	return;
}

bool MD::remove(int bucket_nmb, TCheie c, TValoare v) {
	Node* slow = buckets[bucket_nmb];
	if (!slow) return false;

	Node* curr = slow->next;
	TElem valoare = { c, v };

	if (slow->val == valoare) {
		buckets[bucket_nmb] = curr;
		delete slow;
		return true;
	}

	if (!curr) {
		if (slow->val == valoare) {
			delete slow;
			buckets[bucket_nmb] = 0;
			return true;
		}
		return false;
	}

	while (curr->next != NULL && curr->val != valoare) {
		slow = curr;
		curr = curr->next;
	}
	if (curr->val == valoare) {
		slow->next = curr->next;
		delete curr;
		return true;
	}
	return false;
}

MD::MD() {
	size = 0;
	for (int i = 0; i < BUCKET_COUNT; ++i)
		buckets[i] = NULL;
}


void MD::adauga(TCheie c, TValoare v) {
	int b = abs(c) % BUCKET_COUNT;
	insert(b, c, v);
}


bool MD::sterge(TCheie c, TValoare v) {
	int b = abs(c) % BUCKET_COUNT;
	bool result = remove(b, c, v);
	if (result == true)
		size--;
	return result;
}

vector<TValoare> MD::stergeValoriPentruCheie(TCheie cheie)
{
	int b = abs(cheie) % BUCKET_COUNT;
	vector<TValoare> a;

	Node* curr_bucket = buckets[b];
	while (curr_bucket != NULL)
	{
		TCheie curr_key = curr_bucket->val.first;
		TValoare curr_value = curr_bucket->val.second;
		curr_bucket = curr_bucket->next;
		if (curr_key == cheie)
		{
			a.push_back(curr_value);
			sterge(curr_key , curr_value);
		}
	}
	return a;
}

vector<TValoare> MD::cauta(TCheie c) const {
	vector<TValoare> a;
	int b = abs(c) % BUCKET_COUNT;

	Node* bucket = buckets[b];
	while (bucket != NULL)
	{
		TElem value = bucket->val;
		if (value.first == c)
			a.push_back(value.second);
		bucket = bucket->next;
	}
	return a;
}


int MD::dim() const {
	return size;
}


bool MD::vid() const {
	bool is_vid = false;
	if (size == 0)
		is_vid = true;
	return is_vid;

}

IteratorMD MD::iterator() const {
	return IteratorMD(*this);
}


MD::~MD() {
	int curr_bucket = 0;
	while (curr_bucket < BUCKET_COUNT)
	{
		Node* ptr = buckets[curr_bucket];
		while (ptr != NULL)
		{
			Node* follow = ptr->next;
			delete ptr;
			ptr = follow;
		}
		curr_bucket++;
	}
}

