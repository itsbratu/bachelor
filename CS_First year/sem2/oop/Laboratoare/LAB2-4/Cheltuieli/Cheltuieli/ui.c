#define _CRT_SECURE_NO_WARNINGS
#include "ui.h"
#include <stdio.h>
#include <ctype.h>
#include <stdlib.h>

void print_menu()
{
	/*Functie care afiseaza pe ecranul utilizatorului meniul aplicatiei
	*/

	printf("*************MENIU*************\n");
	printf("1.Adaugare cheltuiala ! \n");
	printf("2.Modificare cheltuiala!  \n");
	printf("3.Stergere cheltuiala ! \n");
	printf("4.Filtrare lista de cheltuieli dupa un anumit criteriu !\n");
	printf("5.Sortare lista de cheltuieli dupa tip/suma in ordine crescatoare/descrescatoare !\n");
	printf("6.Afisare lista curenta ! \n");
	printf("7.Exit !\n");
}

void print_cheltuieli(List *afisare)
{
	/*PARAM : afisare - pointer to List object
	Functie care  afiseaza pe ecranul utilizatorului continutului unui obiect indicat de pointerul afisare
	*/

	printf("%d \n", afisare->size);
	for (int i = 0; i < afisare->size; ++i)
		printf("%d %d %s\n", afisare->elem[i].apartament, afisare->elem[i].suma, afisare->elem[i].type);
}

int get_choice()
{
	/*
	Functie care permite utilizatorului sa aleaga optiuni din meniul aplicatiei
	RETURN : 0 - daca utilizatorul decide sa iasa din aplicatie
	*/

	int end_choice = 0;
	List* l = create_list(100);

	while (end_choice == 0)
	{
		print_menu();
		printf("\n");
		printf("Va rugam sa alegeti optiunea dorita:");

		char choice[20];
		int valid_choice = 1;
		scanf("%s", choice);
		printf("\n");

		int lng = strlen(choice);
		for (int i = 0; i < lng; ++i)
			if (!isdigit(choice[i]))
				valid_choice = 0;
		if (valid_choice == 1)
		{
			int choice_number = atoi(choice);
			if (choice_number < 1 || choice_number > 7)
				valid_choice = 0;

			if (valid_choice == 1)
			{
				if (choice_number == 1)
				{
					int result = add_ui(l);
					if (result == 0)
						printf("Datele introduse pentru cheltuiala incorecte! \n");
				}
				if (choice_number == 2)
				{
					int result = modify_ui(l);
					if (result == 0)
						printf("Datele introduse pentru schimbarea cheltuielii incorecte ! \n");
				}
				if (choice_number == 3)
				{
					int result = delete_ui(l);
					if (result == 0)
						printf("Datele introduse pentru stergerea cheltuielii incorecte ! \n ");
				}
				if (choice_number == 4)
				{
					List* result = filter_ui(l);
					if (result->size == 0)
						printf("Nu exista cheltuieli cu filtrul dorit/datele nu au fost introduse corect ! \n");
					else
						print_cheltuieli(result);
					destroy_list(result);
				}
				if (choice_number == 5)
				{
					if (l->size == 0)
						printf("Nu se poate aplica filtru deoarece nu exista cheltuieli curente! \n");
					int result = sort_ui(l);
					if (result == 0)
						printf("Criterii despre sortare invalide ! \n");
					else
						print_cheltuieli(l);
				}
				if (choice_number == 6)
					print_cheltuieli(l);
				if (choice_number == 7)
				{
					destroy_list(l);
					end_choice = 1;
				}
			}
			else
				printf("Optiunea introdusa invalida ! \n");
		}
		else
			printf("Optiunea introdusa invalida ! \n");
	}

	return 0;

}

int add_ui(List* l)
{
	/*PARAM : l - pointer to List object
	Functie care permite utilizatorului sa introduca campurile unui obiect de tip Payment pentru o viitoare adaugare in lista
	RETURN : 0 - daca datele introduse de utilizator sunt gresite , 1 - caz contrar
	*/

	char ap_citit[20], valoare_citita[20], tip_citit[20];
	printf("Va rugam introduceti numarul apartamentului : ");
	scanf("%s", ap_citit);
	printf("Va rugam introduceti valoarea cheltuielii : ");
	scanf("%s", valoare_citita);
	printf("Va rugam introduceti tipul cheltuielii : ");
	scanf("%s", tip_citit);
	printf("\n");

	int result_adaugare = add_cheltuiala(l, ap_citit, valoare_citita, tip_citit);
	return result_adaugare;
}

int modify_ui(List* l)
{
	/*PARAM : l - pointer to List object
	Functie care permite utilizatorului sa introduca o cheltuiala pe care doreste sa o modifice in lista existenta
	RETURN : 0 - daca datele introduse de catre utilizator sunt invalide , 1 - caz contrar
	*/

	char ap_citit[20], valoare_citita[20], tip_citit[20];
	printf("Va rugam introduceti numarul apartamentului unde doriti modificarea: ");
	scanf("%s", ap_citit);
	printf("Va rugam introduceti noua valoarea pentru cheltuiala : ");
	scanf("%s", valoare_citita);
	printf("Va rugam introduceti numele cheltuielii unde doriti modificarea : ");
	scanf("%s", tip_citit);
	printf("\n");

	int result_modify = modify_cheltuiala(l, ap_citit, valoare_citita, tip_citit);
	return result_modify;
}

int delete_ui(List* l)
{

	/*PARAM : l - pointer to List object
	Functie care permite utilizatorului sa introduca o cheltuiala pe care doreste sa o stearga din lista
	RETURN : 0 - datele introduse de utilizator sunt invalide , 1 - caz contrar
	*/

	char ap_citit[20], tip_citit[20];
	printf("Va rugam introduceti numarul apartamentului unde doriti sa faceti stergerea : ");
	scanf("%s", ap_citit);
	printf("Va rugam introduceti tipul cheltuielii unde doriti sa faceti stergerea : ");
	scanf("%s", tip_citit);
	printf("\n");

	int result_delete = delete_cheltuiala(l, ap_citit, tip_citit);
	return result_delete;
}

List* filter_ui(List* l)
{

	/*PARAM : l - pointer to List object
	Functie care permite utilizatorului sa introduca un filtru si o valoare pentru aceasta pentru vizualizarea anumitor elemente din lista existenta
	RETURN : filtered - pointer to List oject (poate sa pointeze spre o locatie goala daca nu exista elemente care satisfac filtrul / datele introduse incorecte)
	*/

	char filter[20], filter_value[20];
	printf("Va rugam introduceti filtrul dorit(suma/tip/apartament) : ");
	scanf("%s", filter);
	printf("Va rugam introduceti valoarea asociata filtrului : ");
	scanf("%s", filter_value);
	printf("\n");

	List* filtered = filter_cheltuiala(l, filter, filter_value);
	return filtered;

}

int sort_ui(List* l)
{
	/*PARAM : l - pointer to List object
	Functie care ordoneaza elementele curente din lista dupa un anumit criteriu : tip/suma (crescator sau descrescator)
	*/
	char crit[20], order[20];
	printf("Va rugam introduce criteriul dorit(tip / suma) : ");
	scanf("%s", crit);
	printf("Va rugam introduceti modul de ordonare(crescator / descrescator) : ");
	scanf("%s" , order);
	printf("\n");

	int result = sort_cheltuiala(l, crit, order , comp_order);
	return result;
}