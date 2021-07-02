#define _CRT_SECURE_NO_WARNINGS
#include "repository.h"
#include "domain.h"
#include <string.h>
#include <stdio.h>
#include <string.h>
#include <assert.h>

void add_list(List *l, Payment chelt)
{

	/*:PARAM: l - List pointer , chelt - Payment object
	Functie care adauga in lista de cheltuieli o noua cheltuiala
	*/
	l->elem[l->size++] = chelt;
}

void modify_list(List* l, Payment chelt)
{
	/*PARAM : l - List pointer , chelt - Payment obect
	* Functie care modifica un element din lista de cheltuieli / afiseaza un mesaj in cazul in care nu s-a putut realiza operatia
	*/
	int exists = 0;
	int index = -1;
	for (int i = 0; i < l->size; i++)
	{
		if (compare(l->elem[i], chelt) == 0)
		{
			exists = 1;
			index = i;
			break;
		}
	}
	if(exists == 1)
		l->elem[index].suma = chelt.suma;

}

void delete_list(List* l, int ap_nmb, char tip[20])
{

	/*PARAM : l - List pointer , ap_nmb - integer value , tip - char vector
	* Functie care sterge un element din lista de cheltuieli dupa nr.aprtament si tipul acesteia / afiseaza un mesaj in cazul in care nu s-a putut realiza operatia
	*/

	int exists = 0;
	int index = -1;

	for (int i = 0; i < l->size; i++)
	{
		if (l->elem[i].apartament == ap_nmb && strcmp(l->elem[i].type, tip) == 0)
		{
			exists = 1;
			index = i;
			break;
		}
	}
	if (index == l->size - 1)
	{
		destroy_payment(l->elem[index]);
		l->size--;
	}
	else
	{
		destroy_payment(l->elem[index]);
		for (int i = index + 1; i < l->size; ++i)
			l->elem[i - 1] = l->elem[i];
		l->size--;
	}
}

void test_addlist()
{
	List* test_list = create_list(100);
	assert(test_list->size == 0);

	char t1[20], t2[20];
	strcpy(t1, "gaz");
	strcpy(t2, "apa");

	Payment p1 = create_payment(10, 100, t1);
	Payment p2 = create_payment(1, 1000, t2);

	add_list(test_list, p1);
	add_list(test_list, p2);

	assert(test_list->size == 2);
	destroy_list(test_list);
}

void test_deletelist()
{
	List* test_list = create_list(100);
	assert(test_list->size == 0);

	char t1[20], t2[20];
	strcpy(t1, "incalzire");
	strcpy(t2, "canal");

	Payment p1 = create_payment(1, 2, t1);
	Payment p2 = create_payment(1, 3, t2);

	add_list(test_list, p1);
	add_list(test_list, p2);
	assert(test_list->size == 2);

	delete_list(test_list, 1, t1);
	assert(test_list->size == 1);
	destroy_list(test_list);
}

void test_modifylist()
{
	List* test_list = create_list(100);
	assert(test_list->size == 0);

	char t1[20], t2[20];
	strcpy(t1, "incalzire");
	strcpy(t2, "canal");

	Payment p1 = create_payment(1, 200, t1);
	Payment p2 = create_payment(1, 300, t2);

	add_list(test_list, p1);
	add_list(test_list, p2);
	assert(test_list->size == 2);
	assert(test_list->elem[0].suma == 200);
	destroy_list(test_list);
}

void run_tests_repo()
{
	test_addlist();
	test_deletelist();
	test_modifylist();
}


