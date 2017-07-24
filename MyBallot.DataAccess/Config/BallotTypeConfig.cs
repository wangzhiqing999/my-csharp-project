using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MyBallot.Model;



namespace MyBallot.Config
{

    /// <summary>
    /// 投票类型  配置
    /// </summary>
    class BallotTypeConfig : EntityTypeConfiguration<BallotType>
    {

        public BallotTypeConfig()
        {

            // 一个 投票类型  允许有多个 投票类型明细.
            this.HasMany(s => s.BallotTypeDetailList)
                // 一个 投票类型明细 必须 归属于一个 投票类型.
                .WithRequired(m => m.BallotTypeData)
                // 外键的列是  BallotTypeCode
                .HasForeignKey(m => m.BallotTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票类型 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);



            // 一个 投票类型  允许有多个 投票主表.
            this.HasMany(s => s.BallotMasterList)
                // 一个 投票主表 必须 归属于一个 投票类型.
                .WithRequired(m => m.BallotTypeData)
                // 外键的列是  BallotTypeCode
                .HasForeignKey(m => m.BallotTypeCode)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票类型 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }

    }


}
