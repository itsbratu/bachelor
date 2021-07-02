#pragma once

#include <string.h>

typedef struct
{
	int apartament;
	int suma;
	char* type;
} Payment;

int compare(Payment a, Payment b);

Payment create_payment(int apartament, int sum, char* type);

void destroy_payment(Payment payment_ptr);

typedef struct
{
	Payment* elem;
	int size;
	int capacity;
} List;

List* create_list(int capacity);

void destroy_list(List* ptr);

void test_compare();

void run_tests_domain();

void test_createpayment();

void test_createlist();

void run_tests_domain();