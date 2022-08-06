#include <iostream>
#include <fstream>

using namespace std;

int n, m;
int** incidenta;
int* adiacenta;
int** matrix;
int* exterior;
int* interior;


int main()
{
	ifstream fin("date.txt");
	
	fin >> n >> m;

	incidenta = new int* [n];
	for (int i = 0; i < n; i++) {
		incidenta[i] = new int[m];
		for (int j = 0; j < m; ++j) {
			incidenta[i][j] = 0;
		}
	}
	
	int v1, v2;
	for (int i = 0; i < m; ++i) {
		fin >> v1 >> v2;
		incidenta[v1][i] = 1;
		incidenta[v2][i] = 1;
	}
	fin.close();

	matrix = (int**)(calloc(n, sizeof(int*)));

	for (int i = 0; i < n; ++i)
		matrix[i] = (int*)(calloc(n, sizeof(int)));

	int poz1 = -1, poz2 = -1;
	for (int i = 0; i < m; ++i) {
		for (int j = 0; j < n; ++j) {
			if (incidenta[i][j] == 1) {
				if (poz1 == -1)
					poz1 = j;
				else
				{
					poz2 = j;

				}
				
			}
		}
		matrix[poz1][poz2] = 1;
	}

	exterior = (int*)(calloc(n, sizeof(int)));
	interior = (int*)(calloc(n, sizeof(int)));

	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < n; ++j)
		{
			if (matrix[i][j] == 1)
				exterior[i]++;
		}
	}

	for (int i = 0; i < n; ++i) {
		for (int j = 0; j < n; ++j)
		{
			if (matrix[j][i] == 1)
				interior[i]++;
		}
	}

	ofstream fout("iesire.txt");

	int nr = 0;
	for (int i = 0; i < n; ++i)
	{
		if (interior[i] < exterior[i])
		{
			nr++;
			fout << "Varful i" << endl;
		}
	}

	fout << nr;

	return 0;
}