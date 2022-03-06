﻿using Application.Exceptions;
using Shared.Wrappers;
using System.Collections.Generic;
using System.Linq;

namespace Application.Extensions
{
    public static class QueryableExtensions
    {
        public static PaginatedResult<T> ToPaginatedList<T>(this List<T> source, int pageNumber, int pageSize) where T : class
        {
            if (source == null) throw new AppException();
            pageNumber = pageNumber == 0 ? 1 : pageNumber;
            pageSize = pageSize == 0 ? 10 : pageSize;
            int count = source.Count;
            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            List<T> items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return PaginatedResult<T>.Success(items, count, pageNumber, pageSize);
        }
    }
}
