#pragma once
#include "repository.h"

int validare_cheltuiala(char ap_nmb[20], char valoare[20], char tip[20]);

int add_cheltuiala(List* l, char ap_nmb[20], char valoare[20], char tip[20]);

void test_validare();

void run_tests_service();

List* filter_cheltuiala(List* l, char filter[20], char filter_value[20]);

int delete_cheltuiala(List* l, char ap_nmb[20], char tip[20]);

int modify_cheltuiala(List* l, char ap_nmb[20], char valoare[20], char tip[20]);

typedef int(*FunctieComparare)(Payment p1, Payment p2, char crit[20], char order[20]);

int sort_cheltuiala(List* l, char crit[20], char order[20] , FunctieComparare comp);

int comp_order(Payment p1, Payment p2, char crit[20], char order[20]);

void test_adaugare();

void test_filter();

void run_tests_service();

void test_delete();

void test_comp_order();

void test_sort();