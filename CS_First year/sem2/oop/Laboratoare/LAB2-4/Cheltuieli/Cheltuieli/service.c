#define _CRT_SECURE_NO_DEPRECATE
#include "service.h"
#include <stdlib.h>
#include <ctype.h>
#include <string.h>
#include <assert.h>
static const char ideal_valoare[] = "100";

int comp_order(Payment p1, Payment p2, char crit[20], char order[20])
{
	/*PARAM: p1 - Payment object , p2 - Payment object , crit - char vector , order - char vector
	Functie care stabileste ordinea a doua obiecte de tip 'Payment' in functie de un criteriu si tipul ordonarii(asc / desc)
	RETURN : -1 - p1<=p2 , 1 - p1>p2
	*/
	if (strcmp(crit, "tip") == 0)
	{
		if (strcmp(order, "crescator") == 0)
		{
			if (strcmp(p1.type, p2.type) <= 0)
				return -1;
			else
				return 1;
		}
		else
		{
			if (strcmp(p1.type, p2.type) <= 0)
				return 1;
			else
				return -1;
		}
	}
	else
	{
		if (strcmp(order, "crescator") == 0)
		{
			if (p1.suma <= p2.suma)
				return -1;
			else
				return 1;
		}
		else
		{
			if (p1.suma <= p2.suma)
				return 1;
			else
				return -1;
		}
	}
}

int validare_cheltuiala(char ap_nmb[20], char valoare[20], char tip[20])
{
	/*PARAM: ap_nmb - char vector , valoare - char vector , tip - char vector
	Functie care valideaza campurile unui obiect de tip Payment introdus de catre utilizator
	RETURN: 1 - daca campurile sunt valide , 0 in caz contrar
	*/
	int len_ap = strlen(ap_nmb);
	int len_valoare = strlen(valoare);
	int is_valid = 1;

	if (len_ap == 0 || len_valoare == 0)
		is_valid = 0;

	for (int i = 0; i < len_ap; ++i)
		if (!isdigit(ap_nmb[i]))
			is_valid = 0;
	for (int i = 0; i < len_valoare; ++i)
		if (!isdigit(valoare[i]))
			is_valid = 0;
	int integer_ap = atoi(ap_nmb);
	int integer_value = atoi(valoare);
	if (integer_ap <= 0 || integer_value <= 0)
		is_valid = 0;

	if (strcmp(tip, "apa") != 0 && strcmp(tip, "canal") != 0 && strcmp(tip, "incalzire") != 0 && strcmp(tip, "gaz") != 0)
		is_valid = 0;

	return is_valid;
}

int add_cheltuiala(List* l, char ap_nmb[20], char valoare[20], char tip[20])
{
	/*PARAM : l - pointer to List object , ap_nmb - char vector , valoare - char vector , tip - char vector
	Functie care adauga in lista de cheltuieli curente o noua inregistrare daca valorile introduse sunt valide
	RETURN : 1 - daca s - a facut adaugarea cu succes , 0 - caz contrar
	*/
	int validation = validare_cheltuiala(ap_nmb, valoare, tip);
	if (validation == 0) return 0;
	else
	{
		int integer_ap = atoi(ap_nmb);
		int integer_value = atoi(valoare);
		Payment expense = create_payment(integer_ap, integer_value, tip);
		add_list(l, expense);
		return 1;
	}
}

int modify_cheltuiala(List* l, char ap_nmb[20], char valoare[20], char tip[20])
{
	/*PARAM : l - pointer to List object , ap_nmb - char vector , valoare - char vector , tip - char vector
	Functie care modifica in lista de cheltuieli o anumita inregistrare , daca datele introduse de utilizator sunt valide
	RETURN : 1 - daca modificarea a avut succes , 0 - caz contrar
	*/

	int validation = validare_cheltuiala(ap_nmb, valoare, tip);
	if (validation == 0) return 0;
	else
	{
		int integer_ap = atoi(ap_nmb);
		int integer_value = atoi(valoare);
		Payment expense = create_payment(integer_ap, integer_value, tip);
		modify_list(l, expense);
		return 1;
	}
}

