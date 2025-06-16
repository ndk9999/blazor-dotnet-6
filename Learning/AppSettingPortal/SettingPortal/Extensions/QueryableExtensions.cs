using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SettingPortal.Models;

namespace SettingPortal.Extensions;

public static class QueryableExtensions
{
	public static IQueryable<T> WhereIf<T>(
		this IQueryable<T> source, bool condition, Expression<Func<T, bool>> predicate)
	{
		return condition ? source.Where(predicate) : source;
	}


	public static async Task<PagedList<T>> ToPagedListAsync<T>(
		this IQueryable<T> source, int pageNumber, int pageSize,
		CancellationToken cancellationToken = default)
	{
		var totalRecords = await source.CountAsync(cancellationToken);

		var items = await source
			.Skip((pageNumber - 1) * pageSize)
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		return new PagedList<T>(items, pageNumber, pageSize, totalRecords);
	}
}