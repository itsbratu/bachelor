#pragma once

#include "domain.h"
#include <QAbstractTableModel>
#include <vector>
#include <Qbrush>

class MyTableModel : public QAbstractTableModel
{
private:
    vector<Melodie> v;
public:
    MyTableModel() = default;

    void update(vector<Melodie> vec);

    int rowCount(const QModelIndex & p = QModelIndex()) const override {
        return v.size();
    }

    int columnCount(const QModelIndex & p = QModelIndex()) const override {
        return 5;
    }

    QVariant data(const QModelIndex & p, int rol = Qt::DisplayRole) const override {
        int r = p.row();
        int c = p.column();
        Melodie mel = v.at(r);
        if (rol == Qt::DisplayRole) {
            if (c == 0) {
                return QString::number(mel.getId());
            }
            if (c == 1) {
                return QString::fromStdString(mel.getTitle());
            }
            if (c == 2) {
                return QString::fromStdString(mel.getArtist());
            }
            if (c == 3) {
                return QString::number(mel.getRank());
            }
            if (c == 4) {
                int rank_count = 0;
                int rank_curr = mel.getRank();
                for (const auto& m : v) {
                    if (m.getRank() == rank_curr)
                        rank_count++;
                }
                return QString::number(rank_count);
            }
        }
        return QVariant{};
    }
};

