#pragma once
#include "service.h"

void print_menu();

void print_cheltuieli(List* afisare);

int get_choice();

int add_ui(List* list);

int modify_ui(List* l);

int delete_ui(List* l);

List* filter_ui(List* l);

int sort_ui(List* l);