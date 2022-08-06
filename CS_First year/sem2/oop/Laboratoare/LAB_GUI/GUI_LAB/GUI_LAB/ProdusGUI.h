#include <QtWidgets/qwidget.h>
#include <qlistwidget.h>
#include <qpushbutton.h>
#include <qlineedit.h>

#include "Service.h"

class ProdusGUI : public QWidget {
public:
	ProdusGUI(Service& srv, Cos& cos) : srv{ srv }, cos{ cos }{
		initGUI();
		loadData(srv.getAll());
		initConnect();
	}

private:
	Service& srv;
	Cos& cos;

	QListWidget* lista = new QListWidget;

	QPushButton* btn_refresh = new QPushButton("Refresh");

	QPushButton* btn_srt_1 = new QPushButton{ "SortareNume" };
	QPushButton* btn_srt_2 = new QPushButton{ "SortarePret" };
	QPushButton* btn_srt_3 = new QPushButton{ "SortareNumeTip" };

	QPushButton* btn_filtr_1 = new QPushButton{ "FiltrarePret" };
	QPushButton* btn_filtr_2 = new QPushButton{ "FiltrareNume" };
	QPushButton* btn_filtr_3 = new QPushButton{ "FiltrareProd" };

	QLineEdit* nume = new QLineEdit;
	QLineEdit* tip = new QLineEdit;
	QLineEdit* prod = new QLineEdit;
	QLineEdit* pret = new QLineEdit;

	QPushButton* btn_add = new QPushButton("Adauga");

	QPushButton* btn_upp = new QPushButton("Modifica");

	QPushButton* btn_del = new QPushButton("Stergere");

	QPushButton* btn_search = new QPushButton("Cauta");

	QPushButton* btn_undo = new QPushButton("Undo");

	void loadData(vector<Activity> elems);
	void loadDataFiltrare(vector<Activity> elems, int nr);
	void initGUI();
	void initConnect();
	void creeazaTabela(vector<Produs> v);
};