#include "Repository.h"
#include <assert.h>
#include <iostream>
#include <sstream>
#include <vector>
#include <assert.h>
#include <gsl/gsl>
#include <algorithm>

using std::ostream;
using std::stringstream;

bool ActRepo::exists(const Activity& a) const
{
	try {
		find(a.getTitle(), a.getDescription());
		return true;
	}
	catch (ErrorRepo&){
		return false;}
}

void ActRepo::add(const Activity& act)
{
	if (exists(act))
	{
		throw ErrorRepo("Activitatea pe care doriti sa o adaugati deja exista! \n");
	}
	activities.push_back(act);
}

void ActRepo::remove(string title, string description){
	try {
		find(title, description);
	}
	catch (ErrorRepo&) {
		throw ErrorRepo("Activitatea pe care doriti sa o stergeti nu exista! \n");}
	
	int count = 0;
	for (auto p : activities)
	{
		if (p.getTitle() == title && p.getDescription() == description){
			activities[count] = activities.back();
			activities.pop_back();
			break;
		}
		count++;
	}
}


void ActRepo::modify(string title , string description , string type , int length)
{
	try {
		find(title, description);
	}
	catch (ErrorRepo&) {
		throw ErrorRepo("Activitatea pe care doriti sa o modificat nu exista! \n");}
	remove(title, description);
	Activity a{ title , description , type , length };
	add(a);
}


const Activity ActRepo::find(string title, string description) const
{
	for (auto p : activities)
	{
		auto it = std::find_if(activities.begin(), activities.end(), [title , description](const Activity& a)->bool
			{
				bool result = (a.getTitle() == title && a.getDescription() == description);
				return result;
			});
		if (it != activities.end())
			return p;
	}throw ErrorRepo("Nu exista activitatea cautata in lista!");}


vector<Activity> ActRepo::getall() const
{
	return activities;
}

ostream& operator<<(ostream& out, const ErrorRepo& ex) {
	out << ex.msg;
	return out;
}

void test_repository()
{
	Activity a1{"abc" , "xyz" , "xd" , 100 };
	ActRepo rep;

	rep.add(a1);
	vector<Activity> rez = rep.getall();
	assert(rep.getall().size() == 1);
	assert(rep.find("abc", "xyz").getDescription() == "xyz");

	Activity a2{ "aaa" , "bbb" , "ccc" , 10 };
	rep.add(a2);
	assert(rep.getall().size() == 2);

	try{
		rep.add(Activity{ "abc" , "xyz" , "a" , 10 });}
	catch (const ErrorRepo& e)
	{
		stringstream os;
		os << e;
		assert(os.str().find("exista"));
	}

	try {
		rep.remove("aaaaaaaa", "bbbbb");}
	catch (const ErrorRepo& e)
	{
		stringstream os;
		os << e;
		assert(os.str().find("exista"));
	}

	rep.remove("abc", "xyz");
	assert(rep.getall().size() == 1);

	try {
		rep.modify("abc", "xyz" , "ciao" , 100);}
	catch (const ErrorRepo& e)
	{
		stringstream os;
		os << e;
		assert(os.str().find("exista"));
	}

	rep.modify("aaa", "bbb", "ddd", 15);
	assert(rep.getall().size() == 1);

	ActRepo r2;

	Activity act_renew1{ "abc" , "xyz" , "xd" , 100 };
	Activity act_renew2{ "abb" , "aga" , "xax" , 50 };

	r2.add(act_renew1);
	r2.add(act_renew2);

}