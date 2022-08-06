#include "Utilis.h"
#include "Service.h"
#include "Activitati.h"
#include "Domain.h"
#include <assert.h>
#include <string>
#include <algorithm>
#include <iostream>
#include <iomanip>
#include <memory>

bool comparator(const Activity& a1, const Activity& a2) {
	if (a1.getType().compare(a2.getType()) != 0)
		return a1.getType() < a2.getType();
	else
		return a1.getLength() < a2.getLength();
}

void Service::add_activity(string title, string description, string type, int length)
{
	Activity a{ title , description , type , length };
	Val.validate(a);
	Repo.add(a);
	undoActions.push_back(std::make_unique<UndoAdd>(Repo, title, description));
}

void Service::undo() {
	if (undoActions.empty())
		throw ErrorRepo("Nu mai exista undo!");

	undoActions.back()->doUndo();
	undoActions.pop_back();
}

const vector<Activity> Service::filter_activity(string choice , string value)
{
	vector <Activity> all_;
	all_ = get_all();
	vector <Activity> result;

	if (choice.compare("descriere") == 0){
		for (auto p : all_)
		{
			if (p.getDescription() == value)
				result.push_back(p);
		}
	}
	else {
		for (auto p : all_)
		{
			if (p.getType() == value)
				result.push_back(p);
		}
	}
	return result;
}

const vector<Activity> Service::sort_activity(int choice_nmb){
	vector <Activity> all_;
	all_ = get_all();
	if (choice_nmb == 1){
		std::sort(all_.begin(), all_.end(), [](const Activity& a, const Activity& b)->bool
			{
				return a.getTitle() < b.getTitle();
			});
		return all_;
	}
	if (choice_nmb == 2){
		std::sort(all_.begin(), all_.end(), [](const Activity& a, const Activity& b)->bool
			{
				return a.getDescription() < b.getDescription();
			});
		return all_;
	}
	if (choice_nmb == 3) {
		std::sort(all_.begin(), all_.end(), comparator);
		return all_;
	}return all_;
}

void Service::delete_activity(string title, string description)
{
	string type;
	int len =  0;
	for (auto& p : Repo.getall()) {
		if (p.getTitle() == title && p.getDescription() == description){
			type = p.getType();
			len = p.getLength();
		}
	}
	Repo.remove(title, description);
	Lista.remove(title, description);
	Activity act{ title , description , type , len };
 	undoActions.push_back(std::make_unique<UndoRem>(Repo, act));
}

void Service::modify_activity(string title, string description, string type, int length)
{
	Activity a{ title , description , type , length };
	string type_mod;
	int len_mod = 0;

	for (auto& p : Repo.getall()) {
		if (p.getTitle() == title && p.getDescription() == description) {
			type_mod = p.getType();
			len_mod = p.getLength();
		}
	}

	undoActions.push_back(std::make_unique<UndoMod>(Repo, title , description , type_mod , len_mod));
	Val.validate(a);
	Repo.modify(title, description, type, length);
	Lista.modify(title, description, type, length);
}

const Activity Service::find_activity(string title, string description)
{
	return Repo.find(title, description);
}

void Service::delete_plan(){
	Lista.delete_all();
}

void Service::add_plan(string title, string description, string type, int length) {
	Activity a{ title , description , type , length };
	Val.validate(a);
	Repo.find(title , description);
	Lista.add(a);
}

void Service::rand_plan(int nmb) {
	while (nmb > 0) {
		string title = random_string(10);
		string description = random_string(10);
		string type = random_string(10);
		int const length = random_int();
		Activity a{ title , description , type , length };
		Lista.add(a);
		nmb--;
	}
}

void Service::raport(std::map<std::string, DTO_type>& raport) {
	for (const Activity& a : Repo.getall()) {
		if (raport.find(a.getType()) == raport.end()) {
			raport[a.getType()] = DTO_type(a.getType());
		}
		else raport[a.getType()].add();
	}
}

void Service::exportToCVS(string filename) {
	Lista.exportToCVS(filename);
}

