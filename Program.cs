// See https://aka.ms/new-console-template for more information
using Algorithm.search;

Console.WriteLine("Hello, World!");


int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};

OrderSearch orderSearch = new OrderSearch();
Console.WriteLine(orderSearch.HalfSearch(arr, 2));
Console.WriteLine(orderSearch.InterpolationSearch(arr, 2));
Console.WriteLine(orderSearch.FbiSearch(arr, 2));
