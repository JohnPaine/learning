#include <stdio.h>
#include <iostream>

bool binary_search(const string A[], int n, string name, int &count){
   count = 0;                  // Count initialization
   int fst = 0;
   int lst = n+1;              // First, Last and Middle array elements
   int mid = 0;

   while(fst<=lst) {
      count++;

      mid = (fst+lst)/2;      // Calculate mid point of array
      if (A[mid]==name)       // If value is found at mid
      {
         return true;
      }
      else if (A[mid]>name)
      {                       // if value is in lower
         lst = mid++;
         //cout << "elseIfME!" << endl;
      }
      else if (A[mid]<name)
      {                       // if value is in higher
         fst = mid--;
         //cout << "elseME!" << endl;
      }
   }
   return false;
}

int main() {
	

	return 0;
}