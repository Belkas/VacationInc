using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Exceptions
{
    public class ConflictingOrderException : Exception
    {
        public ConflictingOrderException(IEnumerable<int> itemsIds)
           : base($"conflicting with orders ID: {string.Join(", ", itemsIds.Select(x => x.ToString()))}")
        {
        }
    }
}
