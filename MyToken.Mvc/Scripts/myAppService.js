"use strict";

var myAppService = {

    // 是否显示运行日志.
    isShowRunningLog: true,


    // 模拟 App 客户端， 首次扫码.
    doScan: function (code, callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("doScan Start!");
        }
        var _this = this;
        $.ajax({
            url: "/Token/DoScan",
            data: {
                id : code
            },
            type: 'POST',
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("doScan Result:", data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    },




    // 模拟 App 客户端， 扫码之后， 确认登录.
    makesure: function (code, callbackFunc) {
        if (this.isShowRunningLog) {
            console.log("makesure Start!");
        }
        var _this = this;
        $.ajax({
            url: "/Token/Makesure",
            data: {
                id : code
            },
            type: 'POST',
            success: function (data) {
                if (_this.isShowRunningLog) {
                    console.log("makesure Result:", data);
                }
                callbackFunc(data);
            }
        }).fail(function (xhr, textStatus, err) {
            alert('Error: ' + err);
        });
    }


}