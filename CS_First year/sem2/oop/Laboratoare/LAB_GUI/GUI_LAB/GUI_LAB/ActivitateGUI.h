#pragma once
#include <QtWidgets/qwidget.h>
#include <qlistwidget.h>
#include <qpushbutton.h>
#include <qlineedit.h>

#include "Service.h"
#include "Activitati.h"

class ActivityGUI : public QWidget {
public:
	ActivityGUI(Service& srv, PlanRepo& cos) : srv{ srv }, cos{ cos }{
		initGUI();
		loadData(srv.get_all());
		initConnect();
	}

private:
	Service& srv;
	PlanRepo& cos;

	QListWidget* lista = new QListWidget;

	QPushButton* btn_refresh = new QPushButton("Refresh");

	QPushButton* btn_srt_1 = new QPushButton{ "Sort title!" };
	QPushButton* btn_srt_2 = new QPushButton{ "Sort description!" };
	QPushButton* btn_srt_3 = new QPushButton{ "Sort length!" };

	QPushButton* btn_filtr_1 = new QPushButton{ "Filter by length!" };
	QPushButton* btn_filtr_2 = new QPushButton{ "Filter by description!" };

	QLineEdit* title = new QLineEdit;
	QLineEdit* description = new QLineEdit;
	QLineEdit* type = new QLineEdit;
	QLineEdit* length = new QLineEdit;

	QPushButton* btn_add = new QPushButton("Add!");

	QPushButton* btn_upp = new QPushButton("Modify!");

	QPushButton* btn_del = new QPushButton("Delete!");

	QPushButton* btn_search = new QPushButton("Find!");

	QPushButton* btn_undo = new QPushButton("Undo");

	void loadData(vector<Activity> elems);
	void loadDataFiltrare(vector<Activity> elems, int nr ,int color);
	void initGUI();
	void initConnect();
	void creeazaTabela(vector<Activity> v);
	void clearlabels();
};