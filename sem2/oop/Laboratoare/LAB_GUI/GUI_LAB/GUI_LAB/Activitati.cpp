#include "Activitati.h"
#include <assert.h>
#include <iostream>
#include <sstream>
#include <vector>
#include <assert.h>
#include <algorithm>
#include <iostream>
#include <fstream>

using std::ostream;
using std::stringstream;

void PlanRepo::delete_all() noexcept {
	plan.clear();
}

bool PlanRepo::exists(const Activity& a) const
{
	try {
		find(a.getTitle(), a.getDescription());
		return true;
	}
	catch (ErrorPlan&) {
		return false;
	}
}

const Activity PlanRepo::find(string title, string description) const
{
	for (auto p : plan)
	{
		if (p.getTitle() == title && p.getDescription() == description)
			return p;
	}throw ErrorPlan("Nu exista activitatea cautata in lista!");
}

void PlanRepo::add(const Activity& act)
{
	if (exists(act)) {
		throw ErrorPlan("Activitatea pe care doriti sa o includeti in plan deja exista !");
	}
	plan.push_back(act);
}

void PlanRepo::remove(string title, string description) {
	int count = 0;
	for (auto p : plan) {
		if (p.getTitle() == title && p.getDescription() == description) {
			plan[count] = plan.back();
			plan.pop_back();
		}
		count++;
	}
}

void PlanRepo::modify(string title, string description, string type, int length) {
	remove(title, description);
	Activity a{ title , description , type , length };
	add(a);
}

vector<Activity> PlanRepo::getall() const
{
	return plan;
}

void PlanRepo::exportToCVS(string filename) {
	std::ofstream out(filename, std::ios::trunc);
	if (!out.is_open())
		throw ErrorPlan("Unable to open file:" + filename);
	for (const auto& p : plan) {
		out << p.getTitle() << ",";
		out << p.getDescription() << ",";
		out << p.getType() << ",";
		out << p.getLength() << std::endl;
	}
	out.close();
}


ostream& operator<<(ostream& out, const ErrorPlan& ex) {
	out << ex.msg;
	return out;
}

void test_repo_plan()
{
	Activity a1{ "abc" , "xyz" , "xd" , 100 };
	PlanRepo rep;

	rep.add(a1);
	vector<Activity> rez = rep.getall();
	assert(rep.getall().size() == 1);
	assert(rep.find("abc", "xyz").getDescription() == "xyz");

	Activity a2{ "aaa" , "bbb" , "ccc" , 10 };
	rep.add(a2);
	assert(rep.getall().size() == 2);

	try {
		rep.add(Activity{ "abc" , "xyz" , "a" , 10 });}
	catch (const ErrorPlan& e)
	{
		stringstream os;
		os << e;
		assert(os.str().find("exista"));
	}

	rep.remove("abc", "xyz");
	assert(rep.getall().size() == 1);


	rep.modify("aaa", "bbb", "ddd", 15);
	assert(rep.getall().size() == 1);

	PlanRepo r2;

	Activity act_renew1{ "abc" , "xyz" , "xd" , 100 };
	Activity act_renew2{ "abb" , "aga" , "xax" , 50 };

	r2.add(act_renew1);
	r2.add(act_renew2);

	PlanRepo cvs;
	Activity cvs1{ "abc" , "alta" , "alta" , 100 };
	Activity cvs2{ "alta" , "alta" , "xd" , 1000 };

	cvs.add(cvs1);
	cvs.add(cvs2);

	cvs.exportToCVS("test");


}