#pragma once

#include <QtWidgets/QMainWindow>
#include "ui_GUI_LAB.h"

class GUI_LAB : public QMainWindow
{
    Q_OBJECT

public:
    GUI_LAB(QWidget *parent = Q_NULLPTR);

private:
    Ui::GUI_LABClass ui;
};
