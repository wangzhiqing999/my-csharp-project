using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using MyExamination.Model;


namespace MyExamination.ServiceModel
{
    
    
    public class MeQuestionAnswerReport
    {


        /// <summary>
        /// 问题流水号.
        /// </summary>        
        [Column("question_id")]
        [Display(Name = "问题流水号")]
        public long QuestionID { set; get; }


        /// <summary>
        /// 问题类型.
        /// </summary>        
        [Column("question_type")]
        [Display(Name = "问题类型")]
        [Required]
        public MeQuestionType QuestionType { set; get; }


        /// <summary>
        /// 问题描述
        /// </summary>        
        [Column("question_text")]
        [Display(Name = "问题描述")]
        [StringLength(1024)]
        public string QuestionText { set; get; }


        /// <summary>
        /// 题目的显示顺序（排序）
        /// </summary>        
        [Column("display_order")]
        [Display(Name = "题目的显示顺序（排序）")]
        public int DisplayOrder { set; get; }


        /// <summary>
        /// 问题选项流水号.
        /// </summary>        
        [Column("question_option_id")]
        [Display(Name = "问题选项流水号")]
        public long QuestionOptionID { set; get; }


        /// <summary>
        /// 问题选项描述
        /// </summary>        
        [Column("question_option_text")]
        [Display(Name = "问题选项描述")]
        [StringLength(1024)]
        public string QuestionOptionText { set; get; }




        /// <summary>
        /// 用户回答数.
        /// </summary>        
        [Column("user_answer_count")]
        [Display(Name = "用户回答数")]
        public int UserAnswerCount { set; get; }



    }

}
