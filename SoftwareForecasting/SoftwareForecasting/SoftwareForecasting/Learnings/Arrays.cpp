#include <iostream>
#include "Arrays.h"
#include <string>

using namespace std;

void Arrays::Example1()
{
	int arr1[5] = { 1, 2, 3, 4, 5 };
	int arr2[] = { 10, 20, 30, 40, 50 };
	int i;
	cout << "Array arr1 contains:\n";
	for (i = 0; i < 5; i++)
	{
		cout << arr1[i] << "\t";
	}
	cout << "\n\n";
	cout << "Array arr2 contains:\n";
	for (i = 0; i < 5; i++)
	{
		cout << arr2[i] << "\t";
	}

}

void Arrays::Example2()
{
	int arr[10];
	int i;
	cout << "Enter 10 array elements: ";
	for (i = 0; i < 10; i++)
	{
		cin >> arr[i];
	}
	cout << "\nArray contains:\n";
	for (i = 0; i < 10; i++)
	{
		cout << arr[i] << "  ";
	}
}

void Arrays::Example3()
{
	int arr[10];
	int i;
	int sum = 0, avg = 0;
	cout << "Enter 10 array elements: ";
	for (i = 0; i < 10; i++)
	{
		cin >> arr[i];
		sum = sum + arr[i];
	}
	cout << "\nThe array elements are: \n";
	for (i = 0; i < 10; i++)
	{
		cout << arr[i] << "  ";
	}
	cout << "\n\nSum of all elements is: " << sum;
	avg = sum / 10;
	cout << "\nAnd average is: " << avg;
}

void Arrays::Example4()
{
	int arr[5][2] = { {1, 2}, {1, 3}, {1, 4}, {1, 5}, {1, 6} };
	int i, j;
	for (i = 0; i < 5; i++)
	{
		for (j = 0; j < 2; j++)
		{
			cout << "arr[" << i << "][" << j << "] = " << arr[i][j] << "\n";
		}
	}
}

void Arrays::Example5()
{
	int arr[5][2];
	int i, j;
	int sum = 0, avg = 0;

	cout << "Enter 5*2 array elements: ";
	for (i = 0; i < 5; i++)
	{
		for (j = 0; j < 2; j++)
		{
			cin >> arr[i][j];
			sum = sum + arr[i][j];
		}
	}
	cout << "\nThe array elements are: \n";
	for (i = 0; i < 5; i++)
	{
		for (j = 0; j < 2; j++)
		{
			cout << arr[i][j] << "   ";
		}
		cout << "\n";
	}
	cout << "\n\nSum of all elements is: " << sum;
	avg = sum / 10;
	cout << "\nAnd average is: " << avg;
}

