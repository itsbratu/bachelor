#pragma once
#include "Domain.h"
#include <vector>
#include <string>
#include <iostream>

using std::vector;
using std::string;
using std::ostream;


class ActRepo
{
	private:
		vector<Activity> activities;

	public:
		ActRepo() = default;
		ActRepo(const ActRepo& repo) = delete;

		/*
		Verifica daca mai exista activitatea in lista de activitati
		Returneaza true daca exista , false caz contrar
		*/

		bool exists(const Activity& a) const;

		/*
		act - Activity object
		Adauga in lista de activitati o activitate noua sau arunca o exceptie daca deja exista aceasta activitate
		*/
		void virtual add(const Activity& act);

		/*
		title - string , description - string
		Sterge din lista de activitati o activitate cu un anumit titlu si descriere
		*/
		void virtual remove(string title, string description);

		/*
		title - string , description - string , type - string , length - integer
		Modifica activitatea cu un anumit titlu si o anumita descriere
		*/

		void virtual modify(string title, string description, string type, int length);

		/*
		title - string , description - string
		Cauta in lista de activitati o activitate deja existenta sau arunca o exceptie daca aceasta nu exista
		*/
		const Activity virtual find(string title, string description) const;

		/*
		Returneaza toate obiectele "Activity" salvate
		*/
		vector<Activity> virtual getall() const;
};

/*
Clasa custom pentru a semnala erorile
*/

class ErrorRepo
{
	string msg;
	public:
		ErrorRepo(string err) :msg{ err } {}
		friend ostream& operator<<(ostream& out, const ErrorRepo& ex);
};

ostream& operator<<(ostream& out, const ErrorRepo& ex);

/*
Functii de test pentru Repository
*/

void test_repository();
