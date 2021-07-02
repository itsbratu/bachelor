#pragma once
#include <iostream>

using namespace std;

class Melodie
{
	private:
		//Cele 4 campuri ale obiectelor cu care lucram
		int id; // id - integer number unic
		std::string title; // title - string 
		std::string artist; // artist - string
		int rank; // rank - integer between 0 - 10
	public:
		//Constructor default al clasei
		Melodie() = default;

		//Constructor cu parametrii al clasei
		Melodie(const int i, const string t, const string a, const int r) : id{ i }, title{ t }, artist{ a }, rank{ r }{}

		//returneaza id-ul unei melodii
		int getId() const;

		std::string getTitle() const;

		std::string getArtist() const;

		int getRank() const;

};

