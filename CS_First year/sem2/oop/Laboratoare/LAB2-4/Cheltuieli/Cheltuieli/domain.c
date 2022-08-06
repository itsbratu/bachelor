#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include "domain.h"
#include <string.h>
#include <stdio.h>
#include <string.h>
#include <assert.h>

int compare(Payment a, Payment b) {
	// PARAM: a - Payment object , b - Paymanet obhect 
	/// RETURN : < 0 daca a este mai mic decat b, 0 if a egal cu b , sau > 0 daca a > b
	if (a.apartament != b.apartament) return a.apartament - b.apartament;
	return strcmp(a.type, b.type);
}

Payment create_payment(int apartament, int sum, char* type) {
	/*PARAM : apartament - integer value , sum - integer value , tpye - char pointer
	* Creeaza in mod dinamic un obiect de tip Payment pe care il initializeaza in memorie folosind malloc
	* RETURN : new_payment - Payment object
	*/
	Payment new_payment;
	new_payment.apartament = apartament;
	new_payment.suma = sum;
	new_payment.type = malloc(sizeof(char) * (strlen(type) + 1));
	strcpy(new_payment.type, type);
	return new_payment;
}

void destroy_payment(Payment payment) {
	/*PARAM : payment - Payment object
	* Functie care elibereaza din memorie spatiul alocat pentru un obiect Payment
	*/
	free(payment.type);
}

List* create_list(int capacity) {
	/*PARAM : capacity - integer value
	* Functie care creeaza in mod dinamic in memorie un obiect de tip pointer List flosind malloc
	* RETURN : new_list - List pointer
	*/
	List* new_list = malloc(sizeof(List));
	new_list->elem = malloc(sizeof(Payment) * capacity);
	new_list->size = 0;
	new_list->capacity = 0;
	return new_list;
}

void destroy_list(List* ptr) {
	/*PARAM ptr - List pointer
	* Functie care elibereaza spatiul reservat unei liste alocate dinamic de tip List folosind free
	*/
	for (int i = 0; i < ptr->size; i++) {
		destroy_payment(ptr->elem[i]);
	}
	free(ptr->elem);
	free(ptr);
}

void test_compare()
{
	Payment p1 = create_payment(10, 200, "apa");
	Payment p2 = create_payment(20, 300, "canal");

	int return1 = compare(p1, p2);
	assert((return1 < 0) == 1);

	Payment p3 = create_payment(10, 20, "canal");
	Payment p4 = create_payment(10, 30, "apa");

	int return2 = compare(p1, p2);
	assert((return2 <0) == 1);
}

void test_createpayment()
{
	Payment p = create_payment(10, 10, "apa");
	assert(p.apartament == 10);
	assert(p.suma == 10);
	assert(strcmp(p.type, "apa") == 0);
}

void run_tests_domain()
{
	test_compare();
	test_createpayment();
}