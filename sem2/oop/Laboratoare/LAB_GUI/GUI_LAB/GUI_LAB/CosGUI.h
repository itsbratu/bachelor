#pragma once
#include <QWidget>
#include "Service.h"
#include <QListWidget>
#include <QPushButton>
#include <QCheckBox>
#include <QLineEdit>

class GUIPlan : public QWidget {
private:
	Service& srv;
	Cos& cos;

	QListWidget* lista = new QListWidget;

	QLineEdit* nume = new QLineEdit;
	QLineEdit* prod = new QLineEdit;
	QLineEdit* numar = new QLineEdit;
	QLineEdit* nume_fisier = new QLineEdit;

	QPushButton* btn_add = new QPushButton("Adauga");

	QPushButton* btn_add_rand = new QPushButton("Adauga Random");

	QPushButton* btn_gol = new QPushButton("Goleste");

	QPushButton* btn_exp = new QPushButton("Exporta");

	void incarcaLista(vector<Produs> elems);
	void init();
	void connect();
	void add_rand();
	void goleste();
	void exporta();
	void add();

public:
	GUIPlan(Service& srv, Cos& cos);
};