#pragma once
#include <string>
#include <iostream>

using std::string;
using std::cout;

class Activity
{
	private:
		std::string title;
		std::string description;
		std::string type;
		int length;
	public:
		/*
		Constructor cu argumente , campurile clasei
		*/

		Activity() = default;

		Activity(const string t, const string d, const string type, int l):title{ t }, description{ d }, type{ type }, length{ l }{}
		
		/*
		Constructor care copiaza atributele altui obiect Activity
		*/

		/*
		Returneaza titlul unei activitati
		title - std::string
		*/
		string getTitle() const
		{
			return title;
		}

		/*
		Returneaza descrierea unei activitati
		descrption - std::string
		*/
		string getDescription() const
		{
			return description;
		}

		/*
		Returneaza tipul unei activitati
		type - std::string
		*/
		string getType() const
		{
			return type;
		}

		/*
		Returneaza durata unei activitati
		length - integer
		*/
		int getLength() const noexcept
		{
			return length;
		}
};

/*
a1 , a2 - Activity objects
Compara doua activitati dupa Titlu
Returneaza true daca a1.title este mai mic decat a2.title sau false in caz contrar
*/
bool cmpTitle(const Activity& a1, const Activity& a2);

/*
a1 , a2 - Activity objects
Compara doua activitati dupa Descriere
Returneaza true daca a1.description este mai mic decat a2.description sau false in caz contrar 
*/

bool cmpDescription(const Activity& a1, const Activity& a2);

/*
Functii test pentru Domain
*/

void test_get();

void test_cmp();

void test_domain();