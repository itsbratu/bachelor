#pragma once

#include <iostream>

using namespace std;

class Melodie
{
	private:
		//Cele 4 campuri ale obiectelor "Melodie"
		int id;
		std::string title;
		std::string artist;
		std::string gen;
	public:
		//Constructor default
		Melodie() = default;

		//Constructor cu parametri
		Melodie(const int id, const string title, const string artist, const string gen) : id{ id }, title{ title }, artist{ artist }, gen{ gen } {}

		//Getteri pentru campuri

		int getId() const;

		std::string getTitle() const;

		std::string getArtist() const;

		std::string getGen() const;
};

