using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace MyUpdateLog.Model
{

    /// <summary>
    /// 更新项目.
    /// </summary>
    public class UpdateItem
    {

        /// <summary>
        /// 项目名.
        /// </summary>
        [Display(Name = "项目名")]
        public string ItemName { set; get; }


        /// <summary>
        /// 更新前,
        /// </summary>
        [Display(Name = "更新前")]
        public string BeforeValue { set; get; }


        /// <summary>
        /// 更新后.
        /// </summary>
        [Display(Name = "更新后")]
        public string AftertValue { set; get; }


    }
}
