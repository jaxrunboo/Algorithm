// See https://aka.ms/new-console-template for more information
using Algorithm.search;

Console.WriteLine("Hello, World!");


int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

int[] arr1 = { 2, 5, 7, 1, 1, 4567, 3, 56, 123, 7 };

//OrderSearch orderSearch = new OrderSearch();
//Console.WriteLine(orderSearch.HalfSearch(arr, 2));
//Console.WriteLine(orderSearch.InterpolationSearch(arr, 2));
//Console.WriteLine(orderSearch.FbiSearch(arr, 2));

Sort sort = new Sort();
sort.EasySelectSort(arr1);