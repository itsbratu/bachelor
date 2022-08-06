#pragma once
#include "Domain.h"
#include <vector>
#include <iostream>
#include <fstream>

class Repository
{
	private:
		//clasa repository contine fName de unde se citesc date , un vector unde se retin date si doua metode private de salvarea / load din fisier
		std::string fName;
		vector <Melodie> songs;
		void LoadFromFile();
		void SaveToFile();
	public:
		//constructor care primeste ca argument un nume de fisier
		Repository(std::string filename) : fName{ filename } {
			LoadFromFile();
		}
		//adauga o melodie in lista
		//m - Melodie object
		void add(const Melodie& m);

		//sterge o melodie din lista doar daca aceasta nu este ultima a artistului
		//m - Melodie object
		void del(int id);

		void mod(const Melodie& m);

		//Returneaza toate obiectele "Melodie" salvate
		vector<Melodie> getall() const;

};

//clasa care semnaleaza erorile aruncate de Repository
class ErrorRepo
{
	string msg;
public:
	ErrorRepo(string err) :msg{ err } {}
	friend ostream& operator<<(ostream& out, const ErrorRepo& ex);
};

//supraincarcare operator <<
ostream& operator<<(ostream& out, const ErrorRepo& ex);