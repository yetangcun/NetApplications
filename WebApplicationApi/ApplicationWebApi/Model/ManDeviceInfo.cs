using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationWebApi.Model
{
    [Table("man_device_info")]
    public class man_device_info
    {
        /// <summary>
        /// 设备编号，自动生成，为型号+NOCode
        /// </summary>
        [Required]
        [MaxLength(64)]
        public virtual string NO { get; set; }

        /// <summary>
        /// 设备编号序列号，自动生成，4位序列号,不可重复
        /// </summary>
        [Required]
        public virtual int NOCode { get; set; }

        /// <summary>
        /// 设备对接平台的ID
        /// </summary>
        [MaxLength(36)]
        public virtual string CloudId { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public virtual long ProjectId { get; set; }
        /// <summary>
        /// 设备名称
        /// </summary>
        [Required]
        [MaxLength(256)]
        public virtual string Name { get; set; }
        /// <summary>
        /// 父设备ID
        /// </summary>
        [Required]
        public virtual long ParentId { get; set; }
        /// <summary>
        /// 管理机IP
        /// </summary>
        [MaxLength(32)]
        public virtual string MasterIp { get; set; }
        /// <summary>
        /// 设备IP
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string IP { get; set; }

        [MaxLength(11)]
        public virtual int Port { get; set; }

        /// <summary>
        /// 设备MAC
        /// </summary>
        [Required]
        [MaxLength(32)]
        public virtual string MAC { get; set; }
        /// <summary>
        /// 子网掩码
        /// </summary>
        [MaxLength(32)]
        public virtual string NetMask { get; set; }
        /// <summary>
        /// 设备网关
        /// </summary>
        [MaxLength(32)]
        public virtual string GatewayIP { get; set; }

        [MaxLength(64)]
        public virtual string SN { get; set; }

        /// <summary>
        /// 设备CPUID
        /// </summary>
        [MaxLength(64)]
        public virtual string CpuID { get; set; }

        [MaxLength(256)]
        public virtual string Remark { get; set; }

        public bool IsDeleted { get; set; }
    }
}
