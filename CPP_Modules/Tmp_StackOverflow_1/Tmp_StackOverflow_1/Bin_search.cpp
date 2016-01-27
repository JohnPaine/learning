#include "stdafx.h"
#include <cstdlib>
#include <string>
#include <iostream>

bool binary_search(std::string A[], int n, std::string name, int &count) {
	count = 0;                  // Count initialization
	int fst = 0;
	int lst = n + 1;              // First, Last and Middle array elements
	int mid = 0;
	//std::qsort(A, n, sizeof *A, [](const std::string* a, const std::string* b) { return 1; });

	while (fst <= lst) {
		count++;

		mid = (fst + lst) / 2;      // Calculate mid point of array
		if (A[mid] == name)       // If value is found at mid
		{
			return true;
		}
		else if (A[mid]>name)
		{                       // if value is in lower
			lst = mid - 1;
			//cout << "elseIfME!" << endl;
		}
		else if (A[mid]<name)
		{                       // if value is in higher
			fst = mid + 1;
			//cout << "elseME!" << endl;
		}
	}
	return false;
}

int test_binSearch()
{
	std::string names[] = { "Masha", "Dasha", "Vasya", "Petya", "Alyouna", "Bob", "Sergun", "00104", "32f3AA", "__Lapusik", "4r3frt", "2fr5r4rgtyw24ef", "df0023ff" };
	const std::string name = "Alyuna";
	int count = 0;

	std::cout << name.c_str() << (binary_search(names, size(names), name, count) ? " was found for " : " was NOT found") << " for count = " << count << std::endl;

	return 0;
}