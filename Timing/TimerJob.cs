using System.ComponentModel.DataAnnotations;

namespace Timing
{
    public class TimerJob
    {
        public int Id { get; set; }

        /// <summary>
        /// 周期
        /// 单位：秒
        /// </summary>
        public int Period { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(128)]
        public string TypeName { get; set; }

        [StringLength(128)]
        public string MethodName { get; set; }
    }
}