#include "Activitati.h"
#include "Console.h"
#include "Domain.h"
#include "Repository.h"
#include "RepoFile.h"
#include "Activitati.h"
#include "Service.h"
#include "Validator.h"
#include "RepoFile.h"
#include "LabRepo.h"
#define _CRTDBG_MAP_ALLOC

void test_all()
{
	//testrepofile();
	test_repo_plan();
	test_domain();
	test_repository();
	test_service();
	test_validator();
}

int main()
{
	{
		//test_all();
		RepoFile repo{ "date.txt" };
		ActValidator valid;
		PlanRepo lista;
		Service serv(repo, valid, lista);
		Console ui(serv);
		ui.start();
	}
	_CrtDumpMemoryLeaks();
	return 0;
}