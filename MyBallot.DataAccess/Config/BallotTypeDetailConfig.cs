using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;

using MyBallot.Model;


namespace MyBallot.Config
{


    /// <summary>
    /// 投票类型明细
    /// </summary>
    class BallotTypeDetailConfig : EntityTypeConfiguration<BallotTypeDetail>
    {

        public BallotTypeDetailConfig()
        {
            // 一个 投票类型明细  允许有多个 投票明细.
            this.HasMany(s => s.BallotDetailList)
                // 一个 投票明细 必须 归属于一个 投票类型明细.
                .WithRequired(m => m.BallotTypeDetailData)
                // 外键的列是  BallotTypeDetailCode
                .HasForeignKey(m => m.BallotTypeDetailCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票主表 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }

    }
}
