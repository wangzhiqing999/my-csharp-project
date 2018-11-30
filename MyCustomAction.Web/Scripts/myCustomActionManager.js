"use strict";


var myCustomActionManager = {

    // 是否显示运行日志.
    isShowRunningLog: true,

    // 间隔.
    interval: 10,

    // 代码.
    id: null,

    // 最后访问时间.
    lastAccessTime: null,


    // 查询客户操作.
    queryCustomAction: function () {
        if (this.isShowRunningLog) {
            console.log("queryCustomAction Start!", this.id, this.lastAccessTime);
        }

        var _this = this;

        $.ajax({
            url: "/CustomAction/QueryCustomAction",
            type: "POST",
            data: {
                id: _this.id,
                fromTime: _this.lastAccessTime
            },
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("queryCustomAction Result:", data);
                }
                _this.showQueryCustomActionResult(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },


    // 显示查询客户操作结果.
    showQueryCustomActionResult: function (data) {
        
        var resultCount = data.length;

        for (var i = 0; i < resultCount; i++) {
            var item = data[i];
            this.lastAccessTime = item.LastAccessTime;

            this.showOneCustomAction(item);
        }

        setTimeout("myCustomActionManager.queryCustomAction()", this.interval * 1000);
    },



    // 显示一个客户操作.
    showOneCustomAction: function (data) {

        // 此方法将由客户端覆盖掉.
        console.log(data);

    }



}