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
	PlanRepo& cos;

	QListWidget* lista = new QListWidget;

	QLineEdit* title = new QLineEdit;
	QLineEdit* description = new QLineEdit;
	QLineEdit* number = new QLineEdit;
	QLineEdit* file = new QLineEdit;

	QPushButton* btn_add = new QPushButton("Plan - ADD");

	QPushButton* btn_add_rand = new QPushButton("Plan - RANDOM");

	QPushButton* btn_gol = new QPushButton("Plan - CLEAR");

	QPushButton* btn_exp = new QPushButton("Plan - EXPORT");

	void incarcaLista(vector<Activity> elems);
	void clearlabels();
	void init();
	void connect();
	void add_rand();
	void goleste();
	void exporta();
	void add();

public:
	GUIPlan(Service& srv, PlanRepo& cos);
};