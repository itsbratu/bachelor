#pragma once

#include "Repository.h"
#include <map>

class RepoLab : public ActRepo {
	private:
		std::map<int , Activity> all;
		int id = 0;
		double p;
	public:
		RepoLab(double p) : p{ p } {};
		void add(const Activity& act) override;
		void remove(string title, string description) override;
		void modify(string title, string description, string type, int length) override;
		//const Activity find(string title, string description) override;
		int exists(string title, string description);
		vector<Activity> virtual getall() const;
		void afisare();
};

class LabException
{
	string msg;
public:
	LabException(string err) :msg{ err } {}
	friend ostream& operator<<(ostream& out, const LabException& ex);
};

ostream& operator<<(ostream& out, const LabException& ex);