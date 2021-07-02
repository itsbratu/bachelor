#pragma once
#include "service.h"
#include <qwidget.h>
#include <qtableview.h>
#include "TabelView.h"
#include <QLineEdit>
#include <QSlider> 
#include <qpushbutton.h>


class GUI : public QWidget
{
	public:
		GUI(Service& serv) : serv{ serv } {
			initgui();
			connect();
		}

	private:
		Service& serv;

		QPushButton* btn_tabel = new QPushButton{ "Tabel" };
		QPushButton* btn_delete = new QPushButton{ "Delete" };
		QPushButton* btn_update = new QPushButton{ "Update" };
		QTableView* tabel = new QTableView;
		MyTableModel* model = new MyTableModel;

		QLineEdit* id_txt = new QLineEdit;
		QLineEdit* title_txt = new QLineEdit;
		QLineEdit* artist_txt = new QLineEdit;
		QLineEdit* rank_txt = new QLineEdit;
		QSlider* slider_rank = new QSlider;

		//creaza un tabel pentru afisarea instantelor sortate dupa rank
		void create_tabel(vector<Melodie> v);

		//initializeaza formatul interfatei grafice
		void initgui();

		//realizeaza semnalele intre butoane si actiuni
		void connect();

		//incarca in model toate intrarile din tabel
		void load_data(vector<Melodie> v);

};

