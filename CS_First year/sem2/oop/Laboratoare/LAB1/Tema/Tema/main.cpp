#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include <math.h>

void descompunere(int *x, int val)
{
	/*PARAM: *x - integer pointer type and val - prime integer
	Functie care afiseaza pe ecran pentru o valoare numarul de puteri prime val continute in *x, despartite daca este cazul cu simbolul */

	if (*x % val == 0) {

		while (*x % val == 0)
		{
			printf("%d", val);
			*x = *x / val;
			if (*x != 1) {
				printf("%s", "*");
			}
		}
	}
}

bool prime(int valoare)
{
	/*PARAM : valoare - integer value greater than 1
	Functie care testeaza daca un numar dat este prim sau nu
	RETRUN : 1 - daca numarul este prim , 0 - in caz contrar*/

	if (valoare < 2)
		return 0;
	else 
	{
		int pas_curr = 2;
		double radical = sqrt(valoare);
		while (pas_curr <= radical)
		{
			if (valoare % pas_curr == 0) {
				return 0;
			}
			pas_curr = pas_curr + 1;
		}
		return 1;
	}

}

void meniu_print()
{
	/*Functie care afiseaza pe ecranul utilizatorului un mic meniu al aplicatiei*/
	printf("%s", "*****MENIU*****");
	printf("\n");
	printf("1.Factorizare numar nou !");
	printf("\n");
	printf("2.Iesire program !");
}

int main()
{

	bool continues = 1;
	
	while (continues == 1)
	{
		printf("\n");
		meniu_print();
		printf("\n");

		printf("Introduceti optiunea dorita : ");

		int option = 0;
		scanf("%d", &option);


		if (option != 1 && option != 2)
		{
			printf("Optiune introdusa invalida , va rugam reincercati!");
			printf("\n");
		}
		else 
		{
			if (option == 2)
			{
				continues = 0;
				printf("Multumim ca ati utilizat programul !");
			}
			else
			{
				int n = 0;
				printf("%s", "Introduceti numarul n dorit : ");
				scanf("%d", &n);

				if (n <= 0) {
					printf("%s", "Atentie , numarul introdus nu este unul pozitiv mai mare decat zero ! ");
				}
				else {
					if (n == 1 || n == 2) {
						printf("%s %d", "Descompunerea lui n este : ", n);
					}
					else
					{
						int curr_factor = 2;
						while (n != 1)
						{
							if (prime(curr_factor) == 1)
								descompunere(&n, curr_factor);
							curr_factor = curr_factor + 1;
						}
					}
				}
			}
			printf("\n");
		}
	}
}