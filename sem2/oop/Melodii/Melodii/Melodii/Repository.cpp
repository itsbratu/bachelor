#include "Repository.h"

void Repository::add(const Melodie& m) {
	songs.push_back(m);
}

void Repository::del(int id)
{
	std::string curr_artist;
	for (const auto m : songs) {
		if (m.getId() == id)
		{
			curr_artist = m.getArtist();
			break;
		}
	}
	int counter = 0;
	for (const auto m : songs) {
		if (m.getArtist() == curr_artist)
			counter++;
	}
	if (counter == 1)
		throw ErrorRepo("Atentie , aceasta este ultima melodie!");
	else {
		int number_act = 0;
		for (const auto m : songs) {
			if (m.getId() == id)
			{
				songs[number_act] = songs.back();
				songs.pop_back();
				break;
			}
			number_act++;
		}
		SaveToFile();
	}
}

void Repository::mod(const Melodie& m)
{
	Melodie add_new{ m.getId() , m.getTitle() , m.getArtist() , m.getRank() };
	int number_curr = 0;
	for (const auto s : songs) {
		if (s.getId() == m.getId()) {
			songs[number_curr] = songs.back();
			songs.pop_back();
			break;
		}
		number_curr++;
	}
	this->add(add_new);
	SaveToFile();
}

vector<Melodie> Repository::getall() const {
	return songs;
}

void Repository::LoadFromFile() {
	std::ifstream in(fName);
	if (!in.is_open()) {
		throw ErrorRepo("Fisierul dat nu poate fi deschis ! ");
	}

	while (!in.eof()) {
		int id, rank;
		std::string title, artist;

		in >> id;
		in >> title;
		in >> artist;
		in >> rank;

		if (in.eof())
			break;

		Melodie m{ id , title.c_str() , artist.c_str() , rank };
		Repository::add(m);
	}
	in.close();
}

void Repository::SaveToFile()
{
	std::ofstream out(fName);
	if (!out.is_open())
		throw ErrorRepo("Fisierul nu poate fi deschis");

	for (auto& p : getall()) {
		out << p.getId();
		out << std::endl;
		out << p.getTitle();
		out << std::endl;
		out << p.getArtist();
		out << std::endl;
		out << p.getRank();
		out << std::endl;
		out << std::endl;
	}
}

ostream& operator<<(ostream& out, const ErrorRepo& ex) {
	out << ex.msg;
	return out;
}
