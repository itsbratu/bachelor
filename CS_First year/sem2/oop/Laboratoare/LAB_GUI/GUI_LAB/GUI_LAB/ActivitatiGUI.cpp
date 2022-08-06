#include "ActivitateGUI.h"
#include "RepoFile.h"
#include "Validator.h"
#include <QLayout>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QLabel>
#include <QListWidgetItem>
#include <QString>
#include <QFormLayout>
#include <QMessageBox>
#include <QTableWidget>
#include <string>

using std::string;

void ActivityGUI::clearlabels() {
	title->setText("");
	description->setText("");
	type->setText("");
	length->setText("");
}

void ActivityGUI::initGUI()
{
	QHBoxLayout* main = new QHBoxLayout;
	this->setLayout(main);

	QVBoxLayout* l1 = new QVBoxLayout;
	QVBoxLayout* l2 = new QVBoxLayout;

	//setare afisare
	main->addLayout(l1);
	main->addStretch();
	main->addLayout(l2);

	//jumatate 1 aplicatie
	l1->addWidget(lista);
	l1->addWidget(btn_refresh);
	this->loadData(srv.get_all());

	QLabel* sortari = new QLabel("Sortari");
	sortari->setAlignment(Qt::AlignCenter);

	l1->addWidget(sortari);

	l1->addWidget(btn_srt_1);
	l1->addWidget(btn_srt_2);
	l1->addWidget(btn_srt_3);

	QLabel* filtrari = new QLabel("Filtrari");
	filtrari->setAlignment(Qt::AlignCenter);

	l1->addWidget(filtrari);

	l1->addWidget(btn_filtr_1);
	l1->addWidget(btn_filtr_2);

	//jumatate 2 aplicatie
	//l2->addWidget(new QLabel{ "Carte" });

	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);

	info->addRow("Title", title);
	info->addRow("Description", description);
	info->addRow("Type", type);
	info->addRow("Length", length);

	l2->addWidget(btn_add);
	l2->addWidget(btn_upp);
	l2->addWidget(btn_del);
	l2->addWidget(btn_search);
	l2->addWidget(btn_undo);
	l2->addStretch();
}

void ActivityGUI::loadData(vector<Activity> elems)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getTitle()));
		lista->addItem(item);
		item->setData(Qt::UserRole, QString::fromStdString(e.getDescription()));
	}
}

void ActivityGUI::loadDataFiltrare(vector<Activity> elems, int nr , int color)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getTitle()));
		lista->addItem(item);
		if (e.getLength() == nr)
		{
			if (color == 0)
				item->setBackgroundColor(Qt::red);
			else
				item->setBackgroundColor(Qt::darkGreen);
		}
		item->setData(Qt::UserRole, QString::fromStdString(e.getDescription()));
	}
}

