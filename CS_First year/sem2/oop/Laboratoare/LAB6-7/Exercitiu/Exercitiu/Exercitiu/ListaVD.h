#pragma once

template <class T>
class ListVD {

	class iterator
	{
	public:
		typedef iterator self_type;
		typedef T value_type;
		typedef T& reference;
		typedef T* pointer;
		typedef std::forward_iterator_tag iterator_category;
		typedef int difference_type;
		iterator(pointer ptr) : ptr_(ptr) { }
		self_type operator++() { self_type i = *this; ptr_++; return i; }
		self_type operator++(int junk) { ptr_++; return *this; }
		reference operator*() { return *ptr_; }
		pointer operator->() { return ptr_; }
		bool operator==(const self_type& rhs) { return ptr_ == rhs.ptr_; }
		bool operator!=(const self_type& rhs) { return ptr_ != rhs.ptr_; }
	private:
		pointer ptr_;
	};

private:
	int cap;
	int lg;
	T* elems;
public:

	int size() const {
		return lg;
	}

	//constructor default pentru vector dinamic
	ListVD() : cap{ 1 }, lg{ 0 }, elems{ new Activity[cap] }{

	}

	//constructor copiere
	ListVD(const ListVD& ot) : cap{ ot.cap }, lg{ ot.lg }, elems{ new Activity[ot.lg] }{
		for (int i = 0; i < ot.lg; ++i)
			elems[i] = ot.elems[i];
	}

	//operator assignment
	void operator =(const ListVD& ot) {
		delete[] elems;
		elems = new Activity[ot.lg];
		lg = ot.lg;
		cap = ot.cap;

		for (int i = 0; i < lg; ++i)
			elems[i] = ot.elems[i];
	}

	//destructor
	~ListVD() {
		delete[] elems;
	}

	ListVD(std::vector <T> acts)
	{
		for (const auto& a : acts)
			push_back(a);
	}

	std::vector<T> toStdVector() const
	{
		std::vector<T> rez;
		for (int i = 0; i < lg; ++i)
			rez.push_back(elems[i]);
		return rez;
	}

	//Aduagare vector dinamic
	void push_back(const T& a) {
		if (cap == lg) {
			T* aux = new T[cap * 2];

			for (int i = 0; i < lg; ++i)
			{
				aux[i] = elems[i];
			}
			delete[] elems;
			elems = aux;
			cap = cap * 2;
		}
		elems[lg++] = a;
	}

	iterator begin() const { return iterator(&elems[0]); }

	iterator end() const { return iterator(&elems[lg]); }

	T back() const {
		return elems[lg - 1];
	}

	void pop_back() {
		lg--;
	}

	T operator [](size_t i) const { return elems[i]; }

	T& operator [](size_t i) { return elems[i]; }
};