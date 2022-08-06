#pragma once

#include "Repository.h"

class Service
{
	private:
		//service contine in esenta un repository
		Repository& repo;
	public:
		//constructor care primeste ca argument un obiect de tip repository
		Service(Repository& repo) : repo{ repo } {}

		//returneaza toate melodiile salvate curent in lista
		const vector<Melodie> get_all() noexcept {
			return repo.getall();
		}

		//returneaza toate melodiile salvate curent in lista , sortate dupa rank
		const vector<Melodie> sort_rank() noexcept;

		//sterge o melodie din lista curenta
		void del(int id);

		//modifica o melodie din lista curenta
		void mod(const Melodie& m);

};

