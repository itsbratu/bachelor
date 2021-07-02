#include "Service.h"
#include <algorithm>

const vector<Melodie> Service::sort_rank() noexcept
{
	vector<Melodie> all_;
	all_ = get_all();

	std::sort(all_.begin(), all_.end(), [](const Melodie&a, const Melodie& b)->bool
		{
			return a.getRank() < b.getRank();
		});
	return all_;
}

void Service::del(int id)
{
	repo.del(id);
}

void Service::mod(const Melodie& m)
{
	repo.mod(m);
}
