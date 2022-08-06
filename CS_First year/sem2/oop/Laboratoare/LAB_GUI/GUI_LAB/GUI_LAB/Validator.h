#pragma once
#include <string>
#include "Domain.h"
#include <vector>

using std::vector;
using std::string;
using std::ostream;

/*
Clasa folosita pentru a semnala exceptiile aruncate de catre validator
*/

class ValidationException
{
	vector <string> msgs;
	public:
		ValidationException(const vector<string>& errors) : msgs{ errors } {}
		friend ostream& operator<<(ostream& out, const ValidationException& ex);
};

ostream& operator<<(ostream& out, const ValidationException& ex);

void test_validator();

/*
Clasa care valideaza obiectele Activitate
*/

class ActValidator
{
	public:
		void validate(const Activity& act);
};