void test_service()
{
	test_utils();
	ActRepo repo;
	ActValidator val;
	PlanRepo list;
	Service serv{ repo , val , list };
	serv.add_activity("abc", "xyz", "aaa", 100);
	assert(serv.get_all().size() == 1);

	serv.delete_activity("abc", "xyz");
	assert(serv.get_all().size() == 0);

	serv.add_activity("abc", "xyz", "aaa", 100);
	serv.modify_activity("abc", "xyz", "xd", 100);
	assert(serv.get_all().size() == 1);

	Activity a_found = serv.find_activity("abc", "xyz");
	assert(a_found.getType() == "xd");
	assert(a_found.getLength() == 100);

	serv.add_activity("ppp", "ppp", "ppp", 100);
	serv.add_plan("ppp", "ppp", "ppp", 100);
	assert(serv.get_plan().size() == 2);
	serv.delete_plan();
	assert(serv.get_plan().size() == 0);

	serv.rand_plan(5);
	assert(serv.get_plan().size() == 5);

	ActRepo repo2;
	ActValidator val2;
	PlanRepo list2;
	Service serv2{ repo2 , val2 , list2};

	serv2.add_activity("abc", "xyz", "aga", 1000);
	serv2.add_activity("abcd", "xyz", "altele", 150);
	serv2.add_activity("materie", "xd", "tip", 200);

	vector <Activity> v1;
	vector <Activity> v2;

	v1 = serv2.filter_activity("tip", "tip");
	assert(v1.size() == 1);
	v2 = serv2.filter_activity("descriere", "xyz");
	assert(v2.size() == 2);

	ActRepo repo_sort;
	ActValidator val_sort;
	PlanRepo list_sort;
	Service serv_sort{ repo_sort , val_sort , list_sort};

	serv_sort.add_activity("abc", "xaxa", "altele", 1500);
	serv_sort.add_activity("aaa", "popo", "sigur", 300);
	serv_sort.add_activity("bbb", "abc", "altele", 300);

	vector <Activity> sort1;
	vector <Activity> sort2;
	vector <Activity> sort3;

	sort1 = serv_sort.sort_activity(1);
	sort2 = serv_sort.sort_activity(2);
	sort3 = serv_sort.sort_activity(3);

	assert(sort1.size() == 3);
	assert(sort2.size() == 3);
	assert(sort3.size() == 3);

	ActRepo repo_raport;
	ActValidator valid_raport;
	PlanRepo list_raport;

	Service serv_raport{ repo_raport , valid_raport , list_raport };
	serv_raport.add_activity("abc", "bbb", "oop", 1000);
	serv_raport.add_activity("abc", "ccc", "oop", 500);
	serv_raport.add_activity("abc", "ddd", "sda", 200);
	serv_raport.add_activity("aaa", "bbb", "a", 500);
	serv_raport.add_activity("ccc", "ccc", "a", 750);

	std::map<std::string, DTO_type> raport;
	serv_raport.raport(raport);

	std::map<std::string, DTO_type>::iterator it;
	it = raport.begin();

	while (it != raport.end()) {
		if (it->first.compare("a") == 0)
			assert(it->second.getCount() == 2);
		it++;
	}

	ActRepo repocvs;
	ActValidator validcvs;
	PlanRepo activcvs;
	Service servcvs{ repocvs , validcvs , activcvs };

	servcvs.add_activity("alta", "alta", "xd", 100);
	servcvs.exportToCVS("alttest");

	ActRepo repoundo;
	ActValidator validundo;
	PlanRepo activundo;
	Service servundo{ repoundo , validundo , activundo };

	servundo.add_activity("a1", "b1", "c1", 100);
	servundo.add_activity("a2", "b2", "c2", 200);
	assert(servundo.get_all().size() == 2);
	serv.undo();
	servundo.add_activity("alta", "alta", "again", 100);
	servundo.delete_activity("alta", "alta");
	serv.undo();
	servundo.modify_activity("a1", "b1", "undo", 1000);
	serv.undo();

}