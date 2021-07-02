#include "ActivitateGUI.h"
#include "PlanGUI.h"
#include <QLayout>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QLabel>
#include <QListWidgetItem>
#include <QString>
#include <QFormLayout>
#include <QMessageBox>
#include <QTableWidget>
#include "RepoFile.h"
#include "Repository.h"

void GUIPlan::clearlabels() {
	title->setText("");
	description->setText("");
	number->setText("");
	file->setText("");
}

void GUIPlan::incarcaLista(vector<Activity> elems)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getTitle()));
		lista->addItem(item);
		string add_string = e.getTitle() + " " + e.getDescription() + " " + e.getType();
		item->setData(Qt::UserRole, QString::fromStdString(add_string));
	}
}

void GUIPlan::init()
{
	QHBoxLayout* main = new QHBoxLayout;
	this->setLayout(main);

	QVBoxLayout* l1 = new QVBoxLayout;
	QVBoxLayout* l2 = new QVBoxLayout;

	main->addLayout(l1);
	main->addStretch();
	main->addLayout(l2);

	l1->addWidget(lista);
	this->incarcaLista(cos.getall());

	l1->addWidget(btn_gol);

	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);

	info->addRow("Title", title);
	info->addRow("Description", description);
	info->addRow("Number", number);
	info->addRow("File", file);

	l2->addWidget(btn_add);
	l2->addWidget(btn_add_rand);
	l2->addWidget(btn_exp);
	l2->addStretch();
}

void GUIPlan::connect()
{

	QObject::connect(btn_add_rand, &QPushButton::clicked, this, [this]() {
		this->add_rand();
		incarcaLista(srv.get_plan());
		});

	QObject::connect(btn_gol, &QPushButton::clicked, this, [this]() {
		this->goleste();
		incarcaLista(srv.get_plan());
		});

	QObject::connect(btn_exp, &QPushButton::clicked, this, [this]() {
		this->exporta();
		incarcaLista(srv.get_plan());
		});

	QObject::connect(btn_add, &QPushButton::clicked, this, [this]() {
		this->add();
		incarcaLista(srv.get_plan());
		});
}

void GUIPlan::add_rand()
{

	bool ok = true;
	int nr = number->text().toInt(&ok);

	if (ok == false)
	{
		QMessageBox::warning(this, "Eroare", "Trebuie introdusa o valoare numerica.");
		return;
	}

	if (nr < 0)
	{
		QMessageBox::warning(this, "Eroare", "Numarul nu poate fi negativ.");
		return;
	}
	srv.rand_plan(nr);
	clearlabels();
}

void GUIPlan::goleste()
{
	cos.delete_all();
}

void GUIPlan::exporta()
{
	string fn = file->text().toStdString();

	if (fn == "")
	{
		QMessageBox::warning(this, "Eroare", "Trebuie introdus numele fisierului.");
		return;
	}
	srv.exportToCVS(fn);
	clearlabels();
}

void GUIPlan::add()
{
	try {
		string t = title->text().toStdString();
		string d = description->text().toStdString();


		if (t == "" || d == "")
		{
			QMessageBox::warning(this, "Eroare", "Titlul si descrierea nu poti vide!");
			return;
		}

		const Activity p = srv.find_activity(t, d);
		cos.add(p);
		clearlabels();
	}
	catch (ErrorPlan& ex) {
		QMessageBox::warning(this, "Eroare", "De la Plan!");
	}
	catch (ErrorRepo& ex) {
		QMessageBox::warning(this, "Eroare", "De la Repo!");
	}
}

GUIPlan::GUIPlan(Service& srv, PlanRepo& cos) : srv{ srv }, cos{ cos }
{
	this->init();
	this->connect();
}