int delete_cheltuiala(List* l, char ap_nmb[20], char tip[20])
{

	/*PARAM : l - pointer to List object , tip - char vector
	Functie care sterge din lista de cheltuieli o anumita inregistrare , daca datele introduse de utilizator sunt valide
	RETURN : 1 - daca stergerea a avut succes , 0 - caz contrar
	*/

	int validation = validare_cheltuiala(ap_nmb, ideal_valoare, tip);
	if (validation == 0) return 0;
	else
	{
		int integer_ap = atoi(ap_nmb);
		delete_list(l, integer_ap, tip);
		return 1;
	}
}

List* filter_cheltuiala(List* l, char filter[20], char filter_value[20])
{
	/*PARAM : l - pointer to List object , filter - char vector , filter_value - char vector
	Functie care furnizeaza o lista pe care s-a aplicat filtrul dorit de utilizator . Daca nu exista / datele introduse sunt invalide lista este vida
	RETURN : list_return - pointer List object (pointerul poate sa indice spre o lista vida daca datele introduse de utilizator sunt invalide)
	*/

	List* list_return = create_list(100);

	if (strcmp(filter, "suma") != 0 && strcmp(filter, "tip") != 0 && strcmp(filter, "apartament") != 0)
		return list_return;
	else
	{
		int valid_sum = 1;
		int valid_type = 1;
		int valid_ap = 1;
		if (strcmp(filter, "suma") == 0)
		{
			int filtered_sum = -1;
			for (int i = 0; i < strlen(filter_value); ++i)
				if (!isdigit(filter_value[i]))
					valid_sum = 0;
			if (valid_sum == 0)
				return list_return;
			else
			{
				filtered_sum = atoi(filter_value);
				if (filtered_sum <= 0)
					return list_return;
				for (int i = 0; i < l->size; ++i)
					if (l->elem[i].suma >= filtered_sum)
					{
						Payment expense = create_payment(l->elem[i].apartament, l->elem[i].suma, l->elem[i].type);
						add_list(list_return, expense);
					}
				return list_return;
			}
		}
		if (strcmp(filter, "tip") == 0)
		{
			if (strcmp(filter_value, "apa") != 0 && strcmp(filter_value, "incalzire") != 0 && strcmp(filter_value, "gaz") != 0 && strcmp(filter_value, "canal") != 0)
				valid_type = 0;
			if (valid_type == 0)
				return list_return;
			else
			{
				for (int i = 0; i < l->size; ++i)
				{
					if (strcmp(l->elem[i].type, filter_value) == 0)
					{
						Payment expense = create_payment(l->elem[i].apartament, l->elem[i].suma, l->elem[i].type);
						add_list(list_return, expense);
					}
				}
				return list_return;
			}
		}
		if (strcmp(filter, "apartament") == 0)
		{
			int filtered_ap = -1;
			for (int i = 0; i < strlen(filter_value); ++i)
				if (!isdigit(filter_value[i]))
					valid_ap = 0;
			if (valid_ap == 0)
				return list_return;
			else
			{
				filtered_ap = atoi(filter_value);
				if (filtered_ap <= 0)
					return list_return;
				for (int i = 0; i < l->size; ++i)
					if (l->elem[i].apartament == filtered_ap)
					{
						Payment expense = create_payment(l->elem[i].apartament, l->elem[i].suma, l->elem[i].type);
						add_list(list_return, expense);
					}
				return list_return;
			}
		}

	}

}

