namespace GamingProject.Model
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// 
        /// </summary>
        public List<T> Items { get; }
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalPages { get; }
        /// <summary>
        /// 
        /// </summary>
        public bool HasPreviousPage => PageIndex > 1;
        /// <summary>
        /// 
        /// </summary>
        public bool HasNextPage => PageIndex < TotalPages;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="items"></param>
        /// <param name="pageIndex"></param>
        /// <param name="totalPages"></param>
        public PaginatedList(List<T> items, int pageIndex, int totalPages)
        {
            Items = items;
            PageIndex = pageIndex;
            TotalPages = totalPages;
        }
    }
}