void Arrays::LinearSearch()
{
	int arr[10], i, num, n, c = 0, pos;
	cout << "Enter the array size : ";
	cin >> n;
	cout << "Enter Array Elements : ";
	for (i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "Enter the number to be search : ";
	cin >> num;
	for (i = 0; i < n; i++)
	{
		if (arr[i] == num)
		{
			c = 1;
			pos = i + 1;
			break;
		}
	}
	if (c == 0)
	{
		cout << "Number not found..!!";
	}
	else
	{
		cout << num << " found at position " << pos;
	}
}

void Arrays::BinarySearch()
{
	int n, i, arr[50], search, first, last, middle;
	cout << "Enter total number of elements :";
	cin >> n;
	cout << "Enter " << n << " number :";
	for (i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "Enter a number to find :";
	cin >> search;
	first = 0;
	last = n - 1;
	middle = (first + last) / 2;
	while (first <= last)
	{
		if (arr[middle] < search)
		{
			first = middle + 1;

		}
		else if (arr[middle] == search)
		{
			cout << search << " found at location " << middle + 1 << "\n";
			break;
		}
		else
		{
			last = middle - 1;
		}
		middle = (first + last) / 2;
	}
	if (first > last)
	{
		cout << "Not found! " << search << " is not present in the list.";
	}
}

void Arrays::LargestElement()
{
	int large, arr[50], size, i;
	cout << "Enter Array Size (max 50) : ";
	cin >> size;
	cout << "Enter array elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	cout << "Searching for largest number ...\n\n";
	large = arr[0];
	for (i = 0; i < size; i++)
	{
		if (large < arr[i])
		{
			large = arr[i];
		}
	}
	cout << "Largest Number = " << large;
}

void Arrays::SmallestElement()
{
	int small, arr[50], size, i;
	cout << "Enter Array Size (max 50) : ";
	cin >> size;
	cout << "Enter array elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	cout << "Searching for smallest element ...\n\n";
	small = arr[0];
	for (i = 0; i < size; i++)
	{
		if (small > arr[i])
		{
			small = arr[i];
		}
	}
	cout << "Smallest Element = " << small;
}

void Arrays::ReverseArray()
{
	int arr[50], size, i, j, temp;
	cout << "Enter array size : ";
	cin >> size;
	cout << "Enter array elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	j = i - 1;  // now j will point to the last element
	i = 0;   //  and i will be point to the first element
	while (i < j)
	{
		temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
		i++;
		j--;
	}
	cout << "Now the Reverse of the Array is : \n";
	for (i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
}

void Arrays::InsertElement()
{
	int arr[50], size, insert, i, pos;
	cout << "Enter Array Size : ";
	cin >> size;
	cout << "Enter array elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	cout << "Enter element to be insert : ";
	cin >> insert;
	cout << "At which position (Enter index number) ? ";
	cin >> pos;
	// now create a space at the required position
	for (i = size; i > pos; i--)
	{
		arr[i] = arr[i - 1];
	}
	arr[pos] = insert;
	cout << "Element inserted successfully..!!\n";
	cout << "Now the new array is : \n";
	for (i = 0; i < size + 1; i++)
	{
		cout << arr[i] << " ";
	}
}

void Arrays::DeleteElement() 
{
	int arr[50], size, i, del, count = 0;
	cout << "Enter array size : ";
	cin >> size;
	cout << "Enter array elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	cout << "Enter element to be delete : ";
	cin >> del;
	for (i = 0; i < size; i++)
	{
		if (arr[i] == del)
		{
			for (int j = i; j < (size - 1); j++)
			{
				arr[j] = arr[j + 1];
			}
			count++;
			break;
		}
	}
	if (count == 0)
	{
		cout << "Element not found..!!";
	}
	else
	{
		cout << "Element deleted successfully..!!\n";
		cout << "Now the new array is :\n";
		for (i = 0; i < (size - 1); i++)
		{
			cout << arr[i] << " ";
		}
	}
}

void Arrays::MergeTwoArrays()
{
	int arr1[50], arr2[50], size1, size2, size, i, j, k, merge[100];
	cout << "Enter Array 1 Size : ";
	cin >> size1;
	cout << "Enter Array 1 Elements : ";
	for (i = 0; i < size1; i++)
	{
		cin >> arr1[i];
	}
	cout << "Enter Array 2 Size : ";
	cin >> size2;
	cout << "Enter Array 2 Elements : ";
	for (i = 0; i < size2; i++)
	{
		cin >> arr2[i];
	}
	for (i = 0; i < size1; i++)
	{
		merge[i] = arr1[i];
	}
	size = size1 + size2;
	for (i = 0, k = size1; k < size && i < size2; i++, k++)
	{
		merge[k] = arr2[i];
	}
	cout << "Now the new array after merging is :\n";
	for (i = 0; i < size; i++)
	{
		cout << merge[i] << " ";
	}
}

void Arrays::BubbleSort()
{
	int n, i, arr[50], j, temp;
	cout << "Enter total number of elements :";
	cin >> n;
	cout << "Enter " << n << " numbers :";
	for (i = 0; i < n; i++)
	{
		cin >> arr[i];
	}
	cout << "Sorting array using bubble sort technique...\n";
	for (i = 0; i < (n - 1); i++)
	{
		for (j = 0; j < (n - i - 1); j++)
		{
			if (arr[j] > arr[j + 1])
			{
				temp = arr[j];
				arr[j] = arr[j + 1];
				arr[j + 1] = temp;
			}
		}
	}
	cout << "Elements sorted successfully..!!\n";
	cout << "Sorted list in ascending order :\n";
	for (i = 0; i < n; i++)
	{
		cout << arr[i] << " ";
	}
}

void Arrays::SelectionSort()
{
	int size, arr[50], i, j, temp, index, small, count = 0;
	cout << "Enter Array Size : ";
	cin >> size;
	cout << "Enter Array Elements : ";
	for (i = 0; i < size; i++)
		cin >> arr[i];
	cout << "Sorting array using selection sort...\n";
	for (i = 0; i < (size - 1); i++)
	{
		small = arr[i];
		for (j = (i + 1); j < size; j++)
		{
			if (small > arr[j])
			{
				small = arr[j];
				count++;
				index = j;
			}
		}
		if (count != 0)
		{
			temp = arr[i];
			arr[i] = small;
			arr[index] = temp;
		}
		count = 0;
	}
	cout << "Now the Array after sorting is :\n";
	for (i = 0; i < size; i++)
		cout << arr[i] << " ";
}

void Arrays::InsertionSort()
{
	int size, arr[50], i, j, temp;
	cout << "Enter Array Size : ";
	cin >> size;
	cout << "Enter Array Elements : ";
	for (i = 0; i < size; i++)
	{
		cin >> arr[i];
	}
	cout << "Sorting array using selection sort ... \n";
	for (i = 1; i < size; i++)
	{
		temp = arr[i];
		j = i - 1;
		while ((temp < arr[j]) && (j >= 0))
		{
			arr[j + 1] = arr[j];
			j = j - 1;
		}
		arr[j + 1] = temp;
	}
	cout << "Array after sorting : \n";
	for (i = 0; i < size; i++)
	{
		cout << arr[i] << " ";
	}
}

void Arrays::AddTwoMatrices()
{
	int mat1[3][3], mat2[3][3], i, j, mat3[3][3];
	cout << "Enter matrix 1 elements :";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> mat1[i][j];
		}
	}
	cout << "Enter matrix 2 elements :";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> mat2[i][j];
		}
	}
	cout << "Adding the two matrix to form the third matrix .....\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			mat3[i][j] = mat1[i][j] + mat2[i][j];
		}
	}
	cout << "The two matrix added successfully...!!";
	cout << "The new matrix will be :\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cout << mat3[i][j] << " ";
		}
		cout << "\n";
	}
}

