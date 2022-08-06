#include "CosGUI.h"
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
#include "repo.h"


void GUIcos::incarcaLista(vector<Produs> elems)
{
	lista->clear();
	for (const auto& e : elems) {
		QListWidgetItem* item = new QListWidgetItem(QString::fromStdString(e.getName()));
		lista->addItem(item);
		item->setData(Qt::UserRole, QString::fromStdString(e.getProd()));
	}
}

void GUIcos::init()
{
	QHBoxLayout* main = new QHBoxLayout;
	this->setLayout(main);

	QVBoxLayout* l1 = new QVBoxLayout;
	QVBoxLayout* l2 = new QVBoxLayout;

	main->addLayout(l1);
	main->addStretch();
	main->addLayout(l2);

	l1->addWidget(lista);
	this->incarcaLista(cos.getAll());

	l1->addWidget(btn_gol);

	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);

	info->addRow("Nume", nume);
	info->addRow("Numar", numar);
	info->addRow("Producator", prod);
	info->addRow("Fisier", nume_fisier);

	l2->addWidget(btn_add);
	l2->addWidget(btn_add_rand);
	l2->addWidget(btn_exp);
	l2->addStretch();
}

void GUIcos::connect()
{

	QObject::connect(btn_add_rand, &QPushButton::clicked, this, [this]() {
		this->add_rand();
		incarcaLista(srv.getCos());
		});

	QObject::connect(btn_gol, &QPushButton::clicked, this, [this]() {
		this->goleste();
		incarcaLista(srv.getCos());
		});

	QObject::connect(btn_exp, &QPushButton::clicked, this, [this]() {
		this->exporta();
		incarcaLista(srv.getCos());
		});

	QObject::connect(btn_add, &QPushButton::clicked, this, [this]() {
		this->add();
		incarcaLista(srv.getCos());
		});
}

void GUIcos::add_rand()
{

	bool ok = true;
	int nr = numar->text().toInt(&ok);

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

	try
	{
		cos.generare(nr);
	}
	catch (CosException ex)
	{
		QMessageBox::warning(this, "Eroare", QString::fromStdString(ex.getMsg()));
	}
	
}

void GUIcos::goleste()
{
	cos.empty();
}

void GUIcos::exporta()
{
	string fn = nume_fisier->text().toStdString();

	if (fn == "")
	{
		QMessageBox::warning(this, "Eroare", "Trebuie introdus numele fisierului.");
		return;
	}

	srv.ExportCos(fn);
}

void GUIcos::add()
{
	try {
		string n = nume->text().toStdString();
		string producator = prod->text().toStdString();
		

		if (n == "" || producator == "")
		{
			QMessageBox::warning(this, "Eroare", "Numele si producatorul nu pot fi vide.");
			return;
		}

		Produs p = srv.findProdus(n, producator);
		cos.add(p.getName(), p.getType(), p.getProd());

	}
	catch (CosException& ex) {
		QMessageBox::warning(this, "Eroare", QString::fromStdString(ex.getMsg()));
	}
	catch (RepoException& ex) {
		QMessageBox::warning(this, "Eroare", QString::fromStdString(ex.getMsg()));
	}
}

GUIcos::GUIcos(Service& srv, Cos& cos) : srv{ srv }, cos{ cos }
{
	this->init();
	this->connect();
}