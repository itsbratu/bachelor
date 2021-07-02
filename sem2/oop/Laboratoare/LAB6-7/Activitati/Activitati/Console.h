#pragma once
#include "Service.h"
#include "Repository.h"
#include "Domain.h"


class Console
{
	Service& serv;
	/*
	Citeste datele de la tastatura 
	Arunca erori daca nu se poate adauga obiectul / nu este valid
	*/
	void add_UI();

	/*
	Citeste titlul si descrierea unei activitati pe care o sterge
	Arunca erori daca nu exista obiectul dorit
	*/

	void delete_UI();

	/*
	Citeste titlul si descrierea unei activitati , respectiv campurile care reprezinta tipul si durata care urmeaza sa fie modificate
	Arunca erori daca nu exista obiectul dorit
	*/

	void modify_UI();

	/*
	Citeste titlul si descrierea unei activitati pe care o returneaza pentru afisare
	Arunca eroare daca aceasta nu exista
	*/

	void find_UI();

	/*
	a - Activity object
	Afiseaza pe ecran atributele unei activitati daca aceasta exista in lista
	*/

	void print_activity(const Activity& a);

	/*
	Afiseaza pe ecran o lista de activitati
	*/
	void print_UI(const vector<Activity>& act);

	/*Filtreaza lista curenta dupa un anumit camp si o afiseaza*/
	void filter_UI();

	/*Sorteaza lista curenta dupa o proprietate si o afiseaza*/
	void sort_UI();

	/*
	Adauga o activitate in planul curent
	*/
	void add_plan();

	/*
	Afiseaza activitatile din planul curent
	*/
	void print_plan(const vector<Activity>& act);

	/*
	Sterge planul curent cu activitati
	*/

	void delete_plan();

	/*
	Genereaza entitati random pentrul planul curent
	*/

	void generate_plan();

	/*
	Afiseaza raportul dupa destinatie
	*/

	/*
	Functie care realizeaza undo
	*/
	void undo_UI();

	/*
	Exporta planul intr-un CVS
	*/
	void export_plan();

	void afisare_lab();
	
	void raport_UI();

	public:
		Console(Service& serv) : serv{ serv } {}
		Console(const Console& ot) = delete;

		/*
		Functie prin care pornim aplicatia
		*/
		void start();
};