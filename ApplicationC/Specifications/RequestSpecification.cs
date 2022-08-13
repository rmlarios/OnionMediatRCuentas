using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationC.Specifications
{
    public class RequestSpecification
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public RequestSpecification()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public RequestSpecification(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
