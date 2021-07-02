#include "Activitati.h"
#include "Domain.h"
#include "Repository.h"
#include "RepoFile.h"
#include "Activitati.h"
#include "Service.h"
#include "Validator.h"
#include "RepoFile.h"
#include "LabRepo.h"
#include "ActivitateGUI.h"
#include "PlanGUI.h"
#include <qapplication.h>

void test_all()
{
	//testrepofile();
	test_repo_plan();
	test_domain();
	test_repository();
	test_service();
	test_validator();
}

int main(int argc, char* argv[])
{
	{
		//test_all();

		QApplication a(argc, argv);

		RepoFile repo{ "date.txt" };
		ActValidator valid;
		PlanRepo lista;
		Service serv(repo, valid, lista);

		ActivityGUI activities{ serv , lista };
		activities.show();

		GUIPlan plan{ serv , lista };
		plan.show();

		a.exec();
	}
	return 0;
}