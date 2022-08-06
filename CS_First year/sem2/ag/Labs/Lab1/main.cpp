#include <iostream>
#include <fstream>

/*

1. Fie un fisier ce contine un graf neorientat reprezentat sub forma: prima linie contine numarul nodurilor iar urmatoarele randuri muchiile grafului.
Sa se scrie un program in C/C++ care sa citeasca fisierul si sa reprezinte/stocheze un graf folosind matricea de adiacenta, lista de adiacenta si matricea de incidenta.
Sa se converteasca un graf dintr-o forma de reprezentare in alta.
	
Fisier -> matrice de adiacenta -> lista adiacenta -> matrice de incidenta -> lista adiacenta -> matrice de adiacenta -> lista.

exemplu fisier
in.txt
4
1 2
3 4
2 3
4 2

*/

struct punct
{
int l;
int c;
};

using namespace std;

int main()
{
    ifstream fin("in.txt");
    int m[20][20], n, lin, col;

    int l[20][20];

    punct lista[40];
    int muchii = 0;

    int inc[20][30];


    ////// Fisier -> Matricea de adiacenta


    fin>>n;

    for (int i=1;i<=n;i++)
        for (int j=1;j<=n;j++)
            m[i][j]=0;

    while(fin>>lin>>col)
    {
        m[lin][col]=1;
        m[col][lin]=1;
    }

    cout<<"Fisier -> Matricea de adiacenta: "<<endl;
    for (int i=1;i<=n;i++)
    {
        for (int j=1;j<=n;j++)
            cout<<m[i][j]<<" ";
    cout<<endl;
    }


    ////// Matrice de adiacenta -> Lista de adiacenta


    for (int i=1;i<=n;i++)
        l[i][0] = 0;

    for (int i=1;i<=n;i++)
        for(int j=1;j<=n;j++)
            if (m[i][j]==1)
            {
                l[i][0]++;
                l[i][l[i][0]]=j;
            }

    cout<<endl<<"Matrice de adiacenta -> Lista de adiacenta: "<<endl;
    for (int i=1;i<=n;i++)
    {
    cout<<i<<": ";
        for (int j=1; j<=l[i][0];j++)
            cout<<l[i][j]<<" ";
    cout<<endl;
    }


    ////// Lista adiacenta -> Matrice de incidenta


    for (int i=1;i<=n;i++)
        for (int j=1; j<=l[i][0];j++)
        {
            muchii++;
            lista[muchii].l = i;
            lista[muchii].c = l[i][j];
        }

    for (int i=1; i<=muchii; i++)
        for (int j=i+1;j<=muchii;j++)
            if (lista[i].l == lista[j].c && lista[i].c == lista[j].l)
                for (int k=j;k<muchii;k++)
                {
                    lista[k]=lista[k+1];
                    muchii--;
                }

    /*
    cout<<endl<<"Lista de muchii: "<<endl;
    for (int i=1;i<=muchii;i++)
        cout<<"["<<lista[i].l<<","<<lista[i].c<<"] ";
    cout<<endl;
    */

    for (int i=1;i<=n;i++)
        for (int j=1;j<=muchii;j++)
        inc[i][j]=0;

    for (int i=1;i<=muchii;i++)
    {
        inc[lista[i].l][i]=1;
        inc[lista[i].c][i]=1;
    }

    cout<<endl<<"Lista adiacenta -> Matrice de incidenta: "<<endl;
    for (int i=1;i<=n;i++)
    {
        for(int j=1;j<=muchii;j++)
        cout<<inc[i][j]<<" ";
    cout<<endl;
    }


    ////// Matrice incidenta -> Lista de adiacenta


    for (int i=1;i<=n;i++)
        l[i][0] = 0;

    for (int i=1;i<=muchii;i++)
        for(int j=1;j<=n;j++)
            if (m[i][j]==1)
            {
                l[i][0]++;
                l[i][l[i][0]]=j;
            }

    cout<<endl<<"Matrice incidenta -> Lista de adiacenta: "<<endl;
    for (int i=1;i<=n;i++)
    {
    cout<<i<<": ";
        for (int j=1; j<=l[i][0];j++)
            cout<<l[i][j]<<" ";
    cout<<endl;
    }


    ////// Lista de adiacenta -> Matricea de adiacenta


    for (int i=1;i<=n;i++)
        for (int j=1;j<=n;j++)
            m[i][j]=0;

    for (int i=1;i<=n;i++)
        for (int j=1; j<=l[i][0];j++)
            m[i][l[i][j]]=1;

    cout<<endl<<"Lista de adiacenta -> Matricea de adiacenta:"<<endl;
    for (int i=1;i<=n;i++)
    {
        for (int j=1;j<=n;j++)
            cout<<m[i][j]<<" ";
    cout<<endl;
    }



    fin.close();
    return 0;
}
