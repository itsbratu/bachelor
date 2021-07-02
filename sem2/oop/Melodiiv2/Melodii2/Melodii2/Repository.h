#pragma once
#include "Melodie.h"
#include <vector>
#include <iostream>
#include <fstream>
class Repository
{

	private:
		//vector unde sunt salvate date si inca doua metode de citire/scriere in fisier
		vector<Melodie> v;
		std::string filename;
		void LoadFromFile();
		void SaveToFile();
	public:
		//constructor care primeste un nume de fisier
		Repository(std::string f) : filename{ f } {
			LoadFromFile();
		}
		//Adauga o melodie in lista
		//m - "Melodie" object
		//Return : -
		void add(const Melodie& m);

		//Sterge o melodie din lista
		//id - int (id-ul dupa care se realizeaza stergerea)
		//Return : -
		void del(const int id);

		//Preia toate elementele curente din lista
		//Return - vector<Melodie> all care contine toate intrarile curente
		vector<Melodie> getall() noexcept;
};

//clasa care semnaleaza erorile din interiorul repoului

class ErrorRepo {
	string msg;

	public:
		ErrorRepo(string e) : msg{ e } {}
		friend ostream& operator<<(ostream& out, const ErrorRepo& ex);

};

//supraincarcare operator <<
ostream& operator<<(ostream& out, const ErrorRepo& ex);

