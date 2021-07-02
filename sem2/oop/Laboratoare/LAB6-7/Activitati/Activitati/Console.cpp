#include "Console.h"
#include "Service.h"
#include "Repository.h"
#include "Domain.h"
#include "LabRepo.h"

#include <cstring>
#include <iostream>

using std::cout;
using std::cin;

void Console::add_UI()
{
	string title, description, type;
	int length;

	cout << "Introduceti titlu : ";
	cin >> title;
	cout << "Introduceti descriere :";
	cin >> description;
	cout << "Introduceti tipul : ";
	cin >> type;
	cout << "Introduceti durata : ";
	cin >> length;
	cout << "\n";
	serv.add_activity(title, description, type, length);
	cout << "\nActivitate adaugata cu succes ! \n";
}

void Console::delete_UI()
{
	string title, description;
	cout << "Introduceti titlul : ";
	cin >> title;
	cout << "Introduceti descriere : ";
	cin >> description;

	serv.delete_activity(title, description);
	cout << "\nActivitate stearsa cu succes ! \n";
}

void Console::modify_UI()  
{
	string title, description , type;
	int length;
	cout << "Introduceti titlu : ";
	cin >> title;
	cout << "Introduceti descriere :";
	cin >> description;
	cout << "Introduceti noul tipul de activitate : ";
	cin >> type;
	cout << "Introduceti noua durata : ";
	cin >> length;
	cout << "\n";
	serv.modify_activity(title, description, type, length);
	cout << "\nActivitate modificata cu succes ! \n";
}

void Console::filter_UI()
{
	string choice , value;
	cout << "Introduceti dupa ce camp se va face filtrarea : ";
	cin >> choice;
	cout << "Introduceti numele campului dupa care doriti sa se gaseasca : ";
	cin >> value;
	vector <Activity> filtered_acts;
	filtered_acts = serv.filter_activity(choice , value);
	print_UI(filtered_acts);
}

void Console::sort_UI()
{
	int choice_nmb;
	cout << "\n1.Sortare dupa titlu!\n2.Sortare dupa descriere!\n3.Sortare dupa tip+durata!\n";
	cout << "Introduceti optiunea de sortare : ";
	cin >> choice_nmb;
	cout << "\n";
	vector <Activity> sorted_acts;
	sorted_acts = serv.sort_activity(choice_nmb);
	print_UI(sorted_acts);
}

void Console::find_UI()
{
	string title, description;
	cout << "Introduceti titlul activitatii cautate : ";
	cin >> title;
	cout << "Introduceti descrierea activitatii cautate : ";
	cin >> description;
	Activity a = serv.find_activity(title, description);
	print_activity(a);
}

void Console::print_activity(const Activity& a)
{
	cout << "Activitatea cautata este : \n";
	cout << "Titlul : " << a.getTitle() << " ,descrierea : " << a.getDescription() << " ,tipul : " << a.getType() << " ,durata : " << a.getLength() << "\n";
}

void Console::print_UI(const vector<Activity>& act)
{
	cout << "Lista de activitati este : " << "\n";
	for (const auto& a : act)
	{
		cout << a.getTitle() << " " << a.getDescription() << " " << a.getType() << " " << a.getLength();
		cout << "\n";
	}
	cout << "\n**************************\n";
}

void Console::export_plan() {
	string filename;

	cout << "Introduceti numele fisierului : ";
	cin >> filename;
	serv.exportToCVS(filename);

}

void Console::add_plan() {
	string title, description, type;
	int length;

	cout << "Introduceti titlu : ";
	cin >> title;
	cout << "Introduceti descriere :";
	cin >> description;
	cout << "Introduceti tipul : ";
	cin >> type;
	cout << "Introduceti durata : ";
	cin >> length;
	cout << "\n";
	serv.add_plan(title, description, type, length);
	cout << "\nActivitate adaugata cu succes in planul de activitati! \n";
}

void Console::print_plan(const vector<Activity>& act) {
	cout << "Planul curent cu activitati este : " << "\n";
	for (const auto& a : act)
	{
		cout << a.getTitle() << " " << a.getDescription() << " " << a.getType() << " " << a.getLength();
		cout << "\n";
	}
	cout << "\n**************************\n";
}

void Console::undo_UI() {
	serv.undo();
}

void Console::delete_plan() {
	serv.delete_plan();
	cout << "Plan sters cu succes \n \n";
}

void Console::generate_plan() {
	int nmb_generated;
	cout << "Introduceti numarul de entitati generate : ";
	cin >> nmb_generated;
	serv.rand_plan(nmb_generated);
	cout << "Au fost adaugate " << nmb_generated << " entitati cu succes ! \n";
}

void Console::raport_UI() {
	std::map<std::string, DTO_type> raport;
	serv.raport(raport);
	std::map<std::string, DTO_type>::iterator it;
	it = raport.begin();

	while (it != raport.end()) {
		std::cout << it->first << " " << it->second.getCount() << "\n";
		it++;
	}

}

void Console::start()
{
	while (true)
	{
		cout << "1.Adauga activitate noua!\n2.Stergere activitate existenta!\n3.Modificare activitate existenta!\n4.Afisare atribute activitate!\n5.Afisare lista activitati!\n6.Filtrare activitati!\n7.Sortare activitati!\n---------------------\nFUNCTIONALITATE NOUA : \n8.Adauga in plan!\n9.Genereaza plan!\n10.Goleste plan!\n11.Exporta plan!\n12.Afisare plan!\n13.Afisare raport!\n14.UNDO!\n\n0.Iesire aplicatie!";
		cout << "\n\n" << "Alegeti optiunea dorita : ";
		int cmd;
		cin >> cmd;

		try
		{
			switch (cmd){
				case 1:
					add_UI();
					break;
				case 2:
					delete_UI();
					break;
				case 3:
					modify_UI();
					break;
				case 4:
					find_UI();
					break;
				case 5:
					print_UI(serv.get_all());
					break;
				case 6:
					filter_UI();
					break;
				case 7:
					sort_UI();
					break;
				case 8:
					add_plan();
					break;
				case 9:
					generate_plan();
					break;
				case 10:
					delete_plan();
					break;
				case 11:
					export_plan();
					break;
				case 12:
					print_plan(serv.get_plan());
					break;
				case 13:
					raport_UI();
					break;
				case 14:
					undo_UI();
					break;
				case 0:
					return;
				default:
					cout << "Invalid command ! \n";
			}
		}
		catch (const ValidationException& e) {
			cout << e << "\n";
		}
		catch (const ErrorRepo& r)
		{
			cout << r << "\n";
		}
		catch (const ErrorPlan& r) {
			cout << r << "\n";
		}
		catch(const LabException & r) {
			cout << r << "\n";
		}
		cout << "\n";
	}
}
