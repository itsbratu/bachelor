#include <iostream>
#include <fstream>

using namespace std;

int n, m;
int p[200], d[200];

struct muchie
{
    int x;
    int y;
    int p;
};

void initializare(muchie G[], int s)
{
    for (int i = 0; i < n; i++)
    {
        d[i] = INT_MAX-500;
        p[i] = -1;
    }
    d[s] = 0;
}

void relax(int u, int v, int w)
{
    if (d[v] > d[u] + w )
    {
        d[v] = d[u] + w;
        p[v] = u;
    }
}

void BF(muchie G[], int s)
{
    initializare(G, s);
    for (int i = 0; i < m; i++)
        relax(G[i].x, G[i].y, G[i].p);
}

int main(int argc, char* argv[])
{
    muchie muchii[200];
    int s;
    char fi[100];
    char fo[100];

    cin >> fi >> fo;
    ifstream fin(fi);
    ofstream fout(fo); 
    
    //ifstream fin(argv[1]);
    //ofstream fout(argv[2]);

    fin >> n >> m >> s;
    cout << n << " " << m << " " << s << endl;

    int i,x,y,w;

    for (i = 1; i <= m; i++)
    {
        fin >> x >> y >> w;
        muchii[i-1].x = x;
        muchii[i-1].y = y;
        muchii[i-1].p = w;
    }

    for (i = 0; i < m; i++)
    {
        cout << muchii[i].x << " " << muchii[i].y << " " << muchii[i].p << endl;
    }

    BF(muchii, s);

    for (int i = 0; i < n; i++)
        if (d[i] == INT_MAX-500) fout << "INF" << " ";
        else fout << d[i] << " ";

    fout.close();
    fin.close();
    return 0;
}