int sort_cheltuiala(List* l, char crit[20], char order[20] , FunctieComparare cmp)
{
	/*PARAM : l - pointer to List objects , crit - sort criterion , order - sort order
	Functie care sorteaza lista curenta de cheltuieli dupa un anumit criteriu , intr-o anumita ordine aleasa de utilizator
	RETURN : 0 - daca ori criteriul ori ordinea sunt introduse gresit de catre utilizator
	*/
	if((strcmp(crit , "tip") != 0) && (strcmp(crit , "suma") != 0))
		return 0;
	else
	{
		if ((strcmp(order, "crescator") != 0) && (strcmp(order, "descrescator") != 0))
			return 0;
		int i = 0, j = 0;
		for (i = 0; i < l->size - 1; ++i)
		{
			for (j = i + 1; j < l->size; ++j)
			{
				Payment p1 = create_payment(l->elem[i].apartament, l->elem[i].suma, l->elem[i].type);
				Payment p2 = create_payment(l->elem[j].apartament, l->elem[j].suma, l->elem[j].type);
				int result = cmp(p1, p2, crit, order);
				if (result == 1)
				{
					int ap_switch = p1.apartament;
					int value_switch = p1.suma;
					char type_switch[20];
					strcpy(type_switch, p1.type);

					l->elem[i].apartament = l->elem[j].apartament;
					l->elem[i].suma = l->elem[j].suma;
					strcpy(l->elem[i].type, l->elem[j].type);

					l->elem[j].apartament = ap_switch;
					l->elem[j].suma = value_switch;
					strcpy(l->elem[j].type, type_switch);
				}
				destroy_payment(p1);
				destroy_payment(p2);
			}
		}
		return 1;
	}

}

void test_validare()
{
	char tip1[20], tip2[30];
	strcpy(tip1, "apa");
	strcpy(tip2, "gaz");

	char test1_ap[20];
	char test1_valoare[20];
	strcpy(test1_ap, "100");
	strcpy(test1_valoare, "20");
	assert(validare_cheltuiala(test1_ap, test1_valoare, tip1) == 1);

	char test2_ap[20];
	char test2_valoare[20];
	strcpy(test2_ap, "ddaladal");
	strcpy(test2_valoare, "-200");
	assert(validare_cheltuiala(test2_ap, test2_valoare, tip2) == 0);
	char test_again[20];
	strcpy(test_again, "");
	assert(validare_cheltuiala(test_again, test2_valoare, tip2) == 0);
}

void test_adaugare()
{
	List* list_test = create_list(100);
	assert(list_test->size == 0);

	char t1_ap[20];
	char t1_sum[20];
	char t1_tip[20];

	strcpy(t1_ap, "10");
	strcpy(t1_sum, "100");
	strcpy(t1_tip, "gaz");

	assert(add_cheltuiala(list_test, t1_ap, t1_sum, t1_tip) == 1);
	assert(list_test->size == 1);

	char t2_ap[20];
	char t2_sum[20];
	char t2_tip[20];

	strcpy(t2_ap, "-10");
	strcpy(t2_sum, "dadaada");
	strcpy(t2_tip, "apa");

	assert(add_cheltuiala(list_test, t2_ap, t2_sum, t2_tip) == 0);
	assert(list_test->size == 1);
	destroy_list(list_test);
}

void test_modify()
{
	List* l = create_list(100);
	assert((modify_cheltuiala(l , "20", "2", "dadadadapa") == 0));

	char s1[20], s2[20], s3[20];
	strcpy(s1, "1");
	strcpy(s2, "200");
	strcpy(s3, "apa");
	add_cheltuiala(l, s1 , s2 ,s3);
	strcpy(s1, "1");
	strcpy(s2, "1000");
	strcpy(s3, "apa");
	assert((modify_cheltuiala(l, "1", "1000", "apa")) == 1);
	assert(l->elem[0].suma == 1000);
}

void test_delete()
{
	List* list_test = create_list(100);
	assert(list_test->size == 0);

	char add_ap[20];
	char add_sum[20];
	char add_tip[20];

	strcpy(add_ap, "10");
	strcpy(add_sum, "100");
	strcpy(add_tip, "apa");

	add_cheltuiala(list_test, add_ap, add_sum, add_tip);
	assert(list_test->size == 1);

	char deletef_ap[20];
	char deletef_sum[20];
	char deletef_tip[20];

	strcpy(deletef_ap, "dadalda");
	strcpy(deletef_sum, "dadadaxaxaxa");
	strcpy(deletef_tip, "altele");

	assert(delete_cheltuiala(list_test, deletef_ap, deletef_tip) == 0);
	assert(list_test->size == 1);

	assert(delete_cheltuiala(list_test, add_ap, add_tip) == 1);
	assert(list_test->size == 0);
	destroy_list(list_test);

}

