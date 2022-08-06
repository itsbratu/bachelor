#include "Service.h"

void Service::add(const Melodie& m)
{
	repo.add(m);
}

void Service::del(const int id)
{
	repo.del(id);
}
