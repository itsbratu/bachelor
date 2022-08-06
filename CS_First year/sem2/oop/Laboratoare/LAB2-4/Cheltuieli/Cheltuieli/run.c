/*C FILE from where we store our app
*/

#define _CRTDBG_MAP_ALLOC
#include <stdlib.h>
#include <crtdbg.h> 
#include "ui.h"
#include <stdio.h>

int main()
{
	int choice = get_choice();
	_CrtDumpMemoryLeaks();
	return 0;
}