void ActivityGUI::initConnect()
{
	QObject::connect(btn_refresh, &QPushButton::clicked, this, [this]() {
		loadData(srv.get_all());
		clearlabels();
		});

	QObject::connect(btn_srt_1, &QPushButton::clicked, this, [this]() {
		vector<Activity> v = srv.sort_activity(1);
		loadData(v);
		});

	QObject::connect(btn_srt_2, &QPushButton::clicked, this, [this]() {
		vector<Activity> v = srv.sort_activity(2);
		loadData(v);
		});

	QObject::connect(btn_srt_3, &QPushButton::clicked, this, [this]() {
		vector<Activity> v = srv.sort_activity(3);
		loadData(v);
		});

	//length
	QObject::connect(btn_filtr_1, &QPushButton::clicked, this, [this]() {
		bool ok = true;
		int pr = length->text().toInt(&ok);
		if (ok == false) {
			QMessageBox::warning(this, "Eroare", "Valoare numerica invalida");
			return;
		}
		loadDataFiltrare(srv.get_all(), pr , 0);
		clearlabels();
		});

	//title
	QObject::connect(btn_filtr_2, &QPushButton::clicked, this, [this]() {
		string n = description->text().toStdString();
		if (n == "")
		{
			QMessageBox::warning(this, "Eroare", "Numele nu poate fi vid");
			return;
		}

		vector<Activity> v = srv.filter_activity("descriere", n);
		creeazaTabela(v);
		clearlabels();
		});

	QObject::connect(btn_add, &QPushButton::clicked, this, [this]() {
			bool ok = true;
			int pr = length->text().toInt(&ok);
			string n = title->text().toStdString();
			string t = description->text().toStdString();
			string p = type->text().toStdString();
			srv.add_activity(n, t, p, pr);
			loadData(srv.get_all());
			clearlabels();
		});

	QObject::connect(btn_upp, &QPushButton::clicked, this, [this]() {
		try
		{
			bool ok = true;
			int pr = length->text().toInt(&ok);
			string n = title->text().toStdString();
			string t = description->text().toStdString();
			string p = type->text().toStdString();
			srv.modify_activity(n, t, p, pr);
			loadData(srv.get_all());
			clearlabels();
		}
		catch (const ErrorRepo& ex) {
			QMessageBox::warning(this, "Eroare", "Produsul nu exista.");
		}

		});

	QObject::connect(btn_del, &QPushButton::clicked, this, [this]() {
		try
		{
			string n = title->text().toStdString();
			string t = description->text().toStdString();
			srv.delete_activity(n, t);
			loadData(srv.get_all());
			clearlabels();
		}
		catch (const ErrorRepo& ex) {
			QMessageBox::warning(this, "Eroare", "Produsul nu exista.");
		}
		});

	QObject::connect(btn_search, &QPushButton::clicked, this, [this]() {

		try {
			string n = title->text().toStdString();
			string t = description->text().toStdString();
			const Activity a = srv.find_activity(n, t);
			length->setText(QString::number(a.getLength()));
			clearlabels();
			QMessageBox::warning(this, "Gasit!", "Activitatea exista.");
		}
		catch (const ErrorRepo& ex) {
			QMessageBox::warning(this, "Eroare!", "Activitatea nu exista.");
			clearlabels();
		}

		});

	QObject::connect(btn_undo, &QPushButton::clicked, this, [this]() {
		try {
			srv.undo();
			loadData(srv.get_all());
		}
		catch (const ErrorRepo& ex) {
			QMessageBox::warning(this, "Eroare", "Nu mai exista operatii.");
		}
		});

	QObject::connect(this->lista, &QListWidget::itemSelectionChanged, [this]() {
		if (this->lista->selectedItems().isEmpty()) {
			return;
		}
		auto item = this->lista->selectedItems().at(0);

		string title1, description1, type1;
		int length1;

		title1 = item->text().toStdString();
		QVariant data = item->data(Qt::UserRole);
		QString desc = data.toString();
		string descr = desc.toStdString();
		this->description->setText(desc);

		vector<Activity> v = srv.get_all();

		for (const auto& p : v)
		{
			if (p.getTitle() == title1 && p.getDescription() == descr)
			{
				this->title->setText(QString::fromStdString(p.getTitle()));
				this->type->setText(QString::fromStdString(p.getType()));
				this->description->setText(QString::fromStdString(p.getDescription()));
				this->length->setText(QString::number(p.getLength()));
				return;
			}
		}
		});
}

void ActivityGUI::creeazaTabela(vector<Activity> v)
{
	//QWidget* window = new QWidget;
	QTableWidget* window = new QTableWidget(v.size(), 2);
	int i = 0;
	for (const auto e : v) {
		QTableWidgetItem* it1 = new QTableWidgetItem(QString::fromStdString(e.getTitle()));
		QTableWidgetItem* it2 = new QTableWidgetItem(QString::fromStdString(e.getDescription()));
		it1->setBackgroundColor(Qt::yellow);
		it2->setBackgroundColor(Qt::green);
		window->setItem(i, 0, it1);
		window->setItem(i, 1, it2);
		i++;
	}
	window->show();
}