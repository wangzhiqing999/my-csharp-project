using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MyBallot.Model;


namespace MyBallot.Config
{

    /// <summary>
    /// 投票主表 配置
    /// </summary>
    class BallotMasterConfig : EntityTypeConfiguration<BallotMaster>
    {

        public BallotMasterConfig()
        {

            // 一个 投票主表  允许有多个 投票明细.
            this.HasMany(s => s.BallotDetailList)
                // 一个 投票明细 必须 归属于一个 投票主表.
                .WithRequired(m => m.BallotMasterData)
                // 外键的列是  BallotMasterID
                .HasForeignKey(m => m.BallotMasterID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票主表 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);


            // 一个 投票主表  允许有多个 用户投票.
            this.HasMany(s => s.UserBallotList)
                // 一个 用户投票 必须 归属于一个 投票主表.
                .WithRequired(m => m.BallotMasterData)
                // 外键的列是  BallotMasterID
                .HasForeignKey(m => m.BallotMasterID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票主表 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);

        }

    }
}
