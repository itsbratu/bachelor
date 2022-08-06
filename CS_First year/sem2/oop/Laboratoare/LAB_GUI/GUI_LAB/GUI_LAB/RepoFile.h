#pragma once
#include "Domain.h"
#include "Repository.h"
#include <vector>
#include <string>
#include <iostream>

using std::vector;
using std::string;
using std::ostream;

class RepoFile : public ActRepo {
	private:
		string fName;
		void LoadFromFile();
		void SaveToFile();
	public:
		RepoFile(string filename) :ActRepo(), fName{ filename }{
			LoadFromFile();
		}
		
		void add(const Activity& act);

		void remove(string title, string description);

		void modify(string title, string description, string type, int length);
};

void testrepofile();