using System.IO;
using System.Windows.Forms;

namespace Beeant.Tool.Generator
{
    public class GeneratorBase
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual DataGridView DataGridView { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string EntityName { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string EntityNickname { get; set; }
        /// <summary>
        /// 实体名称
        /// </summary>
        public virtual string Module { get; set; }
        /// <summary>
        /// 生成代码
        /// </summary>
        public virtual void Generate()
        {
            
        }
        /// <summary>
        /// 得到根目录
        /// </summary>
        /// <returns></returns>
        protected virtual string GetRootPath()
        {
            var tag = @"\Codes\";
            var path = Directory.GetCurrentDirectory();
            var index = path.IndexOf(tag);
            if (index == -1)
                return null;
            return path.Substring(0, index + tag.Length);
        }
      
    }
}
