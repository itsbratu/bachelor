#define _CRT_SECURE_NO_DEPRECATE
#include <stdio.h>
#include <math.h>

bool prime(int valoare)
{
	/*PARAM : valoare - integer value greater than 1
	Functie care testeaza daca un numar dat este prim sau nu
	RETRUN : 1 - daca numarul este prim , 0 - in caz contrar*/

	if (valoare < 2)
		return 0;
	else
	{
		int curr = 2;
		double radical = sqrt(valoare);
		while (curr <= radical)
		{
			if (valoare % curr == 0) {
				return 0;
			}
			curr = curr + 1;
		}
		return 1;
	}
}

void meniu_print()
{
	/*Functie care afiseaza pe ecranul utilizatorului un mic meniu al aplicatiei*/
	printf("%s", "*****MENIU*****");
	printf("\n");
	printf("1.Gasire descompunere nou numar !");
	printf("\n");
	printf("2.Iesire program !");
}

void solution(int m)
{
	/*PARAM : m - integer greater than 2
	Functie care afiseaza pe ecran una dintre descompunerile in suma de doua numere prime ale parametrului m*/
	int prime1 = 2;
	int prime2 = 0;

	bool solution_stop = 0;

	while (solution_stop == 0)
	{
		if (prime(prime1) == 1)
		{
			prime2 = m - prime1;
			if (prime(prime2) == 1)
			{
				printf("Solutia este : %d + %d", prime1, prime2);
				printf("\n");
				solution_stop = 1;
			}
		}
		prime1 = prime1 + 1;
	}

}

int main()
{
	bool stop = 0;

	while (stop != 1)
	{
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
				stop = 1;
				printf("Multumim ca ati utilizat programul !");
				printf("\n");
			}
			else
			{
				int n = 0;
				printf("%s", "Introduceti numarul dorit : ");
				scanf("%d", &n);

				if (n <= 2)
				{
					printf("%s", "Atentie , numarul introdus invalid!");
					printf("\n");
				}
				else
				{
					solution(n);
				}
			}
		}
		printf("\n");
	}
}