#include "LabRepo.h"

void RepoLab::add(const Activity& act) {
	double r = (double)rand() / double(RAND_MAX);
	if (r < p) {
		throw LabException("Ghinion!");
	}
	all.insert({ id , act });
	id++;
	afisare();
}

void RepoLab::remove(string title, string description) {
	double r = (double)rand() / double(RAND_MAX);
	if (r < p) {
		throw LabException("Ghinion!");
	}
	std::map<int, Activity>::iterator it;
	int id_find = exists(title, description);
	if (id_find != -1)
	{
		it = all.find(id_find);
		all.erase(it);
		afisare();
	}
}

void RepoLab::modify(string title, string description, string type, int length) {
	double r = (double)rand() / double(RAND_MAX);
	if (r < p) {
		throw LabException("Ghinion!");
	}
	Activity new_One{ title , description , type , length };
	remove(title, description);
	add(new_One);
}

//const Activity RepoLab::find(string title, string description) {
//	int id_found = exists(title, description);
//	cout << id_found;
//	if (id_found == -1)
//		throw LabException("Nu exista activitatea cautata!");
//	else {
//		cout << "\nActivitatea cautata este : ";
//		for (auto& act : all) {
//			if (act.first == id_found) {
//				return act.second;
//			}
//		}
//	}
//}

vector<Activity> RepoLab::getall() const {
	vector <Activity> converted;
	for (auto& act : all)
	{
		converted.push_back(act.second);
	}
	return converted;
}

int RepoLab::exists(string title, string description) {
	for (auto& act : all) {
		if (act.second.getTitle() == title && act.second.getDescription() == description) {
			return act.first;
		}
	}
	return -1;
}

void RepoLab::afisare() {
	cout << "\n";
	for (auto& act : all) {
		cout << "Title : " << act.second.getTitle() << "\n";
		cout << "Description : " << act.second.getDescription() << "\n";
		cout << "Type : " << act.second.getType() << "\n";
		cout << "Length : " << act.second.getLength() << "\n";
		cout << "\n";
	}
}

ostream& operator<<(ostream& out, const LabException& ex) {
	out << ex.msg;
	return out;
}