void Arrays::SubtractTwoMatrices()
{
	int arr1[3][3], arr2[3][3], arr3[3][3], sub, i, j;
	cout << "Enter 3*3 Array 1 Elements : ";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> arr1[i][j];
		}
	}
	cout << "Enter 3*3 Array 2 Elements : ";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> arr2[i][j];
		}
	}
	cout << "Subtracting array (array1-array2) ... \n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			arr3[i][j] = arr1[i][j] - arr2[i][j];
		}
	}
	cout << "Result of Array1 - Array2 is :\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cout << arr3[i][j] << " ";
		}
		cout << "\n";
	}
}

void Arrays::TransposeMatrix()
{
	int arr[3][3], i, j, arrt[3][3];
	cout << "Enter 3*3 Array Elements : ";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> arr[i][j];
		}
	}
	cout << "Transposing Array...\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			arrt[i][j] = arr[j][i];
		}
	}
	cout << "Transpose of the Matrix is :\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cout << arrt[i][j];
		}
		cout << "\n";
	}
}

void Arrays::MultiplyTwoMatrices()
{
	int mat1[3][3], mat2[3][3], mat3[3][3], sum = 0, i, j, k;
	cout << "Enter first matrix element (3*3) : ";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> mat1[i][j];
		}
	}
	cout << "Enter second matrix element (3*3) : ";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cin >> mat2[i][j];
		}
	}
	cout << "Multiplying two matrices...\n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			sum = 0;
			for (k = 0; k < 3; k++)
			{
				sum = sum + mat1[i][k] * mat2[k][j];
			}
			mat3[i][j] = sum;
		}
	}
	cout << "\nMultiplication of two Matrices : \n";
	for (i = 0; i < 3; i++)
	{
		for (j = 0; j < 3; j++)
		{
			cout << mat3[i][j] << " ";
		}
		cout << "\n";
	}
}

void Arrays::ThreeDimensionalArray()
{
	int arr[3][4][2] = {
				  {
				 {2, 4},
				 {7, 8},
				 {3, 4},
				 {5, 6}
				  },
				  {
				 {7, 6},
				 {3, 4},
				 {5, 3},
				 {2, 3}
				  },
				  {
				 {8, 9},
				 {7, 2},
				 {3, 4},
				 {5, 1}
				  }
	};
	cout << "arr[0][0][0] = " << arr[0][0][0] << "\n";
	cout << "arr[0][2][1] = " << arr[0][2][1] << "\n";
	cout << "arr[2][3][1] = " << arr[2][3][1] << "\n";
}