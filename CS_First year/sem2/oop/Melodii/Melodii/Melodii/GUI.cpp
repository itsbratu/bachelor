#include "GUI.h"
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
#include <QAbstractTableModel>

#include "TabelView.h"

using std::string;
void GUI::initgui()
{
	QHBoxLayout* main = new QHBoxLayout;
	this->setLayout(main);

	QVBoxLayout* l1 = new QVBoxLayout;
	QVBoxLayout* l2 = new QVBoxLayout;

	main->addLayout(l1);
	main->addWidget(tabel);
	tabel->setModel(model);
	load_data(serv.get_all());
	l1->addWidget(btn_tabel);
	l1->addWidget(btn_delete);
	l1->addWidget(btn_update);
	QFormLayout* info = new QFormLayout;

	l2->addLayout(info);
	info->addRow("ID", id_txt);
	info->addRow("Title", title_txt);
	info->addRow("Artist", artist_txt);
	info->addRow("Rank", rank_txt);
	slider_rank->setMinimum(0);
	slider_rank->setMaximum(10);
	l2->addWidget(slider_rank);
	main->addLayout(l2);
}

void GUI::connect()
{
	QObject::connect(btn_tabel, &QPushButton::clicked, this, [this]() {
		create_tabel(serv.sort_rank());
		});
	QObject::connect(btn_update , &QPushButton::clicked, this, [this]() {
		int id = id_txt->text().toInt();
		string title = title_txt->text().toLocal8Bit().constData();
		string artist = artist_txt->text().toLocal8Bit().constData();
		int rank = rank_txt->text().toInt();
		Melodie m{ id , title , artist , rank };
		serv.mod(m);
		load_data(serv.get_all());
		id_txt->setText("");
		title_txt->setText("");
		artist_txt->setText("");
		rank_txt->setText("");
		});
	QObject::connect(btn_delete , &QPushButton::clicked, this, [this]() {
		try {
			string id = id_txt->text().toStdString();
			int id_number = stoi(id);
			serv.del(id_number);
			load_data(serv.get_all());
			id_txt->setText("");
			title_txt->setText("");
			artist_txt->setText("");
			rank_txt->setText("");
		}
		catch (const ErrorRepo& ex) {
			id_txt->setText("");
			title_txt->setText("");
			artist_txt->setText("");
			rank_txt->setText("");
			QMessageBox::warning(this, "Eroare", "Ultima melodie !");
		}
		});
	QObject::connect(slider_rank, &QSlider::sliderMoved, this, [this]() {
		int current_value = slider_rank->value();
		auto value = std::to_string(current_value);
		rank_txt->setText(QString::fromStdString(value));
		});
	QObject::connect(tabel->selectionModel(), &QItemSelectionModel::selectionChanged, [this]() {
		if (tabel->selectionModel()->selectedIndexes().isEmpty()) {
			id_txt->setText("");
			title_txt->setText("");
			artist_txt->setText("");
			rank_txt->setText("");
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
		rank_txt->setText(cel3Value);
		});

}

void GUI::load_data(vector<Melodie> v)
{
	std::sort(v.begin(), v.end(), [](const Melodie& a, const Melodie& b)->bool
		{
			return a.getRank() < b.getRank();
		});
	model->update(v);
}

void GUI::create_tabel(vector<Melodie> v)
{
	QTableWidget* window = new QTableWidget(v.size(), 4);
	int i = 0;
	for (const auto e : v) {
		QTableWidgetItem* it1 = new QTableWidgetItem(QString::fromStdString(std::to_string(e.getId())));
		QTableWidgetItem* it2 = new QTableWidgetItem(QString::fromStdString(e.getTitle()));
		QTableWidgetItem* it3 = new QTableWidgetItem(QString::fromStdString(e.getArtist()));
		QTableWidgetItem* it4 = new QTableWidgetItem(QString::fromStdString(std::to_string(e.getRank())));
		window->setItem(i, 0, it1);
		window->setItem(i, 1, it2);
		window->setItem(i, 2, it3);
		window->setItem(i, 3, it4);
		i++;
	}
	window->show();
}

