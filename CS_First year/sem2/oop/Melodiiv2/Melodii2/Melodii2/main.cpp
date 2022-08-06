#include <qapplication.h>
#include "Service.h"
#include "GUI.h"

int main(int argc, char *argv[])
{
    QApplication a(argc, argv);
    Repository repo{ "date.txt" };
    Service serv{ repo };
    GUI gui{ serv };
    gui.show();
    a.exec();
}
