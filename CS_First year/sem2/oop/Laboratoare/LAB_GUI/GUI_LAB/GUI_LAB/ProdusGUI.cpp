#include "ProdusGUI.h"
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

void ProdusGUI::initGUI()
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
	this->loadData(srv.getAll());

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
	l1->addWidget(btn_filtr_3);

	//jumatate 2 aplicatie
	//l2->addWidget(new QLabel{ "Carte" });

	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);

	info->addRow("Nume", nume);
	info->addRow("Tip", tip);
	info->addRow("Producator", prod);
	info->addRow("Pret", pret);

	l2->addWidget(btn_add);
	l2->addWidget(btn_upp);
	l2->addWidget(btn_del);
	l2->addWidget(btn_search);
	l2->addWidget(btn_undo);
	l2->addStretch();
}

void ProdusGUI::loadData(vector<Produs> elems)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getName()));
		lista->addItem(item);
		item->setData(Qt::UserRole, QString::fromStdString(e.getProd()));
	}
}

void ProdusGUI::loadDataFiltrare(vector<Produs> elems, int nr)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getName()));
		lista->addItem(item);
		if (e.getPrice() == nr)
			item->setBackgroundColor(Qt::red);
		item->setData(Qt::UserRole, QString::fromStdString(e.getProd()));
	}
}

void ProdusGUI::initConnect()
{
	QObject::connect(btn_refresh, &QPushButton::clicked, this, [this]() {
		loadData(srv.getAll());
		});

	QObject::connect(btn_srt_1, &QPushButton::clicked, this, [this]() {
		vector<Produs> v = srv.SortareNume();
		loadData(v);
		});

	QObject::connect(btn_srt_2, &QPushButton::clicked, this, [this]() {
		vector<Produs> v = srv.SortarePret();
		loadData(v);
		});

	QObject::connect(btn_srt_3, &QPushButton::clicked, this, [this]() {
		vector<Produs> v = srv.SortareNumeTip();
		loadData(v);
		});

	//pret
	QObject::connect(btn_filtr_1, &QPushButton::clicked, this, [this]() {
		bool ok = true;
		int pr = pret->text().toInt(&ok);
		if (ok == false) {
			QMessageBox::warning(this, "Eroare", "Valoare numerica invalida");
			return;
		}
		loadDataFiltrare(srv.getAll(), pr);
		});

	//nume
	QObject::connect(btn_filtr_2, &QPushButton::clicked, this, [this]() {
		string n = nume->text().toStdString();
		if (n == "")
		{
			QMessageBox::warning(this, "Eroare", "Numele nu poate fi vid");
			return;
		}

		vector<Produs> v = srv.FiltrareNume(n);
		creeazaTabela(v);
		});

	//prod
	QObject::connect(btn_filtr_3, &QPushButton::clicked, this, [this]() {
		string pr = prod->text().toStdString();
		if (pr == "")
		{
			QMessageBox::warning(this, "Eroare", "Producatorul nu poate fi vid");
			return;
		}

		vector<Produs> v = srv.FiltrareProd(pr);
		creeazaTabela(v);
		});

	QObject::connect(btn_add, &QPushButton::clicked, this, [this]() {
		try
		{
			bool ok = true;
			int pr = pret->text().toInt(&ok);
			string n = nume->text().toStdString();
			string t = tip->text().toStdString();
			string p = prod->text().toStdString();
			srv.addProdus(n, t, p, pr);
			loadData(srv.getAll());
		}
		catch (const ValidateException& ex) {
			string mesaje = "";
			for (const auto& msg : ex.msgs)
				mesaje = mesaje + msg;

			QMessageBox::warning(this, "Eroare", QString::fromStdString(mesaje));
		}
		catch (const RepoException& ex) {
			QMessageBox::warning(this, "Eroare", "Produsul exista deja in lista");
		}

		});

	QObject::connect(btn_upp, &QPushButton::clicked, this, [this]() {
		try
		{
			bool ok = true;
			int pr = pret->text().toInt(&ok);
			string n = nume->text().toStdString();
			string t = tip->text().toStdString();
			string p = prod->text().toStdString();
			srv.modProdus(n, t, p, pr);
		}
		catch (const RepoException& ex) {
			QMessageBox::warning(this, "Eroare", "Produsul nu exista.");
		}

		});

	QObject::connect(btn_del, &QPushButton::clicked, this, [this]() {
		try
		{
			string n = nume->text().toStdString();
			string t = tip->text().toStdString();
			string p = prod->text().toStdString();
			srv.delProdus(n, t, p);
			loadData(srv.getAll());
		}
		catch (const RepoException& ex) {
			QMessageBox::warning(this, "Eroare", "Produsul nu exista.");
		}
		});

	QObject::connect(btn_search, &QPushButton::clicked, this, [this]() {

		string n = nume->text().toStdString();
		string t = tip->text().toStdString();
		string p = prod->text().toStdString();
		double pr = srv.lookProdus(n, t, p);
		if (pr == -2)
		{
			QMessageBox::warning(this, "Eroare", "Produsul nu a fost gasit.");
		}
		else
		{
			pret->setText(QString::number(pr));
		}
		});

	QObject::connect(btn_undo, &QPushButton::clicked, this, [this]() {
		try {
			srv.Undo();
			loadData(srv.getAll());
		}
		catch (const RepoException& ex) {
			QMessageBox::warning(this, "Eroare", "Nu mai exista operatii.");
		}
		});

	QObject::connect(this->lista, &QListWidget::itemSelectionChanged, [this]() {
		if (this->lista->selectedItems().isEmpty()) {
			return;
		}
		auto item = this->lista->selectedItems().at(0);

		string nume, tip, producator;
		double pret;

		nume = item->text().toStdString();
		QVariant data = item->data(Qt::UserRole);
		QString prod = data.toString();
		producator = prod.toStdString();
		this->prod->setText(prod);

		vector<Produs> v = srv.getAll();

		for (const auto& p : v)
		{
			if (p.getName() == nume && p.getProd() == producator)
			{
				this->nume->setText(QString::fromStdString(p.getName()));
				this->tip->setText(QString::fromStdString(p.getType()));
				this->prod->setText(QString::fromStdString(p.getProd()));
				this->pret->setText(QString::number(p.getPrice()));
				return;
			}
		}
		});
}

void ProdusGUI::creeazaTabela(vector<Produs> v)
{
	//QWidget* window = new QWidget;
	QTableWidget* window = new QTableWidget(v.size(), 2);
	int i = 0;
	for (const auto e : v) {
		QTableWidgetItem* it1 = new QTableWidgetItem(QString::fromStdString(e.getName()));
		QTableWidgetItem* it2 = new QTableWidgetItem(QString::fromStdString(e.getProd()));
		window->setItem(i, 0, it1);
		window->setItem(i, 1, it2);
		i++;
	}
	window->show();
}