void test_filter()
{
	List* list_test = create_list(100);
	assert(list_test->size == 0);

	char a1_ap[20];
	char a1_sum[20];
	char a1_tip[20];
	char a2_ap[20];
	char a2_sum[20];
	char a2_tip[20];
	char a3_ap[20];
	char a3_sum[20];
	char a3_tip[20];

	strcpy(a1_ap, "10");
	strcpy(a1_sum, "1500");
	strcpy(a1_tip, "apa");
	strcpy(a2_ap, "3");
	strcpy(a2_sum, "100");
	strcpy(a2_tip, "apa");
	strcpy(a3_ap, "3");
	strcpy(a3_sum, "150");
	strcpy(a3_tip, "gaz");
	add_cheltuiala(list_test, a1_ap, a1_sum, a1_tip);
	add_cheltuiala(list_test, a2_ap, a2_sum, a2_tip);
	add_cheltuiala(list_test, a3_ap, a3_sum, a3_tip);

	List* result = create_list(100);
	result = filter_cheltuiala(list_test, "tip", "apa");
	assert(result->size == 2);
	result = filter_cheltuiala(list_test, "apartament", "3");
	assert(result->size == 2);
	result = filter_cheltuiala(list_test, "suma", "200");
	assert(result->size == 1);
	result = filter_cheltuiala(list_test, "persoane", "4");
	assert(result->size == 0);
	result = filter_cheltuiala(list_test, "tip", "altele");
	assert(result->size == 0);
	result = filter_cheltuiala(list_test, "suma", "aadada");
	assert(result->size == 0);
	result = filter_cheltuiala(list_test, "apartament", "dadda");
	assert(result->size == 0);
	result = filter_cheltuiala(list_test, "apartament", "0");
	assert(result->size == 0);

	destroy_list(list_test);
	destroy_list(result);

}

void test_comp_order()
{
	Payment p1 = create_payment(1, 200, "apa");
	Payment p2 = create_payment(1, 300, "canal");

	assert(comp_order(p1, p2, "tip", "crescator") == -1);
	assert(comp_order(p2, p1, "tip", "crescator") == 1);
	assert(comp_order(p1, p2, "tip", "descrescator") == 1);
	assert(comp_order(p2, p1, "tip", "descrescator") == -1);

	assert(comp_order(p1, p2, "suma", "crescator") == -1);
	assert(comp_order(p2, p1, "suma", "crescator") == 1);
	assert(comp_order(p1, p2, "suma", "descrescator") == 1);
	assert(comp_order(p2, p1, "suma", "descrescator") == -1);

	destroy_payment(p1);
	destroy_payment(p2);

}


void test_sort()
{
	Payment p1 = create_payment(1, 100, "apa");
	Payment p2 = create_payment(1, 200, "gaz");
	Payment p3 = create_payment(2, 1000, "incalzire");
	Payment p4 = create_payment(3, 300, "canal");

	List* k = create_list(10);
	add_list(k, p1);
	add_list(k, p2);
	add_list(k, p3);
	add_list(k, p4);
	assert(sort_cheltuiala(k, "apartament", "dadada" , comp_order) == 0);
	assert(sort_cheltuiala(k, "tip", "normala" , comp_order) == 0);

	assert(sort_cheltuiala(k, "tip", "crescator" , comp_order) == 1);
	assert(strcmp(k->elem[0].type, "apa") == 0);
	assert(strcmp(k->elem[1].type, "canal") == 0);
	assert(strcmp(k->elem[2].type, "gaz") == 0);
	assert(strcmp(k->elem[3].type, "incalzire") == 0);

	assert(sort_cheltuiala(k, "suma", "descrescator" , comp_order) == 1);
	assert(k->elem[0].suma == 1000);
	assert(k->elem[1].suma == 300);
	assert(k->elem[2].suma == 200);
	assert(k->elem[3].suma == 100);
}


void run_tests_service()
{
	test_validare();
	test_adaugare();
	test_delete();
	test_modify();
	test_filter();
	test_comp_order();
	test_sort();
}
