namespace Winner.Persistence
{
    public enum CacheType
    {
        /// <summary>
        /// 无
        /// </summary>
        None = 1,
        /// <summary>
        /// 本地
        /// </summary>
        Local =2,
        /// <summary>
        /// 本地和远程
        /// </summary>
        LocalAndRemote=4,
        /// <summary>
        /// 远程
        /// </summary>
        Remote=8

    }
}
