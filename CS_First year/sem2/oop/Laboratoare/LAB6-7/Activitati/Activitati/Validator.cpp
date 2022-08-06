#include "Validator.h"
#include <assert.h>
#include <sstream>

void ActValidator::validate(const Activity& act)
{
	vector <string> msgs;
	if (act.getTitle().size() <= 0) msgs.push_back("Invalid titlu !");
	if (act.getDescription().size() <= 0) msgs.push_back("Invalid descriere !");
	if (act.getType().size() <= 0) msgs.push_back("Invalid tip !");
	if (act.getLength() < 0) msgs.push_back("Invalid durata!");

	if (msgs.size() > 0)
		throw ValidationException(msgs);}

vector <string> ValidationException::get_mesaje(){
	return msgs;
}

ostream& operator<<(ostream& out, const ValidationException& ex) {
	for (const auto& msg : ex.msgs) {
		out << msg << " ";
	}
	return out;
}

void test_validator()
{
	ActValidator v;
	Activity a{"abc" , "" , "" , 100 };
	try {
		v.validate(a);}
	catch (const ValidationException& ex){
		std::stringstream sout;
		sout << ex;
		auto const mesaj = sout.str();
		assert(mesaj.find("descriere") >= 0);
		assert(mesaj.find("tip") >= 0);
	}
}
