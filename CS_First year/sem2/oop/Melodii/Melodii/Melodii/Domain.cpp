#include "Domain.h"
#include <assert.h>

int Melodie::getId()const{
	return id;
}

std::string Melodie::getTitle()const {
	return title;
}

std::string Melodie::getArtist()const {
	return artist;
}

int Melodie::getRank()const {
	return rank;
}

void test_Domain() {
	Melodie m{ 1 , "Abc" , "BBB" ,10 };
	assert(m.getId() == 1);
	assert(m.getTitle() == "Abc");
	assert(m.getArtist() == "BBB");
	assert(m.getRank() == 10);
}