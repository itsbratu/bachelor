#pragma once

#include "Domain.h"
#include <vector>
#include <string>
#include <ostream>

using std::vector;
using std::string;
using std::ostream;


class PlanRepo {
private:
	vector<Activity> plan;

public:
	PlanRepo() = default;
	PlanRepo(const PlanRepo& repo) = delete;

	/*
	Elimina toate activitatile din planificarea curenta
	*/
	void delete_all() noexcept;

	/*
	title - string , description - string
	Sterge din lista de planificare curenta dupa titlu si descriere
	*/
	void remove(string title, string description);

	/*
	act - Activity object 
	Adauga in lista de planificari o activitate curenta existenta
	*/
	void add(const Activity& act);

	/*
	title - string , description - string , type - string , length - integer
	Modifica activitatea cu un anumit titlu si o anumita descriere
	*/
	void modify(string title, string description, string type, int length);

	/*
	Verifica daca mai exista activitatea in plan
	Returneaza true daca exista , false caz contrar
	*/
	bool exists(const Activity& a) const;

	/*
	title - string , description - string
	Cauta in lista de activitati o activitate deja existenta sau arunca o exceptie daca aceasta nu exista
	*/
	const Activity find(string title, string description) const;

	/*
	Returneaza toate activitatile din planul curent
	*/
	vector<Activity>getall() const;

	/*
	Export intr-un fisier CSV
	*/
	void exportToCVS(std::string fName);

};

void test_repo_plan();

class ErrorPlan
{
	string msg;
public:
	ErrorPlan(string err) :msg{ err } {}
	friend ostream& operator<<(ostream& out, const ErrorPlan& ex);
};

ostream& operator<<(ostream& out, const ErrorPlan& ex);