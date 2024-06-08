namespace BuildingBlocks.Pagination
{
    public class PaginatedResult<TEntity>
        (int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        where TEntity : class
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; } = data;
    }
}
