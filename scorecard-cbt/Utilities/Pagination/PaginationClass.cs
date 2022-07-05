using System;
using System.Collections.Generic;
using System.Linq;

namespace scorecard_cbt.Utilities.Pagination
{
    public class PaginationClass
    {
        public static PaginationModel<IEnumerable<TSource>> PaginationAsync<TSource>
                                (IEnumerable<TSource> queryable, int pageSize, int pageNumber)
        {
            var count = queryable.Count();
            var pageResult = new PaginationModel<IEnumerable<TSource>>
            {
                PageSize = (pageSize > 10 || pageSize < 1) ? 10 : pageSize,
                CurrentPage = pageNumber >= 1 ? pageNumber : 1,
                PreviousPage = pageNumber > 0 ? pageNumber - 1 : 0
            };
            pageResult.TotalNumberOfPages = (int)Math.Ceiling(count / (double)(pageResult.PageSize));
            var sourceList = queryable.Skip((pageResult.CurrentPage - 1) * pageResult.PageSize).Take(pageResult.PageSize).ToList();
            pageResult.PageItems = sourceList;
            return pageResult;
        }
    }
}
