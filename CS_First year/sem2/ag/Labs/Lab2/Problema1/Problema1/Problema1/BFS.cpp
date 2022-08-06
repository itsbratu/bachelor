/*
* 1. Implementați algoritmul lui Moore pentru un graf orientat neponderat (algoritm bazat pe Breath-first search, vezi cursul 2). 
     Datele sunt citete din fisierul graf.txt. 
     Primul rând din graf.txt conține numărul vârfurilor, iar următoarele rânduri conțin muchiile grafului. 
     Programul trebuie să afiseze lanțul cel mai scurt dintr-un vârf (vârful sursa poate fi citit de la tastatura).
*/

#include <queue>
#include <iostream>
#include <fstream>
#define NMAX 100000
#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h>

using namespace std;

int n = 0, v1 = 0, v2 = 0, v_s = 0, v_d = 0, index = 0;
int* lungime;
int** matrice;
int* distanta;
int* parent;
int* path;

void Moore(int s)
{
    for (int v = 0; v < n; ++v)
    {
        distanta[v] = NMAX;
        parent[v] = -1;
    }
    distanta[s - 1] = 0;
    queue <int> q;
    while (!(q.empty()))
        q.pop();
    q.push(s-1);
    while (!(q.empty()))
    {
        int curr = q.front();
        q.pop();
        for (int ind = 0; ind < lungime[curr]; ++ind)
        {
            if (distanta[matrice[curr][ind]-1] == NMAX)
            {
                parent[matrice[curr][ind]-1] = curr + 1;
                distanta[matrice[curr][ind] - 1] = distanta[curr] + 1;
                q.push(matrice[curr][ind] - 1);
            }
        }
    }
}

void drum_Moore(int p)
{
    while (parent[p] != -1)
    {
        index = index + 1;
        path[index] = parent[p];
        p = parent[p] - 1;
    }
}

void free_memory()
{
    for (int i = 0; i < n; ++i)
        free(matrice[i]);
    free(matrice);
    free(path);
    free(lungime);
    free(parent);
    free(distanta);
}

int main()
{
    
    ifstream fin("graf.txt");
    fin >> n;

    lungime = (int*)(calloc(n , sizeof(int)));
    matrice = (int**)(calloc(n , sizeof(int*)));
    distanta = (int*)(calloc(n, sizeof(int)));
    parent = (int*)(calloc(n, sizeof(int)));
    path = (int*)(calloc(n*n, sizeof(int)));

    for (int i = 0; i < n; ++i)
        matrice[i] = (int*)(calloc(n , sizeof(int)));

    while (fin >> v1 >> v2)
    {
        matrice[v1-1][lungime[v1-1]] = v2;
        /*matrice[v2-1][lungime[v2-1]] = v1;*/
        lungime[v1-1]++;
        //lungime[v2-1]++;
    }
    v_s = 1;
    v_d = 3;
   
    Moore(v_s);

    if (distanta[v_d - 1] == NMAX)
        cout << "Nu se poate stabili un drum minim intre sursa si destinatie !";
    else
    {
        cout << "Drumul este compuns din : " << endl;
        path[index] = v_d;
        drum_Moore(v_d-1);

        cout << v_s << "-";

        for (int i = index - 1; i > -1; --i)
        {
            if (i != 0)
                cout << path[i] << "-";
            else
                cout << path[i];
        }
        cout<< ", cu distanta de : " << distanta[v_d - 1];

    }
 
    free_memory();
    _CrtDumpMemoryLeaks();

    return 0;

}