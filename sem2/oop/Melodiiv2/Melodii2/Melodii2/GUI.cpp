#include "GUI.h"
#include <QLayout>
#include <QHBoxLayout>
#include <QVBoxLayout>
#include <QLabel>
#include <QAbstractTableModel>
#include <QFormLayout>
#include <QTableWidget>
#include <QMessageBox>
#include <cstring>


#include "TabelView.h"
using std::string;

void GUI::create_tabel(vector<Melodie> v)
{
	QTableWidget* window = new QTableWidget(v.size(), 4);
	int i = 0;
	for (const auto e : v) {
		QTableWidgetItem* it1 = new QTableWidgetItem(QString::fromStdString(std::to_string(e.getId())));
		QTableWidgetItem* it2 = new QTableWidgetItem(QString::fromStdString(e.getTitle()));
		QTableWidgetItem* it3 = new QTableWidgetItem(QString::fromStdString(e.getArtist()));
		QTableWidgetItem* it4 = new QTableWidgetItem(QString::fromStdString(e.getGen()));
		window->setItem(i, 0, it1);
		window->setItem(i, 1, it2);
		window->setItem(i, 2, it3);
		window->setItem(i, 3, it4);
		i++;
	}
	window->show();
}

void GUI::init()
{
	QHBoxLayout* main = new QHBoxLayout;
	this->setLayout(main);

	QVBoxLayout* l1 = new QVBoxLayout;
	QVBoxLayout* l2 = new QVBoxLayout;

	main->addLayout(l1);
	main->addWidget(tabel);
	tabel->setModel(model);
	load_data(serv.get_all());
	l1->addWidget(btnTabel);
	l1->addWidget(btnAdd);
	l1->addWidget(btnDelete);
	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);
	info->addRow("ID", id_txt);
	info->addRow("Title", title_txt);
	info->addRow("Artist", artist_txt);
	info->addRow("Gen", gen_txt);
	main->addLayout(l2);
}

void GUI::connect()
{
	QObject::connect(btnTabel, &QPushButton::clicked, this, [this]() {
		create_tabel(serv.get_all());
		});
	QObject::connect(btnAdd, &QPushButton::clicked, this, [this]() {
		int number_generated = 0;
		int i;
		bool ok;
		for (i = 0; i < 100; ++i)
		{
			ok = 1;
			for (const auto& p : serv.get_all()) {
				if (p.getId() == i)
					ok = 0;
			}
			if (ok == 1) {
				number_generated = i;
				break;
			}
		}

		string title = title_txt->text().toLocal8Bit().constData();
		string artist = artist_txt->text().toLocal8Bit().constData();
		string gen = gen_txt->text().toLocal8Bit().constData();
		if (gen.compare("folk") == 0 || gen.compare("pop") == 0 || gen.compare("rock") == 0 || gen.compare("disco") == 0) {
			Melodie m{ number_generated , title , artist , gen };
			serv.add(m);
			load_data(serv.get_all());
		}
		else {
			QMessageBox::warning(this, "Eroare", "Invalid gen!");
		}
		id_txt->setText("");
		title_txt->setText("");
		artist_txt->setText("");
		gen_txt->setText("");
		});
	QObject::connect(btnDelete, &QPushButton::clicked, this, [this]() {
		string id = id_txt->text().toStdString();
		int id_number = stoi(id);
		serv.del(id_number);
		load_data(serv.get_all());
		id_txt->setText("");
		title_txt->setText("");
		artist_txt->setText("");
		gen_txt->setText("");
		});
	QObject::connect(tabel->selectionModel(), &QItemSelectionModel::selectionChanged, [this]() {
		if (tabel->selectionModel()->selectedIndexes().isEmpty()) {
			id_txt->setText("");
			title_txt->setText("");
			artist_txt->setText("");
			gen_txt->setText("");
			return;
		}

		int selRow = tabel->selectionModel()->selectedIndexes().at(0).row();
		auto cel0Index = tabel->model()->index(selRow, 0);
		auto cel1Index = tabel->model()->index(selRow, 1);
		auto cel2Index = tabel->model()->index(selRow, 2);
		auto cel3Index = tabel->model()->index(selRow, 3);

		auto cel0Value = tabel->model()->data(cel0Index, Qt::DisplayRole).toString();
		auto cel1Value = tabel->model()->data(cel1Index, Qt::DisplayRole).toString();
		auto cel2Value = tabel->model()->data(cel2Index, Qt::DisplayRole).toString();
		auto cel3Value = tabel->model()->data(cel3Index, Qt::DisplayRole).toString();
		id_txt->setText(cel0Value);
		title_txt->setText(cel1Value);
		artist_txt->setText(cel2Value);
		gen_txt->setText(cel3Value);
	});
}

void GUI::load_data(vector<Melodie> v)
{
	model->update(v);
}
