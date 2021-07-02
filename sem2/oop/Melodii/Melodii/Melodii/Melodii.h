#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_Melodii.h"

class Melodii : public QMainWindow
{
    Q_OBJECT

public:
    Melodii(QWidget *parent = Q_NULLPTR);

private:
    Ui::MelodiiClass ui;
};
