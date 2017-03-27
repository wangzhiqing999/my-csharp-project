﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MyFramework.Model
{
    public abstract class AbstractCommonData
    {


        /// <summary>
        /// 状态
        /// </summary>
        [Column("status")]
        [Display(Name = "状态")]
        [StringLength(16)]
        public string Status { set; get; }


        /// <summary>
        /// 状态是有效的.
        /// </summary>
        public const string STATUS_IS_ACTIVE = "ACTIVE";


        /// <summary>
        /// 状态是无效的.
        /// </summary>
        public const string STATUS_IS_INACTIVE = "INACTIVE";


        // ==================================================
        // 如果有其他的状态， 可以尝试在这里扩展.
        // ==================================================

        /// <summary>
        /// 状态是否有效.
        /// </summary>
        [NotMapped]
        [Display(Name = "数据有效")]
        [XmlIgnoreAttribute()]
        public virtual bool IsActive
        {
            set
            {
                this.Status = value ? STATUS_IS_ACTIVE : STATUS_IS_INACTIVE;
            }
            get
            {
                return this.Status == STATUS_IS_ACTIVE;
            }
        }











        /// <summary>
        /// 创建人
        /// </summary>
        [Column("create_user")]
        [Display(Name = "创建人")]
        [StringLength(32)]
        [Editable(false)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[未设定]")]
        [XmlIgnoreAttribute()]
        public string CreateUser { set; get; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [Column("create_time")]
        [Display(Name = "创建时间")]
        [Editable(false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [XmlIgnoreAttribute()]
        public DateTime CreateTime { set; get; }




        /// <summary>
        /// 最后更新人
        /// </summary>
        [Column("last_update_user")]
        [Display(Name = "最后更新人")]
        [StringLength(32)]
        [Editable(false)]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[未设定]")]
        [XmlIgnoreAttribute()]
        public string LastUpdateUser { set; get; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        [Column("last_update_time")]
        [Display(Name = "最后更新时间")]
        [ConcurrencyCheck]
        [Editable(false)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [XmlIgnoreAttribute()]
        public DateTime LastUpdateTime { set; get; }





        /// <summary>
        /// 在数据插入之前的操作.
        /// </summary>
        public virtual void BeforeInsertOperation(string userName = "system")
        {
            if (String.IsNullOrEmpty(this.CreateUser)) {

                // 插入人.
                this.CreateUser = userName;
                // 插入时间.
                this.CreateTime = DateTime.Now;


                // 更新人.
                this.LastUpdateUser = userName;
                // 最后更新时间.
                this.LastUpdateTime = DateTime.Now;
            }            
        }


        /// <summary>
        /// 在数据更新之前的操作.
        /// </summary>
        public virtual void BeforeUpdateOperation(string userName = "system")
        {
            // 更新人.
            this.LastUpdateUser = userName;
            // 最后更新时间.
            this.LastUpdateTime = DateTime.Now;
        }

    }
}
