#pragma once
#include "Service.h"
#include "TabelView.h"
#include <qwidget.h>
#include <qtableview.h>
#include <QLineEdit>
#include <qpushbutton.h>

class GUI : public QWidget
{
public:
	GUI(Service& serv) : serv{ serv } {
		init();
		connect();
	}

private:
	Service& serv;

	QPushButton* btnTabel = new QPushButton{ "Tabel" };
	QPushButton* btnAdd = new QPushButton{ "Add" };
	QPushButton* btnDelete = new QPushButton{ "Delete" };
	QTableView* tabel = new QTableView;
	MyTabelModel* model = new MyTabelModel;

	QLineEdit* id_txt = new QLineEdit;
	QLineEdit* title_txt = new QLineEdit;
	QLineEdit* artist_txt = new QLineEdit;
	QLineEdit* gen_txt = new QLineEdit;

	//creeaza un tabel pentru afisarea instantelor
	void create_tabel(vector<Melodie> v);

	//initializeaza formatul interfetei grafice
	void init();

	//conexiune butoane
	void connect();

	//incarca in model toate intrarile din tabel
	void load_data(vector<Melodie> v);

};

