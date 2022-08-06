#include <iostream>
#include <fstream>
#include <queue>

/*
2. Fie un graf reprezentat sub o anumita forma (graful este citit dintr-un fisier). Sa se rezolve:
a. sa se determine nodurile izolate dintr-un graf.
b. sa se determine daca graful este regular.
c. pentru un graf reprezentat cu matricea de adiacenta sa se determine matricea distantelor.
d. pentru un graf reprezentat cu o matrice de adiacenta sa se determine daca este conex.
*/


using namespace std;

/*Variabile folosite pentru d) */
int k = 0;
bool included[100] = { 0 };
int lungime2[100] = { 0 };
int adiacenta2[100][100] = { 0 };

/*Variabile folosite pentru c) */
int valoare;
int dist[100] = { -1 };
int lungime1[100] = { 0 };
int adiacenta1[100][100] = { 0 };
int l = 0;
int matrix_result[100][100] = { 0 };
queue <int> noduri;

/*Functie care realizeaza parcurgerea in adancime pentru graful de la d) in mod recursiv*/
void dfs(int s)
{
	included[s] = 1;
	for (int i = 1; i <= lungime2[s]; ++i)
		if (included[adiacenta2[s][i]] == 0 && s!= adiacenta2[s][i])
			dfs(adiacenta2[s][i]);
}


/*Functie care realizeaza un algoritm similar Dijkstra cu queue din STL*/
void shortest_path(int s)
{
	noduri.push(s);
	int copy_s = s;
	while (!noduri.empty())
	{
		int curr_nod = noduri.front();
		noduri.pop();

		for (int i = 1; i <= lungime1[curr_nod]; ++i)
		{
			int adiacent_nod = adiacenta1[curr_nod][i];
			if (dist[adiacent_nod] == -1 || dist[adiacent_nod] > dist[curr_nod] + 1)
			{
				dist[adiacent_nod] = dist[curr_nod] + 1;
				noduri.push(adiacent_nod);
			}
		}
	}
	for (int i = 1; i <= l; ++i)
		matrix_result[copy_s][i] = dist[i];
}

/*Functie de reinitializare a vectorului de distante*/
void reinitialize(int dist[100])
{
	for (int i = 1; i <= l; ++i)
		dist[i] = -1;
}

int main()
{

	/*Pentru subpunctele a si b voi folosi ca metodă de citire : lista de adiacență deoarece este necesară doar o verificare asupra gradelor vârfurilor din graf - θ(E) unde E - nr. muchii*/

	ifstream fin1("lista.txt"); /*Am terminat fiecare linie din fisier cu -1 pentru a sti cand se trece la urmatorul varf , fara a mai include caractere speciale in .txt(: sau ,)*/
	int n = 0; 
	int nod_curr = 1, vecin = -1;
	int grad[200] = { 0 }; /*vector static in care salvam gradul fiecarui nod*/

	fin1 >> n;
	fin1 >> vecin;

	while (fin1 >> vecin)
	{
		if (vecin == -1)
		{
			nod_curr++;
			fin1 >> vecin;
		}
		else
			grad[nod_curr]++;
	}

	fin1.close();

	/*a) Sa se determine nodurile izolate din graf.*/

	cout << "Nodurile izolate din graf sunt : ";
		for (int i = 1; i <= n; ++i)
			if (grad[i] == 0)
				cout << i << " ";
		cout << endl << endl;
	
	/*b) Sa se determine daca graful este regular.*/

	int grad_graf = grad[1];
	bool ok = 1;
	for (int i = 2; i <= n; ++i)
		if (grad[i] != grad_graf)
			ok = 0;
	if (ok == 1)
		cout << "Graful dat este unul regular !";
	else
		cout << "Graful dat nu este unul regular ! ";
	cout << endl << endl;

	/*c)Pentru un graf reprezentat cu matricea de adiacenta sa se determine matricea distantelor. */

	ifstream fin2("distanta.txt");

	fin2 >> l;
	
	for (int i = 1; i <= l; ++i)
	{
		for (int j = 1; j <= l; ++j)
		{
			fin2 >> valoare;
			if (valoare != 0)
			{
				lungime1[i]++;
				adiacenta1[i][lungime1[i]] = j;
			}
		}
	}
	fin2.close();

	for (int i = 1; i <= l; ++i)
	{
		reinitialize(dist);
		dist[i] = 0;

		shortest_path(i);
	}

	for (int i = 1; i <= l; ++i)
	{
		for (int j = 1; j <= l; ++j)
		{
			cout << matrix_result[i][j] << " ";
		}
		cout << endl;
	}

	cout << endl;
	/*d) Pentru un graf reprezentat cu o matrice de adiacenta sa se determine daca este conex.*/

	ifstream fin3("conex.txt");

	fin3 >> k;
	for (int i = 1; i <= k; ++i)
	{
		for (int j = 1; j <= k; ++j)
		{
			fin3 >> valoare;
			if (valoare != 0)
			{
				lungime2[i]++;
				adiacenta2[i][lungime2[i]] = j;
			}
		}
	}
	fin3.close();

	dfs(1);
	bool conex = 1;
	for (int i = 1; i <= k; ++i)
		if (included[i] == 0)
			conex = 0;
	
	if (conex == 1)
		cout << "Graful dat este conex !";
	else
		cout << "Graful dat nu este conex !";

	
}