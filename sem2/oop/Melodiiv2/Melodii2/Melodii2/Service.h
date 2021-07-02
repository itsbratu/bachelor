#pragma once
#include "Repository.h"

class Service
{
	private:
		//service contine o referinta catre un obiect repository
		Repository& repo;
	public:
		//constructor al service care primeste ca parametru un repository
		Service(Repository& r) : repo{ r } {}

		//functie de adaugare melodie
		//m - "Melodie" object
		//Return : -
		void add(const Melodie& m);

		//functie de stergere melodie dupa id
		//id - integer number
		//Return : - 
		void del(const int id);
		
		//functie care preia toate instantele din repository
		//POSTCONDITII : all - vector<Melodie> contine toate melodiile
		//PRECONDITII : -
		const vector<Melodie> get_all() noexcept {
			return repo.getall();
		}
		


};

