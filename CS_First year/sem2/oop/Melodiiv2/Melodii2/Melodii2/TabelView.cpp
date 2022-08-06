#include "TabelView.h"

void MyTabelModel::update(vector<Melodie> vec)
{
	beginResetModel();

	this->v = vec;

	QModelIndex start = createIndex(0, 0);

	QModelIndex end = createIndex(rowCount(), columnCount());

	emit dataChanged(start, end);

	endResetModel();

}
