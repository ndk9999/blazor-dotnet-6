namespace SettingPortal.Models;

public class PagedList<T>
{
	public int PageIndex => PageNumber - 1;

	public int PageNumber { get; }

	public int PageSize { get; set; }

	public int TotalPages { get; }

	public int TotalRecords { get; }

	public bool HasPreviousPage => PageNumber > 1;

	public bool HasNextPage => PageNumber < TotalPages;

	public IList<T> Records { get; }


	public PagedList(IList<T> items, int pageNumber, int pageSize, int totalRecords)
	{
		PageNumber = pageNumber;
		PageSize = pageSize;
		TotalRecords = totalRecords;
		TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);
		Records = items ?? new List<T>();
	}
}