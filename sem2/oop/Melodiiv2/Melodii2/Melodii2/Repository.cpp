#include "Repository.h"

void Repository::LoadFromFile()
{
	std::ifstream in(filename);
	if (!in.is_open()) {
		throw ErrorRepo("Fisierul nu poate fi deschis!");
	}
	while (!in.eof()) {
		int id;
		std::string title, artist, gen;
		in >> id;
		in >> title;
		in >> artist;
		in >> gen;

		if (in.eof())
			break;
		Melodie m{ id , title , artist , gen };
		Repository::add(m);
	}
	in.close();
}

void Repository::SaveToFile()
{
	std::ofstream out(filename);
	if (!out.is_open())
		throw ErrorRepo("Fisierul nu poate fi deschis!");

	for (auto& p : getall()) {
		out << p.getId();
		out << std::endl;
		out << p.getTitle();
		out << std::endl;
		out << p.getArtist();
		out << std::endl;
		out << p.getGen();
		out << std::endl;
		out << std::endl;
	}

}

void Repository::add(const Melodie& m)
{
	for (const auto& p : v) {
		if (p.getId() == m.getId())
			throw ErrorRepo("Atentie la neatentie !");
	}
	v.push_back(m);
	SaveToFile();
}

void Repository::del(const int id)
{
	int number_count = 0;
	for (const auto& p : v) {
		if (p.getId() == id)
		{
			v[number_count] = v.back();
			v.pop_back();
			break;
		}
		number_count++;
	}
	SaveToFile();
}

vector<Melodie> Repository::getall() noexcept
{
	return v;
}

ostream& operator<<(ostream& out, const ErrorRepo& ex)
{
	out << ex.msg;
	return out;
}
