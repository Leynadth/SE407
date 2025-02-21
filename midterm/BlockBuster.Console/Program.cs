using System;
using Bookstore.Models;
using Microsoft.EntityFrameworkCore.Design;


namespace Bookstore.ConsoleApp
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// ConsoleUtils.ListBooks(BasicFunctions.GetAllBooks());
			// ConsoleUtils.ListObjects(BasicFunctions.GetAllBooks());
			ConsoleUtils.WriteBooksToCsv(BasicFunctions.GetAllBooks());
		}
	}
}

