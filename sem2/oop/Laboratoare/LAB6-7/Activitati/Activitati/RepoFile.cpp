#include "Repository.h"
#include "RepoFile.h"
#include <iostream>
#include <fstream>
#include <assert.h>

using std::ostream;
using std::stringstream;

void RepoFile::add(const Activity& act) {
		ActRepo::add(act);
		SaveToFile();
}

void RepoFile::remove(const string title, string description) {
		ActRepo::remove(title, description);
		SaveToFile();
}

void RepoFile::modify(string title, string description, string type, int length) {
		ActRepo::modify(title, description, type, length);
		SaveToFile();
}

void RepoFile::LoadFromFile() {
		std::ifstream in(fName);
		if (!in.is_open()) {
			throw ErrorRepo("Fisierul dat nu poate fi deschis ! ");
		}

		while (!in.eof()) {
			string title, description, type;
			int length;

			in >> title;
			in >> description;
			in >> type;
			in >> length;

			if (in.eof())
				break;

			Activity a{ title.c_str() , description.c_str() , type.c_str() , length };
			ActRepo::add(a);
		}
		in.close();
}	

void RepoFile::SaveToFile() {
		std::ofstream out(fName);
		if (!out.is_open())
			throw ErrorRepo("Fisierul nu poate fi deschis");

		for (auto& p : getall()) {
			out << p.getTitle();
			out << std::endl;
			out << p.getDescription();
			out << std::endl;
			out << p.getType();
			out << std::endl;
			out << p.getLength();
			out << std::endl;
			out << std::endl;
		}
}

void testrepofile() {
	RepoFile testfile("test.txt");

	Activity act1{ "a" , "b" , "c" , 100 };
	Activity act2{ "d" , "e" , "f" , 200 };
	testfile.add(act1);
	testfile.add(act2);

	assert(testfile.getall().size() == 2);
	testfile.remove("a", "b");
	assert(testfile.getall().size() == 1);
	testfile.modify("d", "e", "alta", 1000);

	RepoFile testload("loadfile.txt");
	assert(testload.getall().size() == 1);
}
