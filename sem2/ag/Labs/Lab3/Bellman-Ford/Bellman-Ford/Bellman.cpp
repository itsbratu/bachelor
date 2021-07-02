#include <fstream>
#include <iostream>
#include <vector>

#include "Adj.h"

#define NMAX 15000000

using namespace std;

vector <Edge> adj;
vector <Vortex> v;
int nmb_vortex, nmb_edge, s;
int x_read, y_read, w_read;

void start_point(int s) {
	int aux_vortex = nmb_vortex;

	while (aux_vortex != 0) {
		Vortex curr_vortex;
		curr_vortex.p = -1;
		curr_vortex.d = NMAX;
		v.push_back(curr_vortex);
		aux_vortex--;
	}
	v[s].d = 0;
}

void relax(int x, int y, int w) {
	if (v[y].d > v[x].d + w) {
		v[y].d = v[x].d + w;
		v[y].p = x;
	}
}

bool bellman_ford(int s) {
	start_point(s);
	for (int i = 1; i <= nmb_edge - 1; ++i) {
		for (int i = 0; i < nmb_edge; ++i) {
			relax(adj[i].x, adj[i].y, adj[i].w);
		}
	}
	for (int i = 0; i < nmb_edge; ++i) {
		if (v[adj[i].y].d > v[adj[i].x].d + adj[i].w)
			return false;
	}
	return true;
}

int main() {

	ifstream fin("in.txt");

	fin >> nmb_vortex;
	fin >> nmb_edge;
	fin >> s;
	int aux = nmb_edge;

	while (aux != 0) {
		Edge edge_add;
		fin >> edge_add.x >> edge_add.y >> edge_add.w;
		adj.push_back(edge_add);
		aux--;
	}

	fin.close();

	bellman_ford(s);

	ofstream fout("out.txt");

	for (int i = 0; i < nmb_vortex; ++i)
	{
		if (v[i].d == NMAX)
			fout << "INF ";
		else
			fout << v[i].d << " ";
	}

	fout.close();

}