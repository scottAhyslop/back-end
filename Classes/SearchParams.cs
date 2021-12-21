using System;

namespace back_end.Classes
{
    public class SearchParams
    {
        const int maxSize = 100;
        private int _size = 50;

        public int Page { get; set; }
        public int Size
        {
            get { return _size; }
            set
            {
                _size = Math.Min(maxSize, value);
            }
        }
        public string SortBy { get; set; } = "DeviceId";
        private string _sortOrder = "asc";
        public string SortOrder
        {
            get { return _sortOrder; }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }
        public string SearchTerm { get; set; }

    }//end SearchParams class
}//end namespace
