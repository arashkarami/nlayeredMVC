using System;

namespace Arash.Utility.Common
{
    public class PagingInfo
    {
        public int PageIndex
        {
            get;
            private set;
        }

        public int PageSize
        {
            get;
            private set;
        }

        public int ItemCount
        {
            get;
            private set;
        }

        public int StartIndex
        {
            get;
            private set;
        }

        public int TotalPages
        {
            get;
            private set;
        }

        public bool IsPageIndexValid
        {
            get
            {
                if (TotalPages != 0)
                {
                    if (PageIndex < 1 || PageIndex > TotalPages)
                        return false;
                }
                else
                {
                    if (PageIndex != 1)
                        return false;
                }

                return true;
            }
        }

        public PagingInfo(int pageIndex, int pageSize, int itemCount)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            ItemCount = itemCount;
            StartIndex = (pageIndex - 1) * pageSize;
            TotalPages = (int)Math.Ceiling(itemCount / (double)pageSize);
        }
    }
}