#include <iostream>
#include <fstream>

/*

1. Fie un fisier ce contine un graf neorientat reprezentat sub forma: prima linie contine numarul nodurilor iar urmatoarele randuri muchiile grafului.
Sa se scrie un program in C/C++ care sa citeasca fisierul si sa reprezinte/stocheze un graf folosind matricea de adiacenta, lista de adiacenta si matricea de incidenta.
Sa se converteasca un graf dintr-o forma de reprezentare in alta.

Fisier -> matrice de adiacenta -> lista adiacenta -> matrice de incidenta -> lista adiacenta -> matrice de adiacenta -> matrice de incidenta

exemplu fisier
in.txt
4
1 2
3 4
2 3
4 2

*/

using namespace std;

struct muchie
{
	int x1;
	int x2;
};

int main()
{
	ifstream fin("in.txt");

	muchie incidenta[100][100];
	int nr_muchii = 0;
	int matrix[100][100] = { 0 };
	int linie = 0, coloana = 0;
	int n = 0;

	for (int i = 1; i <= n; ++i)
		for (int j = 1; j <= n; ++j)
			matrix[i][j] = 0;

	fin >> n;
	
	while (fin >> linie >> coloana) 
	{
		matrix[linie][coloana] = 1;
		matrix[coloana][linie] = 1;

		nr_muchii++;
		incidenta[nr_muchii]->x1 = linie;
		incidenta[nr_muchii]->x2 = coloana;
	}

	cout << "Fisier -> matrice de adiacenta : " << endl;

	for (int i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
			cout << matrix[i][j] << " ";
		cout << endl;
	}

	cout << endl << endl;

	int adiacenta[100][100] = { 0 };
	int contor[100] = { 0 };

	cout << "Matrice de adiacenta -> lista adiacenta :";
	cout << endl;

	for(int i = 1; i <=n; ++i)
		for (int j = 1; j <= n; ++j)
		{
			if (matrix[i][j] == 1)
			{
				contor[i]++;
				adiacenta[i][contor[i]] = j;
			}
		}

	for (int i = 1; i <= n; ++i)
	{
		int curr = 1;
		cout << i << ":" << " ";
		while (curr <= contor[i])
		{
			cout << adiacenta[i][curr] << " ";
			curr++;
		}
		cout << endl;
	}

	cout << endl;

	cout << "Lista adiacenta -> matrice de incidenta : ";
	cout << endl;

	int matrix_incidenta[100][100] = { 0 };

	for (int i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
		{
			if (i == incidenta[j]->x1 || i == incidenta[j]->x2)
				matrix_incidenta[i][j] = 1;
		}
	}

	for (int i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
			cout << matrix_incidenta[i][j] << " ";
		cout << endl;
	}
	cout << endl;
	cout << "Matrice de incidenta -> lista adiacenta : " << endl;

	for (int i = 1; i <= n; ++i)
		for (int j = 1; j <= n; ++j)
		{
			adiacenta[i][j] = 0;
			contor[i] = 0;
		}

	for (int i = 1; i <= n; ++i)
	{
		int nr_adiacente = 0;
		for (int j = 1; j <= n; ++j)
		{
			if (matrix_incidenta[i][j] == 1)
			{
				nr_adiacente++;
				int vf1 = incidenta[j]->x1;
				int vf2 = incidenta[j]->x2;

				if (vf1 == i)
					adiacenta[i][nr_adiacente] = vf2;
				else
					adiacenta[i][nr_adiacente] = vf1;
			}
		}
		contor[i] = nr_adiacente;
	}

	for (int i = 1; i <= n; ++i)
	{
		int curr = 1;
		cout << i << ":" << " ";
		while (curr <= contor[i])
		{
			cout << adiacenta[i][curr] << " ";
			curr++;
		}
		cout << endl;
	}

	cout << endl;

	cout << "Lista adiacenta -> matrice de adiacenta :  ";
	cout << endl;

	for (int i = 1; i <= n; ++i)
		for (int j = 1; j <= n; ++j)
			matrix[i][j] = 0;

	for(int i = 1; i <=n ;++ i)
		for (int j = 1; j <= contor[i]; ++j)
		{
			matrix[i][adiacenta[i][j]] = 1;
			matrix[adiacenta[i][j]][i] = 1;
		}

	for (int i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
			cout << matrix[i][j] << " ";
		cout << endl;
	}

	cout << endl;

	cout << "Matrice de adiacenta -> matrice incidenta: ";
	cout << endl;

	for (int i = 1; i <= n; ++i)
		for (int j = 1; j <= n; ++j)
			matrix_incidenta[i][j] = 0;

	for (int i = 1; i <= n; ++i)
	{
		for (int j = 1; j <= n; ++j)
		{
			if (matrix[i][j] == 1)
			{
				int curr_muchie = 1;
				while (curr_muchie <= nr_muchii)
				{
					if((incidenta[curr_muchie]->x1 == i && incidenta[curr_muchie]->x2 == j) || (incidenta[curr_muchie]->x1 == j && incidenta[curr_muchie]->x2 == i))
						matrix_incidenta[i][curr_muchie] = 1;
					curr_muchie = curr_muchie + 1;
				}
			}
		}
	}

	for(int i = 1 ; i <=n ; ++i)
	{
		for (int j = 1; j <= n; ++j)
			cout << matrix_incidenta[i][j] << " ";
			cout << endl;
	}
	cout << endl;

	fin.close();

}