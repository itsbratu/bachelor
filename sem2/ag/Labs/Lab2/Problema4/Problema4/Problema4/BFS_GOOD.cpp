/*
4. Pentru un graf dat să se afișeze pe ecran vârfurile descoperite de algoritmul BFS și distanța față de vârful sursă (arborele descoperit).
*/

#include <iostream>
#include <fstream>
#include <queue>
#define NMAX 100000

struct varf
{
	int c;
	int d;
	int p;
};

using namespace std;

int n = 0, lista[101][101];
int lungime[101], valoare = 0, pas = 1, i = 0;
varf bfs_nods[101];
queue <int> q;

void change(int p1, int p2)
{
	int c = bfs_nods[p1].c;
	int p = bfs_nods[p1].p;
	int d = bfs_nods[p1].d;

	bfs_nods[p1].c= bfs_nods[p2].c;
	bfs_nods[p1].p= bfs_nods[p2].p;
	bfs_nods[p1].d = bfs_nods[p2].d;

	bfs_nods[p2].c = c;
	bfs_nods[p2].p = p;
	bfs_nods[p2].d = d;

}

void BFS(int s)
{

	/*
	c(culoare) :  -1 reprezinta ALB ,  0 reprezinta GRI si 1 reprezinta NEGRU
	p(parent) : 0 la initializare
	d(distanta) : NMAX(100000) la initializarea nodurilor
	*/
	for (int i = 1; i <= n; ++i)
	{
		bfs_nods[i].c = -1;
		bfs_nods[i].d = NMAX;
		bfs_nods[i].p = 0;
	}
	bfs_nods[s].c = 0;
	bfs_nods[s].d = 0;
	bfs_nods[s].p = 0;

	while (!q.empty())
		q.pop();
	q.push(s);

	while (!q.empty())
	{
		int u = q.front();
		q.pop();
		for (int i = 1; i <= lungime[u]; ++i)
		{
			if (bfs_nods[lista[u][i]].c == -1)
			{
				bfs_nods[lista[u][i]].c = 0;
				bfs_nods[lista[u][i]].d = bfs_nods[u].d + 1;
				bfs_nods[lista[u][i]].p = u;
				q.push(lista[u][i]);
			}
		}
		bfs_nods[u].c = 1;
	}
}

int main()
{
	ifstream fin("fisier.txt");
	fin >> n;

	while (fin >> valoare)
	{
		if (valoare == -1)
			pas++;
		else
		{
			if (pas != valoare)
			{
				lungime[pas]++;
				lista[pas][lungime[pas]] = valoare;
			}
		}
	}
	fin.close();

	BFS(1);

	int maxim = -1;
	for (int i = 1; i <= n; ++i)
		if (bfs_nods[i].d > 0 && bfs_nods[i].c == 1 && bfs_nods[i].d > maxim)
			maxim = bfs_nods[i].d;

	cout << "Varfurile descoperite de BFS in urma parcurgerii sunt : " << endl;
	for (int i = 1; i <= maxim; ++i)
	{
		for (int j = 1; j <= n; ++j)
		{
			if (bfs_nods[j].c == 1 && bfs_nods[j].d == i)
				cout << "------>Varful" << " " << j << " " << "a fost descoperit la o distanta de " << i << " " << "fata de varful sursa!" << endl;
		}
	}

}