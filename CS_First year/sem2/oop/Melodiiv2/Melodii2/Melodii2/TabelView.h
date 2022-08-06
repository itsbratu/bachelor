#pragma once
#include "Melodie.h"
#include <QAbstractTableModel>
#include <vector>
#include <QBrush>

class MyTabelModel : public QAbstractTableModel
{
	private:
		vector<Melodie>v;
	public:
		MyTabelModel() = default;

		void update(vector<Melodie> vec);

		int rowCount(const QModelIndex& p = QModelIndex()) const override {
			return v.size();
		}

		int columnCount(const QModelIndex& p = QModelIndex()) const override {
			return 6;
		}

		QVariant data(const QModelIndex& p, int rol = Qt::DisplayRole) const override {
			int r = p.row();
			int c = p.column();
			Melodie m = v.at(r);

			if(rol == Qt::DisplayRole){}
			{
				if (c == 0)
					return QString::number(m.getId());
				if (c == 1)
					return QString::fromStdString(m.getTitle());
				if (c == 2)
					return QString::fromStdString(m.getArtist());
				if (c == 3)
					return QString::fromStdString(m.getGen());
				if (c == 4)
				{
					int counter = 0;
					std::string curr_autor = m.getArtist();
					for (const auto& p : v) {
						if (p.getArtist() == curr_autor)
							counter++;
					}
					return QString::number(counter);
				}
				if (c == 5)
				{
					int counter = 0;
					std::string curr_gen = m.getGen();
					for (const auto& p : v) {
						if (p.getGen() == curr_gen)
							counter++;
					}
					return QString::number(counter);
				}
			}
			return QVariant{};
		}

};

