#pragma once

#include "domain.h" 
void add_list(List* list, Payment p);

void modify_list(List* l, Payment chelt);

void delete_list(List* l, int ap_nmb, char tip[20]);

void test_addlist();

void test_deletelist();

void test_modifylist();

void run_tests_repo();