/*
5. Pentru un graf dat să se afișeze pe ecran vârfurile descoperite de apelul recursiv al procedurii DFS_VISIT(G, u) (apadurea descoperită de DFS).
*/

#include <iostream>
#include <fstream>

using namespace std;

int n = 0, v1 = 0, v2 = 0;
int* lungime;
int* found;
int** matrix;


void DFS(int s)
{
	found[s-1] = 1;
	int nr_neib = lungime[s - 1];
	for (int i = 0; i < nr_neib; ++i)
	{
		int neib = matrix[s - 1][i];
		if (found[neib - 1] == 0)
			DFS(neib);
	}
}

int main()
{
	ifstream fin("depth.in");

	fin >> n;
	
	lungime = (int*)(calloc(n, sizeof(int)));
	found = (int*)(calloc(n, sizeof(int)));
	matrix = (int**)(calloc(n, sizeof(int*)));

	for (int i = 0; i < n; ++i)
		matrix[i] = (int*)(calloc(n, sizeof(int)));

	while (fin >> v1 >> v2)
	{
		matrix[v1 - 1][lungime[v1-1]] = v2;
		matrix[v2 - 1][lungime[v2-1]] = v1;
		lungime[v1 - 1]++;
		lungime[v2 - 1]++;
	}	
	DFS(1);

	cout << "Arborele gasit din nodul 1 utilizand DFS este format din nodurile : " << endl;
	for (int i = 0; i < n; ++i)
		if (found[i] == 1)
			cout << i + 1 << " ";
}