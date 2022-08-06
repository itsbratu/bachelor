#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

#define DONE -100

int nmb_vortex , parent_curr;
vector<int>parent;
vector<int>coding;

int find_min() {
	int min_result = 0;
	for (int i = 0; i < nmb_vortex; ++i) {
		bool leaf = true;
		if (parent[i] >= 0)
		{
			for (int j = 0; j < nmb_vortex; ++j) {
				if (i != j && parent[j] == i)
				{
					leaf = false;
					break;
				}
			}
			if (leaf == true)
				return i;
		}
	}
}

void Pruffer_Encoding() {
	int steps = nmb_vortex - 1;
	while (steps != 0) {
		int min_leaf = find_min();
		coding.push_back(parent[min_leaf]);
		parent[min_leaf] = DONE;
		steps--;
	}
}

int main() {

	ifstream fin("in.txt");
	fin >> nmb_vortex;

	for (int i = 0; i < nmb_vortex; ++i) {
		fin >> parent_curr;
		parent.push_back(parent_curr);
	}

	fin.close();

	Pruffer_Encoding();
	ofstream fout("out.txt");

	fout << nmb_vortex - 1 << endl;
	for (int i = 0; i < nmb_vortex -1; ++i)
		fout << coding[i] << " ";
	fout.close();

}