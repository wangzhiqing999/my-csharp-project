﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.Entity.ModelConfiguration;

using MyBallot.Model;



namespace MyBallot.Config
{

    /// <summary>
    /// 投票明细 配置
    /// </summary>
    class BallotDetailConfig : EntityTypeConfiguration<BallotDetail>
    {


        public BallotDetailConfig()
        {

            // 一个 投票明细  允许有多个 用户投票.
            this.HasMany(s => s.UserBallotList)
                // 一个 用户投票 必须 归属于一个 投票明细.
                .WithRequired(m => m.BallotDetailData)
                // 外键的列是  BallotDetailID
                .HasForeignKey(m => m.BallotDetailID)
                // 取消 外键的 ON DELETE CASCADE 
                // (因为删除 投票明细 的操作极少. 需要避免误操作)
                .WillCascadeOnDelete(false);
        }
    }


}
