#pragma once

#include "Undo.h"
#include "Activitati.h"
#include "DTO.h"
#include "Domain.h"
#include "Repository.h"
#include <string>
#include <vector>

#include <functional>
#include <map>
#include <iterator>
#include "Validator.h"
#include "RepoFile.h"

using std::vector;
using std::function;
using std::unique_ptr;

class Service
{
	ActRepo& Repo;
	PlanRepo& Lista;
	ActValidator& Val;
	vector<unique_ptr<ActiuneUndo >> undoActions;

	public:
		Service(ActRepo& Repo, ActValidator& Val, PlanRepo& Plan) :Repo{ Repo }, Val{ Val }, Lista{ Plan } {}
		Service(const Service& ot) = delete;

		/*
		title - string , description - string , type - string , length - int
		Functie care adauga o noua activitate in lista sau arunca eroare daca nu poate fi adaugata / nu este valida
		*/
		void add_activity(string title, string description, string type, int length);

		/*
		title -string , description - string
		Functie care sterge o activitate din lista sau arunca o eroare daca nu exista activitatea respectiva in lista
		*/

		void delete_activity(string title, string description);

		/*
		title - string , description - string , type - string , length - int
		Functie care modifica o activitate din lista sau arunca o eroare daca nu exista activitatea respectiva
		*/

		void modify_activity(string title, string description, string type, int length);

		/*
		title - string , description - string
		Functie care gaseste o anumita activitate dupa titlu si descriere , o returneaza
		Arunca eroare daca aceasta nu exista
		*/
		
		/*Functie care returneaza lista de activitati filtrata dupa un camp*/
		const vector <Activity> filter_activity(string choice , string value);

		/*Functie care returneaza lista de activitati sortata dupa un criteriu*/
		const vector <Activity> sort_activity(int choice_nmb);

		/*Functie care gaseste activitatea dorita*/
		const Activity find_activity(string title, string description);

		/*Functie care sterge toate activitatile planificate curent*/

		void delete_plan();

		/*
		title - string , description - string , type - string , length - int
		Functie care adauga o noua activitate in lista de planificari curenta
		*/
		void add_plan(string title , string description , string type , int length);

		/*
		nmb - integer > 0
		*/
		void rand_plan(int nmb);

		/*
		Functie de undo 
		*/

		void undo();

		/*
		Functie care preia toate activitatile curente
		*/

		const vector <Activity> get_all() noexcept {
			return Repo.getall();
		}

		/*
		Functie care realizeaza raportul pe baza de type
		*/
		void raport(std::map<std::string, DTO_type>& raport);

		/*
		Functie care realizeaza export in fisier
		*/
		void exportToCVS(std::string Fname);

		/*
		Functie care preia toate activitatile din plan
		*/

		const vector <Activity> get_plan() noexcept {
			return Lista.getall();
		}

};

void test_add();

void test_service();