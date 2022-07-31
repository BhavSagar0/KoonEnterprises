using System;
using System.Collections.Generic;
using System.Text;

namespace Koon.Models.Employees
{
    public class Pager
    {
        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPage { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }

        public Pager()
        {

        }
        public Pager(int totalItems, int page, int pageSize = 3)
        {
            int totalPage = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);

            int currentPage = page;

            int startPage = currentPage - 5;
            int endPage = currentPage + 4;
            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;

            }

            if (endPage > totalPage)
            {
                endPage = totalPage;
                if (endPage >= 10)

                {
                    startPage = endPage - 9;
                }

            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            StartPage = startPage;
            EndPage = endPage;
            TotalPage = totalPage;
            PageSize = pageSize;
        }





    }
}

