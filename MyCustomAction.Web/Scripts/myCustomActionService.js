"use strict";


var myCustomActionService = {

    // 是否显示运行日志.
    isShowRunningLog: true,

    // 间隔.
    interval: 60,

    // 代码.
    id: 0,
    
    // 模块代码.
    moduleCode: "TEST",

    // 附加数据.
    expData: "",


    newAction: function () {
        if (this.isShowRunningLog) {
            console.log("newAction Start!", this.moduleCode, this.expData);
        }

        var _this = this;

        $.ajax({
            url: "/CustomAction/NewAction",
            type:"POST",
            data: {
                moduleCode: _this.moduleCode,
                expData: _this.expData
            },
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("newAction Result:", data);
                }
                _this.newActionSuccess(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },


    newActionSuccess: function (data) {
        if (data.Result != true) {
            // 处理失败
            return;
        }

        // 获取 ID.
        this.id = data.ResultData;

        setTimeout("myCustomActionService.continueAction()", this.interval * 1000);
    },


    continueAction: function () {
        if (this.isShowRunningLog) {
            console.log("continueAction Start!", this.id, this.moduleCode);
        }

        var _this = this;

        $.ajax({
            url: "/CustomAction/ContinueAction",
            type: "POST",
            data: {
                actionID: _this.id,
                moduleCode: _this.moduleCode                
            },
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("continueAction Result:", data);
                }
                _this.continueActionSuccess(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },


    continueActionSuccess: function (data) {
        if (data == true) {
            setTimeout("myCustomActionService.continueAction()", this.interval * 1000);
        }
    }



}