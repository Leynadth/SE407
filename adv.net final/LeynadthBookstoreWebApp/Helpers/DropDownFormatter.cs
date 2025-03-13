using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using LeynadthBookstore;

namespace LeynadthBookstoreWebApp.Helpers
{
	public class DropDownFormatter
	{
		public static SelectList FormatAuthors()
		{
			return new SelectList(BasicFunctions.GetAllAuthors()
				.OrderBy(a => a.AuthorLast)
				.ToDictionary(a => a.AuthorId, a => a.AuthorLast + ", " + a.AuthorFirst), "Key", "Value");
		}

		public static SelectList FormatGenre()
		{
			return new SelectList(BasicFunctions.GetAllGenres()
				.OrderBy(g => g.GenreType)
				.ToDictionary(g => g.GenreId, g => g.GenreType), "Key", "Value");

		}




		}


}
